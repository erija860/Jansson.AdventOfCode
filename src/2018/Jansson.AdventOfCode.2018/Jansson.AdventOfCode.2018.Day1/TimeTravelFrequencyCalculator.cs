using System.Collections.Generic;
using System.Linq;

namespace Jansson.AdventOfCode._2018.Day1
{
    public class TimeTravelFrequencyCalculator
    {
        public int CalculateDeviceFrequency(string[] input)
        {
            return input
                .Select(int.Parse)
                .Sum();
        }

        public int CalculateDeviceFrequencyToFindDuplicates(string[] input)
        {
            var log = new List<int> {0};
            var frequencyChanges = input.Select(int.Parse).ToList();
            var currentValue = 0;

            while (true)
                foreach (var number in frequencyChanges)
                {
                    currentValue += number;


                    if (log.Any(i => i == currentValue))
                        return currentValue;

                    log.Add(currentValue);
                }
        }
    }
}