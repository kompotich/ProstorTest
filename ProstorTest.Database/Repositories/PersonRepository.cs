using Microsoft.EntityFrameworkCore;
using ProstorTest.Database.Entities;

namespace ProstorTest.Database.Repositories;

public class PersonRepository : IPersonRepository
{
    private bool _disposed;

    private readonly ProstorTestContext _context;

    public PersonRepository()
    {
        _context = new ProstorTestContext();
    }

    public async Task<IEnumerable<PersonDb>> GetAllAsync() =>
        await _context.Persons.Where(x => !x.IsDeleted).ToListAsync();

    public async Task<PersonDb?> GetByIdAsync(int personId) =>
        await _context.Persons.SingleOrDefaultAsync(x => x.Id == personId && !x.IsDeleted);

    public async Task CreateAsync(PersonDb person)
    {
        await _context.Persons.AddAsync(person);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(PersonDb person)
    {
        _context.Entry(person).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int personId)
    {
        var person = await GetByIdAsync(personId);

        if (person != null)
        {
            person.IsDeleted = true;
            await _context.SaveChangesAsync();
        }
    }

    public virtual void Dispose(bool disposing)
    {
        if (_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }

        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
