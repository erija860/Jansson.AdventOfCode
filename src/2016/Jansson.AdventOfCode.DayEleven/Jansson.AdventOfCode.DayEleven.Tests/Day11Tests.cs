using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Jansson.AdventOfCode.DayEleven.Tests
{
    [TestFixture]
    public class Day11Tests
    {
        private GeneratorElevatorCalculator _elevatorCalculator;

        [SetUp]
        public void SetUp()
        {
            _elevatorCalculator = new GeneratorElevatorCalculator();
        }

        [Test]
        public void Test_input_should_return_correct_result_part1()
        {
            var floors = new List<Floor>()
            {
                new Floor("F4", ".", ".", ".", ".", "."),
                new Floor("F3", ".", ".", ".", "LG", "."),
                new Floor("F2", ".", "HG", ".", ".", "."),
                new Floor("F1", "E", ".", "HM", ".", "LM")
            };

            _elevatorCalculator
                .CalculateMinimumStepsToReachFloor4(floors)
                .Should()
                .Be(11);
        }
    }
}