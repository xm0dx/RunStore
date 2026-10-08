using System.Collections.ObjectModel;
using Client.Models;
using Client.Service;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Client.ViewModels;

public partial class ProductViewModel : ViewModelBase
{
    // listan som ProductView visar. ObservableCollection säger till sidan
    // när något läggs till eller tas bort.
    [ObservableProperty]
    public partial ObservableCollection<Product> Products { get; set; }

    public ProductViewModel()
    {
        PageTitle = "Products in RunStore!";
        Products = new ObservableCollection<Product>(ProductService.ListAllProducts());
    }
}
