using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode15.Tests;

public class S22Tests
{
    [Test]
    public void S22()
    {
        var solver = new S22(new string[]
        {
            "Hit Points: 58",
            "Damage: 9"
        });
        solver.Answer1.Should().Be("65");
    }
}