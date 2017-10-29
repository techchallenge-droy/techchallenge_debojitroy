using System;
using System.Collections.Generic;
using System.Linq;
using RaceDay.DAO.Interfaces;
using RaceDay.DAO.Interfaces.Domain;

namespace RaceDay.DAO.Logic
{
    public class CustomerDao : ICustomerDao
    {
        // Creating a internal store for values
        // Actual scenario the details will be coming from a persistent store
        private readonly Dictionary<int, Customer> _store = new Dictionary<int, Customer>();

        public CustomerDao()
        {
            //Seed value
            _store.Add(1, new Customer { CustomerId = 1, CustomerName = "Debojit"});
            _store.Add(2, new Customer { CustomerId = 2, CustomerName = "Stark" });
            _store.Add(3, new Customer { CustomerId = 3, CustomerName = "Lannisters" });
            _store.Add(4, new Customer { CustomerId = 4, CustomerName = "Targaryen" });
            _store.Add(5, new Customer { CustomerId = 5, CustomerName = "Baratheon" });
        }

        public IList<Customer> GetAllCustomers()
        {
            return _store.Values.ToList();
        }

        public Customer GetCustomer(int customerId)
        {
            return _store.ContainsKey(customerId) ? _store[customerId] : null;
        }

        public Customer GetCustomer(string customerName)
        {
            return _store.Values
                .FirstOrDefault(x => x.CustomerName.Equals(customerName, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
