using System.Collections.Generic;
using System.Web.Http.Results;
using Moq;
using NUnit.Framework;
using RaceDay.Models.DTO;
using RaceDay.Models.Responses;
using RaceDay.Providers.Interfaces;
using RaceDay.WebAPI.Controllers;

namespace RaceDay.WebAPI.Tests.Controllers
{
    [TestFixture]
    public class CustomerControllerTests
    {
        private Mock<ICustomerProvider> _customerProvider;
        private CustomerController _sut;

        [SetUp]
        public void Init()
        {
            _customerProvider = new Mock<ICustomerProvider>();
            _sut = new CustomerController(_customerProvider.Object);
        }

        [Test]
        public void GetAllCustomers_returns_all_customers()
        {
            _customerProvider.Setup(x => x.GetAllCustomers()).Returns(new CustomerSearchResource());

            var response = _sut.GetAllCustomers();

            Assert.IsInstanceOf<OkNegotiatedContentResult<CustomerSearchResource>>(response);
        }

        [Test]
        public void GetCustomer_returns_NotFound_if_customer_not_found()
        {
            var response = _sut.GetCustomer("test");

            Assert.IsInstanceOf<NotFoundResult>(response);
        }

        [Test]
        public void GetCustomer_returns_customer_if_customer_found()
        {
            _customerProvider.Setup(x => x.GetCustomer(It.IsAny<string>())).Returns(new Customer());

            var response = _sut.GetCustomer("test");

            Assert.IsInstanceOf<OkNegotiatedContentResult<Customer>>(response);
        }

        [Test]
        public void GetCustomerBets_returns_Not_Found_If_no_bets_found()
        {
            var response = _sut.GetCustomerBets("test");

            Assert.IsInstanceOf<NotFoundResult>(response);
        }

        [Test]
        public void GetCustomerBets_returns_bets_If_bets_found()
        {
            _customerProvider.Setup(x => x.GetCustomerBets(It.IsAny<string>()))
                .Returns(new CustomerBetSearchResource());

            var response = _sut.GetCustomerBets("test");

            Assert.IsInstanceOf<OkNegotiatedContentResult<CustomerBetSearchResource>>(response);
        }

        [Test]
        public void GetAllCustomerBets_returns_all_bets()
        {
            _customerProvider.Setup(x => x.GetAllCustomers()).Returns(new CustomerSearchResource
            {
                Customers = new List<Customer>
                {
                    new Customer { CustomerId = 1, CustomerName = "Test 1" },
                    new Customer { CustomerId = 2, CustomerName = "Test 2" }
                }
            });

            _customerProvider.Setup(x => x.GetCustomerBets(It.IsAny<string>()))
                .Returns(new CustomerBetSearchResource
                {
                    Bets = new List<CustomerBet>
                    {
                        new CustomerBet { HorseId = 1, RaceId = 1, Stake = 100 }
                    }
                });

            var response = _sut.GetCustomerBets();

            Assert.IsInstanceOf<OkNegotiatedContentResult<List<CustomerBetSearchResource>>>(response);
        }

        [TestCase("amber")]
        [TestCase("orange")]
        [TestCase("blue")]
        public void GetCustomersByRisk_returns_Not_Found_if_invalid_risk_profile(string riskProfile)
        {
            var response = _sut.GetCustomersByRisk(riskProfile);
            Assert.IsInstanceOf<NotFoundResult>(response);
        }

        [TestCase("red")]
        [TestCase("yellow")]
        [TestCase("green")]
        public void GetCustomersByRisk_returns_OK_for_valid_risk_profile(string riskProfile)
        {
            _customerProvider.Setup(x => x.GetCustomersByRisk(It.IsAny<string>())).Returns(new CustomerRiskResource());

            var response = _sut.GetCustomersByRisk(riskProfile);
            Assert.IsInstanceOf<OkNegotiatedContentResult<CustomerRiskResource>>(response);
        }
    }
}
