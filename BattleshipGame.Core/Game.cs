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
        }
        
        public void CoordinateAssignmentForComputerBoats(GameGrid gameGrid, List<Boat> boatList)
        {
            foreach(var boat in boatList)
            {
                var numberOfCoordinatesStillNeeded = boat.BoatLength();
                CoordinateAssignmentLoop(gameGrid, boatList, numberOfCoordinatesStillNeeded,  boat);
            }

            Console.WriteLine($"{ConsolePrints.PrintBoatList(boatList)}");
        }

        public void CoordinateAssignmentLoop(GameGrid gameGrid, List<Boat> boatList, int numberOfCoordinatesStillNeeded, Boat boat)
        {
            string pathDirection = "";
            var checkedStarterCoordinate = GenerateStarterCoordinate(gameGrid, boatList, boat);
            numberOfCoordinatesStillNeeded --;
            RemainderCoordinatesGenerator(gameGrid, boatList, boat, checkedStarterCoordinate, pathDirection, numberOfCoordinatesStillNeeded);
        }

        public Coordinate GenerateStarterCoordinate(GameGrid gameGrid, List<Boat> boatList, Boat boat)
        {         
            var starterCoordinate = Coordinate.GenerateCoorindate(gameGrid);
            var checkedStarterCoordinate = Boat.ReceiveACheckedAssignedCoordinate(gameGrid, boatList, starterCoordinate);
            boat.BoatCoordinates.Add(checkedStarterCoordinate);
            return checkedStarterCoordinate;
        }
            
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