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
        /// <param name="gameGrid">The current game grid to update based on the player's guesses.</param>
        /// <param name="boatList">The list of boats to check against for hits.</param>
        /// <returns>
        /// The updated game grid after processing the player's guesses.
        /// </returns>
        /// <remarks>
        /// This method calculates the total number of boat coordinates that need to be guessed, 
        /// and repeatedly prompts the player for valid coordinate guesses until all boat coordinates have been hit. 
        /// It relies on the <see cref="KeepAskingForGuessesIfNeeded"/> method to handle the guessing loop.
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

        /// <summary>
        /// Repeatedly prompts the player for guesses until all boat coordinates are hit.
        /// </summary>
        /// <param name="countOfBoatCoordinates">
        /// The total number of boat coordinates remaining to be guessed.
        /// </param>
        /// <param name="boatList">The list of boats to check against for hits.</param>
        /// <param name="gameGrid">The current game grid to update with hits as they occur.</param>
        /// <returns>
        /// The updated game grid after processing the player's guesses.
        /// </returns>
        /// <remarks>
        /// This method continuously prompts the player to guess coordinates. If a guessed coordinate hits a boat, 
        /// it is marked as a hit on the game grid and the remaining count of boat coordinates decreases. 
        /// If all coordinates are successfully guessed, the player wins the game.
        /// </remarks>
        public static GameGrid KeepAskingForGuessesIfNeeded(int countOfBoatCoordinates, List<Boat> boatList, GameGrid gameGrid)
        {
            HashSet<Coordinate> guessedCoordinates = new HashSet<Coordinate>();

            while (countOfBoatCoordinates > 0)
            {
                var coordinateGuess = AskForAGuess(guessedCoordinates);   
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
        /// asks again if the format is invalid, and asks again if the guess has already been made
        /// </remarks>
        public static string AskForAGuess(HashSet<Coordinate> guessedCoordinates)
        {
            string guess = Prompt.PromptForString("Guess a coordinate of mine. Please format as follows: (1,1)");
            Console.WriteLine("Okay, checking");
            
            bool isItACoord = PromptValidation.ValidateCoordinateStructure(guess);
            Console.WriteLine(ConsolePrints.PrintIfCoordinateIsValidOrNot(isItACoord, guess));

            if (isItACoord == false)
            {
                Console.WriteLine("Please try again and follow the format of (X, Y).");
                return AskForAGuess(guessedCoordinates);
            }

            if (isItACoord == true)
            {
                var coordinate = Coordinate.CreateCoordinateFromString(guess);
                bool wasCoordAddedToList = guessedCoordinates.Add(coordinate);
                Console.WriteLine($"Was {guess} added again? {wasCoordAddedToList}");
                foreach (var coord in guessedCoordinates)
                {
                    Console.WriteLine($"({coord.X}, {coord.Y})");
                }

                if (wasCoordAddedToList == false)
                {
                    Console.WriteLine("This coordinate has already been guessed, so you will need to guess again");
                    return AskForAGuess(guessedCoordinates);
                }
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