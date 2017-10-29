using NUnit.Framework;

namespace RaceDay.DAO.Logic.Tests
{
    [TestFixture]
    public class RaceHorsesDaoTests
    {
        private RaceHorsesDao _sut;

        [SetUp]
        public void Init()
        {
            _sut = new RaceHorsesDao();   
        }

        [TestCase(1)]
        [TestCase(2)]
        public void GetAllRaceHorses_returns_all_horses_for_race(int raceId)
        {
            var horses = _sut.GetAllRaceHorses(raceId);

            Assert.IsNotNull(horses);
            Assert.IsTrue(horses.Count > 0);
            foreach (var raceHorsese in horses)
            {
                Assert.IsTrue(raceHorsese.RaceId == raceId);
            }
        }

        [TestCase(10)]
        [TestCase(11)]
        public void GetAllRaceHorses_returns_no_horses_if_race_doesnt_exist(int raceId)
        {
            var horses = _sut.GetAllRaceHorses(raceId);

            Assert.IsNotNull(horses);
            Assert.IsTrue(horses.Count == 0);
        }
    }
}
