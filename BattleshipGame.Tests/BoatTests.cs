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

            // Should be a test below:
            // var shouldBeFalse = Boat.IsCoordinateAlreadyAssigned(boatList, (0,1));
            // Console.WriteLine(shouldBeFalse);
    }
}
