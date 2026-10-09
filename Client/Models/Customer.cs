namespace Client.Models;

// En kund i butiken. required = måste få ett värde när objektet skapas,
// ? = får vara tomt (null).
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
}
