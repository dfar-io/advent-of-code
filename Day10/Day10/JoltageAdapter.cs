using System;
using System.Linq;

namespace Day10
{
    public class JoltageAdapter
    {
        public int OutputJoltage { get; private set; }

        public JoltageAdapter(int outputJoltage)
        {
            OutputJoltage = outputJoltage;
        }

        public bool CanTake(int joltageInput)
        {
            return OutputJoltage == joltageInput + 3 ||
                   OutputJoltage == joltageInput + 2 ||
                   OutputJoltage == joltageInput + 1;
        }
    }
}
