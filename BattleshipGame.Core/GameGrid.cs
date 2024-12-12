using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleshipGame.Core
{
    public class GameGrid
    {
        public int Width { get; }
        public int Height { get; }
        public List<(int, int)> GridCoordinates { get; } = new();
        public GameGrid(int width = 10, int height = 10)
        {
            Width = width;
            Height = height;

            // Populate the grid coordinates
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    GridCoordinates.Add((x, y));
                }
            }
        }
    }
}