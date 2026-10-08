namespace Client.ViewModels;

// Sidan för kunder. Tom just nu, listan med kunder kommer senare.
// Namnet måste sluta på ViewModel så att ViewLocator hittar CustomersView.
public partial class CustomersViewModel : ViewModelBase
{
    public CustomersViewModel()
    {
        PageTitle = "Kund Lista";
    }
}
