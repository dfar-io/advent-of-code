using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode15.Tests;

public class Solver01Tests
{
    [Test]
    [TestCase("(())", 0)]
    [TestCase("()()", 0)]
    [TestCase("(((", 3)]
    [TestCase("(()(()(", 3)]
    [TestCase("))(((((", 3)]
    [TestCase("())", -1)]
    [TestCase("))(", -1)]
    [TestCase(")))", -3)]
    [TestCase(")())())", -3)]
    public void Solver01_P1(string input, int answer)
    {
        answer.Should().Be(new Solver01(input).Answer1);   
    }

    [Test]
    [TestCase(")", 1)]
    [TestCase("()())", 5)]
    public void Solver01_P2(string input, int answer)
    {
        answer.Should().Be(new Solver01(input).Answer2);   
    }
}