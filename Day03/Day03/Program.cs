using System;
using System.IO;
using System.Numerics;

namespace Day03
{
    class Program
    {
        static void Main(string[] args)
        {
            var records = File.ReadAllLines("puzzle-input.txt");
            var map = new Map(records);

            var answer = new BigInteger(map.GetTreeCount(1,1)) *
                         new BigInteger(map.GetTreeCount(3,1)) *
                         new BigInteger(map.GetTreeCount(5,1)) *
                         new BigInteger(map.GetTreeCount(7,1)) *
                         new BigInteger(map.GetTreeCount(1,2));
            Console.WriteLine(answer);
        }
    }
}
