using FluentAssertions;
using NUnit.Framework;

namespace Jansson.AdventOfCode._2017.Day5.Tests
{ 
    [TestFixture]
    public class Day5Tests
    {
        private CpuInstructionsHelper _cpuInstructionsHelper;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _cpuInstructionsHelper = new CpuInstructionsHelper();
        }

        [Test]
        public void Should_return_correct_steps_count_from_test_input_part1()
        {
            _cpuInstructionsHelper
                .CalculateStepsToExit(@"C:\dev\Jansson.AdventOfCode\src\2017\Jansson.AdventOfCode.2017\Jansson.AdventOfCode.2017.Day5.Tests\Day5TestInputPart1.txt")
                .Should().Be(5);
        }

        [Test]
        public void Should_return_correct_steps_count_part1()
        {
            _cpuInstructionsHelper
                .CalculateStepsToExit(@"C:\dev\Jansson.AdventOfCode\src\2017\Jansson.AdventOfCode.2017\Jansson.AdventOfCode.2017.Day5.Tests\Day5Input.txt")
                .Should().Be(387096);
        }

        [Test]
        public void Should_return_correct_steps_count_from_test_input_part2()
        {
            _cpuInstructionsHelper
                .CalculateStepsToExitWithDecreaseAbove2Offset(@"C:\dev\Jansson.AdventOfCode\src\2017\Jansson.AdventOfCode.2017\Jansson.AdventOfCode.2017.Day5.Tests\Day5TestInputPart1.txt")
                .Should().Be(10);
        }

        [Test]
        public void Should_return_correct_steps_count_part2()
        {
            _cpuInstructionsHelper
                .CalculateStepsToExitWithDecreaseAbove2Offset(@"C:\dev\Jansson.AdventOfCode\src\2017\Jansson.AdventOfCode.2017\Jansson.AdventOfCode.2017.Day5.Tests\Day5Input.txt")
                .Should().Be(28040648);
        }
    }
}
