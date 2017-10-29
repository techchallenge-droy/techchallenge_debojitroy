using RaceDay.Models.DTO;
using RaceDay.Models.Responses;

namespace RaceDay.Providers.Interfaces
{
    public interface ICustomerProvider
    {
        CustomerSearchResource GetAllCustomers();
        Customer GetCustomer(string customerName);
        CustomerBetSearchResource GetCustomerBets(string customerName);
        CustomerRiskResource GetCustomersByRisk(string riskProfile);
    }
}
