using Client.Helpers;

namespace Client.ViewModels;

// tom än så länge, beställningarna kommer senare
public class OrdersViewModel : PageViewModel
{
    public OrdersViewModel()
    {
        PageName = ApplicationNameEnum.Orders;
    }
}
