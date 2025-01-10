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

        public static string PrintBoatList(List<Boat> boatList)
        {
            string result = Environment.NewLine;
            result += "---";
            result += Environment.NewLine;
            result += "Saved in the boatList at the end of running the function is...";
            result += Environment.NewLine;

            for(int i = 0; i < boatList.Count; i ++)
            {
                string make = boatList[i].Make;
                result += $"    {make}: ";

                for (int j = 0; j < boatList[i].BoatCoordinates.Count; j++)
                {
                    var coord1 = boatList[i].BoatCoordinates[j].X;
                    var coord2 = boatList[i].BoatCoordinates[j].Y;

                    result += $"Coord {j+1} = ({coord1}, {coord2})";

                    if (j < boatList[i].BoatCoordinates.Count - 1)
                    {
                        result += ", ";
                    }
                }
                
                result += Environment.NewLine;
            }

            result = result.TrimEnd(',', ' ');

            result += "---";

            return result;
        }
    }
}