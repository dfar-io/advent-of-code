using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode15.Tests;

public class S24Tests
{
    [Test]
    public void S24()
    {
        var solver = new S24(new string[]
        {
            "1",
            "2",
            "3",
            "4",
            "5",
            "7",
            "8",
            "9",
            "10",
            "11",
        });
        solver.Answer1.Should().Be("99");
    }
}