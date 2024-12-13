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
        public List<(int, int)> GridCoordinates { get; } = new();
        public GameGrid(int width = 10, int height = 10)
        {
            XAxis = width;
            YAxis = height;

            // Populate the grid coordinates
            for (int x = 0; x < XAxis; x++)
            {
                for (int y = 0; y < YAxis; y++)
                {
                    GridCoordinates.Add((x, y));
                }
            }
        }

        public static bool IsCoordinatesOnGrid((int, int) coordinates, GameGrid gameGrid)
        {
            if (coordinates.Item1 < 0 || coordinates.Item1 > gameGrid.XAxis )
            {
                return false;
            }

            if (coordinates.Item2 < 0 || coordinates.Item2 > gameGrid.YAxis)
            {
                return false;
            }

            return true;
        }
    }
}