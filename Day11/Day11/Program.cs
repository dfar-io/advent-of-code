using System;
using System.IO;

namespace Day11
{
    class Program
    {
        static void Main(string[] args)
        {
            var puzzleData = File.ReadAllLines("puzzle-input.txt");
            var plane = new Plane(puzzleData);

            Console.WriteLine($"Part 1: {plane.OccupiedSeatCount}");
        }
    }
}
