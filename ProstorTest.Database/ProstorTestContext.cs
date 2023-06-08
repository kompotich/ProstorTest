using Microsoft.EntityFrameworkCore;
using ProstorTest.Database.Entities;

namespace ProstorTest.Database;

public class ProstorTestContext : DbContext
{
    public DbSet<PersonDb> Persons { get; set; }

    public ProstorTestContext()
    {
        //Database.EnsureDeleted();
        //Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=ProstorTest;Username=postgres;Password=postgres");
    }
}
