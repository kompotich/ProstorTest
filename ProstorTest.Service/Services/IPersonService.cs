using ProstorTest.Shared;

namespace ProstorTest.Core.Services;

public interface IPersonService
{
    Task<IEnumerable<Person>> GetAllAsync();

    Task<Person> GetByIdAsync(int personId);

    Task CreateAsync(Person person);

    Task UpdateAsync(Person person);

    Task DeleteAsync(int personId);
}
