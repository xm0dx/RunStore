using System;
using System.Collections.Generic;
using System.IO;
using Client.Models;
using Client.Repositories;

namespace Client.Service;

// hämtar och sparar kunderna i Data/Customer.json
public class CustomerService
{
    private static readonly string CustomerFilePath = Path.Combine(AppContext.BaseDirectory, "Data", "Customer.json");
    private static readonly Storage<Customer> CustomerStorage = new();

    public static List<Customer> ListAllCustomers()
    {
        return CustomerStorage.Read(CustomerFilePath);
    }

    public static void SaveCustomers(List<Customer> customers)
    {
        CustomerStorage.Write(CustomerFilePath, customers);
    }
}
