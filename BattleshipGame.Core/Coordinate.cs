using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleshipGame.Core
{
    public class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Coordinate GenerateCoorindate(GameGrid gameGrid)
        {
            // Random needs instanced data
            var random = new Random();

            int xCoordinate = random.Next(0, gameGrid.XAxis);
            int yCoordinate = random.Next(0, gameGrid.YAxis);
            
            return new Coordinate(xCoordinate, yCoordinate);
        }
    }
}