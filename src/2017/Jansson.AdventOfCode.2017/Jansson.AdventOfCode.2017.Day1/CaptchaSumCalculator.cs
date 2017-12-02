using System.Linq;

namespace Jansson.AdventOfCode._2017.Day1
{
    public class CaptchaSumCalculator
    {
        public int CalculateCaptchaSum_part1(string inputNumbers)
        {
            return inputNumbers
                .ParseInputNumbersToCompareToNextInt()
                .Where(x => x.Value == x.ValueToCompare)
                .Sum(x => x.Value);
        }

        public int CalculateCaptchaSum_part2(string inputNumbers)
        {
            return inputNumbers
                .ParseInputNumbersToCompareToHalfwayInt()
                .Where(x => x.Value == x.ValueToCompare)
                .Sum(x => x.Value);
        }
    }
}