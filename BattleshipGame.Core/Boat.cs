using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.WebSockets;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace BattleshipGame.Core
{
    public class Boat(string make)
    {        
        public string Make { get; set; } = make;
        public List<(int, int)> BoatCoordinates { get; set; } = new List<(int, int)>();

        public int BoatLength()
        {
            if(make == "Large")
            {
                return 3;
            }

            if(make == "Medium")
            {
                return 2;
            }

            if(make == "Small")
            {
                return 1;
            }

            return 0;
        }

        // public void SetBoatOnGrid(Boat boatInstance, GameGrid gameGrid)
        // {
        //     int numberOfCoordinatesNeeded = boatInstance.BoatLength();

        //     for(int i = 0; i < numberOfCoordinatesNeeded; i++)
        //     {
        //         GenerateCoorindates(boatInstance, gameGrid);
        //     }
        // }

        public static (int, int) GenerateCoorindates(GameGrid gameGrid)
        {
            // Random needs instanced data
            var random = new Random();

            int xCoordinate = random.Next(0, gameGrid.XAxis);
            int yCoordinate = random.Next(0, gameGrid.YAxis);
            (int, int) coordinate = (xCoordinate, yCoordinate) ;

            Console.WriteLine($"The x coord is {xCoordinate}, the y coord is {yCoordinate}");

            return coordinate;
        }

        public static bool IsCoordinateAlreadyAssigned(List<Boat> boatList, (int, int) startingCoordinate)
        {
            foreach (var boat in boatList)
            {
                if (boat.BoatCoordinates.Contains(startingCoordinate))
                {
                    return true;
                }
            }
            return false;
        }
    }
}