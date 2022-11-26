using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode15.Tests;

public class S14Tests
{
    [Test]
    public void S14()
    {
        var data = new string[] {
            "Comet can fly 14 km/s for 10 seconds, but then must rest for 127 seconds.",
            "Dancer can fly 16 km/s for 11 seconds, but then must rest for 162 seconds."
        };
        var solver = new S14(data, 1000);
        solver.Answer1.Should().Be("1120");
    }
}