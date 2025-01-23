using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleshipGame.Core
{
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

        /// <summary>Initialises a new instance of the Coordinate Component Positions class by getting and setting the individual parts of (X,Y) values for a Coordinate</summary>
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