using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode.Tests.S15;

public class S1508Tests
{
    [Test]
    [TestCase(new string[] { "\"\"" }, 2, 0, 6)]
    [TestCase(new string[] { "\"abc\"" }, 5, 3, 9)]
    [TestCase(new string[] { "\"aaa\\\"aaa\"" }, 10, 7, 16)]
    [TestCase(new string[] { "\"\\x27\""}, 6, 1, 11)]
    public void S1508(string[] input, int charCount, int stringCount, int char2Count)
    {
        var solver = new S1508(input);
        solver.CharCount.Should().Be(charCount);
        solver.StringCount.Should().Be(stringCount);
    }
}