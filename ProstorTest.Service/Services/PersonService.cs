using AutoMapper;
using ProstorTest.Database.Entities;
using ProstorTest.Database.Repositories;
using ProstorTest.Shared;

namespace ProstorTest.Core.Services;

public class PersonService : IPersonService
{
    private readonly IPersonRepository _repository;
    private readonly IMapper _mapper;

    public PersonService(IPersonRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Person>> GetAllAsync() =>
        _mapper.Map<IEnumerable<Person>>(await _repository.GetAllAsync());

    public async Task<Person> GetByIdAsync(int personId) =>
        _mapper.Map<Person>(await _repository.GetByIdAsync(personId));

    public async Task CreateAsync(Person person) =>
        await _repository.CreateAsync(_mapper.Map<PersonDb>(person));

    public async Task UpdateAsync(Person person) =>
        await _repository.UpdateAsync(_mapper.Map<PersonDb>(person));

    public async Task DeleteAsync(int personId) =>
        await _repository.DeleteAsync(personId);
}