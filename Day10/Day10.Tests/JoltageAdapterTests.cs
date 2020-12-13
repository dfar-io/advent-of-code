using FluentAssertions;
using NUnit.Framework;

namespace Day10.Tests
{
    public class JoltageAdapterTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Initializes_JoltageAdapter_Correctly()
        {
            var joltageAdapter = new JoltageAdapter(16);

            joltageAdapter.OutputJoltage.Should().Be(16);
        }

        [Test]
        [TestCase(12, false)]
        [TestCase(13, true)]
        [TestCase(14, true)]
        [TestCase(15, true)]
        [TestCase(16, false)]
        [TestCase(17, false)]
        public void CanTake(int input, bool result)
        {
            var joltageAdapter = new JoltageAdapter(16);

            joltageAdapter.CanTake(input).Should().Be(result);
        }
    }
}