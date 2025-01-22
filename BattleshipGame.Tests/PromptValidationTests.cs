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

        [Test]
        public void CheckCommaPositionCanBeFound()
        {
            string stringToTest = "X,X";
            var result = PromptValidation.FindCommaPosition(stringToTest);
            int expectedResult = 1;

            Assert.That(result, Is.EqualTo(expectedResult));         
        }

        [Test]
        public void CheckCommaPositionCanNotBeFound()
        {
            string stringToTest = "XX";
            var result = PromptValidation.FindCommaPosition(stringToTest);
            int? expectedResult = null;

            Assert.That(result, Is.EqualTo(expectedResult));         
        }

        [Test]
        public void CheckOpeningBracketPositionNeedsToBeFirst()
        {
            string stringToTest = "(X";
            var result = PromptValidation.FindOpeningBracketPosition(stringToTest);
            int expectedResult = 0;

            Assert.That(result, Is.EqualTo(expectedResult));         
        }

        [Test]
        public void CheckOpeningBracketCantBeFoundIfItIsntFirst()
        {
            string stringToTest = "X(X";
            var result = PromptValidation.FindOpeningBracketPosition(stringToTest);
            int? expectedResult = null;

            Assert.That(result, Is.EqualTo(expectedResult));         
        }

        [Test]
        public void CheckOpeningBracketPositionCanNotBeFound()
        {
            string stringToTest = "XX";
            var result = PromptValidation.FindOpeningBracketPosition(stringToTest);
            int? expectedResult = null;

            Assert.That(result, Is.EqualTo(expectedResult));         
        }

        [Test]
        public void CheckClosingBracketPositionNeedsToBeLast()
        {
            string stringToTest = "X)";
            var result = PromptValidation.FindClosingBracketPosition(stringToTest);
            int expectedResult = stringToTest.Length - 1;

            Assert.That(result, Is.EqualTo(expectedResult));         
        }

        [Test]
        public void CheckClosingBracketCantBeFoundIfItIsntFirst()
        {
            string stringToTest = "X)X";
            var result = PromptValidation.FindClosingBracketPosition(stringToTest);
            int? expectedResult = null;

            Assert.That(result, Is.EqualTo(expectedResult));         
        }

        [Test]
        public void CheckClosingBracketPositionCanNotBeFound()
        {
            string stringToTest = "XX";
            var result = PromptValidation.FindClosingBracketPosition(stringToTest);
            int? expectedResult = null;

            Assert.That(result, Is.EqualTo(expectedResult));         
        }

        [Test]
        public void CheckFirstNumberCanBeFound()
        {
            string stringToTest = "(1,X";
            int commaLocation = 2;
            int locationOfOpeningBracket = 0;
            var result = PromptValidation.IsNumberPresentBetweenOpeningBracketAndComma(stringToTest, commaLocation, locationOfOpeningBracket);
            bool expectedResult = true;

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void CheckSecondNumberCanBeFound()
        {
            string stringToTest = "(1,1)";
            int commaLocation = 2;
            int locationOfClosingBracket = stringToTest.Length - 1;
            var result = PromptValidation.IsNumberPresentBetweenCommaAndClosingBracket(stringToTest, commaLocation, locationOfClosingBracket);
            bool expectedResult = true;

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void CheckFirstNumberCanNotBeFoundIfNoComma()
        {
            string stringToTest = "(1X";
            int commaLocation = -1 ;
            int locationOfOpeningBracket = 0;
            var result = PromptValidation.IsNumberPresentBetweenOpeningBracketAndComma(stringToTest, commaLocation, locationOfOpeningBracket);
            bool expectedResult = false;

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void CheckSecondNumberCanNotBeFoundIfNoComma()
        {
            string stringToTest = "(11)";
            int commaLocation = -1;
            int locationOfClosingBracket = stringToTest.Length - 1;
            var result = PromptValidation.IsNumberPresentBetweenCommaAndClosingBracket(stringToTest, commaLocation, locationOfClosingBracket);
            bool expectedResult = false;

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void CheckFirstNumberCanNotBeFoundIfNoBracket()
        {
            string stringToTest = "1,X)";
            int commaLocation = 1 ;
            int locationOfOpeningBracket = -1;
            var result = PromptValidation.IsNumberPresentBetweenOpeningBracketAndComma(stringToTest, commaLocation, locationOfOpeningBracket);
            bool expectedResult = false;

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void CheckSecondNumberCanNotBeFoundIfNoBracket()
        {
            string stringToTest = "(1,1";
            int commaLocation = 2;
            int locationOfClosingBracket = -1;
            var result = PromptValidation.IsNumberPresentBetweenCommaAndClosingBracket(stringToTest, commaLocation, locationOfClosingBracket);
            bool expectedResult = false;

            Assert.That(result, Is.EqualTo(expectedResult));
        }       
    }
}