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
        public List<Coordinate> BoatCoordinates { get; set; } = new List<Coordinate>();

        public int BoatLength()
        {
            if (make == "Large")
            {
                return 3;
            }

            if (make == "Medium")
            {
                return 2;
            }

            if (make == "Small")
            {
                return 1;
            }

            return 0;
        }

        public static Boat? FindBoatByMake(List<Boat> boatList, string make)
        {
            return boatList.Find(boat => boat.Make == make);
        }


        public static bool IsCoordinateAssigned(List<Boat> boatList, Coordinate coordinate)
        {
            foreach (var boat in boatList)
            {
                var match = boat.BoatCoordinates.Find(coordinateInList => coordinateInList.X == coordinate.X && coordinateInList.Y == coordinate.Y);
                if (match != null)
                {
                    return true;
                }
            }
            return false;
        }

        public static Coordinate ReceiveACheckedAssignedCoordinate(GameGrid gameGrid, List<Boat> boatList, Coordinate starterCoordinate)
        {
            while (Boat.IsCoordinateAssigned(boatList, starterCoordinate))
            {
                starterCoordinate = Coordinate.GenerateCoorindate(gameGrid);
            }
            return starterCoordinate;
        }
    }
}