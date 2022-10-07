using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode15.Tests;

public class S09Tests
{
    //[Test]
    public void S09()
    {
        var input = new string[]
        {
            "London to Dublin = 464",
            "London to Belfast = 518",
            "Dublin to Belfast = 141"
        };
        var solver = new S09(input);
        solver.Answer1.Should().Be("605");
        solver.Answer2.Should().Be("982");
    }
}