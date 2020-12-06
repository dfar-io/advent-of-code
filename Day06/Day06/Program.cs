using System;
using System.Linq;

namespace Day06
{
    class Program
    {
        static void Main(string[] args)
        {
            var groups = GroupReader.ReadData("puzzle-input.txt");
            var anyoneSum = groups.Sum(g => g.QuestionsAnsweredYesByAnyone.Count());
            var everyoneSum = groups.Sum(g => g.QuestionsAnsweredYesByEveryone.Count());
            Console.WriteLine($"Part1: {anyoneSum}");
            Console.WriteLine($"Part2: {everyoneSum}");
        }
    }
}
