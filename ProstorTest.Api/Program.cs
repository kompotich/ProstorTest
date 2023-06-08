using ProstorTest.Database;
using ProstorTest.Database.Repositories;
using ProstorTest.Service.MappingProfiles;
using ProstorTest.Service.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProstorTestContext>();

builder.Services.AddScoped<IPersonRepository, PersonRepository>();

builder.Services.AddScoped<IPersonService, PersonService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(PersonProfile));

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
