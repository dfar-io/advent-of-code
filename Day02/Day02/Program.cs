using System;
using System.IO;
using System.Linq;

namespace Day02
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Puzzle input required.");
                Environment.Exit(1);
            }

            var filepath = args[0];
            PasswordRecord[] passwordRecords = PasswordRecordReader.ReadData(filepath);

            Console.WriteLine($"{passwordRecords.Where(pr => pr.IsValid()).Count()}");
        }
    }
}
