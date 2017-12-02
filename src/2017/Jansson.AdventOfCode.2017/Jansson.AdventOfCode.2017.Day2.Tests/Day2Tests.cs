using FluentAssertions;
using NUnit.Framework;

namespace Jansson.AdventOfCode._2017.Day2.Tests
{
    [TestFixture]
    public class Day2Tests
    {
        private SpreadsheetChecksumCalculator _calculator;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _calculator = new SpreadsheetChecksumCalculator();
        }

        [Test]
        public void Should_return_correct_checksum_part1()
        {
            var result = _calculator.CalculateChecksum(
                "C:\\dev\\Jansson.AdventOfCode\\src\\2017\\Jansson.AdventOfCode.2017\\Jansson.AdventOfCode.2017.Day2.Tests\\TestInputPart1.txt");
            result.Should().Be(18);
        }

        [Test]
        public void Should_return_result_part1()
        {
            var result = _calculator.CalculateChecksum(
                "C:\\dev\\Jansson.AdventOfCode\\src\\2017\\Jansson.AdventOfCode.2017\\Jansson.AdventOfCode.2017.Day2.Tests\\InputFile.txt");
            result.Should().Be(30994);
        }

        [Test]
        public void Should_return_correct_divisible_checksum_part2()
        {
            var result = _calculator.CalculateDivisibleChecksum(
                "C:\\dev\\Jansson.AdventOfCode\\src\\2017\\Jansson.AdventOfCode.2017\\Jansson.AdventOfCode.2017.Day2.Tests\\TestInputPart2.txt");
            result.Should().Be(9);
        }

        [Test]
        public void Should_return_result_part2()
        {
            var result = _calculator.CalculateDivisibleChecksum(
                "C:\\dev\\Jansson.AdventOfCode\\src\\2017\\Jansson.AdventOfCode.2017\\Jansson.AdventOfCode.2017.Day2.Tests\\InputFile.txt");
            result.Should().Be(233);
        }
    }
}