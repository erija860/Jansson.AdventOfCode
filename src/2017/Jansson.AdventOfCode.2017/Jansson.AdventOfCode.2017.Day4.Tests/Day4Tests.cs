using FluentAssertions;
using NUnit.Framework;

namespace Jansson.AdventOfCode._2017.Day4.Tests
{
    [TestFixture]
    public class Day4Tests
    {
        private PassphraseValidator _passphraseValidator;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _passphraseValidator = new PassphraseValidator();
        }

        [Test]
        public void Should_return_valid_count_test_input_part1()
        {
            _passphraseValidator.CalculateValidPassphraseCount(
                @"C:\dev\Jansson.AdventOfCode\src\2017\Jansson.AdventOfCode.2017\Jansson.AdventOfCode.2017.Day4.Tests\Part1TestInput.txt")
                .Should().Be(2);
        }

        [Test]
        public void Should_return_result_count_part1()
        {
            _passphraseValidator.CalculateValidPassphraseCount(
                @"C:\dev\Jansson.AdventOfCode\src\2017\Jansson.AdventOfCode.2017\Jansson.AdventOfCode.2017.Day4.Tests\InputFile.txt")
                .Should().Be(337);
        }

        [Test]
        public void Should_return_valid_count_test_input_part2()
        {
            _passphraseValidator.CalculateValidPassphraseCount(
                @"C:\dev\Jansson.AdventOfCode\src\2017\Jansson.AdventOfCode.2017\Jansson.AdventOfCode.2017.Day4.Tests\Part2TestInput.txt",
                false)
                .Should().Be(3);
        }

        [Test]
        public void Should_return_result_count_part2()
        {
            _passphraseValidator.CalculateValidPassphraseCount(@"C:\dev\Jansson.AdventOfCode\src\2017\Jansson.AdventOfCode.2017\Jansson.AdventOfCode.2017.Day4.Tests\InputFile.txt",
                false)
                .Should().Be(231);
        }
    }
}
