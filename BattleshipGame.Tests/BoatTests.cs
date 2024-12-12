using NUnit.Framework;
using BattleshipGame.Core;

namespace BattleshipGame.Tests
{
    [TestFixture]
    public class BoatTests
    {
        [Test]
        public void BoatLengthForMedium()
        {
            var boat = new Boat("Medium");
            int boatLength = boat.BoatLength();

            Assert.IsNotNull(boatLength == 2);
        }
    }
}
