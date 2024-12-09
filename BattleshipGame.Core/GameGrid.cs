using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleshipGame.Core
{
    public class GameGrid(int width = 10, int height = 10)
    {
        public int Width { get; } = width;
        public int Height { get; } = height;

        
    }

}