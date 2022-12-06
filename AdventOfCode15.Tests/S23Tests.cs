using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode15.Tests;

public class S23Tests
{
    [Test]
    public void S23()
    {
        var solver = new S23(new string[]
        {
            "inc b",
            "jio b, +2",
            "tpl b",
            "inc b"
        });
        solver.Answer1.Should().Be("2");
    }
}