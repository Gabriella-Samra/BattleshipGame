using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using BattleshipGame.Core;

namespace BattleshipGame.Tests
{
    public class PlayerGuessTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CheckCorrectHitOfBoatWithGuessWorks()
        {
            var helper = new HelperMethods();
            var gameInstanceDTO = helper.BasicGameSetupNOCoordinatesAssigned();

            gameInstanceDTO.BoatList[1].BoatCoordinates.Add(new Coordinate(1,1));

            Coordinate playerGuess = new Coordinate(1,1);

            var result = PlayerGuess.CheckIfGuessHitABoat(gameInstanceDTO.BoatList, );
            bool expected = true;

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void CheckMissOfBoatWithGuessWorks()
        {
            var helper = new HelperMethods();
            var gameInstanceDTO = helper.BasicGameSetupNOCoordinatesAssigned();

            gameInstanceDTO.BoatList[1].BoatCoordinates.Add(new Coordinate(1,1));

            Coordinate playerGuess = new Coordinate(2,1);

            var result = PlayerGuess.CheckIfGuessHitABoat(gameInstanceDTO.BoatList, playerGuess);
            bool expected = false;

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}