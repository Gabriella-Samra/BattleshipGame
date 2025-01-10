using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleshipGame.Core
{
    public class GameInstanceDTO
    {
        public Game Game { get; set; }
        public GameGrid GameGrid { get; set; }
        public List<Boat> BoatList { get; set; }

        public GameInstanceDTO(Game game, GameGrid gameGrid, List<Boat> boatList)
        {
            Game = game;
            GameGrid = gameGrid;
            BoatList = boatList;
        }
    }



}