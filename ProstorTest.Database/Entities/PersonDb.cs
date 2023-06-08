namespace ProstorTest.Database.Entities;

public class PersonDb
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public bool IsDeleted { get; set; }
}