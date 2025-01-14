using NUnit.Framework;
using BattleshipGame.Core;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

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

        [Test]
        public void XCoordSpontaneaouslyNotGeneratingCorrectlyForLargeBoatThirdCoordRegressionTest()
        {
            string largeBoatThirdCoord = "";
            List<string> allLoopResults = new List<string>();

            for(var i = 0; i < 20; i++)
            {
                var gameGrid = new GameGrid();
                var game = new Game();

                var smallBoat = new Boat("Small");
                var coord1 = new Coordinate(2, 4);
                smallBoat.BoatCoordinates.Add(coord1);

                var mediumBoat = new Boat("Medium");
                coord1 = new Coordinate(5, 8);
                var coord2 = new Coordinate(5, 9);
                mediumBoat.BoatCoordinates.Add(coord1);
                mediumBoat.BoatCoordinates.Add(coord2);

                var largeBoat = new Boat("Large");
                coord1 = new Coordinate(7, 8);
                coord2 = new Coordinate(6, 8);
                largeBoat.BoatCoordinates.Add(coord1);
                largeBoat.BoatCoordinates.Add(coord2);

                var boatList = new List<Boat>
                {
                    smallBoat,
                    mediumBoat,
                    largeBoat
                };

                var startCoordinates = coord2;
                game.RemainderCoordinatesGenerator(gameGrid, boatList, largeBoat, startCoordinates, "LeftPath", largeBoat.BoatLength() - 2, 2);

                var largeBoatThirdCoordX = boatList[2].BoatCoordinates[2].X;
                var largeBoatThirdCoordY = boatList[2].BoatCoordinates[2].Y;
                largeBoatThirdCoord = $"{largeBoatThirdCoordX}, {largeBoatThirdCoordY}";

                var result = largeBoatThirdCoord != "5, 8";

                if(result)
                {  
                    allLoopResults.Add("true");
                }

                if(!result)
                {  
                    allLoopResults.Add("false");
                }

                // add all the true and false rounds to a list and then will check the list to see if the test passes
            }

            int failedIndex = allLoopResults.FindIndex(result => result != "true");

            Assert.IsTrue(
                failedIndex == -1, 
                failedIndex == -1
                    ? null // All passed
                    : $"The test failed on iteration {failedIndex}"
            );
        }

        private GameInstanceDTO BasicGameSetup(string boat)
        {
            var gameGrid = new GameGrid();
            var game = new Game();

            var smallBoat = new Boat("Small");
            var mediumBoat = new Boat("Medium");
            var largeBoat = new Boat("Large");

            var boatList = new List<Boat>
            {
                smallBoat,
                mediumBoat,
                largeBoat
            };

            game.CoordinateAssignmentForComputerBoats(gameGrid, boatList);
            
            var gameInstanceDTO = new GameInstanceDTO(game, gameGrid, boatList);

            return gameInstanceDTO;
        }

        private bool IsBoatCoordinatesCountCorrect(string boat)
        {
           
            var gameSetup = BasicGameSetup(boat);
            var game = gameSetup.Game;
            var gameGrid = gameSetup.GameGrid;
            var boatList = gameSetup.BoatList;
            
            var matchingBoat = Boat.FindBoatByMake(boatList, boat);

            // TODO: Matchingboat could be null because the boat is not in the list. Need to do an if else here.
            var boatResult = matchingBoat.BoatCoordinates.Count == matchingBoat.BoatLength();
            return boatResult;
        }

        [Test]
        public void CheckCorrectNumberOfCoordsAssignedToSmallBoatRegressionTest()
        {
            var result = IsBoatCoordinatesCountCorrect("Small");

            Assert.That(result);
        }

        [Test]
        public void CheckCorrectNumberOfCoordsAssignedToMediumBoatRegressionTest()
        {
            var result = IsBoatCoordinatesCountCorrect("Medium");

            Assert.That(result);
        }

        [Test]
        public void TwentyChecksCorrectNumberOfCoordsAssignedToLargeBoatRegressionTest()
        {
            bool result;
            List<string> allLoopResults = new List<string>();
            
            for(int i = 0; i <20; i++)
            {
                Console.WriteLine($"Iteration Numer {i}");
                result = IsBoatCoordinatesCountCorrect("Large");


                if(result)
                {  
                    allLoopResults.Add("true");
                }

                if(!result)
                {  
                    allLoopResults.Add("false");
                }
            }

            int failedIndex = allLoopResults.FindIndex(result => result != "true");

            Assert.IsTrue(
                failedIndex == -1, 
                failedIndex == -1
                    ? null // All passed
                    : $"The test failed on iteration {failedIndex}"
            );
        }
    }
}
