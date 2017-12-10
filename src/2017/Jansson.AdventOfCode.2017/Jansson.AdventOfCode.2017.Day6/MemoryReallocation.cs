using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Jansson.AdventOfCode._2017.Day6
{
    public class MemoryReallocation
    {
        public MemoryReallocationResult CalculateStepsOfInfiniteLoopAndStepsToReproduce(string filename)
        {
            var memoryBanks = File
                .ReadAllText(filename)
                .Split(null)
                .Select(int.Parse)
                .ToList();

            var history = new List<string>();
            var count = 0;

            while (true)
            {
                var snapshot = string.Join(",", memoryBanks);

                history.Add(snapshot);
                if (history.Count(x => x == snapshot) == 2)
                {
                    return new MemoryReallocationResult
                    {
                        StepsOfInfiniteLoop = count - history.IndexOf(snapshot),
                        StepsToReproduce = count
                    };
                }

                count++;

                var maxValue = memoryBanks.Max();
                var maxIndex = memoryBanks.IndexOf(maxValue);
                memoryBanks[maxIndex] = 0;

                var position = maxIndex + 1;
                for (var i = 0; i < maxValue; i++)
                {
                    if (position > memoryBanks.Count - 1)
                        position = 0;

                    memoryBanks[position]++;
                    position++;
                }
            }
        }

        public class MemoryReallocationResult
        {
            public int StepsToReproduce { get; set; }
            public int StepsOfInfiniteLoop { get; set; }
        }
    }
}