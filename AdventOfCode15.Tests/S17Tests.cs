using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode15.Tests;

public class S17Tests
{
    [Test]
    public void S17()
    {
        var data = new string[] {
            "100", "20", "15", "10", "5", "5"
        };
        var solver = new S17(data);
        solver.Answer1.Should().Be("2");
        solver.Answer2.Should().Be("2");
    }
}