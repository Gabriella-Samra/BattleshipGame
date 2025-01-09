using NUnit.Framework;
using BattleshipGame.Core;
using System.Linq.Expressions;

namespace BattleshipGame.Tests
{
    [TestFixture]
    public class GameTests
    {
        [Test]
        public void GameInitialization_ShouldCreateGameInstance()
        {
            var game = new Game();

            Assert.IsNotNull(game);
        }

        private Boat GetBoatWithCoordinates(string boatMake, string path)
        {
            var gameGrid = new GameGrid();
            var boat = new Boat(boatMake);
            var boats = new List<Boat> { boat };
            var startCoordinates = new Coordinate(5,5);
            boat.BoatCoordinates.Add(startCoordinates);
            var game = new Game();
            game.RemainderCoordinatesGenerator(gameGrid, boats, boat, startCoordinates, path, boat.BoatLength() - 1, 1);
            return boat;
        }

        [Test]
        public void SmallBoatGetsOneCoordinate()
        {
            var smallBoat = GetBoatWithCoordinates("Small", "LeftPath");
            Assert.That(smallBoat.BoatCoordinates.Count, Is.EqualTo(1));
        }

        [Test]
        public void MediumBoatGetsTwoCoordinates()
        {
            var mediumBoat = GetBoatWithCoordinates("Medium", "LeftPath");
            Assert.That(mediumBoat.BoatCoordinates.Count, Is.EqualTo(2));
        }

        [Test]
        public void MediumBoatGetsSequentialCoordinatesWhenPathingLeft()
        {
            var mediumBoat = GetBoatWithCoordinates("Medium", "LeftPath");
            Assert.That(mediumBoat.BoatCoordinates[0].X, Is.Not.EqualTo(mediumBoat.BoatCoordinates[1].X));
            Assert.That(mediumBoat.BoatCoordinates[0].Y, Is.EqualTo(mediumBoat.BoatCoordinates[1].Y));
        }

        [Test]
        public void LargeBoatGetsThreeCoordinates()
        {
            var largeBoat = GetBoatWithCoordinates("Large", "LeftPath");
            Assert.That(largeBoat.BoatCoordinates.Count, Is.EqualTo(3));
        }

        [Test]
        public void LargeBoatGetsSequentialCoordinatesWhenPathingLeft()
        {
            var largeBoat = GetBoatWithCoordinates("Large", "LeftPath");
            Assert.That(largeBoat.BoatCoordinates[0].X, Is.Not.EqualTo(largeBoat.BoatCoordinates[1].X));
            Assert.That(largeBoat.BoatCoordinates[1].X, Is.Not.EqualTo(largeBoat.BoatCoordinates[2].X));
            Assert.That(largeBoat.BoatCoordinates[0].Y, Is.EqualTo(largeBoat.BoatCoordinates[1].Y));
            Assert.That(largeBoat.BoatCoordinates[1].Y, Is.EqualTo(largeBoat.BoatCoordinates[2].Y));
        }
    }
}
