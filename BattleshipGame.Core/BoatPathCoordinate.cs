using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleshipGame.Core
{
    /// <summary>
    /// A combination of a Coordinate and a path direction
    /// </summary>
    public class BoatPathCoordinate
    {
        /// <summary>Get or set a new instance of a Coordinate.</summary>
        public Coordinate Coordinate { get; set; }
        /// <summary>Get or set the path direction</summary>
        public string PathDirection { get; set; }

        /// <summary>
        /// Initialises a new instance of a combination of a Coordinate and a path direction.
        /// </summary>
        /// <param name="coordinate">An instance of a Coordinate.</param>
        /// <param name="pathDirection">The path direction.</param>
        public BoatPathCoordinate(Coordinate coordinate, string pathDirection)
        {
            Coordinate = coordinate;
            PathDirection = pathDirection;
        }
    }
}