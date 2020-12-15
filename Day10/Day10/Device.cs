using System;
using System.Linq;

namespace Day10
{
    public class Device
    {
        public int JoltageAdapterRating { get; private set; }
        public int[] JoltDifferences { get; private set; }
        public ulong Combinations { get; set; }

        public Device(JoltageAdapter[] adapters)
        {
            JoltageAdapterRating = adapters.Max(a => a.OutputJoltage) + 3;
            JoltDifferences = new int[3]
            {
                0, // 1 jolts
                0, // 2 jolts
                0 // 3 jolts
            };
            
            // Leaving code here for part 1
            var currentRating = 0;
            while (currentRating < JoltageAdapterRating)
            {
                var eligibleAdapters = adapters
                                        .Where(a => a.CanTake(currentRating))
                                        .Append(new JoltageAdapter(JoltageAdapterRating));
                var previousRating = currentRating;
                currentRating = eligibleAdapters.Min(a => a.OutputJoltage);

                var difference = currentRating - previousRating;
                JoltDifferences[difference - 1]++;
            }

            currentRating = 0;
            Combinations = CalcCombinations(0, adapters);
        }

        // This takes a really long time due to the recursion, but it works!
        private ulong CalcCombinations(int currentJoltage, JoltageAdapter[] allAdapters)
        {
            ulong sum = 0;
            
            var eligibleAdapters = allAdapters.Where(a => a.CanTake(currentJoltage));
            if (!eligibleAdapters.Any())
            {
                return 1;
            }

            foreach (var adapter in eligibleAdapters)
            {
                sum += CalcCombinations(adapter.OutputJoltage, allAdapters);
            }

            return sum;
        }
    }
}
