using Client.Helpers;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Client.ViewModels;

// basklass för alla sidor, varje sida vet sitt eget namn
public partial class PageViewModel : ViewModelBase
{
    [ObservableProperty]
    public partial ApplicationNameEnum PageName { get; set; }
}
