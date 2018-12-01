using System.IO;
using FluentAssertions;
using NUnit.Framework;

namespace Jansson.AdventOfCode._2018.Day1.Tests
{
    [TestFixture]
    public class Day1Tests
    {
        private TimeTravelFrequencyCalculator _frequencyCalculator;

        [OneTimeSetUp]
        public void OneTImeSetUp()
        {
            _frequencyCalculator = new TimeTravelFrequencyCalculator();
        }

        [Test]
        [TestCase("Day1Part1TestFIle1.txt", 3)]
        [TestCase("Day1Part1TestFIle2.txt", 0)]
        [TestCase("Day1Part1TestFIle3.txt", -6)]
        public void Day1_testInput_part1(string filePath, int expectedScore)
        {
            var input = File.ReadAllLines(filePath);

            var result = _frequencyCalculator.CalculateDeviceFrequency(input);

            result.Should().Be(expectedScore);
        }

        [Test]
        public void Day1_result_part1()
        {
            var input = File.ReadAllLines("Day1Part1Input.txt");

            var result = _frequencyCalculator.CalculateDeviceFrequency(input);

            result.Should().Be(510);
        }


        [Test]
        [TestCase("Day1Part2TestFIle1.txt", 2)]
        [TestCase("Day1Part2TestFIle2.txt", 10)]
        [TestCase("Day1Part2TestFIle3.txt", 5)]
        public void Day1_testInput_part2(string filePath, int expectedScore)
        {
            var input = File.ReadAllLines(filePath);

            var result = _frequencyCalculator.CalculateDeviceFrequencyToFindDuplicates(input);

            result.Should().Be(expectedScore);
        }

        [Test]
        public void Day1_result_part2()
        {
            var input = File.ReadAllLines("Day1Part1Input.txt");

            var result = _frequencyCalculator.CalculateDeviceFrequencyToFindDuplicates(input);

            result.Should().Be(69074);
        }
    }
}
