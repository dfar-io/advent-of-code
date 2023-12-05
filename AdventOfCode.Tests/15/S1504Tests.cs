using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode.Tests.S15;

public class S1504Tests
{
    [Test]
    [TestCase("abcdef", "6742839")]
    [TestCase("pqrstuv", "5714438")]
    public void Solver04(string input, string answer2)
    {
        var solver = new S1504(input);
        answer2.Should().Be(solver.Answer2);  
    }
}