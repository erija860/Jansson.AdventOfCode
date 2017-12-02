using FluentAssertions;
using NUnit.Framework;

namespace Jansson.AdventOfCode._2017.Day1.Tests
{
    [TestFixture]
    public class Day1Tests
    {
        [SetUp]
        public void OneTimeSetUp()
        {
            _calculator = new CaptchaSumCalculator();
        }

        private CaptchaSumCalculator _calculator;

        [Test]
        [TestCase("1234", 0)]
        [TestCase("1122", 3)]
        [TestCase("1111", 4)]
        [TestCase("91212129", 9)]
        public void Should_return_correct_sum_part1(string input, int expectedResult)
        {
            var result = _calculator.CalculateCaptchaSum_part1(input);
            result.Should().Be(expectedResult);
        }

        [Test]
        [TestCase("1234", 0)]
        [TestCase("1221", 0)]
        [TestCase("1212", 6)]
        [TestCase("1111", 4)]
        [TestCase("123123", 12)]
        public void Should_return_correct_sum_part2(string input, int expectedResult)
        {
            var result = _calculator.CalculateCaptchaSum_part2(input);
            result.Should().Be(expectedResult);
        }
    }
}