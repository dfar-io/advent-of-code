using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode15.Tests;

public class S19Tests
{
    [Test]
    public void S19()
    {
        var data = new string[] {
            "H => HO",
            "H => OH",
            "O => HH",
            "",
            "HOH"
        };
        var solver = new S19(data);
        solver.Answer1.Should().Be("4");
        solver.Answer2.Should().Be("3");
    }
}