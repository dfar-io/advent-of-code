using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode.Tests.S15;

public class S1509Tests
{
    [Test]
    public void S1509()
    {
        var input = new string[]
        {
            "London to Dublin = 464",
            "London to Belfast = 518",
            "Dublin to Belfast = 141"
        };
        var solver = new S1509(input);
        solver.Answer1.Should().Be("605");
        solver.Answer2.Should().Be("982");
    }
}