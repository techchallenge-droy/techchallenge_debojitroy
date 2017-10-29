using System;
using System.Linq;
using System.Web.Http;
using RaceDay.Providers.Interfaces;

namespace RaceDay.WebAPI.Controllers
{
    [RoutePrefix("v1/customer")]
    public class CustomerController : ApiController
    {
        private readonly ICustomerProvider _customerProvider;

        public CustomerController(ICustomerProvider customerProvider)
        {
            _customerProvider = customerProvider;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetCustomer(string customerName)
        {
            var customerDetails = _customerProvider.GetCustomer(customerName);

            if(customerDetails != null)
                return Ok(customerDetails);

            return NotFound();
        }

        [HttpGet]
        [Route("all")]
        public IHttpActionResult GetAllCustomers()
        {
            return Ok(_customerProvider.GetAllCustomers());
        }

        [HttpGet]
        [Route("bets")]
        public IHttpActionResult GetCustomerBets(string customerName)
        {
            var customerBets = _customerProvider.GetCustomerBets(customerName);

            if (customerBets != null)
                return Ok(customerBets);

            return NotFound();
        }

        [HttpGet]
        [Route("bets/all")]
        public IHttpActionResult GetCustomerBets()
        {
            var customers = _customerProvider.GetAllCustomers().Customers;

            var allCustomerBets = customers.Select(customer => _customerProvider.GetCustomerBets(customer.CustomerName))
                .Where(bet => bet != null).ToList();

            return Ok(allCustomerBets);
        }

        [HttpGet]
        [Route("risk")]
        public IHttpActionResult GetCustomersByRisk(string risk)
        {
            if (!string.Equals(risk, "red", StringComparison.InvariantCultureIgnoreCase)
                && !string.Equals(risk, "yellow", StringComparison.InvariantCultureIgnoreCase)
                && !string.Equals(risk, "green", StringComparison.InvariantCultureIgnoreCase))
                return NotFound();

            return Ok(_customerProvider.GetCustomersByRisk(risk));
        }
    }
}
