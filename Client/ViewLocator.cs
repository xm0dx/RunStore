using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Client.ViewModels;

namespace Client;

// Hittar rätt View för en ViewModel genom namnet:
// Client.ViewModels.HomeViewModel -> Client.Views.HomeView
public class ViewLocator : IDataTemplate
{
    public Control? Build(object? data)
    {
        if (data is null) return null;

        // byt ut "ViewModel" mot "View" i namnet
        var viewName = data.GetType().FullName!
            .Replace("ViewModel", "View", StringComparison.InvariantCulture);

        var type = Type.GetType(viewName);
        if (type is null) return null;

        // skapa viewn och koppla den till sin ViewModel
        var control = (Control?)Activator.CreateInstance(type);
        control!.DataContext = data;

        return control;
    }

    // ViewLocator används bara för våra egna ViewModels
    public bool Match(object? data) => data is ViewModelBase;
}
