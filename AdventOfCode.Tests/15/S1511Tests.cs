using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode.Tests.S15;

public class S1511Tests
{
    [Test]
    public void S1511()
    {
        var solver = new S1511("abcdefgh");
        solver.Answer1.Should().Be("abcdffaa");
        solver.Answer2.Should().Be("abcdffbb");
    }
}