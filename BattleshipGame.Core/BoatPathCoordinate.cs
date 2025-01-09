using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleshipGame.Core
{
    public class BoatPathCoordinate
    {
        public Coordinate Coordinate { get; set; }
        public string PathDirection { get; set; }

        public BoatPathCoordinate(Coordinate coordinate, string pathDirection)
        {
            Coordinate = coordinate;
            PathDirection = pathDirection;
        }
    }
}