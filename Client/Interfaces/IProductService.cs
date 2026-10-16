using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client.Models;

namespace Client.Interfaces
{
    public interface IProductService
    {
        // hämtar alla produkter från databasen
        List<Product> List(); // ändrat från ListAllProducts() till List()
    }
}
