using System.Collections.ObjectModel;
using Client.Models;
using Client.Service;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Client.ViewModels;

public partial class ProductViewModel : ViewModelBase
{
    // listan som ProductView visar
    [ObservableProperty]
    private ObservableCollection<Product> _products;

    public ProductViewModel()
    {
        PageTitle = "Products in RunStore!";
        Products = new ObservableCollection<Product>(ProductService.ListAllProducts());
    }
}
