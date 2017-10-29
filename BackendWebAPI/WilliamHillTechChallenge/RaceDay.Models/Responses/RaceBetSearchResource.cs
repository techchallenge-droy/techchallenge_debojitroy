using System.Collections.Generic;
using RaceDay.Models.DTO;

namespace RaceDay.Models.Responses
{
    public class RaceBetSearchResource
    {
        public int RaceId { get; set; }
        public string RaceName { get; set; }
        public List<RaceBet> RaceBets { get; set; }
    }
}
