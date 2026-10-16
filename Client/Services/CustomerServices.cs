using System;
using System.Collections.Generic;
using System.IO;
using Client.Interfaces;
using Client.Models;
using Client.Repositories;

namespace Client.Services;

// hämtar och sparar kunderna i Data/customers.json
public class CustomerServices : ICustomerService
{
    private static readonly string CustomerFilePath = Path.Combine(AppContext.BaseDirectory, "Data", "customers.json");
    private static readonly Storage<Customer> CustomerStorage = new();

    public List<Customer> List()
    {
        return CustomerStorage.Read(CustomerFilePath);
    }

    public static void SaveCustomers(List<Customer> customers)
    {
        CustomerStorage.Write(CustomerFilePath, customers);
    }
}
