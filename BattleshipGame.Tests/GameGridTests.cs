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

        [Test]
        public void CheckGameGridGeneratesCorrectly ()
        {
            var game = new Game();
            var gameGrid = new GameGrid(2, 2);
            Coordinate coordinate = new Coordinate(1, 1);

            var isCoordInList = gameGrid.GridCoordinates.Find(coordinateInList => coordinateInList.X == coordinate.X && coordinateInList.Y == coordinate.Y);

            bool result;

            if(isCoordInList != null)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            Assert.That(result, Is.True);
        }

        [Test]
        public void CheckGameGridGeneratesDoesNotIncludeCoordsItShouldNotHaveOnGrid ()
        {
            var game = new Game();
            var gameGrid = new GameGrid(2, 2);
            Coordinate coordinate = new Coordinate(3, 3);

            var isCoordInList = gameGrid.GridCoordinates.Find(coordinateInList => coordinateInList.X == coordinate.X && coordinateInList.Y == coordinate.Y);

            bool result;

            if(isCoordInList != null)
            {
                result = false;
            }
            else
            {
                result = true;
            }

            Assert.That(result, Is.True);
        }


        [Test]
        public void CheckCoordinateOnGridMethodWorks ()
        {
            var game = new Game();
            var gameGrid = new GameGrid(2, 2);

            var coord = new Coordinate(1, 1);
            var result = GameGrid.IsCoordinatesOnGrid(coord, gameGrid);

            Assert.That(result, Is.True);
        }

        [Test]
        public void CheckCoordinateNOTOnGridMethodWorks ()
        {
            var game = new Game();
            var gameGrid = new GameGrid(2, 2);

            var coord = new Coordinate(3,3);
            var result = GameGrid.IsCoordinatesOnGrid(coord, gameGrid);

            Assert.That(result, Is.False);
        }

        [Test]
        public void CheckSmallBoatCoordIsAddedToGameGrid ()
        {
            var helper = new HelperMethods();
            var game = helper.BasicGameSetup();

            game.BoatList[0].BoatCoordinates.Add(new Coordinate(1, 1));
            int index = game.GameGrid.GridCoordinates.FindIndex(gridCoord => gridCoord.X == 1 && gridCoord.Y == 1);
            var newGameGrid = GameGrid.UpdateGameGridWithBoats(game.GameGrid, game.BoatList);

            int boatLocation = newGameGrid.GridCoordinates.FindIndex(coord => coord is StringCoordinate stringCoord && stringCoord.BoatCode == "S,B");
            
            Is.EqualTo(index == boatLocation);
        }
    }
}
