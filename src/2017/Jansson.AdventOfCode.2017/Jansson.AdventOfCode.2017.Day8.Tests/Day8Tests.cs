using FluentAssertions;
using NUnit.Framework;

namespace Jansson.AdventOfCode._2017.Day8.Tests
{
    [TestFixture]
    public class Day8Tests
    {
        private RegisterInstructionsCalculator _registerInstructionsCalculator;

        [SetUp]
        public void SetUp()
        {
            _registerInstructionsCalculator = new RegisterInstructionsCalculator();
        }

        [Test]
        public void Day8_test_input_part1()
        {
            _registerInstructionsCalculator
                .CalculateLagestRegisterValue(@"C:\dev\Jansson.AdventOfCode\src\2017\Jansson.AdventOfCode.2017\Jansson.AdventOfCode.2017.Day8.Tests\Day8Part1TestInput.txt")
                .LargestFinalRegisterValue
                .Should()
                .Be(1);
        }

        [Test]
        public void Day8_part1()
        {
            _registerInstructionsCalculator
                .CalculateLagestRegisterValue(@"C:\dev\Jansson.AdventOfCode\src\2017\Jansson.AdventOfCode.2017\Jansson.AdventOfCode.2017.Day8.Tests\Day8Input.txt")
                .LargestFinalRegisterValue
                .Should()
                .Be(5966);
        }

        [Test]
        public void Day8_test_input_part2()
        {
            _registerInstructionsCalculator
                .CalculateLagestRegisterValue(@"C:\dev\Jansson.AdventOfCode\src\2017\Jansson.AdventOfCode.2017\Jansson.AdventOfCode.2017.Day8.Tests\Day8Part1TestInput.txt")
                .LargestTotalRegisterValue
                .Should()
                .Be(10);
        }

        [Test]
        public void Day8_part2()
        {
            _registerInstructionsCalculator
                .CalculateLagestRegisterValue(@"C:\dev\Jansson.AdventOfCode\src\2017\Jansson.AdventOfCode.2017\Jansson.AdventOfCode.2017.Day8.Tests\Day8Input.txt")
                .LargestTotalRegisterValue
                .Should()
                .Be(6347);
        }
    }
}