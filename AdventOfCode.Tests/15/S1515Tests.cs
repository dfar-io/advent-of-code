using NUnit.Framework;
using FluentAssertions;

namespace AdventOfCode.Tests.S15;

public class S1515Tests
{
    [Test]
    public void S1515()
    {
        var data = new string[] {
            "Butterscotch: capacity -1, durability -2, flavor 6, texture 3, calories 8",
            "Cinnamon: capacity 2, durability 3, flavor -2, texture -1, calories 3",
            "FakeIngredient1: capacity 0, durability 0, flavor 0, texture 0, calories 0",
            "FakeIngredient2: capacity 0, durability 0, flavor 0, texture 0, calories 0"
        };
        var solver = new S1515(data);
        solver.Answer1.Should().Be("62842880");
    }
}