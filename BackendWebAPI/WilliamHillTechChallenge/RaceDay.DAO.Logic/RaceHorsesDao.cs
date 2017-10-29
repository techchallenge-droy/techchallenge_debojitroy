using System.Collections.Generic;
using System.Linq;
using RaceDay.DAO.Interfaces;
using RaceDay.DAO.Interfaces.Domain;

namespace RaceDay.DAO.Logic
{
    public class RaceHorsesDao : IRaceHorsesDao
    {
        private readonly List<RaceHorses> _store = new List<RaceHorses>();

        public RaceHorsesDao()
        {
            //Completed race will have final positions
            _store.Add(new RaceHorses { RaceId = 1, HorseId = 1, Odds = 2.5, HorsePosition = 3 });
            _store.Add(new RaceHorses { RaceId = 1, HorseId = 2, Odds = 1.5, HorsePosition = 2 });
            _store.Add(new RaceHorses { RaceId = 1, HorseId = 3, Odds = 5.0, HorsePosition = 4 });
            _store.Add(new RaceHorses { RaceId = 1, HorseId = 4, Odds = 2.0, HorsePosition = 1 });
            _store.Add(new RaceHorses { RaceId = 1, HorseId = 5, Odds = 4.5, HorsePosition = 5 });

            //Pending and InProgress dont have positions
            _store.Add(new RaceHorses { RaceId = 2, HorseId = 6, Odds = 3.4 });
            _store.Add(new RaceHorses { RaceId = 2, HorseId = 7, Odds = 1.4 });
            _store.Add(new RaceHorses { RaceId = 2, HorseId = 8, Odds = 2.4 });
            _store.Add(new RaceHorses { RaceId = 2, HorseId = 9, Odds = 2.0 });
            _store.Add(new RaceHorses { RaceId = 2, HorseId = 10, Odds = 5.5 });

            _store.Add(new RaceHorses { RaceId = 3, HorseId = 11, Odds = 1.5 });
            _store.Add(new RaceHorses { RaceId = 3, HorseId = 12, Odds = 2.5 });
            _store.Add(new RaceHorses { RaceId = 3, HorseId = 13, Odds = 3.0 });
            _store.Add(new RaceHorses { RaceId = 3, HorseId = 14, Odds = 2.0 });
            _store.Add(new RaceHorses { RaceId = 3, HorseId = 15, Odds = 4.5 });

            _store.Add(new RaceHorses { RaceId = 4, HorseId = 16, Odds = 1.9 });
            _store.Add(new RaceHorses { RaceId = 4, HorseId = 17, Odds = 2.8 });
            _store.Add(new RaceHorses { RaceId = 4, HorseId = 18, Odds = 3.6 });
            _store.Add(new RaceHorses { RaceId = 4, HorseId = 19, Odds = 1.2 });
            _store.Add(new RaceHorses { RaceId = 4, HorseId = 20, Odds = 1.1 });
        }

        public IList<RaceHorses> GetAllRaceHorses(int raceId)
        {
            return _store.Where(x => x.RaceId == raceId).ToList();
        }
    }
}
