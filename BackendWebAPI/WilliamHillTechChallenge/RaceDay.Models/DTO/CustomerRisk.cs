namespace RaceDay.Models.DTO
{
    public class CustomerRisk
    {
        public Customer CustomerDetails { get; set; }
        public double TotalStake { get; set; }
        public string RiskProfile { get; set; }
    }
}
