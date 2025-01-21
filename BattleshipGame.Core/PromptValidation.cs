using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace BattleshipGame.Core
{
    public class PromptValidation
    {
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

        public static int? FindCommaPosition(string coord)
        {
            for (int i = 0; i < coord.Length; i++)
            {
                if (coord[i] == ',') return i;
            }
            return null;
        }

        public static int? FindOpeningBracketPosition(string coord)
        {
            if (coord[0] != '(') return null;
            return 0;
        }    

        public static int? FindClosingBracketPosition(string coord)
        {
            if (coord[coord.Length - 1] != ')') return null;
            return coord.Length - 1;
        }
            
        public static bool IsNumberPresentBetweenOpeningBracketAndComma(string coord, int commaLocation, int locationOfOpeningBracket)
        {
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

        public static bool IsNumberPresentBetweenCommaAndClosingBracket(string coord, int commaLocation, int locationOfClosingBracket)
        {
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