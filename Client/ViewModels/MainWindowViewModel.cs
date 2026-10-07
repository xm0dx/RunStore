using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Client.ViewModels;

// Styr navigeringen: varje knapp i menyn kör en Command här,
// den byter CurrentView och ViewLocator visar rätt sida.
public partial class MainWindowViewModel : ViewModelBase
{
    // sidorna i appen, skapas en gång och återanvänds
    private readonly HomeViewModel _homeViewModel = new();
    private readonly ProductViewModel _productViewModel = new();
    private readonly OrdersViewModel _ordersViewModel = new();
    private readonly CustomersViewModel _customersViewModel = new();

    // sidan som visas just nu. [ObservableProperty] skapar egenskapen CurrentView
    // och säger till MainWindow varje gång den ändras.
    [ObservableProperty]
    private ViewModelBase? _currentView;

    public MainWindowViewModel()
    {
        // startsidan
        CurrentView = _homeViewModel;
    }

    // [RelayCommand] skapar GoToHomeCommand osv. som knapparna i XAML binder till
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
