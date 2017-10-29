using System.Collections.Generic;
using System.Linq;
using RaceDay.DAO.Interfaces;
using RaceDay.DAO.Interfaces.Domain;

namespace RaceDay.DAO.Logic
{
    public class CustomerBetsDao : ICustomerBetsDao
    {
        private readonly List<CustomerBets> _store = new List<CustomerBets>();

        public CustomerBetsDao()
        {
            //Seed some data
            _store.Add(new CustomerBets { RaceId = 1, HorseId = 1, CustomerId = 1, BetAmount = 35 });
            _store.Add(new CustomerBets { RaceId = 1, HorseId = 2, CustomerId = 2, BetAmount = 50 });
            _store.Add(new CustomerBets { RaceId = 1, HorseId = 3, CustomerId = 3, BetAmount = 25 });
            _store.Add(new CustomerBets { RaceId = 1, HorseId = 4, CustomerId = 4, BetAmount = 30 });
            _store.Add(new CustomerBets { RaceId = 1, HorseId = 5, CustomerId = 5, BetAmount = 40 });

            _store.Add(new CustomerBets { RaceId = 2, HorseId = 6, CustomerId = 1, BetAmount = 100 });
            _store.Add(new CustomerBets { RaceId = 2, HorseId = 7, CustomerId = 2, BetAmount = 60 });
            _store.Add(new CustomerBets { RaceId = 2, HorseId = 8, CustomerId = 3, BetAmount = 70 });
            _store.Add(new CustomerBets { RaceId = 2, HorseId = 9, CustomerId = 4, BetAmount = 80 });
            _store.Add(new CustomerBets { RaceId = 2, HorseId = 10, CustomerId = 5, BetAmount = 90 });

            _store.Add(new CustomerBets { RaceId = 3, HorseId = 11, CustomerId = 1, BetAmount = 25 });
            _store.Add(new CustomerBets { RaceId = 3, HorseId = 12, CustomerId = 2, BetAmount = 30 });
            _store.Add(new CustomerBets { RaceId = 3, HorseId = 13, CustomerId = 3, BetAmount = 155 });
            _store.Add(new CustomerBets { RaceId = 3, HorseId = 14, CustomerId = 4, BetAmount = 40 });
            _store.Add(new CustomerBets { RaceId = 3, HorseId = 15, CustomerId = 5, BetAmount = 45 });

            _store.Add(new CustomerBets { RaceId = 4, HorseId = 16, CustomerId = 1, BetAmount = 60 });
            _store.Add(new CustomerBets { RaceId = 4, HorseId = 17, CustomerId = 2, BetAmount = 50 });
            _store.Add(new CustomerBets { RaceId = 4, HorseId = 18, CustomerId = 3, BetAmount = 40 });
            _store.Add(new CustomerBets { RaceId = 4, HorseId = 19, CustomerId = 4, BetAmount = 30 });
            _store.Add(new CustomerBets { RaceId = 4, HorseId = 20, CustomerId = 5, BetAmount = 20 });
        }

        public IList<CustomerBets> GetAllBets()
        {
            return _store;
        }

        public IList<CustomerBets> GetAllBetsForCustomer(int customerId)
        {
            return _store.Where(x => x.CustomerId == customerId).ToList();
        }

        public IList<CustomerBets> GetAllBetsForRace(int raceId)
        {
            return _store.Where(x => x.RaceId == raceId).ToList();
        }

        public IList<CustomerBets> GetAllBetsForHorse(int horseId)
        {
            return _store.Where(x => x.HorseId == horseId).ToList();
        }
    }
}
