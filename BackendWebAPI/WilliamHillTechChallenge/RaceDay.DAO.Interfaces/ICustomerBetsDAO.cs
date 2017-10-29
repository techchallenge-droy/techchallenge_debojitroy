using System.Collections.Generic;
using RaceDay.DAO.Interfaces.Domain;

namespace RaceDay.DAO.Interfaces
{
    public interface ICustomerBetsDao
    {
        IList<CustomerBets> GetAllBets();
        IList<CustomerBets> GetAllBetsForCustomer(int customerId);
        IList<CustomerBets> GetAllBetsForRace(int raceId);
        IList<CustomerBets> GetAllBetsForHorse(int horseId);
    }
}
