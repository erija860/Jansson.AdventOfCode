using FluentAssertions;
using NUnit.Framework;

namespace Jansson.AdventOfCode.DayThree.Tests
{
    [TestFixture]
    public class TriangleValidatorTests
    {
        private TriangleValidator _triangleValidator;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _triangleValidator = new TriangleValidator();
        }

        [Test]
        public void SomeTest()
        {
            _triangleValidator.GetNumberOfValidTriangles(
                    @"C:\dev\Jansson.AdventOfCode\src\Jansson.AdventOfCode.DayThree\Jansson.AdventOfCode.DayThree.Tests\TestInput.txt")
                .Should()
                .Be(3);
        }
    }
}