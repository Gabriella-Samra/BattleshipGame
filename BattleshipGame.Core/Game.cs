using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

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

        // TODO: Need to assign Coordindates that are next to each other only when within a boat.

        public static (int, int) AddAdditionalCoordinatesToBoats((int, int) starterCoordinate, List<Boat> boatList, GameGrid gameGrid)
        {

        // TODO: Could refactor the below to use a Dictionary instead to make it more concise and then wrap the 2 checks in a foreach loop around all the options in the dictionary

            (int, int) leftMovingXCoordinate = (starterCoordinate.Item1 - 1, starterCoordinate.Item2);

            (int, int) rightMovingXCoordinate = (starterCoordinate.Item1 + 1, starterCoordinate.Item2);

            (int, int) upMovingYCoordinate = (starterCoordinate.Item1, starterCoordinate.Item2 - 1);

            (int, int) downMovingYCoordinate = (starterCoordinate.Item1, starterCoordinate.Item2 + 1);

            var LeftPath = !Boat.IsCoordinateAssigned(boatList, leftMovingXCoordinate); // if the coord is assigned then this is true then flipped to false
            var RightPath = !Boat.IsCoordinateAssigned(boatList, rightMovingXCoordinate);
            var UpPath = !Boat.IsCoordinateAssigned(boatList, upMovingYCoordinate);
            var DownPath = !Boat.IsCoordinateAssigned(boatList, downMovingYCoordinate);

            if (GameGrid.IsCoordinatesOnGrid(leftMovingXCoordinate, gameGrid) == false) LeftPath = false;
            if (GameGrid.IsCoordinatesOnGrid(rightMovingXCoordinate, gameGrid) == false) RightPath = false;
            if (GameGrid.IsCoordinatesOnGrid(upMovingYCoordinate, gameGrid) == false) UpPath = false;
            if (GameGrid.IsCoordinatesOnGrid(downMovingYCoordinate, gameGrid) == false) DownPath = false;

            List<string> availablePaths = new List<string>();

            if (LeftPath == true) availablePaths.Add("LeftPath");
            if (RightPath == true) availablePaths.Add("RightPath");
            if (UpPath == true) availablePaths.Add("UpPath");
            if (DownPath == true) availablePaths.Add("DownPath");

            if (availablePaths.Count == 0)
            {
                return (-1, -1); // returning a negative coord means a new starter coord needs to be rolled for
            }
            else if (availablePaths.Count == 1)
            {
                var chosenPath = availablePaths[1];

                return chosenPath switch
                {
                    "LeftPath" => leftMovingXCoordinate,
                    "RightPath" => rightMovingXCoordinate,
                    "UpPath" => upMovingYCoordinate,
                    "DownPath" => downMovingYCoordinate,
                    _ => (-1, -1)
                };
            }
            else
            {
                Random random = new Random();
                string chosenPath = availablePaths[random.Next(availablePaths.Count)];

                return chosenPath switch
                {
                    "LeftPath" => leftMovingXCoordinate,
                    "RightPath" => rightMovingXCoordinate,
                    "UpPath" => upMovingYCoordinate,
                    "DownPath" => downMovingYCoordinate,
                    _ => (-1, -1)
                };
            }
        }
    }
}