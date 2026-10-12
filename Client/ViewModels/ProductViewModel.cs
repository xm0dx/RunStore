using System;
using System.Collections.ObjectModel;
using Client.Interface;
using Client.Models;
using Client.Service;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Client.ViewModels;

public partial class ProductViewModel : ViewModelBase
{
    private readonly IProductService _service;
    // listan som ProductView visar
    [ObservableProperty]
    private ObservableCollection<Product> _products = new();

    public ProductViewModel(IProductService service)
    {
        PageTitle = "Products in RunStore!";
        _service = service;
        LoadProducts();
    }

    private void LoadProducts()
    {
        try
        {
            // hämtar alla produkter från databasen
            Products = new ObservableCollection<Product>(_service.List()); // Fyller listan med produkter

        }
        catch (Exception ex)
        {
            // byts ut mot en riktig felruta senare
            Console.WriteLine(ex.Message);
        }
    }
}
