using System;
using System.IO;
using System.Linq;

namespace Day01
{
    class Program
    {
        static void Main(string[] args)
        {
            VerifyArgsPassedIn(args);

            var expenseReportPath = args[0];
            var entryCount = args[1];
            ProcessExpenses(expenseReportPath, entryCount);
        }

        private static void ProcessExpenses(
            string expenseReportPath,
            string entryCount
        )
        {
            int[] expenses;
            try
            {
                expenses = ExpenseReportReader.ReadExpenseReport(expenseReportPath);
                var matchingValues = entryCount == "2" ? 
                    ExpenseReportProcessor.Find2020SumEntriesForTwo(expenses) :
                    ExpenseReportProcessor.Find2020SumEntriesForThree(expenses);
                if (matchingValues == null)
                {
                    Console.WriteLine($"No matching values found");
                    Environment.Exit(0);
                }

                Console.WriteLine($"{matchingValues.Aggregate(1, (a, b) => a * b)}");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"File {expenseReportPath} not found.");
                Environment.Exit(1);
            }
            catch (ArgumentException)
            {
                Console.WriteLine($"Invalid data provided.");
                Environment.Exit(1);
            }
        }

        private static void VerifyArgsPassedIn(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Expense report (in .txt) AND entry count required.");
                Environment.Exit(1);
            }

            if (args[1] != "2" && args[1] != "3")
            {
                Console.WriteLine("Entry counts of 2 and 3 are supported.");
                Environment.Exit(1);
            }
        }
    }
}
