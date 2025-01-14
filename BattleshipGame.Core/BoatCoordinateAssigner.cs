using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleshipGame.Core
{
    public class BoatCoordinateAssigner
    {
        public static BoatPathCoordinate AddAdditionalCoordinatesToBoats(Coordinate starterCoordinate, List<Boat> boatList, GameGrid gameGrid, string pathDirection)
        {
            return pathDirection switch
            {
                "LeftPath" => GetPathCoordinate(starterCoordinate, boatList, gameGrid, -1, 0, "LeftPath"),
                "RightPath" => GetPathCoordinate(starterCoordinate, boatList, gameGrid, 1, 0, "RightPath"),
                "UpPath" => GetPathCoordinate(starterCoordinate, boatList, gameGrid, 0, -1, "UpPath"),
                "DownPath" => GetPathCoordinate(starterCoordinate, boatList, gameGrid, 0, 1, "DownPath"),
                _ => GetAllPathsCoordinate(starterCoordinate, boatList, gameGrid)
            };
        }

        private static BoatPathCoordinate GetPathCoordinate(Coordinate starterCoordinate, List<Boat> boatList, GameGrid gameGrid, int xDiff, int yDiff, string pathDirection)
        {
            Coordinate newCoordinate = new Coordinate(starterCoordinate.X + xDiff, starterCoordinate.Y + yDiff);

            bool isPathValid = IsPathValid(newCoordinate, boatList, gameGrid);

            if (!isPathValid)
            {
                return new BoatPathCoordinate(new Coordinate(-1, -1), "no path");
            }

            return new BoatPathCoordinate(newCoordinate, pathDirection);
        }

        private static BoatPathCoordinate GetAllPathsCoordinate(Coordinate starterCoordinate, List<Boat> boatList, GameGrid gameGrid)
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
                var newCoordinate = new Coordinate(starterCoordinate.X + xDiff, starterCoordinate.Y + yDiff);

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