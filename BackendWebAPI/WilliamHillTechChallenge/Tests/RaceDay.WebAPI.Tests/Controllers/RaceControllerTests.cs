using System.Collections.Generic;
using System.Web.Http.Results;
using Moq;
using NUnit.Framework;
using RaceDay.Models.DTO;
using RaceDay.Models.Responses;
using RaceDay.Providers.Interfaces;
using RaceDay.WebAPI.Controllers;

namespace RaceDay.WebAPI.Tests.Controllers
{
    [TestFixture]
    public class RaceControllerTests
    {
        private Mock<IRaceProvider> _raceProvider;
        private RaceController _sut;

        [SetUp]
        public void Init()
        {
            _raceProvider = new Mock<IRaceProvider>();

            _sut = new RaceController(_raceProvider.Object);
        }

        [Test]
        public void GetAllRaces_returns_OK_with_All_Races()
        {
            _raceProvider.Setup(x => x.GetAllRaces())
                .Returns(new RaceDetailsResource {RaceDetails = new List<RaceDetails>()});

            var response = _sut.GetAllRaces();

            Assert.IsInstanceOf<OkNegotiatedContentResult<RaceDetailsResource>>(response);
        }

        [Test]
        public void GetAllBetsForRace_returns_NotFound_if_race_not_found()
        {
            var response = _sut.GetAllBetsForRace(1);

            Assert.IsInstanceOf<NotFoundResult>(response);
        }

        [Test]
        public void GetAllBetsForRace_returns_allBets_if_race_is_found()
        {
            _raceProvider.Setup(x => x.GetAllBetsForRace(It.IsAny<int>())).Returns(new RaceBetSearchResource { RaceId = 1, RaceName = "test race", RaceBets = new List<RaceBet> { new RaceBet() }});

            var response = _sut.GetAllBetsForRace(1);

            Assert.IsInstanceOf<OkNegotiatedContentResult<RaceBetSearchResource>>(response);
        }
    }
}
