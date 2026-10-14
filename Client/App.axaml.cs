using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using Client.Helpers;
using Client.Views;
using Client.ViewModels;


namespace Client;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        // Instansierar MainWindow och sätter datacontext till MainWindowViewModel
        // MainWindowViewModel är en ViewModel som hanterar logiken för MainWindow

        var collection = new ServiceCollection();
        collection.AddServices();

        var serviceProvider = collection.BuildServiceProvider();
        var vm = serviceProvider.GetRequiredService<MainWindowViewModel>();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                // sätter datacontext till MainWindowViewModel
                DataContext = vm
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}


