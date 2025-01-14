using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using BattleshipGame.Core;

namespace BattleshipGame.Tests
{
    public class HelperMethods
    {
        public static Boat GetBoatWithCoordinates(string boatMake, string pathDirection)
        {
            var gameGrid = new GameGrid();
            var boat = new Boat(boatMake);
            var boatList = new List<Boat> { boat };
            var startCoordinates = new Coordinate(5,5);
            boat.BoatCoordinates.Add(startCoordinates);
            var game = new Game();
            game.RemainderCoordinatesGenerator(gameGrid, boatList, boat, startCoordinates, pathDirection, boat.BoatLength() - 1);
            return boat;
        }

        public GameInstanceDTO BasicGameSetup()
        {
            var gameGrid = new GameGrid();
            var game = new Game();

            var smallBoat = new Boat("Small");
            var mediumBoat = new Boat("Medium");
            var largeBoat = new Boat("Large");

            var boatList = new List<Boat>
            {
                smallBoat,
                mediumBoat,
                largeBoat
            };

            game.CoordinateAssignmentForComputerBoats(gameGrid, boatList);
            
            var gameInstanceDTO = new GameInstanceDTO(game, gameGrid, boatList);

            return gameInstanceDTO;
        }

        public bool IsBoatCoordinatesCountCorrect(string boat)
        {
            var helper = new HelperMethods();
            var gameSetup = helper.BasicGameSetup();
            var boatList = gameSetup.BoatList;
            
            var matchingBoat = Boat.FindBoatByMake(boatList, boat);
            bool boatResult;

            if (matchingBoat != null)
            {
                boatResult = matchingBoat.BoatCoordinates.Count == matchingBoat.BoatLength();
            }
            else{
                throw new Exception("boat does not exist in list");
            }
            
            return boatResult;
        }
    }
}