using NUnit.Framework;

namespace RaceDay.DAO.Logic.Tests
{
    [TestFixture]
    public class RaceDaoTests
    {
        private RaceDao _sut;

        [SetUp]
        public void Init()
        {
            _sut = new RaceDao();   
        }

        [Test]
        public void GetAllRaces_returns_all_races_test()
        {
            var allRaces = _sut.GetAllRaces();

            Assert.IsNotNull(allRaces);
            Assert.IsTrue(allRaces.Count > 0);
        }

        [TestCase(1)]
        [TestCase(2)]
        public void GetRaces_returns_race_for_existing_values(int raceId)
        {
            var race = _sut.GetRace(raceId);

            Assert.IsNotNull(race);
        }

        [TestCase(10)]
        [TestCase(20)]
        public void GetRaces_returns_null_for_non_existing_values(int raceId)
        {
            var race = _sut.GetRace(raceId);

            Assert.IsNull(race);
        }
    }
}
