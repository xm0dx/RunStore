using System;
using System.Collections.ObjectModel;
using Client.Helpers;
using Client.Interfaces;
using Client.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Client.ViewModels;

public partial class ProductsViewModel : PageViewModel
{
    private readonly IProductService _service;

    // listan som ProductsView visar
    [ObservableProperty]
    private ObservableCollection<Product> _products = new();

    public ProductsViewModel(IProductService service)
    {
        _service = service;
        PageName = ApplicationNameEnum.Products;
        PageTitle = "Products in RunStore!";
        LoadProducts();
    }

    // knapparna på raderna skickar med produktens artikelnummer
    [RelayCommand]
    private void Edit(string id)
    {
        Console.WriteLine("Ändra produkt " + id);
    }

    [RelayCommand]
    private void Delete(string id)
    {
        Console.WriteLine("Ta bort produkt " + id);
    }

    private void LoadProducts()
    {
        try
        {
            Products = new ObservableCollection<Product>(_service.List());
        }
        catch (Exception ex)
        {
            // byts ut mot en riktig felruta senare
            Console.WriteLine(ex.Message);
        }
    }
}
