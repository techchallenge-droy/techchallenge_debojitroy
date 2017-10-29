using System.Collections.Generic;
using RaceDay.DAO.Interfaces.Domain;

namespace RaceDay.DAO.Interfaces
{
    public interface IRaceHorsesDao
    {
        IList<RaceHorses> GetAllRaceHorses(int raceId);
    }
}
