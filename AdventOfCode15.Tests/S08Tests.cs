using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode15.Tests;

public class S08Tests
{
    [Test]
    [TestCase(new string[] { "" }, 2, 0)]
    [TestCase(new string[] { "abc" }, 5, 3)]
    [TestCase(new string[] { "aaa\"aaa" }, 10, 7)]
    [TestCase(new string[] { "\x27"}, 6, 1)]
    public void S08P1(string[] input, int charCount, int stringCount)
    {
        var solver = new S08(input);
        solver.CharCount.Should().Be(charCount);
        solver.StringCount.Should().Be(stringCount);
    }
}