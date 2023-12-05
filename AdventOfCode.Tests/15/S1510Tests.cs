using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode.Tests.S15;

public class S1510Tests
{
    [Test]
    public void S1510()
    {
        var solver = new S1510("1113122113");
        solver.Answer2.Should().Be("5103798");
    }
}