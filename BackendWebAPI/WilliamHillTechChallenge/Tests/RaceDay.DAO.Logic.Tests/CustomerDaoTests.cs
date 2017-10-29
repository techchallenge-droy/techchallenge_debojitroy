using NUnit.Framework;

namespace RaceDay.DAO.Logic.Tests
{
    [TestFixture]
    public class CustomerDaoTests
    {
        private CustomerDao _sut;

        [SetUp]
        public void Init()
        {
            _sut = new CustomerDao();
        }

        [Test]
        public void GetAllCustomers_returns_all_customers()
        {
            var customers = _sut.GetAllCustomers();

            Assert.IsNotNull(customers);
            Assert.IsTrue(customers.Count > 0);
        }

        [TestCase(1)]
        [TestCase(2)]
        public void GetCustomer_returns_customer(int customerId)
        {
            var customer = _sut.GetCustomer(customerId);

            Assert.IsNotNull(customer);
        }

        [TestCase(100)]
        [TestCase(101)]
        public void GetCustomer_doesnot_returns_customer(int customerId)
        {
            var customer = _sut.GetCustomer(customerId);

            Assert.IsNull(customer);
        }
    }
}
