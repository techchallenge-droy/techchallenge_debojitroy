using System.Collections.Generic;
using RaceDay.Models.DTO;

namespace RaceDay.Models.Responses
{
    public class CustomerBetSearchResource
    {
        public Customer CustomerDetails { get; set; }
        public List<CustomerBet> Bets { get; set; }
        public double TotalStake { get; set; }
    }
}
