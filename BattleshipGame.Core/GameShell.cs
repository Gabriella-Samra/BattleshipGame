using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleshipGame.Core
{
    public class GameShell
    {
        public static void Main()
        {
            Console.WriteLine("Game Loading");

            var gameInstance = new Game();

            gameInstance.GameInitialiser();

        }
    }
}