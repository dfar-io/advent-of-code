using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode.Tests.S15;

public class S1523Tests
{
    [Test]
    public void S1523()
    {
        var solver = new S1523(new string[]
        {
            "inc b",
            "jio b, +2",
            "tpl b",
            "inc b"
        });
        solver.Answer1.Should().Be("2");
    }
}