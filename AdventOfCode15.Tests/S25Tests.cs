using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode15.Tests;

public class S25Tests
{
    [Test]
    public void S25()
    {
        var solver = new S25("6,6");
        solver.Answer1.Should().Be("27995004");
    }
}