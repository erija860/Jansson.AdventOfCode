using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Jansson.AdventOfCode.DayTwo.Tests
{
    [TestFixture]
    public class When_using_test_input_for_part_2
    {
        private BathroomCodeCalculator _calculator;
        private string[] _result;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _calculator =
                new BathroomCodeCalculator(new List<IKeypad>
                {
                    new KeypadPartTwo()
                });

            _result =
                _calculator.CalculateCode(
                    "C:\\dev\\Jansson.AdventOfCode\\src\\Jansson.AdventOfCode.DayTwo\\Jansson.AdventOfCode.DayTwo.Tests/TestInput.txt");
        }

        [Test]
        public void Result_should_be_5DB3()
        {
            _result[0].Should().Be("5DB3");
        }
    }
}