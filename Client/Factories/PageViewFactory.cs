using System;
using Client.Helpers;
using Client.Interfaces;
using Client.ViewModels;

namespace Client.Factories;

// fabriken får en funktion (Func) från ServiceCollection som vet hur varje sida skapas.
// MainWindowViewModel behöver då bara säga vilket namn den vill ha.
public class PageViewFactory(Func<ApplicationNameEnum, PageViewModel> pageFactory) : IPageViewFactory
{
    public PageViewModel LoadPageViewModel(ApplicationNameEnum pageName) => pageFactory.Invoke(pageName);
}
