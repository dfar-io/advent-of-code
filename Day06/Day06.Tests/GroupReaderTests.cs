using FluentAssertions;
using NUnit.Framework;

namespace Day06.Tests
{
    public class GroupReaderTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Reads_Correct_Group_Count()
        {
            var groups = GroupReader.ReadData("test-data.txt");

            groups.Should().HaveCount(5);
        }
    }
}