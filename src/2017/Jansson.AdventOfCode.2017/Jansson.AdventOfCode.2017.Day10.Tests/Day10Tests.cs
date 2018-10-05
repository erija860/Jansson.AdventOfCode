using FluentAssertions;
using NUnit.Framework;

namespace Jansson.AdventOfCode._2017.Day10.Tests
{
    [TestFixture]
    public class Day10Tests
    {
        private KnotHash _knotHashCalculator;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _knotHashCalculator = new KnotHash();
        }

        [Test]
        public void Day10_result_part1()
        {
            var result = _knotHashCalculator
                .Calculate(
                    new CircularList(256),
                    new[] { 165, 1, 255, 31, 87, 52, 24, 113, 0, 91, 148, 254, 158, 2, 73, 153 });

            result
                .FirstTwoNumbersMultiplied
                .Should()
                .Be(4114);
        }


        [Test]
        public void Day10_testInput_part1()
        {
            var result = _knotHashCalculator
                .Calculate(new CircularList(5), new[] { 3, 4, 1, 5 });

            result
                .FirstTwoNumbersMultiplied
                .Should()
                .Be(12);
        }

        [Test]
        public void Day10_testInput_part2()
        {
            var result = _knotHashCalculator
                .CalculatePart2(new CircularList(256), "1,2,3");

            result
                .DenseHash
                .Should()
                .Be("3efbe78a8d82f29979031a4aa0b16a9d");
        }
    }
}