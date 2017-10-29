using System.Collections.Generic;
using System.Linq;
using RaceDay.DAO.Interfaces;
using RaceDay.Models.DTO;
using RaceDay.Models.Responses;
using RaceDay.Providers.Interfaces;

namespace RaceDay.Providers
{
    public class CustomerProvider : ICustomerProvider
    {
        private readonly IRaceDao _raceDao;
        private readonly IHorseDao _horseDao;
        private readonly ICustomerDao _customerDao;
        private readonly ICustomerBetsDao _customerBetsDao;

        public CustomerProvider(IRaceDao raceDao, IHorseDao horseDao, ICustomerDao customerDao, ICustomerBetsDao customerBetsDao)
        {
            _raceDao = raceDao;
            _horseDao = horseDao;
            _customerDao = customerDao;
            _customerBetsDao = customerBetsDao;
        }

        public CustomerSearchResource GetAllCustomers()
        {
            var customerSearchResource = new CustomerSearchResource();
            var customers = _customerDao.GetAllCustomers();

            if (customers == null || !customers.Any())
                return customerSearchResource;

            customerSearchResource.Customers = new List<Customer>();

            foreach (var customer in customers)
            {
                customerSearchResource.Customers.Add(new Customer { CustomerId = customer.CustomerId, CustomerName = customer.CustomerName });
            }

            return customerSearchResource;
        }

        public Customer GetCustomer(string customerName)
        {
            if (string.IsNullOrWhiteSpace(customerName))
                return null;

            var customer = _customerDao.GetCustomer(customerName);

            return customer == null ? null : new Customer { CustomerId = customer.CustomerId, CustomerName = customer.CustomerName };
        }

        public CustomerBetSearchResource GetCustomerBets(string customerName)
        {
            var customer = GetCustomer(customerName);

            if (customer == null)
                return null;

            var customerBetSearchResource = new CustomerBetSearchResource { CustomerDetails = customer, Bets = new List<CustomerBet>() };

            var bets = _customerBetsDao.GetAllBetsForCustomer(customer.CustomerId);

            if (bets == null || !bets.Any())
                return customerBetSearchResource;

            foreach (var bet in bets)
            {
                var race = _raceDao.GetRace(bet.RaceId);
                var horse = _horseDao.GetHorse(bet.HorseId);

                customerBetSearchResource.Bets.Add(new CustomerBet
                {
                    RaceId = race?.RaceId ?? 0,
                    RaceName = race?.RaceName,
                    HorseId = horse?.HorseId ?? 0,
                    HorseName = horse?.HorseName,
                    Stake = bet.BetAmount
                });

                customerBetSearchResource.TotalStake += bet.BetAmount;
            }

            return customerBetSearchResource;
        }

        public CustomerRiskResource GetCustomersByRisk(string riskProfile)
        {
            var customerRiskResource = new CustomerRiskResource { CustomerRiskProfiles = new List<CustomerRisk>() };

            var raceBets = _customerBetsDao.GetAllBets();

            // Create a temp map for aggregation
            var customerStakes = new Dictionary<int, double>();

            foreach (var bet in raceBets)
            {
                if (customerStakes.ContainsKey(bet.CustomerId))
                {
                    customerStakes[bet.CustomerId] = customerStakes[bet.CustomerId] + bet.BetAmount;
                }
                else
                {
                    customerStakes[bet.CustomerId] = bet.BetAmount;
                }
            }

            IEnumerable<KeyValuePair<int,double>> filteredCustomerIds;

            switch (riskProfile.ToLowerInvariant())
            {
                case "red":
                    filteredCustomerIds = customerStakes.Where(x => x.Value >= 200.0);
                    break;
                case "yellow":
                    filteredCustomerIds = customerStakes.Where(x => x.Value <= 200.0 && x.Value >= 100.0);
                    break;
                default:
                    filteredCustomerIds = customerStakes.Where(x => x.Value < 100.0);
                    break;
            }

            foreach (var filteredCustomer in filteredCustomerIds)
            {
                var customer = _customerDao.GetCustomer(filteredCustomer.Key);

                customerRiskResource.CustomerRiskProfiles.Add(new CustomerRisk
                {
                    CustomerDetails = new Customer
                    {
                        CustomerId = customer?.CustomerId ?? filteredCustomer.Key,
                        CustomerName = customer?.CustomerName
                    },
                    TotalStake = filteredCustomer.Value
                });
            }

            return customerRiskResource;
        }
    }
}
