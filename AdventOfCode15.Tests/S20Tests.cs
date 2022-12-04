using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode15.Tests;

public class S20Tests
{
    [Test]
    public void S20()
    {
        var solver = new S20("150");
        solver.Answer1.Should().Be("8");
    }
}