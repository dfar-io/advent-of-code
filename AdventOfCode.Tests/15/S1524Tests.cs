using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode.Tests.S15;

public class S1524Tests
{
    [Test]
    public void S1524()
    {
        var solver = new S1524(new string[]
        {
            "1",
            "2",
            "3",
            "4",
            "5",
            "7",
            "8",
            "9",
            "10",
            "11",
        });
        solver.Answer1.Should().Be("44");
    }
}