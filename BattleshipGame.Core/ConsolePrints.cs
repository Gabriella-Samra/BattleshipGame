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
            .Select(coord => $"{coord.Item1},{coord.Item2}"));
            
            // refactor the below to wrap in a method that repeats itself till we have all printed

            result += "\n";
            result += string.Join(" || ", gameGrid.GridCoordinates

            .Skip(10)
            .Take(10)
            .Select(coord => $"{coord.Item1},{coord.Item2}"));

            result += "\n";
            result += string.Join(" || ", gameGrid.GridCoordinates
            
            .Skip(20)
            .Take(10)
            .Select(coord => $"{coord.Item1},{coord.Item2}"));

            result += "\n";
            result += string.Join(" || ", gameGrid.GridCoordinates
            
            .Skip(30)
            .Take(10)
            .Select(coord => $"{coord.Item1},{coord.Item2}"));

            result += "\n";
            result += string.Join(" || ", gameGrid.GridCoordinates
            
            .Skip(40)
            .Take(10)
            .Select(coord => $"{coord.Item1},{coord.Item2}"));

            result += "\n";
            result += string.Join(" || ", gameGrid.GridCoordinates
            
            .Skip(50)
            .Take(10)
            .Select(coord => $"{coord.Item1},{coord.Item2}"));

            result += "\n";
            result += string.Join(" || ", gameGrid.GridCoordinates
            
            .Skip(60)
            .Take(10)
            .Select(coord => $"{coord.Item1},{coord.Item2}"));

            result += "\n";
            result += string.Join(" || ", gameGrid.GridCoordinates
            
            .Skip(70)
            .Take(10)
            .Select(coord => $"{coord.Item1},{coord.Item2}"));

            result += "\n";
            result += string.Join(" || ", gameGrid.GridCoordinates
            
            .Skip(80)
            .Take(10)
            .Select(coord => $"{coord.Item1},{coord.Item2}"));

            result += "\n";
            result += string.Join(" || ", gameGrid.GridCoordinates
            
            .Skip(90)
            .Take(10)
            .Select(coord => $"{coord.Item1},{coord.Item2}"));

            return result;
        }


    }
}