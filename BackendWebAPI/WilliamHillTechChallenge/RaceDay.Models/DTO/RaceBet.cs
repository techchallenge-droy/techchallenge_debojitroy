namespace RaceDay.Models.DTO
{
    public class RaceBet
    {
        public int HorseId { get; set; }
        public string HorseName { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public double BetAmount { get; set; }
    }
}
