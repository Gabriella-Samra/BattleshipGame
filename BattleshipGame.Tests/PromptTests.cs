using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using BattleshipGame.Core;

namespace BattleshipGame.Tests
{
    public class PromptTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PromptForStringShouldPrintPromptMessage()
        {
            // Arrange
            string expectedMessage = "Guess a coordinate of mine. Please format as follows: (1,1)";
            using (var consoleOutput = new StringWriter())
            {
                Console.SetOut(consoleOutput);
                
                // Simulate user input
                using (var consoleInput = new StringReader("(1,1)"))
                {
                    Console.SetIn(consoleInput);

                    // Act
                    Prompt.PromptForString(expectedMessage);
                }

                // Assert
                string output = consoleOutput.ToString();
                Assert.IsTrue(output.Contains(expectedMessage));
            }
        }

        [Test]
        public void PromptForStringShouldPromptAgainOnEmptyInputAndReturnValidResponse()
        {
            string promptMessage = "Guess a coordinate of mine. Please format as follows: (1,1)";
            
            using var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            using var consoleInput = new StringReader("\n(1,1)\n");
            Console.SetIn(consoleInput);

            string result = Prompt.PromptForString(promptMessage);

            // Assert that the final returned value is correct
            Assert.That(result, Is.EqualTo("(1,1)"), "Expected valid coordinate response after retry.");

            string output = consoleOutput.ToString();

            // Ensure the original prompt appears initially
            Assert.That(output, Does.Contain(promptMessage), "The initial prompt was not printed.");

            // Ensure the invalid prompt was shown after empty input
            Assert.That(output, Does.Contain("Invalid: " + promptMessage), "Expected invalid prompt after empty input.");
        }

        [Test]
        public void PromptForStringShouldStopRecursionOnValidInput()
        {
            string initialMessage = "Guess a coordinate of mine. Please format as follows: (1,1)";

            using var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            using var consoleInput = new StringReader("\n\n\n(1,1)\n");
            Console.SetIn(consoleInput);

            string result = Prompt.PromptForString(initialMessage);

            Assert.That(result, Is.EqualTo("(1,1)"), "Expected valid coordinate response after retries.");
        }
    }
}