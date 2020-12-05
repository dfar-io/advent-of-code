using FluentAssertions;
using NUnit.Framework;

namespace Day04.Tests
{
    public class PassportReaderTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Returns_Passports()
        {
            var passports = PassportReader.ReadData("test-data.txt");

            passports.Should().BeOfType<Passport[]>();
            passports.Should().HaveCount(4);
        }
    }
}