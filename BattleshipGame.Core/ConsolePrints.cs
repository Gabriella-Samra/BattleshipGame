using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace BattleshipGame.Core
{
    public class ConsolePrints
    {
        public static string InitialGridPrint(GameGrid gameGrid)
        {
            string result = string.Join(" || ", gameGrid.GridCoordinates
            
            .Take(10)
            .Select(coord => $"{coord.X},{coord.Y}"));

            for (int i = 10; i < gameGrid.GridCoordinates.Count; i += 10)
            {
                result += Environment.NewLine;
                result += string.Join(" || ", gameGrid.GridCoordinates

                .Skip(i)
                .Take(10)
                .Select(coord => $"{coord.X},{coord.Y}"));
            }

            return result;
        }
    }
}