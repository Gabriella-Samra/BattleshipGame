using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace BattleshipGame.Core
{
    /// <summary>
    /// Provides methods to validate coordinate strings with specific structure requirements.
    /// </summary>
    public class PromptValidation
    {
        /// <summary>
        /// Validates whether a given coordinate string follows the expected format of (X,Y).
        /// </summary>
        /// <param name="coord">The coordinate string to validate.</param>
        /// <returns>True if the coordinate follows the expected format; otherwise, false.</returns>
        public static bool ValidateCoordinateStructure(string coord)
        {
            if (!CheckOnlyValidCharacters(coord)) return false;
            var commaLocation = FindCommaPosition(coord);
            if (!commaLocation.HasValue) return false;
            var openingBracketLocation = FindOpeningBracketPosition(coord);
            if (!openingBracketLocation.HasValue) return false;
            var closingBracketPosition = FindClosingBracketPosition(coord);
            if (!closingBracketPosition.HasValue) return false;
            var hasLeftComponent = IsNumberPresentBetweenOpeningBracketAndComma(coord, commaLocation.Value, openingBracketLocation.Value);
            if (!hasLeftComponent) return false;
            var hasRightComponent = IsNumberPresentBetweenCommaAndClosingBracket(coord, commaLocation.Value, closingBracketPosition.Value);
            if (!hasRightComponent) return false;
            return true;
        }

        /// <summary>
        /// Checks if the coordinate string contains only valid characters: digits, commas, brackets, or spaces.
        /// </summary>
        /// <param name="coord">The coordinate string to check.</param>
        /// <returns>True if the string contains only valid characters; otherwise, false.</returns>
        public static bool CheckOnlyValidCharacters(string coord)
        {
            for (int i = 0; i < coord.Length; i++)
            {
                // If any character in the coord is not a , () or a number then return false
                if ( coord[i] != ',' && coord[i] != '(' && coord[i] != ')' && !char.IsDigit(coord[i]) && coord[i] != ' ') 
                {
                    Console.WriteLine("If any character in the coord is not a , () or a number then return false");
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Finds the position of the first comma in the coordinate string.
        /// </summary>
        /// <param name="coord">The coordinate string to search.</param>
        /// <returns>The index of the first comma if found; otherwise, null.</returns>
        public static int? FindCommaPosition(string coord)
        {
            for (int i = 0; i < coord.Length; i++)
            {
                if (coord[i] == ',') return i;
            }
            return null;
        }

        /// <summary>
        /// Determines if the coordinate string starts with an opening bracket.
        /// </summary>
        /// <param name="coord">The coordinate string to check.</param>
        /// <returns>The index of the opening bracket if found at the beginning; otherwise, null.</returns>
        public static int? FindOpeningBracketPosition(string coord)
        {
            if (coord[0] != '(') return null;
            return 0;
        }

        /// <summary>
        /// Determines if the coordinate string ends with a closing bracket.
        /// </summary>
        /// <param name="coord">The coordinate string to check.</param>
        /// <returns>The index of the closing bracket if found at the end; otherwise, null.</returns>
        public static int? FindClosingBracketPosition(string coord)
        {
            if (coord[coord.Length - 1] != ')') return null;
            return coord.Length - 1;
        }

        /// <summary>
        /// Checks if a valid numeric value is present between the opening bracket and the comma in the coordinate string.
        /// </summary>
        /// <param name="coord">The coordinate string to check.</param>
        /// <param name="commaLocation">The index of the comma in the string.</param>
        /// <param name="locationOfOpeningBracket">The index of the opening bracket in the string.</param>
        /// <returns>True if a valid number is present; otherwise, false.</returns>            
        public static bool IsNumberPresentBetweenOpeningBracketAndComma(string coord, int commaLocation, int locationOfOpeningBracket)
        {
            if (commaLocation < 2) return false;
            if (locationOfOpeningBracket < 0) return false;

            string numCheckValue = coord.Substring(locationOfOpeningBracket + 1, commaLocation - (locationOfOpeningBracket + 1));
            bool isNumber = !string.IsNullOrEmpty(numCheckValue) && numCheckValue.All(char.IsDigit);
            // If the string between the ( and , is not a number then return false
            // If the string is empty then return false
            if (!isNumber) 
            {
                Console.WriteLine("If the string between the ( and , is not a number then return false. If the string is empty then return false");
                return false;
            }
            return true;
        }    

        /// <summary>
        /// Checks if a valid numeric value is present between the comma and the closing bracket in the coordinate string.
        /// </summary>
        /// <param name="coord">The coordinate string to check.</param>
        /// <param name="commaLocation">The index of the comma in the string.</param>
        /// <param name="locationOfClosingBracket">The index of the closing bracket in the string.</param>
        /// <returns>True if a valid number is present; otherwise, false.</returns>
        public static bool IsNumberPresentBetweenCommaAndClosingBracket(string coord, int commaLocation, int locationOfClosingBracket)
        {
            if (commaLocation < 2) return false;
            if (locationOfClosingBracket < coord.Length - 1) return false;

            string numCheckValue = coord.Substring(commaLocation + 1, locationOfClosingBracket - (commaLocation + 1));
            bool isNumber = !string.IsNullOrEmpty(numCheckValue) && numCheckValue.All(char.IsDigit);
            // If the string between the , and ) is not a number then return false
            // If the string is empty then return false
            if (!isNumber) 
            {
                Console.WriteLine("If the string between the , and ) is not a number then return false If the string is empty then return false");
                return false;
            }
            return true;
        }                      
    }
}