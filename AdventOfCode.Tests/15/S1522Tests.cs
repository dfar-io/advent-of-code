using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode.Tests.S15;

public class S1522Tests
{
    [Test]
    public void S1522()
    {
        var solver = new S1522(new string[]
        {
            "Hit Points: 58",
            "Damage: 9"
        });
        solver.Answer1.Should().Be("1309");
    }
}