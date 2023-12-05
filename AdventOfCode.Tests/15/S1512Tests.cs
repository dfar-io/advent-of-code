using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode.Tests.S15;

public class S1512Tests
{
    [Test]
    [TestCase("[1,2,3]", 6)]
    [TestCase("{\"a\":2,\"b\":4}", 6)]
    [TestCase("[[[3]]]", 3)]
    [TestCase("{\"a\":{\"b\":4},\"c\":-1}", 3)]
    [TestCase("{\"a\":[-1,1]}", 0)]
    [TestCase("[-1,{\"a\":1}]", 0)]
    [TestCase("[]", 0)]
    [TestCase("{}", 0)]
    [TestCase("[1,{\"c\":\"red\",\"b\":2},3]", 4)]
    [TestCase("[1,\"red\",5]", 6)]
    public void S1512(string input, int answer)
    {
        var solver = new S1512(input);
        solver.Answer1.Should().Be(answer.ToString());
    }
}