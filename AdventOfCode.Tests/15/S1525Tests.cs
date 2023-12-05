using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode.Tests.S15;

public class S1525Tests
{
    [Test]
    public void S1525()
    {
        var solver = new S1525("6,6");
        solver.Answer1.Should().Be("27995004");
    }
}