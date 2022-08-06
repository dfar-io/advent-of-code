using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode15.Tests;

public class Solver02Tests
{
    [Test]
    [TestCase("2x3x4", 58)]
    [TestCase("1x1x10", 43)]
    public void Solver02_P1(string input, int answer)
    {
        answer.Should().Be(new Solver02(input).Answer1);   
    }

    [Test]
    [TestCase("2x3x4", 34)]
    [TestCase("1x1x10", 14)]
    public void Solver02_P2(string input, int answer)
    {
        answer.Should().Be(new Solver02(input).Answer2);   
    }
}