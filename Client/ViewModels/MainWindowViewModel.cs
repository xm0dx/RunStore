using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Client.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private readonly HomeViewModel _homeViewModel = new();
    private readonly ProductViewModel _productViewModel = new();

    [ObservableProperty]
    private ViewModelBase? _currentView;

    public MainWindowViewModel()
    {
        CurrentView = _homeViewModel;
    }

    [RelayCommand]
    private void GotoHome()
    {
        CurrentView = _homeViewModel;
    }

    [RelayCommand]
    private void GotoProducts()
    {
        CurrentView = _productViewModel;
    }
}
