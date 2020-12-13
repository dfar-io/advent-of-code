using System;
using System.IO;

namespace Day09
{
    class Program
    {
        static void Main(string[] args)
        {
            var puzzleData = File.ReadAllLines("puzzle-input.txt");
            var xmasData = new XmasData(puzzleData, 25);

            Console.WriteLine($"Part 1: {xmasData.InvalidNumber}");
            Console.WriteLine($"Part 2: {xmasData.EncryptionWeakness}");
        }
    }
}
