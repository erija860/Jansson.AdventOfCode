using System.IO;
using FluentAssertions;
using NUnit.Framework;

namespace Jansson.AdventOfCode._2018.Day2.Tests
{
    [TestFixture]
    public class Day2Tests
    {
        private BoxChecksumCalculator _calculator;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _calculator = new BoxChecksumCalculator();
        }

        [Test]
        public void Day2_testInput_part1()
        {
            var input = File.ReadAllLines("Day2Part1TestFile1.txt");

            var result = _calculator.CalculateChecksum(input);

            result.Should().Be(12);
        }

        [Test]
        public void Day2_result_part1()
        {
            var input = File.ReadAllLines("Day2Input.txt");

            var result = _calculator.CalculateChecksum(input);

            result.Should().Be(3952);
        }

        [Test]
        public void Day2_testInput_part2()
        {
            var input = File.ReadAllLines("Day2Part2TestFile1.txt");

            var result = _calculator.GetCommonCharactersOfSingleDifferingId(input);

            result.Should().Be("fgij");
        }

        [Test]
        public void Day2_result_part2()
        {
            var input = File.ReadAllLines("Day2Input.txt");

            var result = _calculator.GetCommonCharactersOfSingleDifferingId(input);

            result.Should().Be("vtnikorkulbfejvyznqgdxpaw");
        }
    }
}
