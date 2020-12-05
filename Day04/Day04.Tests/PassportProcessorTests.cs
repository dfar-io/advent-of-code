using FluentAssertions;
using NUnit.Framework;

namespace Day04.Tests
{
    public class PassportProcessorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Processes_Valid_Passport_Count()
        {
            var passports = PassportProcessor.FindValidPassportCount("test-data.txt");

            passports.Should().Be(2);
        }
    }
}