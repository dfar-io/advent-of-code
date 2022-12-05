using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode15.Tests;

public class S04Tests
{
    [Test]
    [TestCase("abcdef", "6742839")]
    [TestCase("pqrstuv", "5714438")]
    public void Solver04(string input, string answer2)
    {
        var solver = new S04(input);
        answer2.Should().Be(solver.Answer2);  
    }
}