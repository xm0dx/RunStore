using System;
using System.Collections.ObjectModel;
using Client.Models;
using Client.Service;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Client.ViewModels;

public partial class ProductViewModel : ViewModelBase
{
    // listan som ProductView visar
    [ObservableProperty]
    private ObservableCollection<Product> _products = new();

    public ProductViewModel()
    {
        PageTitle = "Products in RunStore!";
        LoadProducts();
    }

    private void LoadProducts()
    {
        try
        {
            Products = new ObservableCollection<Product>(ProductService.ListAllProducts());
        }
        catch (Exception ex)
        {
            // byts ut mot en riktig felruta senare
            Console.WriteLine(ex.Message);
        }
    }
}
