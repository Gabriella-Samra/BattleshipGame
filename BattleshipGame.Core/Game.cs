using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleshipGame.Core
{
    public class Game
    {
        public static void Main()
        {
            Console.WriteLine("Game Starting");
            var gameGrid = new GameGrid();
            var boatList = new List<Boat>{};
            Console.WriteLine("Initial Grid:");
            Console.WriteLine($"The Grid Height is {gameGrid.YAxis}");
            Console.WriteLine($"The Grid Height is {gameGrid.XAxis}");

            var largeBoat = new Boat("Large");
            boatList.Add(largeBoat);
            var mediumBoat = new Boat("Medium");
            boatList.Add(mediumBoat);
            var smallBoat = new Boat("Small");
            boatList.Add(smallBoat);

            Console.WriteLine($"The size of my large boat is {largeBoat.BoatLength()}");
            Console.WriteLine($"The size of my medium boat is {mediumBoat.BoatLength()}");
            Console.WriteLine($"The size of my small boat is {smallBoat.BoatLength()}");
            Console.WriteLine($"{ConsolePrints.InitialGridPrint(gameGrid)}");

            largeBoat.SetBoatOnGrid(largeBoat, gameGrid);
        }
    }
}