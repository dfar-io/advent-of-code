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
            "a LSHIFT 2 -> f",
            "y RSHIFT 2 -> g",
            "123 -> a",
            "456 -> y",
            "a AND y -> d",
            "a OR y -> e",
            "NOT a -> h",
            "NOT y -> i"
        };
        var solver = new S07(input);
        solver.GetWireValue("d").Should().Be(72);
        solver.GetWireValue("e").Should().Be(507);
        solver.GetWireValue("f").Should().Be(492);
        solver.GetWireValue("g").Should().Be(114);
        solver.GetWireValue("h").Should().Be(65412);
        solver.GetWireValue("i").Should().Be(65079);
        solver.GetWireValue("a").Should().Be(123);
        solver.GetWireValue("y").Should().Be(456);
    }
}