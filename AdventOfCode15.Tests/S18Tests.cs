using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode15.Tests;

public class S18Tests
{
    [Test]
    public void S18()
    {
        var data = new string[] {
            "##.#.#",
            "...##.",
            "#....#",
            "..#...",
            "#.#..#",
            "####.#"
        };
        var solver = new S18(data, 5);
        solver.Answer1.Should().Be("17");
    }
}