using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace BattleshipGame.Core
{
    public class PlayerGuess
    {
        public static string AskForAGuess()
        {
            string guess = Prompt.PromptForString("Guess a coordinate of mine. Please format as follows: (1,1)");
            Console.WriteLine("Okay, checking");
            
            bool isItACoord = PromptValidation.ValidateCoordinateStructure(guess);
            Console.WriteLine(ConsolePrints.PrintIfCoordinateIsValidOrNot(isItACoord, guess));

            if (isItACoord == false)
            {
                Console.WriteLine("Please try again and follow the format of (X, Y).");
                return AskForAGuess();
            }

            return guess;
        }

        public static bool CheckIfGuessHitABoat(List<Boat> boatList, string playerGuess)
        {
            var coordinate = Coordinate.CreateCoordinateFromString(playerGuess);
            var isCoordAssigned = Boat.IsCoordinateAssigned(boatList, coordinate);

            return isCoordAssigned;
        }
    }
}