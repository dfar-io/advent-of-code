using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode.Tests.S15;

public class S1503Tests
{
    [Test]
    [TestCase("^>v<", "4", "3")]
    [TestCase("^v^v^v^v^v", "2", "11")]
    public void Solver03(string input, string answer1, string answer2)
    {
        var solver = new S1503(input);
        answer1.Should().Be(solver.Answer1);
        answer2.Should().Be(solver.Answer2);
    }
}