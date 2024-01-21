using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode.Tests.S16;

public class S1601Tests
{
    [Test]
    [TestCase("R2, L3", "5")]
    [TestCase("R2, R2, R2", "2")]
    [TestCase("R5, L5, R5, R3", "12")]
    [TestCase("L5, L5", "10")]
    [TestCase("L10", "10")]
    public void P1(string input, string answer)
    {
        answer.Should().Be(new S1601(input).Answer1);   
    }
}