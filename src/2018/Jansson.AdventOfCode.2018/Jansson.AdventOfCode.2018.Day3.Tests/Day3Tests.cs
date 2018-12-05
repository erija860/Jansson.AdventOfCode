using System.IO;
using FluentAssertions;
using NUnit.Framework;

namespace Jansson.AdventOfCode._2018.Day3.Tests
{
    [TestFixture]
    public class Day3Tests
    {
        private FabricCalculator _calculator;

        [OneTimeSetUp]
        public void SetUp()
        {
            _calculator = new FabricCalculator();
        }

        [Test]
        public void Day3Part1TestInput()
        {
            var input = File.ReadAllLines("Day3Part1TestFile1.txt");

            var result = _calculator.CalculateOverlappingSquareInches(input);

            result.Should().Be(4);
        }

        [Test]
        public void Day3Part1Result()
        {
            var input = File.ReadAllLines("Day3Input.txt");

            var result = _calculator.CalculateOverlappingSquareInches(input);

            result.Should().Be(110383);
        }

        [Test]
        public void Day3Part2TestInput()
        {
            var input = File.ReadAllLines("Day3Part1TestFile1.txt");

            var result = _calculator.FindNonOverlappingClaim(input);

            result.Should().Be("3");
        }

        [Test]
        public void Day3Part2Result()
        {
            var input = File.ReadAllLines("Day3Input.txt");

            var result = _calculator.FindNonOverlappingClaim(input);

            result.Should().Be("129");
        }
    }
}
