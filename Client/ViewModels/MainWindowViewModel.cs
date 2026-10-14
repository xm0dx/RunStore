using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Client.Service;
using Client.Views;

namespace Client.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    // sidorna i appen, skapas en gång
    private readonly HomeViewModel _homeViewModel;
    private readonly ProductViewModel _productViewModel;
    private readonly OrdersViewModel _ordersViewModel;
    private readonly CustomersViewModel _customersViewModel;

    // sidan som visas just nu
    [ObservableProperty]
    private ViewModelBase? _currentView;

    public MainWindowViewModel(ProductViewModel productViewModel, HomeViewModel homeViewModel, OrdersViewModel ordersViewModel, CustomersViewModel customersViewModel) // konstruktor som tar emot de olika sidorna som parametrar
    {
        _productViewModel = productViewModel;
        _homeViewModel = homeViewModel;
        _ordersViewModel = ordersViewModel;
        _customersViewModel = customersViewModel; // sidorna i appen, skapas en gång // Konstruktor injection används för att skicka in de olika sidorna som parametrar, så att de kan användas i MainWindowViewModel

        CurrentView = _homeViewModel;
    }

    // [RelayCommand] gör GoToHomeCommand osv. som knapparna i MainWindow använder
    [RelayCommand]
    private void GoToHome()
    {
        CurrentView = _homeViewModel;
    }

    [RelayCommand]
    private void GoToProducts()
    {
        CurrentView = _productViewModel;
    }

    [RelayCommand]
    private void GoToOrders()
    {
        CurrentView = _ordersViewModel;
    }

    [RelayCommand]
    private void GoToCustomers()
    {
        CurrentView = _customersViewModel;
    }

    // [RelayCommand] gör GoToHomeCommand osv. som knapparna i MainWindow använder
}
