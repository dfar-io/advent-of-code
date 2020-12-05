using FluentAssertions;
using NUnit.Framework;

namespace Day05.Tests
{
    public class BoardingPassTests
    {
        private const string BoardingPassData1 = "FBFBBFFRLR";
        private const string BoardingPassData2 = "BFFFBBFRRR";
        private const string BoardingPassData3 = "FFFBBBFRRR";
        private const string BoardingPassData4 = "BBFFBBFRLL";

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(BoardingPassData1, 44)]
        [TestCase(BoardingPassData2, 70)]
        [TestCase(BoardingPassData3, 14)]
        [TestCase(BoardingPassData4, 102)]
        public void Provides_Correct_Row(string data, int row)
        {
            var boardingPass = new BoardingPass(data);

            boardingPass.Row.Should().Be(row);
        }

        [Test]
        [TestCase(BoardingPassData1, 5)]
        [TestCase(BoardingPassData2, 7)]
        [TestCase(BoardingPassData3, 7)]
        [TestCase(BoardingPassData4, 4)]
        public void Provides_Correct_Column(string data, int column)
        {
            var boardingPass = new BoardingPass(data);

            boardingPass.Column.Should().Be(column);
        }

        [Test]
        [TestCase(BoardingPassData1, 357)]
        [TestCase(BoardingPassData2, 567)]
        [TestCase(BoardingPassData3, 119)]
        [TestCase(BoardingPassData4, 820)]
        public void Provides_Correct_SeatId(string data, int seatId)
        {
            var boardingPass = new BoardingPass(data);

            boardingPass.SeatId.Should().Be(seatId);
        }

        [Test]
        [TestCase(BoardingPassData1, "row:44, col:5, seatId:357")]
        [TestCase(BoardingPassData2, "row:70, col:7, seatId:567")]
        [TestCase(BoardingPassData3, "row:14, col:7, seatId:119")]
        [TestCase(BoardingPassData4, "row:102, col:4, seatId:820")]
        public void Provides_Correct_String_Data(string data, string output)
        {
            var boardingPass = new BoardingPass(data);

            boardingPass.ToString().Should().Be(output);
        }
    }
}