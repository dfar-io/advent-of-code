using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode15.Tests;

public class S16Tests
{
    [Test]
    public void S16()
    {
        var data = new string[] {
            "Sue 369: trees: 1, goldfish: 8, cars: 8",
            "Sue 370: vizslas: 0, cars: 2, perfumes: 5",
            "Sue 371: trees: 2, cars: 3, vizslas: 8",
            "Sue 372: trees: 10, children: 9, cats: 1",
            "Sue 373: pomeranians: 3, perfumes: 1, vizslas: 0"
        };
        var solver = new S16(data);
        solver.Answer1.Should().Be("373");
    }
}