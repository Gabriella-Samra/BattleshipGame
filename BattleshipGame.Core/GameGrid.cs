using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleshipGame.Core
{
    public class GameGrid(int width = 10, int height = 10)
    {
        public int Width { get; } = width;
        public int Height { get; } = height;
        public List<(int, int)> GridCoordinates { get; } = new List<(int, int)>();

        public List<(int ,int)> Coordinates(int gridXLength, int gridYLength)
        {
            for (int x = 0; x < gridXLength; x++)
            {
                for (int y = 0; y < gridYLength; y++)
                {
                    GridCoordinates.Add((x, y));
                }
            }
            return GridCoordinates;
        }
        
    }
}