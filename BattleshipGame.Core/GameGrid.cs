using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleshipGame.Core
{
    public class GameGrid
    {
        public int XAxis { get; }
        public int YAxis { get; }
        public List<Coordinate> GridCoordinates { get; } = new();
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

        public static bool IsCoordinatesOnGrid(Coordinate coordinates, GameGrid gameGrid)
        {
            if (coordinates.X < 0 || coordinates.X > gameGrid.XAxis )
            {
                return false;
            }

            if (coordinates.Y < 0 || coordinates.Y > gameGrid.YAxis)
            {
                return false;
            }

            return true;
        }
    }
}