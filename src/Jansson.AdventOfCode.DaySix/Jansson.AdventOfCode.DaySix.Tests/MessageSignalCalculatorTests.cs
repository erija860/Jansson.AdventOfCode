using System;
using NUnit.Framework;

namespace Jansson.AdventOfCode.DaySix.Tests
{
    [TestFixture]
    public class MessageSignalCalculatorTests
    {
        private MessageSignalCalculator _calculator;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _calculator = new MessageSignalCalculator();
        }

        [Test]
        public void SomeTest()
        {
            Console.WriteLine(
                _calculator.CalculateMessage(
                    @"C:\dev\Jansson.AdventOfCode\src\Jansson.AdventOfCode.DaySix\Jansson.AdventOfCode.DaySix\InputFile.txt"));
        }
    }
}