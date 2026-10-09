using System;
using System.Collections.ObjectModel;
using Client.Models;
using Client.Service;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

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

    // knapparna på raden skickar med sin produkt
    [RelayCommand]
    private void Edit(Product product)
    {
        Console.WriteLine($"Ändra produkt {product.Name}");
    }

    [RelayCommand]
    private void Delete(Product product)
    {
        Console.WriteLine($"Radera produkt {product.Name}");
    }
}
