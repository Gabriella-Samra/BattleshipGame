using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleshipGame.Core
{
    /// <summary>Methods to assigning the next Coordinate needed based on the path taken for the previous Coordinates</summary>
    public class BoatCoordinateAssigner
    {
        /// <summary>Looking at the path direction supplied, the correct method is called to assign the remaining Coordinates needed.</summary>
        /// <param name="lastCoordinate">The last Coordinate assigned to the boat to make sure the next coordinate is assigned only 1 grid spot away.</param>
        /// <param name="boatList">An instance of all the boats assigned to the list.</param>
        /// <param name="gameGrid">An instance of the game grid with all the X and Y Coordinates set.</param>
        /// <param name="pathDirection">The direction that was taken by the last Coordinate that was set for the boat</param>
        /// <returns>A combination of a Coordinate and a PathDirection is returned.</returns>
        public static BoatPathCoordinate AddAdditionalCoordinatesToBoats(Coordinate lastCoordinate, List<Boat> boatList, GameGrid gameGrid, string pathDirection)
        {
            return pathDirection switch
            {
                "LeftPath" => GetPathCoordinate(lastCoordinate, boatList, gameGrid, -1, 0, "LeftPath"),
                "RightPath" => GetPathCoordinate(lastCoordinate, boatList, gameGrid, 1, 0, "RightPath"),
                "UpPath" => GetPathCoordinate(lastCoordinate, boatList, gameGrid, 0, -1, "UpPath"),
                "DownPath" => GetPathCoordinate(lastCoordinate, boatList, gameGrid, 0, 1, "DownPath"),
                _ => GetAllPathsCoordinate(lastCoordinate, boatList, gameGrid)
            };
        }
        
        /// <summary>
        /// Based on the path Direction, a new coordinate is generated taking into account the difference from the given coordinate
        /// </summary>
        /// <param name="givenCoordinate">The Coordinate used to determine what the next Coordinate should be.</param>
        /// <param name="boatList">An instance of all the boats assigned to the list.</param>
        /// <param name="gameGrid">An instance of the game grid with all the X and Y Coordinates set.</param>
        /// <param name="xDiff">The difference between the givenCoordinates X coordinate and what the path would dictate would be the new Coordinate's x coord.</param>
        /// <param name="yDiff">The difference between the givenCoordinates y coordinate and what the path would dictate would be the new Coordinate's y coord.</param>
        /// <param name="pathDirection">The direction that was taken by the last Coordinate that was set for the boat</param>
        /// <returns>A combination of a Coordinate and a PathDirection is returned.</returns>
        private static BoatPathCoordinate GetPathCoordinate(Coordinate givenCoordinate, List<Boat> boatList, GameGrid gameGrid, int xDiff, int yDiff, string pathDirection)
        {
            Coordinate newCoordinate = new Coordinate(givenCoordinate.X + xDiff, givenCoordinate.Y + yDiff);

            bool isPathValid = IsPathValid(newCoordinate, boatList, gameGrid);

            if (!isPathValid)
            {
                return new BoatPathCoordinate(new Coordinate(-1, -1), "no path");
            }

            return new BoatPathCoordinate(newCoordinate, pathDirection);
        }

        /// <summary>
        /// A random selection between the four different path directions (left, right, up, or down) based on if the new Coordinate for each direction is on the grid and not already assigned to another boat.
        /// </summary>
        /// <param name="givenCoordinate">The Coordinate used to determine what the next Coordinate should be.</param>
        /// <param name="boatList">An instance of all the boats assigned to the list.</param>
        /// <param name="gameGrid">An instance of the game grid with all the X and Y Coordinates set.</param>
        /// <returns>A combination of a Coordinate and a PathDirection is returned.</returns>
        private static BoatPathCoordinate GetAllPathsCoordinate(Coordinate givenCoordinate, List<Boat> boatList, GameGrid gameGrid)
        {
            var pathDirections = new Dictionary<string, (int xDiff, int yDiff)>
            {
                { "LeftPath", (-1, 0) },
                { "RightPath", (1, 0) },
                { "UpPath", (0, -1) },
                { "DownPath", (0, 1) }
            };

            List<string> availablePaths = new List<string>();
            Dictionary<string, Coordinate> validCoordinates = new Dictionary<string, Coordinate>();

            foreach (var path in pathDirections)
            {
                var (xDiff, yDiff) = path.Value;
                var newCoordinate = new Coordinate(givenCoordinate.X + xDiff, givenCoordinate.Y + yDiff);

                if (IsPathValid(newCoordinate, boatList, gameGrid))
                {
                    availablePaths.Add(path.Key);
                    validCoordinates[path.Key] = newCoordinate;
                }
            }

            if (availablePaths.Count == 0)
            {
                return new BoatPathCoordinate(new Coordinate(-1, -1), "no path");
            }
            else if (availablePaths.Count == 1)
            {
                string chosenPath = availablePaths[0];
                return new BoatPathCoordinate(validCoordinates[chosenPath], chosenPath);
            }
            else
            {
                Random random = new Random();
                string chosenPath = availablePaths[random.Next(availablePaths.Count)];
                return new BoatPathCoordinate(validCoordinates[chosenPath], chosenPath);
            }
        }

        /// <summary>
        /// Checks to see if the given coordinate is already assigned to a boat already in the list and or if the boat is within the bounds of the gameGrid
        /// </summary>
        /// <param name="coordinate">The Coordinate used to determine what the next Coordinate should be.</param>
        /// <param name="boatList">An instance of all the boats assigned to the list.</param>
        /// <param name="gameGrid">An instance of the game grid with all the X and Y Coordinates set.</param>
        /// <returns>A combination of a Coordinate and a PathDirection is returned.</returns>
        /// <returns>A boolean of false is returned if the given coordinate is not on the grid. Returns false if the coordinate is already assigned to a boat.</returns>
        private static bool IsPathValid(Coordinate coordinate, List<Boat> boatList, GameGrid gameGrid)
        {
            if (!GameGrid.IsCoordinatesOnGrid(coordinate, gameGrid))
            {
                return false;
            }

            return !Boat.IsCoordinateAssigned(boatList, coordinate);
        }
    }
}