using Client.Factories;
using Client.Helpers;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Client.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    // fabriken skapar sidorna, MainWindowViewModel behöver inte känna till dem själv
    private readonly PageViewFactory _factory;

    // sidan som visas just nu
    [ObservableProperty]
    private ViewModelBase? _currentView;

    public MainWindowViewModel(PageViewFactory factory)
    {
        _factory = factory;
        GoToHome();
    }

    // [RelayCommand] gör GoToHomeCommand osv. som knapparna i MainWindow använder
    [RelayCommand]
    private void GoToHome()
    {
        CurrentView = _factory.LoadPageViewModel(ApplicationNameEnum.Home);
    }

    [RelayCommand]
    private void GoToProducts()
    {
        CurrentView = _factory.LoadPageViewModel(ApplicationNameEnum.Products);
    }

    [RelayCommand]
    private void GoToOrders()
    {
        CurrentView = _factory.LoadPageViewModel(ApplicationNameEnum.Orders);
    }

    [RelayCommand]
    private void GoToCustomers()
    {
        CurrentView = _factory.LoadPageViewModel(ApplicationNameEnum.Customers);
    }
}
