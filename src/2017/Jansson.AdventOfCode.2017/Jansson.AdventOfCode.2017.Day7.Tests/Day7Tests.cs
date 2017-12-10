using FluentAssertions;
using NUnit.Framework;

namespace Jansson.AdventOfCode._2017.Day7.Tests
{
    [TestFixture]
    public class Day7Tests
    {
        private RecursiveCircus _recursiveCircus;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _recursiveCircus = new RecursiveCircus();
        }

        [Test]
        public void Day7_test_input_part1()
        {
            _recursiveCircus.CalculateBottomProgram(@"C:\dev\Jansson.AdventOfCode\src\2017\Jansson.AdventOfCode.2017\Jansson.AdventOfCode.2017.Day7.Tests\Day7TestInputPart1.txt")
                .Should().Be("tknk");
        }

        [Test]
        public void Day7_part1()
        {
            _recursiveCircus.CalculateBottomProgram(@"C:\dev\Jansson.AdventOfCode\src\2017\Jansson.AdventOfCode.2017\Jansson.AdventOfCode.2017.Day7.Tests\Day7Input.txt")
                .Should().Be("dtacyn");
        }

        [Test]
        public void Day7_test_input_part2()
        {
            _recursiveCircus.CalculateNewWeightForProgramWithWrongWeight(@"C:\dev\Jansson.AdventOfCode\src\2017\Jansson.AdventOfCode.2017\Jansson.AdventOfCode.2017.Day7.Tests\Day7TestInputPart1.txt")
                .Should().Be(60);

        }

        [Test]
        public void Day7_part2()
        {
            _recursiveCircus.CalculateNewWeightForProgramWithWrongWeight(@"C:\dev\Jansson.AdventOfCode\src\2017\Jansson.AdventOfCode.2017\Jansson.AdventOfCode.2017.Day7.Tests\Day7Input.txt")
                .Should().Be(521);
        }
    }
}
