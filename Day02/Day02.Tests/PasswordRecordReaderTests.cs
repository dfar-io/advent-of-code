using FluentAssertions;
using NUnit.Framework;

namespace Day02.Tests
{
    public class PasswordRecordReaderTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Returns_Password_Data()
        {
            var passwordRecords = PasswordRecordReader.ReadData("test-data.txt");

            passwordRecords.Should().HaveCount(3);
            passwordRecords.Should().AllBeOfType<PasswordRecordPartTwo>();
        }
    }
}