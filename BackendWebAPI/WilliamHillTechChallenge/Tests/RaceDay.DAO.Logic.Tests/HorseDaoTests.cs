using NUnit.Framework;

namespace RaceDay.DAO.Logic.Tests
{
    [TestFixture]
    public class HorseDaoTests
    {
        private HorseDao _sut;

        [SetUp]
        public void Init()
        {
            _sut = new HorseDao();
        }

        [Test]
        public void GetAllHorses_returns_all_horses()
        {
            var horses = _sut.GetAllHorses();

            Assert.IsNotNull(horses);
            Assert.IsTrue(horses.Count > 0);
        }

        [TestCase(1)]
        [TestCase(2)]
        public void GetHorses_returns_horses(int horseId)
        {
            var horse = _sut.GetHorse(horseId);

            Assert.IsNotNull(horse);
        }

        [TestCase(100)]
        [TestCase(101)]
        public void GetHorses_doesnot_returns_horses(int horseId)
        {
            var horse = _sut.GetHorse(horseId);

            Assert.IsNull(horse);
        }
    }
}
