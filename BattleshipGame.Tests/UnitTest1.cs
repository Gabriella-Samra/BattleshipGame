using NUnit.Framework;
using BattleshipGame.Core;

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

        [Test]
        public void GameGridWidthAndHeightIs10()
        {
            var gameGrid = new GameGrid();

            Assert.That(gameGrid.Width == 10 && gameGrid.Height == 10);
        }

        [Test]
        public void BoatLengthForMedium()
        {
            var boat = new Boat("Medium");
            var boatLength = boat.BoatLength();

            Assert.IsNotNull(boatLength == 2);
        }
    }
}
