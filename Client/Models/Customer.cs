using System;

namespace Client.Models;

// en kund i butiken, ? betyder att fältet får vara tomt
public class Customer
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public string? Phone { get; set; }
    public string? AddressLine { get; set; }
    public string? PostalCode { get; set; }
    public string? City { get; set; }

    // knapparna på raden i CustomersView kör de här
    public void Edit()
    {
        Console.WriteLine($"Ändra kund {FirstName} {LastName}");
    }

    public void Delete()
    {
        Console.WriteLine($"Radera kund {FirstName} {LastName}");
    }
}
