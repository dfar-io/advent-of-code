using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode.Tests.S15;

public class S1516Tests
{
    [Test]
    public void S1516()
    {
        var data = new string[] {
            "Sue 258: cats: 7, trees: 0, vizslas: 1",
            "Sue 259: perfumes: 7, cars: 7, akitas: 7",
            "Sue 260: goldfish: 0, vizslas: 0, samoyeds: 2",
            "Sue 261: vizslas: 2, children: 2, cats: 3",
            "Sue 262: vizslas: 2, pomeranians: 9, samoyeds: 3",
            "Sue 263: cats: 1, akitas: 3, vizslas: 1",
            "Sue 264: pomeranians: 10, trees: 2, goldfish: 7"
        };
        var solver = new S1516(data);
        solver.Answer2.Should().Be("260");
    }
}