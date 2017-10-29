using NUnit.Framework;

namespace RaceDay.DAO.Logic.Tests
{
    [TestFixture]
    public class CustomerBetsDaoTests
    {
        private CustomerBetsDao _sut;

        [SetUp]
        public void Init()
        {
            _sut = new CustomerBetsDao();
        }

        [Test]
        public void GetAllBets_returns_bets()
        {
            var allbets = _sut.GetAllBets();

            Assert.IsNotNull(allbets);
            Assert.IsTrue(allbets.Count > 0);
        }

        [TestCase(1)]
        [TestCase(2)]
        public void GetAllBetsForCustomer_returns_all_bets_for_customer(int customerId)
        {
            var customerBets = _sut.GetAllBetsForCustomer(customerId);

            Assert.IsNotNull(customerBets);
            Assert.IsTrue(customerBets.Count > 0);
            foreach (var customerBet in customerBets)
            {
                Assert.IsTrue(customerBet.CustomerId == customerId);
            }
        }

        [TestCase(1)]
        [TestCase(2)]
        public void GetAllBetsForRace_returns_all_bets_for_race(int raceId)
        {
            var raceBets = _sut.GetAllBetsForRace(raceId);

            Assert.IsNotNull(raceBets);
            Assert.IsTrue(raceBets.Count > 0);
            foreach (var bet in raceBets)
            {
                Assert.IsTrue(bet.RaceId == raceId);
            }
        }

        [TestCase(1)]
        [TestCase(2)]
        public void GetAllBetsForHorse_returns_all_bets_for_horse(int horseId)
        {
            var horseBets = _sut.GetAllBetsForHorse(horseId);

            Assert.IsNotNull(horseBets);
            Assert.IsTrue(horseBets.Count > 0);
            foreach (var bet in horseBets)
            {
                Assert.IsTrue(bet.HorseId == horseId);
            }
        }
    }
}
