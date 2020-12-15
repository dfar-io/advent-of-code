using FluentAssertions;
using NUnit.Framework;

namespace Day11.Tests
{
    public class PlaneTests
    {
        private string[] _data;

        [SetUp]
        public void Setup()
        {
            _data = new string[10]
            {
                "L.LL.LL.LL",
                "LLLLLLL.LL",
                "L.L.L..L..",
                "LLLL.LL.LL",
                "L.LL.LL.LL",
                "L.LLLLL.LL",
                "..L.L.....",
                "LLLLLLLLLL",
                "L.LLLLLL.L",
                "L.LLLLL.LL"
            };
        }

        [Test]
        public void Sets_Initial_State()
        {
            var initialState = new Plane(_data);

            initialState.InitialState.Should().BeEquivalentTo(
                new char[,]
                {
                    { 'L', '.', 'L', 'L', '.', 'L', 'L', '.', 'L', 'L' },
                    { 'L', 'L', 'L', 'L', 'L', 'L', 'L', '.', 'L', 'L' },
                    { 'L', '.', 'L', '.', 'L', '.', '.', 'L', '.', '.' },
                    { 'L', 'L', 'L', 'L', '.', 'L', 'L', '.', 'L', 'L' },
                    { 'L', '.', 'L', 'L', '.', 'L', 'L', '.', 'L', 'L' },
                    { 'L', '.', 'L', 'L', 'L', 'L', 'L', '.', 'L', 'L' },
                    { '.', '.', 'L', '.', 'L', '.', '.', '.', '.', '.' },
                    { 'L', 'L', 'L', 'L', 'L', 'L', 'L', 'L', 'L', 'L' },
                    { 'L', '.', 'L', 'L', 'L', 'L', 'L', 'L', '.', 'L' },
                    { 'L', '.', 'L', 'L', 'L', 'L', 'L', '.', 'L', 'L' },
                }
            );
        }
    }
}