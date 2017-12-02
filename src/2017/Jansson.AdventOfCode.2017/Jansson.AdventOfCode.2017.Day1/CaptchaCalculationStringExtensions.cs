using System.Collections.Generic;
using System.Linq;

namespace Jansson.AdventOfCode._2017.Day1
{
    public static class CaptchaCalculationStringExtensions
    {
        public static IEnumerable<Number> ParseInputNumbersToCompareToNextInt(this string inputNumbers)
        {
            var parsedNumbers = new List<Number>();

            for (var i = 0; i < inputNumbers.Length - 1; i++)
                parsedNumbers.Add(Number.Create(inputNumbers[i], inputNumbers[i + 1]));

            parsedNumbers.Add(Number.Create(inputNumbers.Last(), inputNumbers.First()));
            return parsedNumbers;
        }

        public static IEnumerable<Number> ParseInputNumbersToCompareToHalfwayInt(this string inputNumbers)
        {
            var parsedNumbers = new List<Number>();
            var stepsForwardToCompare = inputNumbers.Length / 2;

            for (var i = 0; i < inputNumbers.Length - 1; i++)
            {
                var placeToCompare =
                    inputNumbers.CalculatePlaceOfValueInCircularListFromString(i, stepsForwardToCompare);

                parsedNumbers.Add(Number.Create(inputNumbers[i], inputNumbers[placeToCompare]));
            }

            parsedNumbers.Add(Number.Create(inputNumbers.Last(), inputNumbers[stepsForwardToCompare - 1]));
            return parsedNumbers;
        }

        public static int CalculatePlaceOfValueInCircularListFromString(this string numbers, int currentPlace,
            int stepsForward)
        {
            if (currentPlace + stepsForward < numbers.Length)
                return currentPlace + stepsForward;

            return currentPlace + stepsForward - numbers.Length;
        }
    }
}