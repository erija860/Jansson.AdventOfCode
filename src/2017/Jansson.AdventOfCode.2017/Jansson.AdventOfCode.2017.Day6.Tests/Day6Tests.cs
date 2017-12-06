using FluentAssertions;
using NUnit.Framework;

namespace Jansson.AdventOfCode._2017.Day6.Tests
{
    [TestFixture]
    public class Day6Tests
    {
        private MemoryReallocation _memoryReallocation;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _memoryReallocation = new MemoryReallocation();
        }

        [Test]
        public void Should_return_correct_steps_to_reproduce_test_input_part1()
        {
            _memoryReallocation.CalculateStepsToReproduce(@"C:\dev\Jansson.AdventOfCode\src\2017\Jansson.AdventOfCode.2017\Jansson.AdventOfCode.2017.Day6.Tests\TestInputPart1.txt")
                .Should().Be(5);
        }

        [Test]
        public void Should_return_correct_steps_to_reproduce_part1()
        {
            _memoryReallocation.CalculateStepsToReproduce(@"C:\dev\Jansson.AdventOfCode\src\2017\Jansson.AdventOfCode.2017\Jansson.AdventOfCode.2017.Day6.Tests\InputDay6.txt")
                .Should().Be(7864);
        }

        [Test]
        public void Should_return_correct_steps_of_infinite_loop_test_input_part1()
        {
            _memoryReallocation.CalculateStepsOfInfiniteLoop(@"C:\dev\Jansson.AdventOfCode\src\2017\Jansson.AdventOfCode.2017\Jansson.AdventOfCode.2017.Day6.Tests\TestInputPart1.txt")
                .Should().Be(4);
        }

        [Test]
        public void Should_return_correct_steps_of_infinite_loop_part2()
        {
            _memoryReallocation.CalculateStepsOfInfiniteLoop(@"C:\dev\Jansson.AdventOfCode\src\2017\Jansson.AdventOfCode.2017\Jansson.AdventOfCode.2017.Day6.Tests\InputDay6.txt")
                .Should().Be(1695);
        }
    }
}