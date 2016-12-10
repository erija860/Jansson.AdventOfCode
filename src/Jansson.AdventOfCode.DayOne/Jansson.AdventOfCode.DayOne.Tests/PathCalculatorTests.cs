using FluentAssertions;
using NUnit.Framework;

namespace Jansson.AdventOfCode.DayOne.Tests
{
    [TestFixture]
    public class PathCalculatorTests
    {
        [SetUp]
        public void SetUp()
        {
            _pathCalculator = new PathCalculator();
        }

        private PathCalculator _pathCalculator;

        [TestCase("R2, L3", 5)]
        [TestCase("R2, R2, R2", 2)]
        [TestCase("R5, L5, R5, R3", 12)]
        public void Should_calculate_answer_from_input(string directions, int result)
        {
            _pathCalculator.CalculateDistanceBetweenStartAndFinish(directions).Should().Be(result);
        }

        [Test]
        public void Should_get_distance_from_first_duplicated_place()
        {
            _pathCalculator.CalculateDistanceBetweenStartAndFinish("R8, R4, R4, R8");
            _pathCalculator.GetFirstDuplicatedPosition().Should().Be(4);
        }
    }
}