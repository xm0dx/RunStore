using System.Collections.Generic;
using Client.Models;

namespace Client.Interface;

public interface ICustomerService
{
    List<Customer> List();
}
