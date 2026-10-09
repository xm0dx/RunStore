using System.Text.Json.Serialization;

namespace Client.Models;

// En produkt i butiken. required = måste få ett värde när objektet skapas.
public class Product
{
    public required string Id { get; set; }
    public required string ItemNumber { get; set; }
    public required string Name { get; set; }
    public required string SupplierName { get; set; }
    public int Price { get; set; }
    public string? Description { get; set; }

    [JsonPropertyName("imageUrl")]
    public string? Image { get; set; }
}
