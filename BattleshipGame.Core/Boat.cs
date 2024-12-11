using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace BattleshipGame.Core
{
    public class Boat(string make)
    {        
        public string Make { get; set; } = make;

        public int BoatLength()
        {
            if(make == "Large")
            {
                return 3;
            }

            if(make == "Medium")
            {
                return 2;
            }

            if(make == "Small")
            {
                return 1;
            }

            return 0;
        }
    }
}