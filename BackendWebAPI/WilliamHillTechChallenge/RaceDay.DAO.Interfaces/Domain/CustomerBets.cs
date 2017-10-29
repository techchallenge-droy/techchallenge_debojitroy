namespace RaceDay.DAO.Interfaces.Domain
{
    public class CustomerBets
    {
        public int CustomerId { get; set; }
        public int RaceId { get; set; }
        public int HorseId { get; set; }
        public double BetAmount { get; set; }
    }
}
