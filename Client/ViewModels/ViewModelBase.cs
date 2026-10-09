using CommunityToolkit.Mvvm.ComponentModel;

namespace Client.ViewModels;

public partial class ViewModelBase : ObservableObject
{
    // rubriken som varje sida visar
    [ObservableProperty]
    private string _pageTitle = "";
}
