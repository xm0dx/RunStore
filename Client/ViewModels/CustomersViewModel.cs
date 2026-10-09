using System;
using System.Collections.ObjectModel;
using Client.Models;
using Client.Service;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Client.ViewModels;

public partial class CustomersViewModel : ViewModelBase
{
    // listan som CustomersView visar
    [ObservableProperty]
    private ObservableCollection<Customer> _customers = new();

    public CustomersViewModel()
    {
        PageTitle = "Kund Lista";
        LoadCustomers();
    }

    private void LoadCustomers()
    {
        try
        {
            Customers = new ObservableCollection<Customer>(CustomerService.ListAllCustomers());
        }
        catch (Exception ex)
        {
            // byts ut mot en riktig felruta senare
            Console.WriteLine(ex.Message);
        }
    }
}
