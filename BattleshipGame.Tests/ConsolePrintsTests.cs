using NUnit.Framework;
using BattleshipGame.Core;
using System.Diagnostics.CodeAnalysis;

namespace BattleshipGame.Tests
{
    [TestFixture]
    public class ConsolePrintsTests
    {
        [Test]
        public void InitialGridPrintsFullCoordinates()
        {
            var gameGrid = new GameGrid(10, 10);
            var initialGrid = ConsolePrints.InitialGridPrint(gameGrid);
            Console.WriteLine(initialGrid);
            var expected = string.Join(Environment.NewLine, new[]
            {
                "0,0 || 1,0 || 2,0 || 3,0 || 4,0 || 5,0 || 6,0 || 7,0 || 8,0 || 9,0",
                "0,1 || 1,1 || 2,1 || 3,1 || 4,1 || 5,1 || 6,1 || 7,1 || 8,1 || 9,1",
                "0,2 || 1,2 || 2,2 || 3,2 || 4,2 || 5,2 || 6,2 || 7,2 || 8,2 || 9,2",
                "0,3 || 1,3 || 2,3 || 3,3 || 4,3 || 5,3 || 6,3 || 7,3 || 8,3 || 9,3",
                "0,4 || 1,4 || 2,4 || 3,4 || 4,4 || 5,4 || 6,4 || 7,4 || 8,4 || 9,4",
                "0,5 || 1,5 || 2,5 || 3,5 || 4,5 || 5,5 || 6,5 || 7,5 || 8,5 || 9,5",
                "0,6 || 1,6 || 2,6 || 3,6 || 4,6 || 5,6 || 6,6 || 7,6 || 8,6 || 9,6",
                "0,7 || 1,7 || 2,7 || 3,7 || 4,7 || 5,7 || 6,7 || 7,7 || 8,7 || 9,7",
                "0,8 || 1,8 || 2,8 || 3,8 || 4,8 || 5,8 || 6,8 || 7,8 || 8,8 || 9,8",
                "0,9 || 1,9 || 2,9 || 3,9 || 4,9 || 5,9 || 6,9 || 7,9 || 8,9 || 9,9",
            });

            Assert.That(initialGrid, Is.EqualTo(expected));
        }

        [Test]
        public void CheckUpdatedGameGridPrintWorksAsExpected()
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

            // Assign coordinates to boats
            boatList[0].BoatCoordinates.Add(new Coordinate(0, 0));
            boatList[1].BoatCoordinates.Add(new Coordinate(1, 0));
            boatList[1].BoatCoordinates.Add(new Coordinate(1, 1));
            boatList[2].BoatCoordinates.Add(new Coordinate(2, 0));
            boatList[2].BoatCoordinates.Add(new Coordinate(2, 1));
            boatList[2].BoatCoordinates.Add(new Coordinate(2, 2));

            foreach (var boat in boatList)
            {
                boat.BoatCoordinates = boat.BoatCoordinates.Distinct().ToList();
            }

            // Update the game grid
            GameGrid.UpdateGameGridWithBoats(gameGrid, boatList);

            // Generate and test output
            var updatedGrid = ConsolePrints.UpdatesWithBoatGridPrint(gameGrid);
            Console.WriteLine("Updated Grid:");
            Console.WriteLine(updatedGrid);

            var expected = string.Join(Environment.NewLine, new[]
            {
                "S,B || M,B || L,B || 3,0 || 4,0 || 5,0 || 6,0 || 7,0 || 8,0 || 9,0",
                "0,1 || M,B || L,B || 3,1 || 4,1 || 5,1 || 6,1 || 7,1 || 8,1 || 9,1",
                "0,2 || 1,2 || L,B || 3,2 || 4,2 || 5,2 || 6,2 || 7,2 || 8,2 || 9,2",
                "0,3 || 1,3 || 2,3 || 3,3 || 4,3 || 5,3 || 6,3 || 7,3 || 8,3 || 9,3",
                "0,4 || 1,4 || 2,4 || 3,4 || 4,4 || 5,4 || 6,4 || 7,4 || 8,4 || 9,4",
                "0,5 || 1,5 || 2,5 || 3,5 || 4,5 || 5,5 || 6,5 || 7,5 || 8,5 || 9,5",
                "0,6 || 1,6 || 2,6 || 3,6 || 4,6 || 5,6 || 6,6 || 7,6 || 8,6 || 9,6",
                "0,7 || 1,7 || 2,7 || 3,7 || 4,7 || 5,7 || 6,7 || 7,7 || 8,7 || 9,7",
                "0,8 || 1,8 || 2,8 || 3,8 || 4,8 || 5,8 || 6,8 || 7,8 || 8,8 || 9,8",
                "0,9 || 1,9 || 2,9 || 3,9 || 4,9 || 5,9 || 6,9 || 7,9 || 8,9 || 9,9",
            });

            var normalizedUpdatedGrid = updatedGrid.Replace("\r\n", "\n").Trim();
            var normalizedExpected = expected.Replace("\r\n", "\n").Trim();

            Assert.That(normalizedUpdatedGrid, Is.EqualTo(normalizedExpected));
        }


        [Test]
        public void CheckBoatListPrinterPrintsCorrectly()
        {
            var smallBoat = new Boat("Small");
            smallBoat.BoatCoordinates.Add(new Coordinate(1, 1));

            var mediumBoat = new Boat("Medium");
            mediumBoat.BoatCoordinates.Add(new Coordinate(2, 2));
            mediumBoat.BoatCoordinates.Add(new Coordinate(2, 3));

            var largeBoat = new Boat("Large");
            largeBoat.BoatCoordinates.Add(new Coordinate(3, 3));
            largeBoat.BoatCoordinates.Add(new Coordinate(3, 4));
            largeBoat.BoatCoordinates.Add(new Coordinate(3, 5));

            var boatList = new List<Boat>
            {
                smallBoat,
                mediumBoat,
                largeBoat
            };

            var result = ConsolePrints.PrintBoatList(boatList);
            
            string expectedResult = Environment.NewLine +
                        "---" + Environment.NewLine +
                        "Saved in the boatList is:" + Environment.NewLine +
                        "    Small: Coord 1 = (1, 1)" + Environment.NewLine +
                        "    Medium: Coord 1 = (2, 2), Coord 2 = (2, 3)" + Environment.NewLine +
                        "    Large: Coord 1 = (3, 3), Coord 2 = (3, 4), Coord 3 = (3, 5)" + Environment.NewLine +
                        "---";

            Assert.That(result, Is.EqualTo(expectedResult).Using((System.Collections.IComparer)StringComparer.Ordinal), "The generated string does not match the expected format.");
        }
    }
}
