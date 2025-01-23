using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleshipGame.Core
{
    /// <summary>
    /// Handles user input prompts and returns the entered string.
    /// </summary>
    public class Prompt
    {
        /// <summary>
        /// Prompts the user with a message to enter a string response and returns the input.
        /// </summary>
        /// <param name="message">The message to display to the user, e.g., "Guess a coordinate of mine."</param>
        /// <returns>
        /// The user's input as a non-null, non-empty string.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the user provides an empty or null response.
        /// </exception>
        public static string PromptForString(string message)
        {
            Console.WriteLine($"{message}");            
            string? response = Console.ReadLine();

            if (string.IsNullOrEmpty(response)) 
            {
                string tryAgainString = "Invalid: ";
                return PromptForString(tryAgainString + message);
            }
            else
            {
                return response;
            }
        }
    }
}