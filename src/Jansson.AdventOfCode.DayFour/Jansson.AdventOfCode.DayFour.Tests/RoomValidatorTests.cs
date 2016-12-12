using FluentAssertions;
using NUnit.Framework;

namespace Jansson.AdventOfCode.DayFour.Tests
{
    [TestFixture]
    public class RoomValidatorTests
    {
        private RoomValidator _validator;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _validator = new RoomValidator();
            
        }

        [Test]
        public void SomeTest()
        {
            _validator.GetSumOfSectorIdsOfRealRooms(
                @"C:\dev\Jansson.AdventOfCode\src\Jansson.AdventOfCode.DayFour\Jansson.AdventOfCode.DayFour.Tests\TestInput.txt").Should().Be(1614);
        }
    }
}