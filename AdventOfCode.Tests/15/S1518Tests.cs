using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode.Tests.S15;

public class S1518Tests
{
    [Test]
    public void S1518()
    {
        var data = new string[] {
            "##.#.#",
            "...##.",
            "#....#",
            "..#...",
            "#.#..#",
            "####.#"
        };
        var solver = new S1518(data, 5);
        solver.Answer1.Should().Be("17");
    }
}