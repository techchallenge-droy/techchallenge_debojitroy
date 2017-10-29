using System.Collections.Generic;
using RaceDay.DAO.Interfaces.Domain;

namespace RaceDay.DAO.Interfaces
{
    public interface IHorseDao
    {
        IList<Horse> GetAllHorses();
        Horse GetHorse(int horseId);
    }
}
