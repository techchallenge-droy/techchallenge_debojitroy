using RaceDay.Models.Responses;

namespace RaceDay.Providers.Interfaces
{
    public interface IRaceProvider
    {
        RaceDetailsResource GetAllRaces();
        RaceBetSearchResource GetAllBetsForRace(int raceId);
    }
}
