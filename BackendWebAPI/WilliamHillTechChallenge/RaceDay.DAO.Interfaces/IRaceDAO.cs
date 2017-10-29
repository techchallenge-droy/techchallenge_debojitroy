using System.Collections.Generic;
using RaceDay.DAO.Interfaces.Domain;

namespace RaceDay.DAO.Interfaces
{
    public interface IRaceDao
    {
        IList<Race> GetAllRaces();
        Race GetRace(int raceId);
    }
}
