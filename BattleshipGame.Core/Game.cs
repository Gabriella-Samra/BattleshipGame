using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleshipGame.Core
{
    public class Game
    {
        public static void GameInitialiser()
        {
            Console.WriteLine("Game Starting...Grid Loading");
            var gameGrid = new GameGrid();
            var boatList = new List<Boat>{};

            var largeBoat = new Boat("Large");
            boatList.Add(largeBoat);
            var mediumBoat = new Boat("Medium");
            boatList.Add(mediumBoat);
            var smallBoat = new Boat("Small");
            boatList.Add(smallBoat);

            Console.WriteLine($"{ConsolePrints.InitialGridPrint(gameGrid)}");
            
        }
    }
}