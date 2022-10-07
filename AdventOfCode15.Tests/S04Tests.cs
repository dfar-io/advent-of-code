using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode15.Tests;

public class S04Tests
{
    //[Test]
    [TestCase("abcdef", "609043", "6742839")]
    [TestCase("pqrstuv", "1048970", "5714438")]
    public void Solver04(string input, string answer1, string answer2)
    {
        var solver = new S04(input);
        answer1.Should().Be(solver.Answer1);
        answer2.Should().Be(solver.Answer2);  
    }
}