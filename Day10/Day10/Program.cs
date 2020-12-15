using System;
using System.IO;

namespace Day10
{
    class Program
    {
        static void Main(string[] args)
        {
            var puzzleData = File.ReadAllLines("puzzle-input.txt");
            var joltageAdapters = Array.ConvertAll(
                puzzleData,
                new Converter<string, JoltageAdapter>(StringToJoltageAdapter)
            );
            var device = new Device(joltageAdapters);

            Console.WriteLine($"Part 1: {device.JoltDifferences[0] * device.JoltDifferences[2]}");
            Console.WriteLine($"Part 2: {device.Combinations}");
        }

        private static JoltageAdapter StringToJoltageAdapter(string input)
        {
            return new JoltageAdapter(int.Parse(input));
        }
    }
}
