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

            Assert.That(gameGrid.Width == 20 && gameGrid.Height == 20);
        }
    }
}
