using System;
using FluentAssertions;
using NUnit.Framework;

namespace Jansson.AdventOfCode.DayNine.Tests
{
    [TestFixture]
    public class CompressedFileCalculatorTests
    {
        private CompressedFileCalculator _calculator;

        [Test]
        public void SomeTest2()
        {
            _calculator =
                new CompressedFileCalculator(
                    @"C:\dev\Jansson.AdventOfCode\src\Jansson.AdventOfCode.DayNine\Jansson.AdventOfCode.DayNine\InputFile.txt");
            Console.WriteLine(_calculator.GetDecompressedLengthRecursive());
        }

        [Test]
        public void Test_input()
        {
            _calculator =
                new CompressedFileCalculator(
                    @"C:\dev\Jansson.AdventOfCode\src\Jansson.AdventOfCode.DayNine\Jansson.AdventOfCode.DayNine\TestFile.txt");
            _calculator.GetDecompressedLengthRecursive().Should().Be(445);
        }

        [Test]
        public void Test_input2()
        {
            _calculator =
                new CompressedFileCalculator(
                    @"C:\dev\Jansson.AdventOfCode\src\Jansson.AdventOfCode.DayNine\Jansson.AdventOfCode.DayNine\SecondTestFile.txt");
            _calculator.GetDecompressedLengthRecursive().Should().Be(241920);
        }

        [Test]
        public void Test_input3()
        {
            _calculator =
                new CompressedFileCalculator(
                    @"C:\dev\Jansson.AdventOfCode\src\Jansson.AdventOfCode.DayNine\Jansson.AdventOfCode.DayNine\TestInput3.txt");
            _calculator.GetDecompressedLengthRecursive().Should().Be(9);
        }
    }
}