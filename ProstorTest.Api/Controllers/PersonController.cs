using Microsoft.AspNetCore.Mvc;
using ProstorTest.Core.Services;
using ProstorTest.Shared;

namespace ProstorTest.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    private readonly IPersonService _service;
    private readonly ILogger<PersonController> _logger;

    public PersonController(IPersonService service, ILogger<PersonController> logger)
    {
        _service = service;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IEnumerable<Person>> GetAllAsync() => await _service.GetAllAsync();


    [HttpGet("{personId:int}")]
    public async Task<Person> GetAsync([FromRoute] int personId) => await _service.GetByIdAsync(personId);

    [HttpPost]
    public async Task CreateAsync([FromBody] Person person) => await _service.CreateAsync(person);

    [HttpPut]
    public async Task UpdateAsync([FromBody] Person person) => await _service.UpdateAsync(person);

    [HttpDelete]
    public async Task DeleteAsync(int personId) => await _service.DeleteAsync(personId);
}