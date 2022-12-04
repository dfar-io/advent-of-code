using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode15.Tests;

public class S21Tests
{
    [Test]
    public void S21()
    {
        var solver = new S21(new string[]
        {
            "Hit Points: 12",
            "Damage: 7",
            "Armor: 2"
        }, 8);
        solver.Answer1.Should().Be("65");
        solver.Answer2.Should().Be("65");
    }
}