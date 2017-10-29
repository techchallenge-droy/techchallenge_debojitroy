using System.Collections.Generic;
using System.Linq;
using RaceDay.DAO.Interfaces;
using RaceDay.Models.DTO;
using RaceDay.Models.Responses;
using RaceDay.Providers.Interfaces;

namespace RaceDay.Providers
{
    public class RaceProvider : IRaceProvider
    {
        private readonly IRaceDao _raceDao;
        private readonly IHorseDao _horseDao;
        private readonly IRaceHorsesDao _raceHorsesDao;
        private readonly ICustomerDao _customerDao;
        private readonly ICustomerBetsDao _customerBetsDao;

        public RaceProvider(IRaceDao raceDao, IHorseDao horseDao, IRaceHorsesDao raceHorsesDao, ICustomerDao customerDao, ICustomerBetsDao customerBetsDao)
        {
            _raceDao = raceDao;
            _horseDao = horseDao;
            _raceHorsesDao = raceHorsesDao;
            _customerDao = customerDao;
            _customerBetsDao = customerBetsDao;
        }

        public RaceDetailsResource GetAllRaces()
        {
            var races = _raceDao.GetAllRaces();

            if (races == null
                || !races.Any())
                return null;

            var raceDetailsResource = new RaceDetailsResource { RaceDetails = new List<RaceDetails>() };

            foreach (var race in races)
            {                    
                var raceDetails = new RaceDetails
                {   RaceId = race.RaceId,
                    RaceName = race.RaceName,
                    RaceStatus = race.RaceStatus,
                    HorseDetails = new List<RaceHorseDetails>()
                };

                var horses = _raceHorsesDao.GetAllRaceHorses(race.RaceId);
                var bets = _customerBetsDao.GetAllBetsForRace(race.RaceId);

                raceDetails.TotalBets = bets.Sum(x => x.BetAmount);

                raceDetailsResource.RaceDetails.Add(raceDetails);

                if (horses == null
                    || !horses.Any())
                    continue;

                foreach (var horse in horses)
                {
                    var horseDetails = _horseDao.GetHorse(horse.HorseId);
                    var horseBets = bets.Where(x => x.HorseId == horse.HorseId).ToList();

                    var raceHorse = new RaceHorseDetails
                    {
                        HorseId = horse.HorseId,
                        HorseName = horseDetails?.HorseName,
                        Odds = horse.Odds,
                        TotalBets = horseBets.Sum(x => x.BetAmount),
                        BetCount = horseBets.Count
                    };

                    raceHorse.EstimatedPayout = raceHorse.Odds * raceHorse.TotalBets;

                    raceDetails.HorseDetails.Add(raceHorse);
                }
            }

            return raceDetailsResource;
        }

        public RaceBetSearchResource GetAllBetsForRace(int raceId)
        {
            var race = _raceDao.GetRace(raceId);

            if (race == null)
                return null;

            var raceBetSearchResource = new RaceBetSearchResource
            {
                RaceId = race.RaceId,
                RaceName = race.RaceName,
                RaceBets = new List<RaceBet>()
            };

            var bets = _customerBetsDao.GetAllBetsForRace(race.RaceId);

            if (bets == null || !bets.Any())
                return raceBetSearchResource;

            foreach (var customerBet in bets)
            {
                var horse = _horseDao.GetHorse(customerBet.HorseId);
                var customer = _customerDao.GetCustomer(customerBet.CustomerId);

                var raceBet = new RaceBet
                {
                    CustomerId = customer?.CustomerId ?? customerBet.CustomerId,
                    CustomerName = customer?.CustomerName,
                    HorseId = horse?.HorseId ?? customerBet.HorseId,
                    HorseName = horse?.HorseName,
                    BetAmount = customerBet.BetAmount
                };

                raceBetSearchResource.RaceBets.Add(raceBet);
            }

            return raceBetSearchResource;
        }
    }
}
