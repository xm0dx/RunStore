using System.Collections.ObjectModel;
using Client.Models;
using Client.Service;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Client.ViewModels;

public partial class CustomersViewModel : ViewModelBase
{
    // listan som CustomersView visar. ObservableCollection säger till sidan
    // när något läggs till eller tas bort.
    [ObservableProperty]
    public partial ObservableCollection<Customer> Customers { get; set; }

    public CustomersViewModel()
    {
        PageTitle = "Kund Lista";
        Customers = new ObservableCollection<Customer>(CustomerService.ListAllCustomers());
    }
}
