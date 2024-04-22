using TodoApp.Api.Services.Interfaces;
namespace TodoApp.Api.Services.Configs;

public static class ServiceConfigs
{
    public static IServiceCollection AddServiceConfigs(this IServiceCollection services)
        => services
                .AddScoped<ITodoInterface, TodoService>();
        
    
}
