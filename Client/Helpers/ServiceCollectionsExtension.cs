using System;
using Client.Factory;
using Client.Interface;
using Client.Service;
using Client.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Client.Helpers;

public static class ServiceCollectionsExtension
{
    public static void AddServices(this IServiceCollection collection)
    {
        collection.AddSingleton<MainWindowViewModel>();
        collection.AddSingleton<PageViewFactory>();
        collection.AddTransient<HomeViewModel>();
        collection.AddTransient<CustomersViewModel>();
        collection.AddTransient<ProductViewModel>();
        collection.AddTransient<OrdersViewModel>();
        collection.AddTransient<IProductService, ProductService>();
        collection.AddTransient<ICustomerService, CustomerService>();

        // funktionen som fabriken använder: ett namn in, rätt sida ut
        collection.AddSingleton<Func<ApplicationNameEnum, PageViewModel>>(c => name => name switch
        {
            ApplicationNameEnum.Home => c.GetRequiredService<HomeViewModel>(),
            ApplicationNameEnum.Customers => c.GetRequiredService<CustomersViewModel>(),
            ApplicationNameEnum.Orders => c.GetRequiredService<OrdersViewModel>(),
            ApplicationNameEnum.Products => c.GetRequiredService<ProductViewModel>(),
            _ => throw new InvalidOperationException("Okänd sida")
        });
    }
}
