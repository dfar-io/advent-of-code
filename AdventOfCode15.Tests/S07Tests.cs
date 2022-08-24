using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode15.Tests;

public class S07Tests
{
    [Test]
    public void S07P1()
    {
        var input = new string[]
        {
            "123 -> x",
            "456 -> y",
            "x AND y -> d",
            "x OR y -> e",
            "x LSHIFT 2 -> f",
            "y RSHIFT 2 -> g",
            "NOT x -> h",
            "NOT y -> i"
        };
        var solver = new S07(input);
        solver.GetValue("d").Should().Be(72);
        solver.GetValue("e").Should().Be(507);
        solver.GetValue("f").Should().Be(492);
        solver.GetValue("g").Should().Be(114);
        solver.GetValue("h").Should().Be(65412);
        solver.GetValue("i").Should().Be(65079);
        solver.GetValue("x").Should().Be(123);
        solver.GetValue("y").Should().Be(456);
    }
}