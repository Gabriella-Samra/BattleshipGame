using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleshipGame.Core
{
    /// <summary>
    /// The container for a game.
    /// </summary>
    public class GameShell
    {
        /// <summary>
        /// Entry point for the game
        ///</summary>
        public static void Main()
        {
            Console.WriteLine("Game Loading");

            var gameInstance = new Game();

            gameInstance.GameInitialiser();

        }
    }
}