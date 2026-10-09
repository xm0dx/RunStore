using System;
using System.Collections.Generic;
using System.IO;
using Client.Models;
using Client.Repositories;

namespace Client.Service;

// hämtar och sparar produkterna i Data/Product.json
public class ProductService
{
    private static readonly string ProductFilePath = Path.Combine(AppContext.BaseDirectory, "Data", "Product.json");
    private static readonly Storage<Product> ProductStorage = new();

    public static List<Product> ListAllProducts()
    {
        return ProductStorage.Read(ProductFilePath);
    }

    public static void SaveProducts(List<Product> products)
    {
        ProductStorage.Write(ProductFilePath, products);
    }
}
