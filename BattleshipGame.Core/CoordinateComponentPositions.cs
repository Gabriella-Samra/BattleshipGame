using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleshipGame.Core
{
    /// <summary>
    /// Represents the component positions of a coordinate string in the format "(X,Y)".
    /// </summary>
    public class CoordinateComponentPositions
    {
        /// <summary>Gets or sets the x part of the coordinate</summary>
        public int X { get; set; }
        /// <summary>Gets or sets the y part of the coordinate</summary>
        public int Y { get; set; }
        /// <summary>Gets or sets the Opening Bracket Position part of the coordinate</summary>
        public int OpeningBracketPosition { get; set; }
        /// <summary>Gets or sets the Closing Bracket Position part of the coordinate</summary>
        public int ClosingBracketPosition { get; set; }
        /// <summary>Gets or sets the Comma Position part of the coordinate</summary>
        public int CommaPosition { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CoordinateComponentPositions"/> class.
        /// </summary>
        /// <param name="x">The x-coordinate value.</param>
        /// <param name="y">The y-coordinate value.</param>
        /// <param name="openingBracketPosition">The position of the opening bracket.</param>
        /// <param name="closingBracketPosition">The position of the closing bracket.</param>
        /// <param name="commaPosition">The position of the comma.</param>
        public CoordinateComponentPositions(int x, int y, int openingBracketPosition, int closingBracketPosition, int commaPosition)
        {
            X = x;
            Y = y;
            OpeningBracketPosition = openingBracketPosition;
            ClosingBracketPosition = closingBracketPosition;
            CommaPosition = commaPosition;
        }
    }
}