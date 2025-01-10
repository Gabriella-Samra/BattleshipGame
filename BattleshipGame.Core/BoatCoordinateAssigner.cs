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

            // TODO: Could refactor the below to use a Dictionary instead to make it more concise and then wrap the 2 checks in a foreach loop around all the options in the dictionary

            if (pathDirection == "LeftPath" || pathDirection == "RightPath")
            {
                return LeftRightPathsForAdditionalCoordinates(starterCoordinate, boatList, gameGrid);
            }

            else if (pathDirection == "UpPath" || pathDirection == "DownPath")
            {
                return UpDownForAdditionalCoordinates(starterCoordinate, boatList, gameGrid);
            }

            else
            {
                return AllPathsForAdditionalCoordinates(starterCoordinate, boatList, gameGrid);
            }
        }

        public static BoatPathCoordinate LeftRightPathsForAdditionalCoordinates(Coordinate starterCoordinate, List<Boat> boatList, GameGrid gameGrid)
        {
            Coordinate leftMovingXCoordinate = new Coordinate(starterCoordinate.X - 1, starterCoordinate.Y);

            Coordinate rightMovingXCoordinate = new Coordinate(starterCoordinate.X + 1, starterCoordinate.Y);

            var LeftPath = !Boat.IsCoordinateAssigned(boatList, leftMovingXCoordinate); // if the coord is assigned then this is true then flipped to false
            var RightPath = !Boat.IsCoordinateAssigned(boatList, rightMovingXCoordinate);

            if (GameGrid.IsCoordinatesOnGrid(leftMovingXCoordinate, gameGrid) == false) LeftPath = false;
            if (GameGrid.IsCoordinatesOnGrid(rightMovingXCoordinate, gameGrid) == false) RightPath = false;

            List<string> availablePaths = new List<string>();

            if (LeftPath == true) availablePaths.Add("LeftPath");
            if (RightPath == true) availablePaths.Add("RightPath");

            if (availablePaths.Count == 0)
            {
                return new BoatPathCoordinate(new Coordinate(-1, -1), "no path"); // returning a negative coord means a new starter coord needs to be rolled for
            }
            else if (availablePaths.Count == 1)
            {
                var chosenPath = availablePaths[0];

                return chosenPath switch
                {
                    "LeftPath" => new BoatPathCoordinate(new Coordinate(leftMovingXCoordinate.X, leftMovingXCoordinate.Y), "LeftPath"),
                    "RightPath" => new BoatPathCoordinate(new Coordinate(rightMovingXCoordinate.X, rightMovingXCoordinate.Y), "RightPath"),
                    _ => new BoatPathCoordinate(new Coordinate(-1, -1), "no path")
                };
            }
            else
            {
                Random random = new Random();
                string chosenPath = availablePaths[random.Next(availablePaths.Count)];

                return chosenPath switch
                {
                    "LeftPath" => new BoatPathCoordinate(new Coordinate(leftMovingXCoordinate.X, leftMovingXCoordinate.Y), "LeftPath"),
                    "RightPath" => new BoatPathCoordinate(new Coordinate(rightMovingXCoordinate.X, rightMovingXCoordinate.Y), "RightPath"),
                    _ => new BoatPathCoordinate(new Coordinate(-1, -1), "no path")
                };
            }
        }

        public static BoatPathCoordinate UpDownForAdditionalCoordinates(Coordinate starterCoordinate, List<Boat> boatList, GameGrid gameGrid)
        {
            Coordinate upMovingYCoordinate = new Coordinate(starterCoordinate.X, starterCoordinate.Y - 1);

            Coordinate downMovingYCoordinate = new Coordinate(starterCoordinate.X, starterCoordinate.Y + 1);

            var UpPath = !Boat.IsCoordinateAssigned(boatList, upMovingYCoordinate);
            var DownPath = !Boat.IsCoordinateAssigned(boatList, downMovingYCoordinate);

            if (GameGrid.IsCoordinatesOnGrid(upMovingYCoordinate, gameGrid) == false) UpPath = false;
            if (GameGrid.IsCoordinatesOnGrid(downMovingYCoordinate, gameGrid) == false) DownPath = false;

            List<string> availablePaths = new List<string>();

            if (UpPath == true) availablePaths.Add("UpPath");
            if (DownPath == true) availablePaths.Add("DownPath");

            if (availablePaths.Count == 0)
            {
                return new BoatPathCoordinate(new Coordinate(-1, -1), "no path"); // returning a negative coord means a new starter coord needs to be rolled for
            }
            else if (availablePaths.Count == 1)
            {
                var chosenPath = availablePaths[0];

                return chosenPath switch
                {
                    "UpPath" => new BoatPathCoordinate(new Coordinate(upMovingYCoordinate.X, upMovingYCoordinate.Y), "UpPath"),
                    "DownPath" => new BoatPathCoordinate(new Coordinate(downMovingYCoordinate.X, downMovingYCoordinate.Y), "DownPath"),
                    _ => new BoatPathCoordinate(new Coordinate(-1, -1), "no path")
                };
            }
            else
            {
                Random random = new Random();
                string chosenPath = availablePaths[random.Next(availablePaths.Count)];

                return chosenPath switch
                {
                    "UpPath" => new BoatPathCoordinate(new Coordinate(upMovingYCoordinate.X, upMovingYCoordinate.Y), "UpPath"),
                    "DownPath" => new BoatPathCoordinate(new Coordinate(downMovingYCoordinate.X, downMovingYCoordinate.Y), "DownPath"),
                    _ => new BoatPathCoordinate(new Coordinate(-1, -1), "no path")
                };
            }
        }

        public static BoatPathCoordinate AllPathsForAdditionalCoordinates(Coordinate starterCoordinate, List<Boat> boatList, GameGrid gameGrid)
        {
            Coordinate leftMovingXCoordinate = new Coordinate(starterCoordinate.X - 1, starterCoordinate.Y);

            Coordinate rightMovingXCoordinate = new Coordinate(starterCoordinate.X + 1, starterCoordinate.Y);

            Coordinate upMovingYCoordinate = new Coordinate(starterCoordinate.X, starterCoordinate.Y - 1);

            Coordinate downMovingYCoordinate = new Coordinate(starterCoordinate.X, starterCoordinate.Y + 1);

            var LeftPath = !Boat.IsCoordinateAssigned(boatList, leftMovingXCoordinate); // if the coord is assigned then this is true then flipped to false
            var RightPath = !Boat.IsCoordinateAssigned(boatList, rightMovingXCoordinate);
            var UpPath = !Boat.IsCoordinateAssigned(boatList, upMovingYCoordinate);
            var DownPath = !Boat.IsCoordinateAssigned(boatList, downMovingYCoordinate);

            if (GameGrid.IsCoordinatesOnGrid(leftMovingXCoordinate, gameGrid) == false) LeftPath = false;
            if (GameGrid.IsCoordinatesOnGrid(rightMovingXCoordinate, gameGrid) == false) RightPath = false;
            if (GameGrid.IsCoordinatesOnGrid(upMovingYCoordinate, gameGrid) == false) UpPath = false;
            if (GameGrid.IsCoordinatesOnGrid(downMovingYCoordinate, gameGrid) == false) DownPath = false;

            List<string> availablePaths = new List<string>();

            if (LeftPath == true) availablePaths.Add("LeftPath");
            if (RightPath == true) availablePaths.Add("RightPath");
            if (UpPath == true) availablePaths.Add("UpPath");
            if (DownPath == true) availablePaths.Add("DownPath");

            if (availablePaths.Count == 0)
            {
                return new BoatPathCoordinate(new Coordinate(-1, -1), "no path"); // returning a negative coord means a new starter coord needs to be rolled for
            }
            else if (availablePaths.Count == 1)
            {
                var chosenPath = availablePaths[0];

                return chosenPath switch
                {
                    "LeftPath" => new BoatPathCoordinate(new Coordinate(leftMovingXCoordinate.X, leftMovingXCoordinate.Y), "LeftPath"),
                    "RightPath" => new BoatPathCoordinate(new Coordinate(rightMovingXCoordinate.X, rightMovingXCoordinate.Y), "RightPath"),
                    "UpPath" => new BoatPathCoordinate(new Coordinate(upMovingYCoordinate.X, upMovingYCoordinate.Y), "UpPath"),
                    "DownPath" => new BoatPathCoordinate(new Coordinate(downMovingYCoordinate.X, downMovingYCoordinate.Y), "DownPath"),
                    _ => new BoatPathCoordinate(new Coordinate(-1, -1), "no path")
                };
            }
            else
            {
                Random random = new Random();
                string chosenPath = availablePaths[random.Next(availablePaths.Count)];

                return chosenPath switch
                {
                    "LeftPath" => new BoatPathCoordinate(new Coordinate(leftMovingXCoordinate.X, leftMovingXCoordinate.Y), "LeftPath"),
                    "RightPath" => new BoatPathCoordinate(new Coordinate(rightMovingXCoordinate.X, rightMovingXCoordinate.Y), "RightPath"),
                    "UpPath" => new BoatPathCoordinate(new Coordinate(upMovingYCoordinate.X, upMovingYCoordinate.Y), "UpPath"),
                    "DownPath" => new BoatPathCoordinate(new Coordinate(downMovingYCoordinate.X, downMovingYCoordinate.Y), "DownPath"),
                    _ => new BoatPathCoordinate(new Coordinate(-1, -1), "no path")
                };
            }
        }
    }
}