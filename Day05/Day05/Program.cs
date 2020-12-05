using System;
using System.IO;
using System.Linq;

namespace Day05
{
    class Program
    {
        static void Main(string[] args)
        {
            var boardingPassDatas = File.ReadAllLines("puzzle-input.txt");
            var boardingPasses = Array.ConvertAll(
                boardingPassDatas,
                new Converter<string, BoardingPass>(StringToBoardingPass)
            );

            Console.WriteLine($"Part1: {boardingPasses.OrderByDescending(bp => bp.SeatId).First().SeatId}");
            var seatIds = boardingPasses.Select(bp => bp.SeatId);
            var missingId = Enumerable.Range(40,801).Except(seatIds).First();
            Console.WriteLine($"Part2: {missingId}");
        }

        private static BoardingPass StringToBoardingPass(string record)
        {
            return new BoardingPass(record);
        }
    }
}
