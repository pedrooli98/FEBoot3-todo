namespace TodoApp.Api.Services.Interfaces;

public interface IBaseInterface<T> where T : class
{
    Task<T?> Get(Guid id);
    Task<T> Create(T t);
    Task<T> Update(Guid id, T t);
    Task<bool> Delete(Guid id);
}
