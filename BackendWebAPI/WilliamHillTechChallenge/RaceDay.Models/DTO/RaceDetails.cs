using System.Collections.Generic;

namespace RaceDay.Models.DTO
{
    public class RaceDetails
    {
        public int RaceId { get; set; }
        public string RaceName { get; set; }
        public string RaceStatus { get; set; }
        public double TotalBets { get; set; }
        public List<RaceHorseDetails> HorseDetails { get; set; }
    }
}
