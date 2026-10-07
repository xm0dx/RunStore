using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Client.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    // sidorna i appen, skapas en gång
    private readonly HomeViewModel _homeViewModel = new();
    private readonly ProductViewModel _productViewModel = new();

    // sidan som visas just nu, MainWindow binder till CurrentView
    [ObservableProperty]
    private ViewModelBase? _currentView;

    public MainWindowViewModel()
    {
        CurrentView = _homeViewModel;
    }

    // [RelayCommand] skapar GoToHomeCommand som knappen i XAML använder
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
}
