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
            // this might be a performance problem if the dataset is large
            return Enumerable.Range(OutputJoltage - 3, 3).Contains(joltageInput);
        }
    }
}
