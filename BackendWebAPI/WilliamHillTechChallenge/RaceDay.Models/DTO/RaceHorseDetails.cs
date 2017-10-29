namespace RaceDay.Models.DTO
{
    public class RaceHorseDetails
    {
        public int HorseId { get; set; }
        public string HorseName { get; set; }
        public double Odds { get; set; }
        public double TotalBets { get; set; }
        public int BetCount { get; set; }
        public double EstimatedPayout { get; set; }
    }
}
