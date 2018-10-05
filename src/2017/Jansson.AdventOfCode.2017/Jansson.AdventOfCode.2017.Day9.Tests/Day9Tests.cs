using System.IO;
using FluentAssertions;
using NUnit.Framework;

namespace Jansson.AdventOfCode._2017.Day9.Tests
{
    [TestFixture]
    public class Day9Tests
    {
        private StreamProcessing _streamProcessor;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _streamProcessor = new StreamProcessing();
        }

        [Test]
        [TestCase("{}", 1)]
        [TestCase("{{{}}}", 6)]
        [TestCase("{{},{}}", 5)]
        [TestCase("{{{},{},{{}}}}", 16)]
        [TestCase("{<a>,<a>,<a>,<a>}", 1)]
        [TestCase("{{<ab>},{<ab>},{<ab>},{<ab>}}", 9)]
        [TestCase("{{<!!>},{<!!>},{<!!>},{<!!>}}", 9)]
        [TestCase("{{<a!>},{<a!>},{<a!>},{<ab>}}", 3)]
        public void Day9_testInput_part1(string input, int expectedScore)
        {
            var result = _streamProcessor.Cleanup(input.ToCharArray());

            result
                .Score
                .Should()
                .Be(expectedScore);
        }

        [Test]
        public void Day9_result_part1()
        {
            var input = File
                .ReadAllText(
                    @"C:\dev\Jansson.AdventOfCode\src\2017\Jansson.AdventOfCode.2017\Jansson.AdventOfCode.2017.Day9.Tests\Day9Input.txt")
                .ToCharArray();

            var result = _streamProcessor.Cleanup(input);

            result.Score.Should().Be(8337);
        }

        [Test]
        [TestCase("<>", 0)]
        [TestCase("<random characters>", 17)]
        [TestCase("<<<<>", 3)]
        [TestCase("<{!>}>", 2)]
        [TestCase("<!!>", 0)]
        [TestCase("<!!!>>", 0)]
        public void Day9_testInput_part2(string input, int expectedScore)
        {
            var result = _streamProcessor.Cleanup(input.ToCharArray());

            result
                .RemovedCharacters
                .Should()
                .Be(expectedScore);
        }

        [Test]
        public void Day9_result_part2()
        {
            var input = File
                .ReadAllText(
                    @"C:\dev\Jansson.AdventOfCode\src\2017\Jansson.AdventOfCode.2017\Jansson.AdventOfCode.2017.Day9.Tests\Day9Input.txt")
                .ToCharArray();

            var result = _streamProcessor.Cleanup(input);

            result.RemovedCharacters.Should().Be(4330);
        }
    }
}