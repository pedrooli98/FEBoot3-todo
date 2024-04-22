using Microsoft.EntityFrameworkCore;
using TodoApp.Api.Db;
using TodoApp.Api.Services;
using TodoApp.Api.Services.Interfaces;
using TodoApp.Api.Services.Configs;
using Swashbuckle.AspNetCore;
using System.Dynamic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddServiceConfigs();
builder.Services.AddSwaggerGen(c => 
    {
        c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
        {
            Title = "TodoApp API",
            Version = "v1"
        });    
    });
builder.Services.AddDbContext<TodoContext>(options => options.UseInMemoryDatabase("TodoApp"));

builder.Services.AddScoped<ITodoInterface, TodoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
