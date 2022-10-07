using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode15.Tests;

public class S10Tests
{
    [Test]
    public void S10()
    {
        var solver = new S10("1113122113");
        solver.Answer1.Should().Be(5103798);
    }
}