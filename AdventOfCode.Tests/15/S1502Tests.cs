using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode.Tests.S15;

public class S1502Tests
{
    [Test]
    [TestCase(new string[] { "2x3x4" }, "58", "34")]
    [TestCase(new string[] { "1x1x10" }, "43", "14")]
    public void Solver02_P1(string[] input, string answer1, string answer2)
    {
        var solver = new S1502(input);
        answer1.Should().Be(solver.Answer1);
        answer2.Should().Be(solver.Answer2); 
    }
}