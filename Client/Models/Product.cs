namespace Client.Models;

// en produkt i butiken, samma fält som i Data/Product.json
public record Product
{
    public required string Id { get; set; }
    public required string ItemNumber { get; set; }
    public required string Name { get; set; }
    public required string SupplierName { get; set; }
    public int Price { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
}
