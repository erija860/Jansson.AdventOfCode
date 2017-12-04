using FluentAssertions;
using NUnit.Framework;

namespace Jansson.AdventOfCode._2017.Day3.Tests
{
    [TestFixture]
    public class Day3Tests
    {
        private SpiralMemory _memory;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _memory = new SpiralMemory();
        }

        [Test]
        [TestCase(1, 0)]
        [TestCase(2, 1)]
        [TestCase(3, 2)]
        [TestCase(4, 1)]
        [TestCase(5, 2)]
        [TestCase(6, 1)]
        [TestCase(7, 2)]
        [TestCase(8, 1)]
        [TestCase(12, 3)]
        [TestCase(23, 2)]
        [TestCase(24,3)]
        [TestCase(1024,31)]
        public void Should_calculate_steps_for_test_input_part1(int square, int minSteps)
        {
            _memory.CalculateMinStepsToAccessPort(square).Should().Be(minSteps);
        }

        [Test]
        public void Should_return_result_part1()
        {
            _memory.CalculateMinStepsToAccessPort(289326).Should().Be(419);
        }

        [Test]
        [TestCase(1, 2)]
        [TestCase(3, 4)]
        [TestCase(25, 26)]
        public void Should_calculate_return_value_for_test_input_part2(int input, int expectedResult)
        {
            _memory.GetFirstValueHigherThanInput(input).Should().Be(expectedResult);
        }

        [Test]
        public void Should_return_result_part2()
        {
            _memory.GetFirstValueHigherThanInput(289326).Should().Be(295229);
        }
    }
}
