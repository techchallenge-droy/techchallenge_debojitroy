using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using RaceDay.DAO.Interfaces;
using RaceDay.DAO.Interfaces.Domain;

namespace RaceDay.Providers.Tests
{
    [TestFixture]
    public class RaceProviderTests
    {
        private Mock<IRaceDao> _raceDao;
        private Mock<IHorseDao> _horseDao;
        private Mock<IRaceHorsesDao> _raceHorsesDao;
        private Mock<ICustomerDao> _customerDao;
        private Mock<ICustomerBetsDao> _customerBetsDao;
        private RaceProvider _sut;

        [SetUp]
        public void Init()
        {
            _raceDao = new Mock<IRaceDao>();
            _horseDao = new Mock<IHorseDao>();
            _raceHorsesDao = new Mock<IRaceHorsesDao>();
            _customerDao = new Mock<ICustomerDao>();
            _customerBetsDao = new Mock<ICustomerBetsDao>();

            _sut = new RaceProvider(_raceDao.Object, 
                _horseDao.Object, 
                _raceHorsesDao.Object, 
                _customerDao.Object, 
                _customerBetsDao.Object);
        }

        [Test]
        public void GetAllRaces_returns_null_if_no_races()
        {
            var allraces = _sut.GetAllRaces();

            Assert.IsNull(allraces);
        }

        [Test]
        public void GetAllRaces_returns_all_races()
        {
            _raceDao.Setup(x => x.GetAllRaces()).Returns(new List<Race>() { new Race { RaceId = 1, RaceName = "test", RaceStatus = "Completed" }} );
            _horseDao.Setup(x => x.GetHorse(It.IsAny<int>())).Returns(new Horse { HorseId = 1, HorseName = "Test Horse" });
            _raceHorsesDao.Setup(x => x.GetAllRaceHorses(It.IsAny<int>())).Returns(new List<RaceHorses> { new RaceHorses { HorseId = 1, RaceId = 1, Odds = 2.0 }});
            _customerDao.Setup(x => x.GetCustomer(It.IsAny<int>())).Returns(new Customer { CustomerId = 1, CustomerName = "Test Customer"});
            _customerBetsDao.Setup(x => x.GetAllBetsForRace(It.IsAny<int>())).Returns(new List<CustomerBets> { new CustomerBets { BetAmount = 100, CustomerId = 1, HorseId = 1, RaceId = 1 }});

            var allRaces = _sut.GetAllRaces();

            Assert.IsNotNull(allRaces);
            Assert.IsNotNull(allRaces.RaceDetails);
            Assert.IsTrue(allRaces.RaceDetails.Count > 0);

            foreach (var raceDetail in allRaces.RaceDetails)
            {
                Assert.IsNotNull(raceDetail.HorseDetails);
            }
        }

        [Test]
        public void GetAllBetsForRace_returns_all_bets()
        {
            _raceDao.Setup(x => x.GetRace(It.IsAny<int>())).Returns(new Race { RaceId = 1, RaceName = "test", RaceStatus = "Completed" });
            _horseDao.Setup(x => x.GetHorse(It.IsAny<int>())).Returns(new Horse { HorseId = 1, HorseName = "Test Horse" });
            _raceHorsesDao.Setup(x => x.GetAllRaceHorses(It.IsAny<int>())).Returns(new List<RaceHorses> { new RaceHorses { HorseId = 1, RaceId = 1, Odds = 2.0 } });
            _customerDao.Setup(x => x.GetCustomer(It.IsAny<int>())).Returns(new Customer { CustomerId = 1, CustomerName = "Test Customer" });
            _customerBetsDao.Setup(x => x.GetAllBetsForRace(It.IsAny<int>())).Returns(new List<CustomerBets> { new CustomerBets { BetAmount = 100, CustomerId = 1, HorseId = 1, RaceId = 1 } });

            var raceBet = _sut.GetAllBetsForRace(1);

            Assert.IsNotNull(raceBet);
            Assert.IsNotNull(raceBet.RaceBets);
            Assert.IsTrue(raceBet.RaceBets.Count > 0);

            foreach (var betDetail in raceBet.RaceBets)
            {
                Assert.IsNotNull(betDetail);
            }
        }
    }
}
