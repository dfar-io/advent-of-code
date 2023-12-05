using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode.Tests.S15;

public class S1521Tests
{
    [Test]
    public void S1521()
    {
        var solver = new S1521(new string[]
        {
            "Hit Points: 12",
            "Damage: 7",
            "Armor: 2"
        }, 8);
        solver.Answer1.Should().Be("65");
        solver.Answer2.Should().Be("188");
    }
}