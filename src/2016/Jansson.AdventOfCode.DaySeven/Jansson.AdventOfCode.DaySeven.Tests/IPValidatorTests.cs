using System;
using FluentAssertions;
using NUnit.Framework;

namespace Jansson.AdventOfCode.DaySeven.Tests
{
    [TestFixture]
    public class IPValidatorTests
    {
        [SetUp]
        public void SetUp()
        {
        }

        private IPValidator _validator;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _validator = new IPValidator();
            _validator.LoadIPs(
                @"C:\dev\Jansson.AdventOfCode\src\Jansson.AdventOfCode.DaySeven\Jansson.AdventOfCode.DaySeven\InputFile.txt");
        }

        [Test]
        public void SSL()
        {
            Console.WriteLine(
                _validator.GetNumberOfValidatedSslIps());
        }

        [Test]
        public void TLS()
        {
            Console.WriteLine(
                _validator.GetNumberOfValidatedTlsIps());
        }

        [Test]
        public void TLSTestInput()
        {
            _validator = new IPValidator();
            _validator.LoadIPs(
                @"C:\dev\Jansson.AdventOfCode\src\Jansson.AdventOfCode.DaySeven\Jansson.AdventOfCode.DaySeven\TestFile.txt");
            _validator.GetNumberOfValidatedTlsIps().Should().Be(2);
        }
    }
}