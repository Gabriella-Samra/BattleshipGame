using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleshipGame.Core
{
    public class Game
    {
        public static void GameInitialiser()
        {
            Console.WriteLine("Game Starting...Grid Loading");
            var gameGrid = new GameGrid();
            var boatList = new List<Boat>{};

            var smallBoat = new Boat("Small");
            boatList.Add(smallBoat);
            var mediumBoat = new Boat("Medium");
            boatList.Add(mediumBoat);
            var largeBoat = new Boat("Large");
            boatList.Add(largeBoat);

            Console.WriteLine($"{ConsolePrints.InitialGridPrint(gameGrid)}");
            CoordinateAssignmentForComputerBoats(gameGrid, boatList);

        }
        
        public static void CoordinateAssignmentForComputerBoats(GameGrid gameGrid, List<Boat> boatList)
        {
            foreach(var boat in boatList)
            {
                var starterCoordinate = Boat.GenerateCoorindates(gameGrid);
                int numberOfCoordinatesStillNeeded = boat.BoatLength();

                while (numberOfCoordinatesStillNeeded > 0)
                {
                    var checkedStarterCoordinate = Boat.ReceiveACheckedCoordinate(gameGrid, boatList, starterCoordinate);
                    boat.BoatCoordinates.Add(checkedStarterCoordinate);
                    numberOfCoordinatesStillNeeded --; // Removes 1 from the count
                }
            }
        }

        public void AddAdditionalCoordinatesToBoats((int, int) starterCoordinate, List<Boat> boatList, GameGrid gameGrid)
        {
            (int, int) leftMovingXCoordinate = (starterCoordinate.Item1 - 1, starterCoordinate.Item2);

            (int, int) rightMovingXCoordinate = (starterCoordinate.Item1 + 1, starterCoordinate.Item2);

            (int, int) upMovingYCoordinate = (starterCoordinate.Item1, starterCoordinate.Item2 - 1);

            (int, int) bottomMovingYCoordinate = (starterCoordinate.Item1, starterCoordinate.Item2 + 1);

            var LeftPath = Boat.IsCoordinateAssigned(boatList, leftMovingXCoordinate);
            var RightPath = Boat.IsCoordinateAssigned(boatList, rightMovingXCoordinate);
            var UpPath = Boat.IsCoordinateAssigned(boatList, upMovingYCoordinate);
            var DownPath = Boat.IsCoordinateAssigned(boatList, bottomMovingYCoordinate);

            if (GameGrid.IsCoordinatesOnGrid(leftMovingXCoordinate, gameGrid) == false)
            {
                LeftPath = false;
            }

            if (GameGrid.IsCoordinatesOnGrid(rightMovingXCoordinate, gameGrid) == false)
            {
                RightPath = false;
            }

            if (GameGrid.IsCoordinatesOnGrid(upMovingYCoordinate, gameGrid) == false)
            {
                UpPath = false;
            }

            if (GameGrid.IsCoordinatesOnGrid(bottomMovingYCoordinate, gameGrid) == false)
            {
                DownPath = false;
            }

            // TODO: Finish the below.
            // if all are false then we need to go back and roll a new coordinate
            // if only 1 is true then that path is the chosen one
            // if 2 paths are true then random between the 2 options
            // if 3 paths are true then random between the 3 options
            // Repeat these checks for all needed coordinates for the boat

        }
    }
}