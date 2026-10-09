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

    // raden som är markerad i listan, null om ingen är markerad
    [ObservableProperty]
    private Product? _selectedProduct;

    public ProductViewModel()
    {
        PageTitle = "Products in RunStore!";
        Products = new ObservableCollection<Product>(ProductService.ListAllProducts());
    }

    [RelayCommand]
    private void Edit()
    {
        if (SelectedProduct is null) return;

        Console.WriteLine($"Ändra produkt {SelectedProduct.Name}");
    }

    [RelayCommand]
    private void Delete()
    {
        if (SelectedProduct is null) return;

        Console.WriteLine($"Radera produkt {SelectedProduct.Name}");
    }
}
