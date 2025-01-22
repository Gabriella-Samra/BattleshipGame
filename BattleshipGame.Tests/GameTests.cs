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

        [Test]
        public void SmallBoatGetsOneCoordinate()
        {
            var smallBoat = HelperMethods.GetBoatWithCoordinates("Small", "LeftPath");
            Assert.That(smallBoat.BoatCoordinates.Count, Is.EqualTo(1));
        }

        [Test]
        public void MediumBoatGetsTwoCoordinates()
        {
            var mediumBoat = HelperMethods.GetBoatWithCoordinates("Medium", "LeftPath");
            Assert.That(mediumBoat.BoatCoordinates.Count, Is.EqualTo(2));
        }

        [Test]
        public void MediumBoatGetsSequentialCoordinatesWhenPathingLeft()
        {
            var mediumBoat = HelperMethods.GetBoatWithCoordinates("Medium", "LeftPath");
            Assert.That(mediumBoat.BoatCoordinates[0].X, Is.Not.EqualTo(mediumBoat.BoatCoordinates[1].X));
            Assert.That(mediumBoat.BoatCoordinates[0].Y, Is.EqualTo(mediumBoat.BoatCoordinates[1].Y));
        }

        [Test]
        public void LargeBoatGetsThreeCoordinates()
        {
            var largeBoat = HelperMethods.GetBoatWithCoordinates("Large", "LeftPath");
            Assert.That(largeBoat.BoatCoordinates.Count, Is.EqualTo(3));
        }

        [Test]
        public void LargeBoatGetsSequentialCoordinatesWhenPathingLeft()
        {
            var largeBoat = HelperMethods.GetBoatWithCoordinates("Large", "LeftPath");
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
                game.RemainderCoordinatesGenerator(gameGrid, boatList, largeBoat, startCoordinates, "LeftPath", largeBoat.BoatLength() - 2);

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

        [Test]
        public void CheckCorrectNumberOfCoordsAssignedToSmallBoatRegressionTest()
        {
            var helper = new HelperMethods();
            var result = helper.IsBoatCoordinatesCountCorrect("Small");

            Assert.That(result, Is.True);
        }

        [Test]
        public void CheckCorrectNumberOfCoordsAssignedToMediumBoatRegressionTest()
        {
            var helper = new HelperMethods();
            var result = helper.IsBoatCoordinatesCountCorrect("Medium");

            Assert.That(result, Is.True);
        }

        [Test]
        public void TwentyChecksCorrectNumberOfCoordsAssignedToLargeBoatRegressionTest()
        {
            bool result;
            List<string> allLoopResults = new List<string>();
            
            for(int i = 0; i <20; i++)
            {
                Console.WriteLine($"Iteration Numer {i}");
                var helper = new HelperMethods();
                result = helper.IsBoatCoordinatesCountCorrect("Large");


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

        [Test]
        public void MediumBoatAssignedCoordinateOffGridAndReassignedANewCoordRegressionTest()
        {
            var helper = new HelperMethods();
            var gameDTO = helper.BasicGameSetupNOCoordinatesAssigned();

            gameDTO.BoatList[0].BoatCoordinates.Add(new Coordinate(8, 8));
            
            gameDTO.BoatList[1].BoatCoordinates.Add(new Coordinate(6, 9));

            var mediumBoat = gameDTO.BoatList[1];
            var starterCoordinate = new Coordinate(6, 9);

            gameDTO.Game.RemainderCoordinatesGenerator(gameDTO.GameGrid, gameDTO.BoatList, mediumBoat, starterCoordinate, "DownPath", 1);

            var MediumBoatAssignedSecondCoord = gameDTO.BoatList[1].BoatCoordinates[1];
            
            var mediumXComponent = MediumBoatAssignedSecondCoord.X;
            var mediumYComponent = MediumBoatAssignedSecondCoord.Y;

            Console.WriteLine($"X Component is {mediumXComponent}, Y Component is {mediumYComponent}");

            var result = GameGrid.IsCoordinatesOnGrid(MediumBoatAssignedSecondCoord, gameDTO.GameGrid);

            Assert.That(result, Is.True);
        }

        [Test]
        public void MediumBoatAssignedCoordinateOffGridAndItIsFlaggedAsOffGridRegressionTest()
        {
            var helper = new HelperMethods();
            var gameDTO = helper.BasicGameSetupNOCoordinatesAssigned();

            gameDTO.BoatList[0].BoatCoordinates.Add(new Coordinate(8, 8));
            
            gameDTO.BoatList[1].BoatCoordinates.Add(new Coordinate(6, 9));

            var mediumBoat = gameDTO.BoatList[1];
            var offGridCoord = new Coordinate(6, 10);

            var result = GameGrid.IsCoordinatesOnGrid(offGridCoord, gameDTO.GameGrid);

            Assert.That(result, Is.False);
        }
    }
}
