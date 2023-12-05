using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode.Tests.S15;

public class S1501Tests
{
    [Test]
    [TestCase("(())", "0")]
    [TestCase("()()", "0")]
    [TestCase("(((", "3")]
    [TestCase("(()(()(", "3")]
    [TestCase("))(((((", "3")]
    [TestCase("())", "-1")]
    [TestCase("))(", "-1")]
    [TestCase(")))", "-3")]
    [TestCase(")())())", "-3")]
    public void Solver01_P1(string input, string answer)
    {
        answer.Should().Be(new S1501(input).Answer1);   
    }

    [Test]
    [TestCase(")", "1")]
    [TestCase("()())", "5")]
    public void Solver01_P2(string input, string answer)
    {
        answer.Should().Be(new S1501(input).Answer2);   
    }
}