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

        // Override Equals to compare values instead of references
        /// <summary>
        /// Determines whether the specified object is equal to the current <see cref="Coordinate"/> instance.
        /// </summary>
        /// <param name="obj">The object to compare with the current coordinate.</param>
        /// <returns>
        /// <c>true</c> if the specified object is a <see cref="Coordinate"/> with the same X and Y values; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object? obj)
        {
            if (obj is Coordinate other)
            {
                return X == other.X && Y == other.Y;
            }
            return false;
        }

        // Override GetHashCode to ensure consistent hashing for identical coordinates
        /// <summary>
        /// Returns a hash code for the current <see cref="Coordinate"/> instance.
        /// </summary>
        /// <returns>
        /// A hash code that uniquely represents this coordinate.
        /// </returns>
        /// <remarks>
        /// This method ensures that two coordinates with the same X and Y values generate the same hash code,
        /// allowing proper functionality when used in collections like <see cref="HashSet{T}"/>.
        /// </remarks>
        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
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

        /// <summary>
        /// Parses a coordinate string and creates a <see cref="Coordinate"/> object from it.
        /// </summary>
        /// <param name="stringCoord">The coordinate string in the format "(X,Y)".</param>
        /// <returns>
        /// A <see cref="Coordinate"/> object with extracted X and Y values.
        /// </returns>
        public static Coordinate CreateCoordinateFromString(string stringCoord)
        {
            int commaPosition = -1;
            int openingBracketPosition = -1;
            int closingBracketPosition = -1;
            int xComponentPosition;
            int yComponentPosition;

            for (int i = 0; i < stringCoord.Length; i++)
            {
                if (stringCoord[i] == ',')
                {
                    commaPosition = i;
                }
                
                if (stringCoord[i] == '(')
                {
                    openingBracketPosition = i;
                }

                if (stringCoord[i] == ')')
                {
                    closingBracketPosition = i;
                }                
            }

            xComponentPosition = int.Parse(stringCoord[(openingBracketPosition + 1)..commaPosition]);
            yComponentPosition = int.Parse(stringCoord[(commaPosition + 1).. closingBracketPosition]);

            return new Coordinate(xComponentPosition, yComponentPosition);
        }
    }
}