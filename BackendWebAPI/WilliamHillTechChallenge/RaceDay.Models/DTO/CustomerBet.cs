namespace RaceDay.Models.DTO
{
    public class CustomerBet
    {
        public int RaceId { get; set; }
        public string RaceName { get; set; }
        public int HorseId { get; set; }
        public string HorseName { get; set; }
        public double Stake { get; set; }
    }
}
