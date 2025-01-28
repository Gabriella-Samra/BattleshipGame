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
        /// Handles the player's guessing loop for the Battleship game and updates the game grid accordingly.
        /// </summary>
        /// <param name="gameGrid">The current game grid to update based on the player's guess.</param>
        /// <param name="boatList">The list of boats to check against for hits.</param>
        /// <returns>
        /// The updated game grid after processing the player's guess.
        /// </returns>
        /// <remarks>
        /// This method recursively prompts the player for a valid coordinate guess, checks if it hits a boat, 
        /// updates the grid if it is a hit, and repeats the process if it is a miss.
        /// </remarks>
        public static GameGrid PlayerGuessRequestLoop(GameGrid gameGrid, List<Boat> boatList)
        {
            // TODO: This executes if you make the same guess as before. Obvs don't want that.
            int countOfBoatCoordinates = 0;

            foreach (Boat boat in boatList)
            {
                countOfBoatCoordinates += boat.BoatCoordinates.Count;
                Console.WriteLine($"The number of boat coordinates still to guess is {countOfBoatCoordinates}");
            }

            gameGrid = KeepAskingForGuessesIfNeeded(countOfBoatCoordinates, boatList, gameGrid);
            
            return gameGrid;
        } 

        public static GameGrid KeepAskingForGuessesIfNeeded(int countOfBoatCoordinates, List<Boat> boatList, GameGrid gameGrid)
        {
            while (countOfBoatCoordinates > 0)
            {
                var coordinateGuess = AskForAGuess();   
                var coordinate = Coordinate.CreateCoordinateFromString(coordinateGuess);
                var isCoordAssigned = CheckIfGuessHitABoat(boatList, coordinate);
                Console.WriteLine(ConsolePrints.PrintIfGuessHitABoat(isCoordAssigned));

                if (isCoordAssigned == true)
                {
                    gameGrid = GameGrid.UpdateGameGridWithHits(gameGrid, coordinate);
                    countOfBoatCoordinates--;
                    Console.WriteLine($"{ConsolePrints.UpdatesWithBoatGridPrint(gameGrid)}");
                    Console.WriteLine($"The number of boat coordinates still to guess is {countOfBoatCoordinates}");

                    if(countOfBoatCoordinates == 0)
                    {
                        Console.WriteLine("Congratulations! You have found and hit all my boats!! You Won!");
                    }
                }

                else
                {
                    Console.WriteLine("You missed my boat, please try again");
                } 
            }

            return gameGrid;
        }

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
        public static bool CheckIfGuessHitABoat(List<Boat> boatList, Coordinate playerGuess)
        {
            var isCoordAssigned = Boat.IsCoordinateAssigned(boatList, playerGuess);

            return isCoordAssigned;
        }
    }
}