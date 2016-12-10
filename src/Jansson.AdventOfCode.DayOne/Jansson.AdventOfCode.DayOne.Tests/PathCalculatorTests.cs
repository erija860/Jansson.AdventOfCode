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
        }

        private PathCalculator _pathCalculator;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _pathCalculator = new PathCalculator();
        }

        [TestCase("R2, L3", 5)]
        [TestCase("R2, R2, R2", 2)]
        [TestCase("R5, L5, R5, R3", 12)]
        public void Should_calculate_answer_fromm_input(string directions, int result)
        {
            _pathCalculator.CalculateDistanceBetweenStartAndFinish(directions).Should().Be(result);
        }
    }

    [TestFixture]
    public class DuplicatePathCalculatorTests
    {
        private PathCalculator _pathCalculator;
        private int _result;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _pathCalculator = new PathCalculator();
            _result = _pathCalculator.CalculateDistanceToFirstPlaceVisitedTwice("R8, R4, R4, R8");
        }

        [Test]
        public void Should_calculate_answer_fromm_input()
        {
            _result.Should().Be(4);
        }
    }
}