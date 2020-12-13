using System;
using System.IO;

namespace Day08
{
    class Program
    {
        static void Main(string[] args)
        {
            var instructionData = File.ReadAllLines("puzzle-input.txt");
            var bootCode = new BootCode(instructionData);
            var bootCodeFixer = new BootCodeFixer(bootCode);

            Console.WriteLine($"Part 1: {bootCode.Accumulator}");
            Console.WriteLine($"Part 2: {bootCodeFixer.Accumulator}");
        }
    }
}
