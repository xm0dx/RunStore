using Client.Helpers;
using Client.ViewModels;

namespace Client.Interface;

public interface IPageViewFactory
{
    PageViewModel LoadPageViewModel(ApplicationNameEnum pageName);
}
