using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode.Tests.S15;

public class S1517Tests
{
    [Test]
    public void S1517()
    {
        var data = new string[] {
            "100", "20", "15", "10", "5", "5"
        };
        var solver = new S1517(data);
        solver.Answer1.Should().Be("2");
        solver.Answer2.Should().Be("2");
    }
}