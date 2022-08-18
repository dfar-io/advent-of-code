using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode15.Tests;

public class S05Tests
{
    [Test]
    [TestCase(new string[] { "ugknbfddgicrmopn" }, 1)]
    [TestCase(new string[] { "aaa" }, 1)]
    [TestCase(new string[] { "jchzalrnumimnmhp" }, 0)]
    [TestCase(new string[] { "haegwjzuvuyypxyu" }, 0)]
    [TestCase(new string[] { "dvszwmarrgswjxmb" }, 0)]
    public void S05P1(string[] input, int answer)
    {
        answer.Should().Be(new S05(input).Answer1);   
    }

    [Test]
    [TestCase(new string[] { "qjhvhtzxzqqjkmpb" }, 1)]
    [TestCase(new string[] { "xxyxx" }, 1)]
    [TestCase(new string[] { "uurcxstgmygtbstg" }, 0)]
    [TestCase(new string[] { "ieodomkazucvgmuy" }, 0)]
    public void S05P2(string[] input, int answer)
    {
        answer.Should().Be(new S05(input).Answer2);   
    }
}