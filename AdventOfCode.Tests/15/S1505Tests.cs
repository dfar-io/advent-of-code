using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode.Tests.S15;

public class S1505Tests
{
    [Test]
    [TestCase(new string[] { "ugknbfddgicrmopn" }, "1")]
    [TestCase(new string[] { "aaa" }, "1")]
    [TestCase(new string[] { "jchzalrnumimnmhp" }, "0")]
    [TestCase(new string[] { "haegwjzuvuyypxyu" }, "0")]
    [TestCase(new string[] { "dvszwmarrgswjxmb" }, "0")]
    public void S1505P1(string[] input, string answer)
    {
        answer.Should().Be(new S1505(input).Answer1);   
    }

    [Test]
    [TestCase(new string[] { "qjhvhtzxzqqjkmpb" }, "1")]
    [TestCase(new string[] { "xxyxx" }, "1")]
    [TestCase(new string[] { "uurcxstgmygtbstg" }, "0")]
    [TestCase(new string[] { "ieodomkazucvgmuy" }, "0")]
    public void S1505P2(string[] input, string answer)
    {
        answer.Should().Be(new S1505(input).Answer2);   
    }
}