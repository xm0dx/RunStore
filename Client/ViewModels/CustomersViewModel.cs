using System;
using System.Collections.ObjectModel;
using Client.Helpers;
using Client.Interfaces;
using Client.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Client.ViewModels;

public partial class CustomersViewModel : PageViewModel
{
    private readonly ICustomerService _customerService;

    // listan som CustomersView visar
    [ObservableProperty]
    private ObservableCollection<Customer> _customers = new();

    public CustomersViewModel(ICustomerService customerService)
    {
        _customerService = customerService;
        PageName = ApplicationNameEnum.Customers;
        PageTitle = "Kund Lista";
        LoadCustomers();
    }

    private void LoadCustomers()
    {
        try
        {
            Customers = new ObservableCollection<Customer>(_customerService.List());
        }
        catch (Exception ex)
        {
            // byts ut mot en riktig felruta senare
            Console.WriteLine(ex.Message);
        }
    }
}
