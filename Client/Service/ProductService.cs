using System.Collections.Generic;
using Client.Models;

namespace Client.Service;

// Ger oss produkterna. Just nu en fast lista, senare kommer de från en fil eller databas.
public class ProductService
{
    public static List<Product> ListAllProducts()
    {
        return new List<Product>
        {
            new Product { Id = 1, ItemNumber = "1001", Name = "Gel 27", SupplierName = "Asics", Price = 2295 },
            new Product { Id = 2, ItemNumber = "1002", Name = "SuperBlast 3", SupplierName = "Asics", Price = 1890 },
            new Product { Id = 3, ItemNumber = "1003", Name = "SuperBlast 4", SupplierName = "Asics", Price = 2295 },
        };
    }
}
