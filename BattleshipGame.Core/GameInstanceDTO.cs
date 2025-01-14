using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleshipGame.Core
{
    /// <summary>
    /// A combination of an instance of a game, GameGrid, and A List of Boats.
    /// </summary>
    public class GameInstanceDTO
    {
        /// <summary> Get or set a game.</summary>
        public Game Game { get; set; }
        /// <summary> Get or set a game grid.</summary>
        public GameGrid GameGrid { get; set; }
        /// <summary> Get or set a list of Boats.</summary>
        public List<Boat> BoatList { get; set; }

        /// <summary>
        /// A combination of an instance of a game, gameGrid, and a boatList
        /// </summary>
        /// <param name="game">A instance of a game to play.</param>
        /// <param name="gameGrid">An instance of the game grid with all the X and Y Coordinates set.</param>
        /// <param name="boatList">An instance of all boats added to the list</param>
        public GameInstanceDTO(Game game, GameGrid gameGrid, List<Boat> boatList)
        {
            Game = game;
            GameGrid = gameGrid;
            BoatList = boatList;
        }
    }



}