namespace Client.Models;

// En produkt i butiken. required = måste få ett värde när objektet skapas.
public class Product
{
    public int Id { get; set; }
    public required string ItemNumber { get; set; }
    public required string Name { get; set; }
    public required string SupplierName { get; set; }
    public int Price { get; set; }
    public string? Description { get; set; }
    public string? Image { get; set; }
}
