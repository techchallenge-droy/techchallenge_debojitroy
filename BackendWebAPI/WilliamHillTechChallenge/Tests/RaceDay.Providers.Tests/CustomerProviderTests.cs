using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using RaceDay.DAO.Interfaces;
using RaceDay.DAO.Interfaces.Domain;

namespace RaceDay.Providers.Tests
{
    [TestFixture]
    public class CustomerProviderTests
    {
        private Mock<IRaceDao> _raceDao;
        private Mock<IHorseDao> _horseDao;
        private Mock<ICustomerDao> _customerDao;
        private Mock<ICustomerBetsDao> _customerBetsDao;
        private CustomerProvider _sut;

        [SetUp]
        public void Init()
        {
            _raceDao = new Mock<IRaceDao>();
            _horseDao = new Mock<IHorseDao>();
            _customerDao = new Mock<ICustomerDao>();
            _customerBetsDao = new Mock<ICustomerBetsDao>();

            _sut = new CustomerProvider(_raceDao.Object,
                _horseDao.Object,
                _customerDao.Object,
                _customerBetsDao.Object);
        }

        [Test]
        public void GetAllCustomers_returns_all_customers()
        {
            _customerDao.Setup(x => x.GetAllCustomers()).Returns(new List<Customer> {new Customer { CustomerId = 1, CustomerName = "test customer"}});

            var allCustomers = _sut.GetAllCustomers();

            Assert.IsNotNull(allCustomers);
            Assert.IsNotNull(allCustomers.Customers);
            Assert.IsTrue(allCustomers.Customers.Count > 0);
        }

        [Test]
        public void GetCustomer_returns_null_if_no_customer_found()
        {
            var customer = _sut.GetCustomer("test");

            Assert.IsNull(customer);
        }

        [Test]
        public void GetCustomer_returns_customer_if_customer_found()
        {
            _customerDao.Setup(x => x.GetCustomer(It.IsAny<string>())).Returns(new Customer { CustomerId = 1, CustomerName = "test"});

            var customer = _sut.GetCustomer("test");

            Assert.IsNotNull(customer);
        }
        
        [Test]
        public void GetCustomerBets_returns_all_bets_for_customer()
        {
            _customerDao.Setup(x => x.GetCustomer(It.IsAny<string>())).Returns(new Customer { CustomerId = 1, CustomerName = "test" });
            _customerBetsDao.Setup(x => x.GetAllBetsForCustomer(It.IsAny<int>())).Returns(new List<CustomerBets> { new CustomerBets { RaceId = 1, HorseId = 1, BetAmount = 100, CustomerId = 1 }});
            _raceDao.Setup(x => x.GetRace(It.IsAny<int>())).Returns(new Race { RaceId = 1, RaceName = "test", RaceStatus = "Completed" });
            _horseDao.Setup(x => x.GetHorse(It.IsAny<int>())).Returns(new Horse { HorseId = 1, HorseName = "Test Horse" });

            var customerBets = _sut.GetCustomerBets("test");

            Assert.IsNotNull(customerBets);
            Assert.IsNotNull(customerBets.Bets);
            Assert.IsNotNull(customerBets.CustomerDetails);
            Assert.IsTrue(customerBets.TotalStake > 0);
            Assert.IsTrue(customerBets.Bets.Count > 0);
        }
        
        [TestCase("red",200, 100000)]
        [TestCase("yellow", 100, 200)]
        [TestCase("green", 0, 100)]
        public void GetCustomersByRisk_returns_in_range(string riskProfile, int lowerLimit, int upperLimit)
        {
            _customerBetsDao.Setup(x => x.GetAllBets()).Returns(new List<CustomerBets> { new CustomerBets {BetAmount = 1000, CustomerId = 1, HorseId = 1, RaceId = 1}, new CustomerBets { BetAmount = 150, CustomerId = 2, RaceId = 2, HorseId = 2}, new CustomerBets { BetAmount = 50, CustomerId = 3, RaceId = 3, HorseId = 3}});
            _customerDao.Setup(x => x.GetCustomer(It.IsAny<int>())).Returns(new Customer { CustomerId = 1, CustomerName = "test" });

            var customerRiskProfiles = _sut.GetCustomersByRisk(riskProfile);

            Assert.IsNotNull(customerRiskProfiles);
            Assert.IsNotNull(customerRiskProfiles.CustomerRiskProfiles);
            Assert.IsTrue(customerRiskProfiles.CustomerRiskProfiles.Count > 0);

            customerRiskProfiles.CustomerRiskProfiles.ForEach(x => Assert.IsTrue(x.TotalStake >= lowerLimit && x.TotalStake <= upperLimit));
        }
    }
}
