using Client.Interface;
using Client.Service;
using Client.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Client.Helpers
{
    public static class ServiceCollectionsExtension
    {
        public static void AddServices(this IServiceCollection collection)
        {
            // Registrerar ProductService som en singleton
            // Collection.AddSingleton<MainViewModel>();
            // Collections.addSingleton<IProductService.ProductService>();
            collection.AddSingleton<ProductViewModel>();
            collection.AddSingleton<IProductService, ProductService>();
        }
    }
}
