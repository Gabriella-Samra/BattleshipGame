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
            string comma = "(";
            var result = PromptValidation.CheckOnlyValidCharacters(comma);

            Assert.That(result, Is.True);           
        }

        [Test]
        public void CheckClosingBracketPassesValidCharactersCheckMethod()
        {
            string comma = ")";
            var result = PromptValidation.CheckOnlyValidCharacters(comma);

            Assert.That(result, Is.True);           
        }

        [Test]
        public void CheckSpacePassesValidCharactersCheckMethod()
        {
            string comma = " ";
            var result = PromptValidation.CheckOnlyValidCharacters(comma);

            Assert.That(result, Is.True);           
        }

        [Test]
        public void CheckNumberPassesValidCharactersCheckMethod()
        {
            string comma = "1";
            var result = PromptValidation.CheckOnlyValidCharacters(comma);

            Assert.That(result, Is.True);           
        }

        [Test]
        public void CheckLetterDoesNotPassValidCharactersCheckMethod()
        {
            string comma = "a";
            var result = PromptValidation.CheckOnlyValidCharacters(comma);

            Assert.That(result, Is.False);           
        }

    }
}