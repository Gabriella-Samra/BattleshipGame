using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace BattleshipGame.Core
{
    /// <summary>
    /// A instance of a game to play.
    /// </summary>
    public class Game
    {
        /// <summary>Initilises the game with all the starting items the game needs to be played.</summary>
        public void GameInitialiser()
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
            GameGrid.UpdateGameGridWithBoats(gameGrid, boatList);
            Console.WriteLine($"{ConsolePrints.UpdatesWithBoatGridPrint(gameGrid)}");

            gameGrid = PlayerGuess.PlayerGuessRequestLoop(gameGrid, boatList);
            Console.WriteLine($"{ConsolePrints.UpdatesWithBoatGridPrint(gameGrid)}");
        }
        
        /// <summary>The starter method for setting coordinates for all 3 boats that belong to the computer. 1 coord for small, 2 for medium, and 3 for large boats.</summary>
        /// <param name="gameGrid">An instance of the game grid with all the X and Y Coordinates set.</param>
        /// <param name="boatList">An instance of all 3 boats set. In this case no coordinates for the boats would be set yet.</param>
        public void CoordinateAssignmentForComputerBoats(GameGrid gameGrid, List<Boat> boatList)
        {
            foreach(var boat in boatList)
            {
                var numberOfCoordinatesStillNeeded = boat.BoatLength();
                CoordinateAssignmentLoop(gameGrid, boatList, numberOfCoordinatesStillNeeded,  boat);
            }

            Console.WriteLine($"{ConsolePrints.PrintBoatList(boatList)}");
        }

        /// <summary>
        /// Assigns coordinates for all 3 boats that belong to the computer. 1 coord for small, 2 for medium, and 3 for large boats. 
        /// First assigns the starter coord via the generate starter coordinate method and then it assigns the reminder of coordinates to the boat using the RemainderCoordinatesGenerator method if more coords are needed.
        /// </summary>
        /// <param name="gameGrid">An instance of the game grid with all the X and Y Coordinates set.</param>
        /// <param name="boatList">An instance of all 3 boats set. In this case no coordinates for the boats would be set yet.</param>
        /// <param name="numberOfCoordinatesStillNeeded">By looking at the length of the boat (i.e the number of coords needed for that boat), this figure is used to determine how many coords are still needed to be assigned to the boat's coordinate list.</param>
        /// <param name="boat">An instance a specific boat which can be small, medium, or large.</param>
        public void CoordinateAssignmentLoop(GameGrid gameGrid, List<Boat> boatList, int numberOfCoordinatesStillNeeded, Boat boat)
        {
            string pathDirection = "";
            var checkedStarterCoordinate = GenerateStarterCoordinate(gameGrid, boatList, boat);
            numberOfCoordinatesStillNeeded --;
            RemainderCoordinatesGenerator(gameGrid, boatList, boat, checkedStarterCoordinate, pathDirection, numberOfCoordinatesStillNeeded);
        }

        /// <summary>
        /// Assigns the first coordinate for the given boat by calling the GenerateCoordinate method. 
        /// The method then checks the coordinate is not assigned to another coordinate and if it is will cont. reassign the coord until a free coord is returned.
        /// The coord is then added to the specific boat's list of coords.
        /// </summary>
        /// <param name="gameGrid">An instance of the game grid with all the X and Y Coordinates set.</param>
        /// <param name="boatList">An instance of all 3 boats set. In this case no coordinates for the boats would be set yet.</param>
        /// <param name="boat">An instance a specific boat which can be small, medium, or large.</param>
        public Coordinate GenerateStarterCoordinate(GameGrid gameGrid, List<Boat> boatList, Boat boat)
        {         
            var starterCoordinate = Coordinate.GenerateCoorindate(gameGrid);
            var checkedStarterCoordinate = Boat.CheckAndOrReassignCoordinate(gameGrid, boatList, starterCoordinate);
            boat.BoatCoordinates.Add(checkedStarterCoordinate);
            return checkedStarterCoordinate;
        }

        /// <summary>
        /// Generate and assign the remainder of the coordinates to a boat if they are needed based on the number of coordinates variable. 
        /// If all possible paths are blocked for the sequential coordinates then the method will recall the CoordinateAssignmentLoop method to start assigning coords from the beginning again. 
        /// </summary>
        /// <param name="gameGrid">An instance of the game grid with all the X and Y Coordinates set.</param>
        /// <param name="boatList">An instance of all 3 boats set. In this case no coordinates for the boats would be set yet.</param>
        /// <param name="starterCoordinate">The chosen intial Coordinate that has been checked that it is not assigned to another boat and that it is on the gameGrid.</param>
        /// <param name="pathDirection">The direction the coordinates need to be set in. eg. if you have set the first 2 coordinates going left to right then the third coord should follow the same pattern.</param>
        /// <param name="numberOfCoordinatesStillNeeded">By looking at the length of the boat (i.e the number of coords needed for that boat), this figure is used to determine how many coords are still needed to be assigned to the boat's coordinate list.</param>
        /// <param name="boat">An instance a specific boat which can be small, medium, or large.</param>    
        public void RemainderCoordinatesGenerator(GameGrid gameGrid, List<Boat> boatList, Boat boat, Coordinate starterCoordinate, string pathDirection, int numberOfCoordinatesStillNeeded)
        {
            while (numberOfCoordinatesStillNeeded > 0)
            {
                var CoordinatesDto = BoatCoordinateAssigner.AddAdditionalCoordinatesToBoats(starterCoordinate, boatList, gameGrid, pathDirection);
                
                var xCoord = CoordinatesDto.Coordinate.X;
                var yCoord = CoordinatesDto.Coordinate.Y;
                pathDirection = CoordinatesDto.PathDirection;

                if (pathDirection == "no path")
                {
                    boat.BoatCoordinates.Clear();
                    numberOfCoordinatesStillNeeded = boat.BoatLength();
                    CoordinateAssignmentLoop(gameGrid, boatList, numberOfCoordinatesStillNeeded, boat);
                    return;
                }

                starterCoordinate = new Coordinate(xCoord, yCoord);
                boat.BoatCoordinates.Add(starterCoordinate);
                numberOfCoordinatesStillNeeded --;
            }
        }
    }
}