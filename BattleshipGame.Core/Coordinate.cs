using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleshipGame.Core
{
    /// <summary>The location for a grid position based on an X and Y location</summary>
    public class Coordinate
    {
        /// <summary>Gets or sets the x part of the coordinate</summary>
        public int X { get; set; }
        /// <summary>Gets or sets the y part of the coordinate</summary>
        public int Y { get; set; }

        /// <summary>Initialises a new instance of the Coordinate class by getting and setting the X and Y values for a Coordinate</summary>
        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>Generates random coordinates based on the width and height restrictions set by the game grid.</summary>
        /// <param name="gameGrid">An instance of the game grid with all the X and Y Coordinates set.</param>
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