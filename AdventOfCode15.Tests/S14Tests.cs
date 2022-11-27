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

    [Test]
    
    public void S14_Loops_Correctly_Answer()
    {
        var data = new string[] {
            "Cupid can fly 8 km/s for 17 seconds, but then must rest for 114 seconds.",
            "Dancer can fly 1 km/s for 5 seconds, but then must rest for 200 seconds."
        };
        var solver = new S14(data, 263);
        solver.Answer1.Should().Be("278");
    }
}