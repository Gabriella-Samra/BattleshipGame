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
        
    // TODO: Code is not finished. Currently we get to knowing where all the paths lead but we need to know which path to take. 
    // TODO: Huge refactor needed of this code from here! Remove the repetative stuff. Create separate methods for things.
    // TODO: Consider boat size logic in the refactoring so it isn't a separate set of instructions for each but rather look at the number of coordinates needed to make a decision
    // TODO: Make a new class where a lot of these coordinate methods move to as they don't belong here OR add to Boat.cs as there are coordinate stuff there already
        public static void CoordinateAssignmentForComputerBoats(GameGrid gameGrid, List<Boat> boatList)
        {
            // -- Small Boat Logic
            var starterCoordinate = Boat.GenerateCoorindates(gameGrid);
            
            while (Boat.IsCoordinateNotAlreadyAssigned(boatList, starterCoordinate))
            {
                starterCoordinate = Boat.GenerateCoorindates(gameGrid);
            }

            var smallBoat = boatList.Find(boat => boat.Make == "Small");

            if (smallBoat != null)
            {
                smallBoat.BoatCoordinates.Add(starterCoordinate);
            }

            // -- Medium Boat Logic

            starterCoordinate = Boat.GenerateCoorindates(gameGrid);

            while (Boat.IsCoordinateNotAlreadyAssigned(boatList, starterCoordinate))
            {
                starterCoordinate = Boat.GenerateCoorindates(gameGrid);
            }

            var mediumBoat = boatList.Find(boat => boat.Make == "Medium");

            if (mediumBoat != null)
            {
                mediumBoat.BoatCoordinates.Add(starterCoordinate);
            }

            int numberOfCoordinatesStillNeeded = mediumBoat.BoatLength() - 1;

            if (numberOfCoordinatesStillNeeded > 0)
            {

            }


            // -- Large Boat Logic - TD

        }

        public void AddAdditionalCoordinatesToBoats((int, int) starterCoordinate, List<Boat> boatList, GameGrid gameGrid)
        {
            (int, int) leftMovingXCoordinate = (starterCoordinate.Item1 - 1, starterCoordinate.Item2);

            (int, int) rightMovingXCoordinate = (starterCoordinate.Item1 + 1, starterCoordinate.Item2);

            (int, int) upMovingYCoordinate = (starterCoordinate.Item1, starterCoordinate.Item2 - 1);

            (int, int) bottomMovingYCoordinate = (starterCoordinate.Item1, starterCoordinate.Item2 + 1);

            var LeftPath = Boat.IsCoordinateNotAlreadyAssigned(boatList, leftMovingXCoordinate);
            var RightPath = Boat.IsCoordinateNotAlreadyAssigned(boatList, rightMovingXCoordinate);
            var UpPath = Boat.IsCoordinateNotAlreadyAssigned(boatList, upMovingYCoordinate);
            var DownPath = Boat.IsCoordinateNotAlreadyAssigned(boatList, bottomMovingYCoordinate);

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