using FluentAssertions;
using NUnit.Framework;

namespace Jansson.AdventOfCode.DayTwo.Tests
{
    [TestFixture]
    public class KeypadTests
    {
        private KeypadPartOne _keypad;

        [SetUp]
        public void SetUp()
        {
            _keypad = new KeypadPartOne();
        }

        [Test]
        public void Should_move_up()
        {
            _keypad.Walk('U');
            _keypad.CurrentPosition.Name.Should().Be("2");
        }

        [Test]
        public void Should_move_down()
        {
            _keypad.Walk('D');
            _keypad.CurrentPosition.Name.Should().Be("8");
        }

        [Test]
        public void Should_move_left()
        {
            _keypad.Walk('L');
            _keypad.CurrentPosition.Name.Should().Be("4");
        }

        [Test]
        public void Should_move_right()
        {
            _keypad.Walk('R');
            _keypad.CurrentPosition.Name.Should().Be("6");
        }
    }
}