using System;
using System.Collections.Generic;
using System.IO;
using Client.Interfaces;
using Client.Models;
using Client.Repositories;

namespace Client.Services;

// hämtar och sparar produkterna i Data/products.json
public class ProductServices : IProductService
{
    private static readonly string ProductFilePath = Path.Combine(AppContext.BaseDirectory, "Data", "products.json");
    private static readonly Storage<Product> ProductStorage = new();

    public List<Product> List()
    {
        return ProductStorage.Read(ProductFilePath);
    }

    public static void SaveProducts(List<Product> products)
    {
        ProductStorage.Write(ProductFilePath, products);
    }
}
