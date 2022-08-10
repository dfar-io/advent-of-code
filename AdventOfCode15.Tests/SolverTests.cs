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

    [Test]
    [TestCase(new string[] { "2x3x4" }, 58, 34)]
    [TestCase(new string[] { "1x1x10" }, 43, 14)]
    public void Solver02_P1(string[] input, int answer1, int answer2)
    {
        var solver = new Solver02(input);
        answer1.Should().Be(solver.Answer1);
        answer2.Should().Be(solver.Answer2); 
    }

    [Test]
    [TestCase("^>v<", 4, 3)]
    [TestCase("^v^v^v^v^v", 2, 11)]
    public void Solver03(string input, int answer1, int answer2)
    {
        var solver = new Solver03(input);
        answer1.Should().Be(solver.Answer1);
        answer2.Should().Be(solver.Answer2);
    }

    [Test]
    [TestCase("abcdef", 609043, 6742839)]
    [TestCase("pqrstuv", 1048970, 5714438)]
    public void Solver04(string input, int answer1, int answer2)
    {
        var solver = new Solver04(input);
        answer1.Should().Be(solver.Answer1);
        answer2.Should().Be(solver.Answer2);  
    }
}