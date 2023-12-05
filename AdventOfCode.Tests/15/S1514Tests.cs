using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode.Tests.S15;

public class S1514Tests
{
    [Test]
    public void S1514()
    {
        var data = new string[] {
            "Comet can fly 14 km/s for 10 seconds, but then must rest for 127 seconds.",
            "Dancer can fly 16 km/s for 11 seconds, but then must rest for 162 seconds."
        };
        var solver = new S1514(data, 1000);
        solver.Answer1.Should().Be("1120");
        solver.Answer2.Should().Be("689");
    }

    [Test]
    
    public void S1514_Loops_Correctly_Answer()
    {
        var data = new string[] {
            "Cupid can fly 8 km/s for 17 seconds, but then must rest for 114 seconds.",
            "Dancer can fly 1 km/s for 5 seconds, but then must rest for 200 seconds."
        };
        var solver = new S1514(data, 263);
        solver.Answer1.Should().Be("280");
    }
}