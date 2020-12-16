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

        [Test]
        public void Process_One_Step()
        {
            var initialState = new Plane(_data, 1);

            initialState.FinalState.Should().BeEquivalentTo(
                new char[,]
                {
                    { '#', '.', '#', '#', '.', '#', '#', '.', '#', '#' },
                    { '#', '#', '#', '#', '#', '#', '#', '.', '#', '#' },
                    { '#', '.', '#', '.', '#', '.', '.', '#', '.', '.' },
                    { '#', '#', '#', '#', '.', '#', '#', '.', '#', '#' },
                    { '#', '.', '#', '#', '.', '#', '#', '.', '#', '#' },
                    { '#', '.', '#', '#', '#', '#', '#', '.', '#', '#' },
                    { '.', '.', '#', '.', '#', '.', '.', '.', '.', '.' },
                    { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
                    { '#', '.', '#', '#', '#', '#', '#', '#', '.', '#' },
                    { '#', '.', '#', '#', '#', '#', '#', '.', '#', '#' },
                }
            );
        }

        [Test]
        public void Process_Two_Steps()
        {
            var initialState = new Plane(_data, 2);

            initialState.FinalState.Should().BeEquivalentTo(
                new char[,]
                {
                    { '#', '.', 'L', 'L', '.', 'L', '#', '.', '#', '#' },
                    { '#', 'L', 'L', 'L', 'L', 'L', 'L', '.', 'L', '#' },
                    { 'L', '.', 'L', '.', 'L', '.', '.', 'L', '.', '.' },
                    { '#', 'L', 'L', 'L', '.', 'L', 'L', '.', 'L', '#' },
                    { '#', '.', 'L', 'L', '.', 'L', 'L', '.', 'L', 'L' },
                    { '#', '.', 'L', 'L', 'L', 'L', '#', '.', '#', '#' },
                    { '.', '.', 'L', '.', 'L', '.', '.', '.', '.', '.' },
                    { '#', 'L', 'L', 'L', 'L', 'L', 'L', 'L', 'L', '#' },
                    { '#', '.', 'L', 'L', 'L', 'L', 'L', 'L', '.', 'L' },
                    { '#', '.', '#', 'L', 'L', 'L', 'L', '.', '#', '#' },
                }
            );
        }

        [Test]
        public void Compute_Final_State()
        {
            var initialState = new Plane(_data);

            initialState.FinalState.Should().BeEquivalentTo(
                new char[,]
                {
                    { '#', '.', '#', 'L', '.', 'L', '#', '.', '#', '#' },
                    { '#', 'L', 'L', 'L', '#', 'L', 'L', '.', 'L', '#' },
                    { 'L', '.', '#', '.', 'L', '.', '.', '#', '.', '.' },
                    { '#', 'L', '#', '#', '.', '#', '#', '.', 'L', '#' },
                    { '#', '.', '#', 'L', '.', 'L', 'L', '.', 'L', 'L' },
                    { '#', '.', '#', 'L', '#', 'L', '#', '.', '#', '#' },
                    { '.', '.', 'L', '.', 'L', '.', '.', '.', '.', '.' },
                    { '#', 'L', '#', 'L', '#', '#', 'L', '#', 'L', '#' },
                    { '#', '.', 'L', 'L', 'L', 'L', 'L', 'L', '.', 'L' },
                    { '#', '.', '#', 'L', '#', 'L', '#', '.', '#', '#' },
                }
            );
        }

        [Test]
        public void Provides_Occupied_Seat_Count()
        {
            var initialState = new Plane(_data);

            initialState.OccupiedSeatCount.Should().Be(37);
        }
    }
}