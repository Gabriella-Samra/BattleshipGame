using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleshipGame.Core
{
    /// <summary>Represents a instance of a game grid.</summary>
    public class GameGrid
    {
        /// <summary>Gets the length of the width of the grid.</summary>
        public int XAxis { get; }
        /// <summary>Gets the height of the width of the grid.</summary>
        public int YAxis { get; }
        /// <summary>Gets all the combinations of (x, y) Coordinates stored in a list</summary>
        public List<Coordinate> GridCoordinates { get; } = new();

        /// <summary>Intialises a new instance of GameGrid</summary>
        /// <param name="width">The width of the grid. Set to 10 in the constructor.</param>
        /// <param name="height">The height of the grid. Set to 10 in the constructor.</param>
        public GameGrid(int width = 10, int height = 10)
        {
            XAxis = width;
            YAxis = height;

            // Populate the grid coordinates
            for (int y = 0; y < YAxis; y++)
            {
                for (int x = 0; x < XAxis; x++)
                {
                    GridCoordinates.Add(new Coordinate(x, y));
                }
            }
        }

        ///<summary>Checks if the supplied Coordinate is within the bounds of the supplier gameGrid</summary>
        ///<param name="coordinate">A given coordinate to check if it is on the gameGrid.</param>
        ///<param name="gameGrid">An instance of a gameGrid with set x and y axis lengths</param>
        ///<returns>A boolean of false if either the x or y part of the coordinate is not within the confines of the gameGrid. True if the coordinate is within the bounds of the GameGrid.</returns>
        public static bool IsCoordinatesOnGrid(Coordinate coordinate, GameGrid gameGrid)
        {
            if (coordinate.X < 0 || coordinate.X >= gameGrid.XAxis )
            {
                return false;
            }

            if (coordinate.Y < 0 || coordinate.Y >= gameGrid.YAxis)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Updates the given gameGrid based on boat coordinate locations. The location on the grid is replaced with initials of the boat eg. Small boat will show SB, Medium will show MB etc. 
        /// </summary>
        /// <returns>A GameGrid which has been updated to show the location of boats based on the boatList passed in.</returns>
        public static GameGrid UpdateGameGridWithBoats(GameGrid gameGrid, List<Boat> boatList)
        {
            foreach (var boat in boatList)
            {
                string boatCode = boat.Make switch
                {
                    "Small" => "S,B",
                    "Medium" => "M,B",
                    "Large" => "L,B",
                    _ => "--" // Default case if the boat's make is unknown
                };

                foreach (var boatCoordinate in boat.BoatCoordinates)
                {
                    int index = gameGrid.GridCoordinates.FindIndex(gridCoord => gridCoord.X == boatCoordinate.X && gridCoord.Y == boatCoordinate.Y);

                    if (index != -1) // Coordinate found
                    {
                        gameGrid.GridCoordinates[index] = new StringCoordinate(boatCoordinate.X, boatCoordinate.Y, boatCode);
                    }
                }
            }

            return gameGrid;
        }

        public static GameGrid UpdateGameGridWithHits(GameGrid gameGrid, Coordinate coordThatIsAHit)
        {
            
            int index = gameGrid.GridCoordinates.FindIndex(gridCoord => gridCoord.X == coordThatIsAHit.X && gridCoord.Y == coordThatIsAHit.Y);

            if (index != -1) // Coordinate found
            {
                gameGrid.GridCoordinates[index] = new StringCoordinate(coordThatIsAHit.X, coordThatIsAHit.Y, " X ");
            }
            
            return gameGrid;
        }
    }
}