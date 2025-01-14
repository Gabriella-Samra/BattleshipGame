using NUnit.Framework;
using BattleshipGame.Core;

namespace BattleshipGame.Tests
{
    [TestFixture]
    public class BoatTests
    {
        [Test]
        public void BoatLengthForSmall()
        {
            var boat = new Boat("Small");
            int boatLength = boat.BoatLength();

            Is.EqualTo(boatLength == 1);
        }

        [Test]
        public void BoatLengthForMedium()
        {
            var boat = new Boat("Medium");
            int boatLength = boat.BoatLength();

            Is.EqualTo(boatLength == 2);
        }

        [Test]
        public void BoatLengthForLarge()
        {
            var boat = new Boat("Large");
            int boatLength = boat.BoatLength();

            Is.EqualTo(boatLength == 3);
        }

        [Test]
        public void BoatLengthForOtherType()
        {
            var boat = new Boat("Other");
            int boatLength = boat.BoatLength();

            Is.EqualTo(boatLength == 0);
        }

        [Test]
        public void CheckThatOverlappingCoordinatesWillBeFlagged()
        {
            var smallBoat = new Boat("Small");
            var boatList = new List<Boat>{smallBoat};

            smallBoat.BoatCoordinates.Add(new Coordinate(1,1));

            Coordinate coordToCheck = new Coordinate(1, 1);
            var shouldBeTrue = Boat.IsCoordinateAssigned(boatList, coordToCheck);

            Assert.That(shouldBeTrue);
        }

        [Test]
        public void GivenBoatWillBeFoundInList()
        {
            var boatList = new List<Boat>();
            var smallBoat = new Boat("Small");
            boatList.Add(smallBoat);

            var selectedBoat = Boat.FindBoatByMake(boatList, smallBoat.Make);
            bool result;

            if(selectedBoat != null)
            {
                result = true;
            }
            else{
                result = false;
            }

            Assert.That(result);
        }
    }
}
