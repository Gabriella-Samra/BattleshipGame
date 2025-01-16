using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleshipGame.Core
{
    /// <summary>
    /// Represents a coordinate on the game grid with an associated boat code.
    /// </summary>
    public class StringCoordinate : Coordinate
    {
        /// <summary>
        /// Gets the code representing the boat assigned to this coordinate.
        /// </summary>
        public string BoatCode { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="StringCoordinate"/> class.
        /// </summary>
        /// <param name="x">The X-coordinate of the grid position.</param>
        /// <param name="y">The Y-coordinate of the grid position.</param>
        /// <param name="boatCode">The code representing the boat at this coordinate.</param>
        public StringCoordinate(int x, int y, string boatCode) : base(x, y)
        {
            BoatCode = boatCode;
        }

        /// <summary>
        /// Returns a string representation of the coordinate, including the boat code.
        /// </summary>
        /// <returns>A string in the format "BoatCode (X, Y)".</returns>
        public override string ToString()
        {
            return $"{BoatCode} ({X}, {Y})";
        }
    }
}