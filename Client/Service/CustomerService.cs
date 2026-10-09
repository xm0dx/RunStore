using System.Collections.Generic;
using Client.Models;

namespace Client.Service;

// Ger oss kunderna. Just nu två påhittade, senare kommer de från en fil eller databas.
public class CustomerService
{
    public static List<Customer> ListAllCustomers()
    {
        return new List<Customer>
        {
            new Customer { Id = 1, FirstName = "Anna", LastName = "Berg", Email = "anna.berg@mail.com", City = "Göteborg" },
            new Customer { Id = 2, FirstName = "Johan", LastName = "Lind", Email = "johan.lind@mail.com", City = "Borås" },
        };
    }
}
