using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode15.Tests;

public class S11Tests
{
    [Test]
    public void S11()
    {
        var solver = new S11("abcdefgh");
        solver.Answer1.Should().Be("abcdffaa");
        solver.Answer2.Should().Be("abcdffbb");
    }
}