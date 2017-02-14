using System;
using FluentAssertions;
using NUnit.Framework;

namespace Jansson.AdventOfCode.DayFive.Tests
{
    [TestFixture]
    public class SecurityDoorCodeCrackerTests
    {
        private SecurityDoorCodeCracker _codeCracker;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _codeCracker = new SecurityDoorCodeCracker();
        }

        [Test]
        public void TestInput()
        {
            _codeCracker.CrackCode("abc").Should().Be("05ace8e3");
        }

        [Test]
        public void RealInput()
        {
            Console.WriteLine(_codeCracker.CrackCode("ffykfhsq"));
        }

    }
}