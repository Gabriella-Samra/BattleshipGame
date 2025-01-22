using NUnit.Framework;
using BattleshipGame.Core;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace BattleshipGame.Tests
{
    [TestFixture]
    public class CoordinateTests
    {
        [Test]
        public void CheckGeneratingACoordinateWorks()
        {
            var gameGrid = new GameGrid(2, 2); // Grid coords that should generate are (0,0), (0,1), (1,0), (1,1)
            bool result;
            
            var coordinate = Coordinate.GenerateCoorindate(gameGrid);

            var IsCoordOnGrid = gameGrid.GridCoordinates.Find(i => i.X == coordinate.X && i.Y == coordinate.Y);

            if(IsCoordOnGrid != null) // if a coord has been found on the list then add true to the result list
            {
                result = true;
            }
            else  // if no coord has been found on the list then add false to the result list
            {
                result =false;
            }

            Assert.That(result, Is.True);
        }
    }
}