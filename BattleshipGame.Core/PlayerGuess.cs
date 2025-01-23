using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace BattleshipGame.Core
{
    /// <summary>
    /// Provides functionality for handling player guesses in the Battleship game.
    /// </summary>
    /// <remarks>
    /// This class includes methods to prompt the player for a coordinate guess, validate the input, 
    /// and check if the guessed coordinate hits a boat on the game grid.
    /// </remarks>
    public class PlayerGuess
    {
        /// <summary>
        /// Handles the player's coordinate guess input and validation.
        /// </summary>
        /// <returns>
        /// The valid guessed coordinate as a string.
        /// </returns>
        /// <remarks>
        /// This method prompts the user for a coordinate input, validates its structure, 
        /// and asks again if the format is invalid.
        /// </remarks>
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

        /// <summary>
        /// Checks whether the player's guess matches any boat's coordinates.
        /// </summary>
        /// <param name="boatList">A list of boats containing their assigned coordinates.</param>
        /// <param name="playerGuess">The player's guessed coordinate string.</param>
        /// <returns>
        /// <c>true</c> if the guess matches any boat's coordinate; otherwise, <c>false</c>.
        /// </returns>
        public static bool CheckIfGuessHitABoat(List<Boat> boatList, string playerGuess)
        {
            var coordinate = Coordinate.CreateCoordinateFromString(playerGuess);
            var isCoordAssigned = Boat.IsCoordinateAssigned(boatList, coordinate);

            return isCoordAssigned;
        }
    }
}