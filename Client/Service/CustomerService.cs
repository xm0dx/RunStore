using System;
using System.Collections.Generic;
using System.IO;
using Client.Interface;
using Client.Models;
using Client.Repositories;

namespace Client.Service;

// hämtar och sparar kunderna i Data/Customer.json
public class CustomerService : ICustomerService
{
    private static readonly string CustomerFilePath = Path.Combine(AppContext.BaseDirectory, "Data", "Customer.json");
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
