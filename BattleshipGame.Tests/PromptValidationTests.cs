using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using BattleshipGame.Core;

namespace BattleshipGame.Tests
{
    public class PromptValidationTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CheckCommaPassesValidCharactersCheckMethod()
        {
            string comma = ",";
            var result = PromptValidation.CheckOnlyValidCharacters(comma);

            Assert.That(result, Is.True);           
        }

        [Test]
        public void CheckOpeningBracketPassesValidCharactersCheckMethod()
        {
            string openingBracket = "(";
            var result = PromptValidation.CheckOnlyValidCharacters(openingBracket);

            Assert.That(result, Is.True);           
        }

        [Test]
        public void CheckClosingBracketPassesValidCharactersCheckMethod()
        {
            string closingBracket = ")";
            var result = PromptValidation.CheckOnlyValidCharacters(closingBracket);

            Assert.That(result, Is.True);           
        }

        [Test]
        public void CheckSpacePassesValidCharactersCheckMethod()
        {
            string space = " ";
            var result = PromptValidation.CheckOnlyValidCharacters(space);

            Assert.That(result, Is.True);           
        }

        [Test]
        public void CheckNumberPassesValidCharactersCheckMethod()
        {
            string number = "1";
            var result = PromptValidation.CheckOnlyValidCharacters(number);

            Assert.That(result, Is.True);           
        }

        [Test]
        public void CheckLetterDoesNotPassValidCharactersCheckMethod()
        {
            string letter = "a";
            var result = PromptValidation.CheckOnlyValidCharacters(letter);

            Assert.That(result, Is.False);           
        }

        [Test]
        public void CheckSpecialCharacterDoesNotPassValidCharactersCheckMethod()
        {
            string specialCharacter = "*";
            var result = PromptValidation.CheckOnlyValidCharacters(specialCharacter);

            Assert.That(result, Is.False);           
        }

        [Test]
        public void CheckCombinationOfAllowedAndNotAllowedStringDoesNotPassValidCharactersCheckMethod()
        {
            string stringToTest = "*1,";
            var result = PromptValidation.CheckOnlyValidCharacters(stringToTest);

            Assert.That(result, Is.False);           
        }

        

    }
}