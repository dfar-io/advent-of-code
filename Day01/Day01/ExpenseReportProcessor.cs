using System.Collections.Generic;

namespace Day01
{
    // This works, but it would be nice to figure out a way to dynamically allow
    // for the entries desired.
    public static class ExpenseReportProcessor
    {
        public static int[] Find2020SumEntriesForTwo(int[] expenses)
        {
            for (int i = 0; i < expenses.Length; i++)
            {
                for (int j = i + 1; j < expenses.Length; j++)
                {
                    if (expenses[i] + expenses[j] == 2020)
                    {
                        return new int[]
                        {
                            expenses[i],
                            expenses[j]
                        };
                    }
                }
            }

            // return null if nothing
            return null;
        }

        public static int[] Find2020SumEntriesForThree(int[] expenses)
        {
            for (int i = 0; i < expenses.Length; i++)
            {
                for (int j = i + 1; j < expenses.Length; j++)
                {
                    for (int k = j + 1; k < expenses.Length; k++)
                    {
                        if (expenses[i] + expenses[j] + expenses[k] == 2020)
                        {
                            return new int[]
                            {
                                expenses[i],
                                expenses[j],
                                expenses[k]
                            };
                        }
                    }
                }
            }

            // return null if nothing
            return null;
        }
    }
}
