using System.Collections.Generic;
using System.Linq;
using RaceDay.DAO.Interfaces;
using RaceDay.DAO.Interfaces.Domain;

namespace RaceDay.DAO.Logic
{
    public class RaceDao : IRaceDao
    {
        // Creating a internal store for values
        // Actual scenario the details will be coming from a persistent store
        private readonly Dictionary<int, Race> _store = new Dictionary<int, Race>();

        public RaceDao()
        {
            //Seed value
            _store.Add(1, new Race { RaceId = 1, RaceName = "Race 1", RaceStatus = "Completed" });
            _store.Add(2, new Race { RaceId = 2, RaceName = "Race 2", RaceStatus = "InProgress" });
            _store.Add(3, new Race { RaceId = 3, RaceName = "Race 3", RaceStatus = "Pending" });
            _store.Add(4, new Race { RaceId = 4, RaceName = "Race 4", RaceStatus = "Pending" });
        }

        public IList<Race> GetAllRaces()
        {
            return _store.Values.ToList();
        }

        public Race GetRace(int raceId)
        {
            return _store.ContainsKey(raceId) ? _store[raceId] : null;
        }
    }
}
