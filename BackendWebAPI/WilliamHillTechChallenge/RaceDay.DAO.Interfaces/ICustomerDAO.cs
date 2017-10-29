using System.Collections.Generic;
using RaceDay.DAO.Interfaces.Domain;

namespace RaceDay.DAO.Interfaces
{
    public interface ICustomerDao
    {
        IList<Customer> GetAllCustomers();
        Customer GetCustomer(int customerId);
        Customer GetCustomer(string customerName);
    }
}
