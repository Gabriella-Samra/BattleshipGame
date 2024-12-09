using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace BattleshipGame.Core
{
    public class Boat( string make, int size)
    {        
        public string Make { get; set; } = make;
        public int Size { get; set; } = size;

        public static int BoatLength(string type)
        {
            if( type == "Large")
            {
                return 3;
            }

            if( type == "Medium")
            {
                return 2;
            }

            if( type == "Small")
            {
                return 1;
            }

            return 0;
        }
    }
}