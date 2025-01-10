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
            Console.WriteLine($"{Environment.NewLine}");
            CoordinateAssignmentForComputerBoats(gameGrid, boatList);
        }
        
        public void CoordinateAssignmentForComputerBoats(GameGrid gameGrid, List<Boat> boatList)
        {
            foreach(var boat in boatList)
            {
                var numberOfCoordinatesStillNeeded = boat.BoatLength();
                var loopCount = 0;
                CoordinateAssignmentLoop(gameGrid, boatList, numberOfCoordinatesStillNeeded, loopCount, boat);
            }

            Console.WriteLine($"{ConsolePrints.PrintBoatList(boatList)}");
        }

        public void CoordinateAssignmentLoop(GameGrid gameGrid, List<Boat> boatList, int numberOfCoordinatesStillNeeded, int loopCount, Boat boat)
        {
            string pathDirection = "";
            var checkedStarterCoordinate = GenerateStarterCoordinate(gameGrid, boatList, boat);
            numberOfCoordinatesStillNeeded --;
            RemainderCoordinatesGenerator(gameGrid, boatList, boat, checkedStarterCoordinate, pathDirection, numberOfCoordinatesStillNeeded - 1, loopCount + 1);
        }

        public Coordinate GenerateStarterCoordinate(GameGrid gameGrid, List<Boat> boatList, Boat boat)
        {         
            var starterCoordinate = Coordinate.GenerateCoorindate(gameGrid);
            var checkedStarterCoordinate = Boat.ReceiveACheckedAssignedCoordinate(gameGrid, boatList, starterCoordinate);
            boat.BoatCoordinates.Add(checkedStarterCoordinate);
            Console.WriteLine($"The Coordinate for {boat.Make} is ({checkedStarterCoordinate.X}, {checkedStarterCoordinate.Y})");
            return checkedStarterCoordinate;
        }
            
        public void RemainderCoordinatesGenerator(GameGrid gameGrid, List<Boat> boatList, Boat boat, Coordinate checkedStarterCoordinate, string pathDirection, 
            int numberOfCoordinatesStillNeeded, int loopCount)
        {
            while (numberOfCoordinatesStillNeeded > 0)
            {
                if(loopCount < 2)
                {
                    var CoordinatesDto = BoatCoordinateAssigner.AddAdditionalCoordinatesToBoats(checkedStarterCoordinate, boatList, gameGrid, pathDirection);

                    if (CoordinatesDto.PathDirection == "no path")
                    {
                        boat.BoatCoordinates.Clear();
                        loopCount = 0;           
                        numberOfCoordinatesStillNeeded = boat.BoatLength();
                        CoordinateAssignmentLoop(gameGrid, boatList, numberOfCoordinatesStillNeeded, loopCount, boat);
                        return;
                    }

                    else
                    {
                        var checkedStarterCoordinateItem1 = CoordinatesDto.Coordinate.X;
                        var checkedStarterCoordinateItem2 = CoordinatesDto.Coordinate.Y;
                        pathDirection = CoordinatesDto.PathDirection;
                        
                        checkedStarterCoordinate = new Coordinate(checkedStarterCoordinateItem1, checkedStarterCoordinateItem2);
                        boat.BoatCoordinates.Add(checkedStarterCoordinate);
                        numberOfCoordinatesStillNeeded --; // Removes 1 from the count
                        Console.WriteLine($"The Coordinate for {boat.Make} is ({checkedStarterCoordinate.X}, {checkedStarterCoordinate.Y}, the direction is {pathDirection})");
                    }
                }
                else
                {
                    var CoordinatesDto = BoatCoordinateAssigner.AddAdditionalCoordinatesToBoats(checkedStarterCoordinate, boatList, gameGrid, pathDirection);
                    var checkedStarterCoordinateItem1 = CoordinatesDto.Coordinate.X;
                    var checkedStarterCoordinateItem2 = CoordinatesDto.Coordinate.Y;
                    pathDirection = CoordinatesDto.PathDirection;

                    if (CoordinatesDto.PathDirection == "no path")
                    {
                        boat.BoatCoordinates.Clear();
                        loopCount = 0;           
                        numberOfCoordinatesStillNeeded = boat.BoatLength();
                        CoordinateAssignmentLoop(gameGrid, boatList, numberOfCoordinatesStillNeeded, loopCount, boat);
                    }

                    else
                    {
                        checkedStarterCoordinate = new Coordinate(checkedStarterCoordinateItem1, checkedStarterCoordinateItem2);
                        boat.BoatCoordinates.Add(checkedStarterCoordinate);
                        numberOfCoordinatesStillNeeded --; // Removes 1 from the count
                        Console.WriteLine($"The Coordinate for {boat.Make} is ({checkedStarterCoordinate.X}, {checkedStarterCoordinate.Y}, the direction is {pathDirection})");
                    }
                }

                loopCount ++;
            }
        }

        // TODO: Need to assign Coordindates that are next to each other only when within a boat.     
    }
}