using System.Collections.Generic;
using System.Linq;
using RaceDay.DAO.Interfaces;
using RaceDay.DAO.Interfaces.Domain;

namespace RaceDay.DAO.Logic
{
    public class HorseDao : IHorseDao
    {
        // Creating a internal store for values
        // Actual scenario the details will be coming from a persistent store
        private readonly Dictionary<int, Horse> _store = new Dictionary<int, Horse>();

        public HorseDao()
        {
            //Seed value
            _store.Add(1, new Horse { HorseId = 1, HorseName = "Horse 1" });
            _store.Add(2, new Horse { HorseId = 2, HorseName = "Horse 2" });
            _store.Add(3, new Horse { HorseId = 3, HorseName = "Horse 3" });
            _store.Add(4, new Horse { HorseId = 4, HorseName = "Horse 4" });
            _store.Add(5, new Horse { HorseId = 5, HorseName = "Horse 5" });
            _store.Add(6, new Horse { HorseId = 6, HorseName = "Horse 6" });
            _store.Add(7, new Horse { HorseId = 7, HorseName = "Horse 7" });
            _store.Add(8, new Horse { HorseId = 8, HorseName = "Horse 8" });
            _store.Add(9, new Horse { HorseId = 9, HorseName = "Horse 9" });
            _store.Add(10, new Horse { HorseId = 10, HorseName = "Horse 10" });
            _store.Add(11, new Horse { HorseId = 11, HorseName = "Horse 11" });
            _store.Add(12, new Horse { HorseId = 12, HorseName = "Horse 12" });
            _store.Add(13, new Horse { HorseId = 13, HorseName = "Horse 13" });
            _store.Add(14, new Horse { HorseId = 14, HorseName = "Horse 14" });
            _store.Add(15, new Horse { HorseId = 15, HorseName = "Horse 15" });
            _store.Add(16, new Horse { HorseId = 16, HorseName = "Horse 16" });
            _store.Add(17, new Horse { HorseId = 17, HorseName = "Horse 17" });
            _store.Add(18, new Horse { HorseId = 18, HorseName = "Horse 18" });
            _store.Add(19, new Horse { HorseId = 19, HorseName = "Horse 19" });
            _store.Add(20, new Horse { HorseId = 20, HorseName = "Horse 20" });
        }

        public IList<Horse> GetAllHorses()
        {
            return _store.Values.ToList();
        }

        public Horse GetHorse(int horseId)
        {
            return _store.ContainsKey(horseId) ? _store[horseId] : null;
        }
    }
}
