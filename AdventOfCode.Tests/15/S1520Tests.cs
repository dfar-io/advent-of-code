using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode.Tests.S15;

public class S1520Tests
{
    [Test]
    public void S1520()
    {
        var solver = new S1520("150");
        solver.Answer1.Should().Be("8");
    }
}