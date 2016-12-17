using System;
using NUnit.Framework;

namespace Jansson.AdventOfCode.DayEight.Tests
{
    [TestFixture]
    public class KeypadScreenCalculatorTests
    {
        private KeypadScreenCalculator _calculator;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _calculator = new KeypadScreenCalculator();
            _calculator.ParseInput(
                @"C:\dev\Jansson.AdventOfCode\src\Jansson.AdventOfCode.DayEight\Jansson.AdventOfCode.DayEight\InputFile.txt");
            _calculator.ExecuteCommands();
        }

        [Test]
        public void SomeTest()
        {
            Console.WriteLine(_calculator.GetCountOfPixelsLit());
        }
    }
}