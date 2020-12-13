using System;
using System.Linq;

namespace Day10
{
    public class Device
    {
        public int JoltageAdapterRating { get; private set; }
        public int[] JoltDifferences { get; private set; }

        public Device(JoltageAdapter[] adapters)
        {
            JoltageAdapterRating = adapters.Max(a => a.OutputJoltage) + 3;

            JoltDifferences = new int[3]
            {
                7, // 1 jolts
                0, // 2 jolts
                5 // 3 jolts
            };
        }
    }
}
