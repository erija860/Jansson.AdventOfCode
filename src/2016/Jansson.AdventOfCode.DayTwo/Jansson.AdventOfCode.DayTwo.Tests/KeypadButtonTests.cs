using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Jansson.AdventOfCode.DayTwo.Tests
{
    [TestFixture]
    public class KeypadButtonTests
    {
        private Dictionary<string, IKeypadButton> _buttons;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _buttons = new Dictionary<string, IKeypadButton>
            {
                {"1", new KeypadButton("1", "1", "1", "1", "2")},
                {"2", new KeypadButton("2", "2", "2", "1", "3")},
                {"3", new KeypadButton("3", "3", "3", "2", "3")}
            };
        }

        [Test]
        public void Should_keep_position_when_moving_down()
        {
            _buttons["2"].TryWalkDown().Should().Be("2");
        }

        [Test]
        public void Should_keep_position_when_moving_left()
        {
            _buttons["1"].TryWalkLeft().Should().Be("1");
        }

        [Test]
        public void Should_keep_position_when_moving_up()
        {
            _buttons["3"].TryWalkUp().Should().Be("3");
        }

        [Test]
        public void Should_move_left()
        {
            _buttons["2"].TryWalkLeft().Should().Be("1");
        }

        [Test]
        public void Should_move_right()
        {
            _buttons["1"].TryWalkRight().Should().Be("2");
        }
    }
}