using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode15.Tests;

public class S08Tests
{
    [Test]
    [TestCase(new string[] { "\"\"" }, 2, 0, 6)]
    [TestCase(new string[] { "\"abc\"" }, 5, 3, 9)]
    [TestCase(new string[] { "\"aaa\\\"aaa\"" }, 10, 7, 16)]
    [TestCase(new string[] { "\"\\x27\""}, 6, 1, 11)]
    public void S08(string[] input, int charCount, int stringCount, int char2Count)
    {
        var solver = new S08(input);
        solver.CharCount.Should().Be(charCount);
        solver.StringCount.Should().Be(stringCount);
    }
}