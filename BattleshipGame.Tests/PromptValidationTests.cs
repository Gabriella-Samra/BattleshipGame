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

        
    }
}