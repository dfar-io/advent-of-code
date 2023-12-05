using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode.Tests.S15;

public class S1506Tests
{
    [Test]
    [TestCase(new string[] { "turn on 0,0 through 999,999" }, "1000000")]
    [TestCase(new string[] { "turn on 0,0 through 999,999", "toggle 0,0 through 999,0" }, "999000")]
    [TestCase(new string[] { "turn on 0,0 through 999,999", "turn off 499,499 through 500,500" }, "999996")]
    public void S1506P1(string[] input, string answer)
    {
        answer.Should().Be(new S1506(input).Answer1);   
    }

    [Test]
    [TestCase(new string[] { "turn on 0,0 through 0,0" }, "1")]
    [TestCase(new string[] { "toggle 0,0 through 999,999" }, "2000000")]
    public void S1506P2(string[] input, string answer)
    {
        answer.Should().Be(new S1506(input).Answer2);   
    }
}