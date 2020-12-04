using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Day03.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(1, 1, 2)]
        [TestCase(3, 1, 7)]
        [TestCase(5, 1, 3)]
        [TestCase(7, 1, 4)]
        [TestCase(1, 2, 2)]
        public void Gets_Correct_Tree_Count(int right, int down, int answer)
        {
            var data = new List<string>()
            {
                "..##.......",
                "#...#...#..",
                ".#....#..#.",
                "..#.#...#.#",
                ".#...##..#.",
                "..#.##.....",
                ".#.#.#....#",
                ".#........#",
                "#.##...#...",
                "#...##....#",
                ".#..#...#.#"
            }.ToArray();
            var map = new Map(data);

            map.GetTreeCount(right, down).Should().Be(answer);
        }
    }
}