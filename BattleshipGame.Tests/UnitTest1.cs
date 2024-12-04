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
            // Arrange & Act
            var game = new Game();

            // Assert
            Assert.IsNotNull(game);
        }
    }
}
