using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode15.Tests;

public class Solver03Tests
{
    [Test]
    [TestCase(">", 2)]
    [TestCase("^>v<", 4)]
    [TestCase("^v^v^v^v^v", 2)]
    public void Solver03_P1(string input, int answer)
    {
        answer.Should().Be(new Solver03(input).Answer1);   
    }

    [Test]
    [TestCase("^v", 3)]
    [TestCase("^>v<", 3)]
    [TestCase("^v^v^v^v^v", 11)]
    public void Solver03_P2(string input, int answer)
    {
        answer.Should().Be(new Solver03(input).Answer2);   
    }
}