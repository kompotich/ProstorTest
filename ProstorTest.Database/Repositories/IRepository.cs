namespace ProstorTest.Database.Repositories;

public interface IRepository<T> : IDisposable
        where T : class
{
    Task<IEnumerable<T>> GetAllAsync();

    Task<T?> GetByIdAsync(int id);
    
    Task CreateAsync(T item);

    Task UpdateAsync(T item);

    Task DeleteAsync(int id);
}
