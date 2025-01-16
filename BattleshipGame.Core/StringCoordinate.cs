using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleshipGame.Core
{
    public class StringCoordinate : Coordinate
{
    public string BoatCode { get; }

    public StringCoordinate(int x, int y, string boatCode) : base(x, y)
    {
        BoatCode = boatCode;
    }

    public override string ToString()
    {
        return $"{BoatCode} ({X}, {Y})";
    }
}

}