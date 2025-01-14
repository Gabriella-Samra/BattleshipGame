using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.WebSockets;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace BattleshipGame.Core
{
    /// <summary>Represents a boat in the game.</summary>
    /// <param name="make">The type of boat based on it's size. eg. Small, Medium, or Large.</param>
    public class Boat(string make)
    {
        /// <summary>Gets or sets the make of the boat</summary>
        public string Make { get; set; } = make;
        /// <summary>The list of Coordinates assigned to a given instance of a boat</summary>
        public List<Coordinate> BoatCoordinates { get; set; } = new List<Coordinate>();

        
        /// <summary>Finds the length of a boat based on the make of the boat</summary>
        /// <returns>An integer based on the make of the boat. eg. Small = 1.</returns>
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

        /// <summary> Based on the make provided as a pamater, the method will aim to find that boat in the list provided.</summary>
        /// <param name="boatList">An instance of all the boats add to the list.</param>
        /// <param name="make">The type of boat that is being searched for eg. Small</param>
        /// <returns>If the boat is found then that boat is returned. If that boat does not exist in the list then null is returned.</returns>
        public static Boat? FindBoatByMake(List<Boat> boatList, string make)
        {
            return boatList.Find(boat => boat.Make == make);
        }

        /// <summary>
        /// Checks to see if the given Coordinate has been assigned to any other boat that is in the boatList.
        /// </summary>
        /// <param name="boatList">An instance of all the boats add to the list.</param>
        /// <param name="coordinate">A given Coordinate to check if that coordinate has been assigned to any boat</param>
        /// <returns>A boolean that returns true if the coordinate has been assigned to another boat or false if it has not been assigned.</returns>
        public static bool IsCoordinateAssigned(List<Boat> boatList, Coordinate coordinate)
        {
            foreach (var boat in boatList)
            {
                var match = boat.BoatCoordinates.Find(coordinateInList => coordinateInList.X == coordinate.X && coordinateInList.Y == coordinate.Y);
                if (match != null) // if the coord is in the list then it is assigned to match. If match has an coord then return true
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Calls a method to see if the given Coordinate has been assigned to a boat or not. If it has been assign then it will generate a new coordinate continuously until it has a unassigned Coordinate.
        /// </summary>
        /// <param name="gameGrid">An instance of the game grid with all the X and Y Coordinates set.</param>
        /// <param name="boatList">An instance of all the boats add to the list.</param>
        /// <param name="starterCoordinate">A given coordinate that is wanted to be checked</param>
        /// <returns>A Coordinate that has been checked to not have been assigned to a boat already.</returns>
        public static Coordinate CheckAndOrReassignCoordinate(GameGrid gameGrid, List<Boat> boatList, Coordinate starterCoordinate)
        {
            while (Boat.IsCoordinateAssigned(boatList, starterCoordinate))
            {
                starterCoordinate = Coordinate.GenerateCoorindate(gameGrid);
            }
            return starterCoordinate;
        }
    }
}