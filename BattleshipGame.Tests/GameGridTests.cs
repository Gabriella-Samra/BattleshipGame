using NUnit.Framework;
using BattleshipGame.Core;

namespace BattleshipGame.Tests
{
    [TestFixture]
    public class GameGridTests
    {
        [Test]
        public void GameGridWidthAndHeightIsAsSupplied()
        {
            var gameGrid = new GameGrid(20, 20);

            Assert.That(gameGrid.XAxis == 20 && gameGrid.YAxis == 20);
        }

        [Test]
        public void GameGridPrintsInXYOrder()
        {
            var gameGrid = new GameGrid(2, 2);
            var printed = ConsolePrints.InitialGridPrint(gameGrid);
            var expected = "0,0 || 1,0 || 0,1 || 1,1";
            Assert.That(printed, Is.EqualTo(expected));
        }

        
    }
}
