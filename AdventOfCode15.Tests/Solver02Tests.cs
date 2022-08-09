using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode15.Tests;

public class Solver02Tests
{
    [Test]
    [TestCase("2x3x4", 58, 34)]
    [TestCase("1x1x10", 43, 14)]
    public void Solver02_P1(string input, int answer1, int answer2)
    {
        var solver = new Solver02(input);
        answer1.Should().Be(solver.Answer1);
        answer2.Should().Be(solver.Answer2); 
    }
}