using System;
using System.IO;
using System.Linq;

namespace Day07
{
    class Program
    {
        static void Main(string[] args)
        {
            var ruleDatas = File.ReadAllLines("puzzle-input.txt");
            var rules = Array.ConvertAll(ruleDatas, new Converter<string, Rule>(StringToRule));

            var count = rules.Where(r => r.CanContainColor(rules, "shiny gold")).Count();
            var bagCount = rules.Where(r => r.Color == "shiny gold").First().BagCount(rules);

            Console.WriteLine($"Part1: {count}");
            Console.WriteLine($"Part2: {bagCount}");
        }

        private static Rule StringToRule(string record)
        {
            return new Rule(record);
        }
    }
}
