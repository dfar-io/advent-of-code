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
            "123 -> a",
            "456 -> y",
            "a AND y -> d",
            "a OR y -> e",
            "a LSHIFT 2 -> f",
            "y RSHIFT 2 -> g",
            "NOT a -> h",
            "NOT y -> i"
        };
        var solver = new S07(input);
        solver.GetWireValue("d").Value.Should().Be(72);
        solver.GetWireValue("e").Value.Should().Be(507);
        solver.GetWireValue("f").Value.Should().Be(492);
        solver.GetWireValue("g").Value.Should().Be(114);
        solver.GetWireValue("h").Value.Should().Be(65412);
        solver.GetWireValue("i").Value.Should().Be(65079);
        solver.GetWireValue("a").Value.Should().Be(123);
        solver.GetWireValue("y").Value.Should().Be(456);
    }
}