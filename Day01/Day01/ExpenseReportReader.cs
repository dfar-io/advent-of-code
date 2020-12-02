using System;
using System.IO;

namespace Day01
{
    public static class ExpenseReportReader
    {
        public static int[] ReadExpenseReport(string path)
        {
            var expenses = File.ReadAllLines(path);
            return Array.ConvertAll(expenses, int.Parse);
        }
    }
}
