using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode15.Tests;

public class S02Tests
{
    //[Test]
    [TestCase(new string[] { "2x3x4" }, "58", "34")]
    [TestCase(new string[] { "1x1x10" }, "43", "14")]
    public void Solver02_P1(string[] input, string answer1, string answer2)
    {
        var solver = new S02(input);
        answer1.Should().Be(solver.Answer1);
        answer2.Should().Be(solver.Answer2); 
    }
}