using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Client.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    // sidorna i appen, skapas en gång
    private readonly HomeViewModel _homeViewModel = new();
    private readonly ProductViewModel _productViewModel = new();
    private readonly OrdersViewModel _ordersViewModel = new();
    private readonly CustomersViewModel _customersViewModel = new();

    // sidan som visas just nu
    [ObservableProperty]
    private ViewModelBase? _currentView;

    public MainWindowViewModel()
    {
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
}
