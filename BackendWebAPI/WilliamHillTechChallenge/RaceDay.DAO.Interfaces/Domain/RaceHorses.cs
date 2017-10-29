namespace RaceDay.DAO.Interfaces.Domain
{
    public class RaceHorses
    {
        public int RaceId { get; set; }
        public int HorseId { get; set; }
        public double Odds { get; set; }
        public int? HorsePosition { get; set; }
    }
}
