using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode.Tests.S15;

public class S1519Tests
{
    [Test]
    public void S1519()
    {
        var data = new string[] {
            "e => H",
            "e => O",
            "H => HO",
            "H => OH",
            "O => HH",
            "",
            "HOH"
        };
        var solver = new S1519(data);
        solver.Answer1.Should().Be("4");
        solver.Answer2.Should().Be("3");
    }
}