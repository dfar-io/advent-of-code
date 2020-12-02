using FluentAssertions;
using NUnit.Framework;

namespace Day02.Tests
{
    public class PasswordRecordTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("1-3 a: abcde", 1, 3, 'a', "abcde")]
        [TestCase("1-3 b: cdefg", 1, 3, 'b', "cdefg")]
        [TestCase("2-9 c: ccccccccc", 2, 9, 'c', "ccccccccc")]
        public void Converts_Record_To_PasswordRecordPartOne(
            string record,
            int minLetterCount,
            int maxLetterCount,
            char letter,
            string password
        )
        {
            var passwordRecord = new PasswordRecordPartOne(record);

            passwordRecord.MinimumLetterCount.Should().Be(minLetterCount);
            passwordRecord.MaximumLetterCount.Should().Be(maxLetterCount);
            passwordRecord.Letter.Should().Be(letter);
            passwordRecord.Password.Should().Be(password);
        }

        [Test]
        [TestCase("1-3 a: abcde", 1, 3, 'a', "abcde")]
        [TestCase("1-3 b: cdefg", 1, 3, 'b', "cdefg")]
        [TestCase("2-9 c: ccccccccc", 2, 9, 'c', "ccccccccc")]
        public void Converts_Record_To_PasswordRecordPartTwo(
            string record,
            int position1,
            int position2,
            char letter,
            string password
        )
        {
            var passwordRecord = new PasswordRecordPartTwo(record);

            passwordRecord.Position1.Should().Be(position1);
            passwordRecord.Position2.Should().Be(position2);
            passwordRecord.Letter.Should().Be(letter);
            passwordRecord.Password.Should().Be(password);
        }

        [Test]
        [TestCase("1-3 a: abcde", true)]
        [TestCase("1-3 b: cdefg", false)]
        [TestCase("2-9 c: ccccccccc", true)]
        public void Determines_If_Valid_Password_PartOne(
            string record,
            bool isValid
        )
        {
            var passwordRecord = new PasswordRecordPartOne(record);

            passwordRecord.IsValid().Should().Be(isValid);
        }

        [Test]
        [TestCase("1-3 a: abcde", true)]
        [TestCase("1-3 b: cdefg", false)]
        [TestCase("2-9 c: ccccccccc", false)]
        public void Determines_If_Valid_Password_PartTwo(
            string record,
            bool isValid
        )
        {
            var passwordRecord = new PasswordRecordPartTwo(record);

            passwordRecord.IsValid().Should().Be(isValid);
        }
    }
}