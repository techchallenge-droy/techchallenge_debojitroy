using System.Linq;
using System.Web.Http;
using RaceDay.Providers.Interfaces;

namespace RaceDay.WebAPI.Controllers
{
    [RoutePrefix("v1/race")]
    public class RaceController : ApiController
    {
        private readonly IRaceProvider _raceProvider;

        public RaceController(IRaceProvider raceProvider)
        {
            _raceProvider = raceProvider;
        }

        [HttpGet]
        [Route("all")]
        public IHttpActionResult GetAllRaces()
        {
            return Ok(_raceProvider.GetAllRaces());
        }

        [HttpGet]
        [Route("bets/{raceId:int}")]
        public IHttpActionResult GetAllBetsForRace(int raceId)
        {
            var raceBets = _raceProvider.GetAllBetsForRace(raceId);

            if (raceBets?.RaceBets != null && raceBets.RaceBets.Any())
                return Ok(raceBets);

            return NotFound();
        }
    }
}
