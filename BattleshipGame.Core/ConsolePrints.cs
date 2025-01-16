using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace BattleshipGame.Core
{
    /// <summary>
    /// All the methods that will return a complicated string to be printed to the console.
    /// </summary>
    public class ConsolePrints
    {
        /// <summary>Joins all the grid coordinates for the given gameGrid and places them into a format to make the output look like a grid.</summary>
        /// <param name="gameGrid">An instance of the game grid with all the X and Y Coordinates set.</param>
        /// <returns>A formatted string of Coordinates Where every row of 10 Coordinates starts a new line</returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameGrid"></param>
        /// <returns></returns>
        public static string UpdatesWithBoatGridPrint(GameGrid gameGrid)
        {
            string result = string.Join(" || ", gameGrid.GridCoordinates
                .Take(10)
                .Select(coord => coord is StringCoordinate stringCoord ? stringCoord.BoatCode : $"{coord.X},{coord.Y}"));

            for (int i = 10; i < gameGrid.GridCoordinates.Count; i += 10)
            {
                result += Environment.NewLine;
                result += string.Join(" || ", gameGrid.GridCoordinates
                    .Skip(i)
                    .Take(10)
                    .Select(coord => coord is StringCoordinate stringCoord ? stringCoord.BoatCode : $"{coord.X},{coord.Y}"));
            }

            return result;
        }

        /// <summary>
        /// Interates through the list of boats and creates a formatted string based on the Boat make and the list of Coordinates assigned to the boat.
        /// </summary>
        /// <param name="boatList">An instance of a list of boats</param>
        /// <returns>A formatted string of all the instances of boats and their coordinates added to the given list.</returns>
        public static string PrintBoatList(List<Boat> boatList)
        {
            string result = Environment.NewLine;
            result += "---";
            result += Environment.NewLine;
            result += "Saved in the boatList is:";
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