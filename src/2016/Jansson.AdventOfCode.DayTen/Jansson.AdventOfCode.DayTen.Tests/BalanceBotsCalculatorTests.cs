using FluentAssertions;
using NUnit.Framework;

namespace Jansson.AdventOfCode.DayTen.Tests
{
    [TestFixture]
    public class BalanceBotsCalculatorTests
    {
        [Test]
        public void Get_result_part1()
        {
            var calculator =
                new BalanceBotsCalculator(
                    @"C:\dev\Jansson.AdventOfCode\src\2016\Jansson.AdventOfCode.DayTen\Jansson.AdventOfCode.DayTen.Tests\InputFile.txt",
                    17, 61);

            calculator.GetBotThatHandlesGivenNumbers().Should().Be("113");
        }

        [Test]
        public void Get_test_result_part1()
        {
            var calculator =
                new BalanceBotsCalculator(
                    @"C:\dev\Jansson.AdventOfCode\src\2016\Jansson.AdventOfCode.DayTen\Jansson.AdventOfCode.DayTen.Tests\TestInputPart1.txt",
                    2, 5);

            calculator.GetBotThatHandlesGivenNumbers().Should().Be("2");
        }

        [Test]
        public void Get_result_part2()
        {
            var calculator =
                new BalanceBotsCalculator(
                    @"C:\dev\Jansson.AdventOfCode\src\2016\Jansson.AdventOfCode.DayTen\Jansson.AdventOfCode.DayTen.Tests\InputFile.txt",
                    17, 61);

            calculator.GetBotThatHandlesGivenNumbers().Should().Be("113");
            calculator.Part2Result().Should().Be("12803");
        }
    }
}