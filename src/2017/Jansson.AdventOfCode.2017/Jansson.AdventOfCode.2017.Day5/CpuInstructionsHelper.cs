using System.IO;
using System.Linq;

namespace Jansson.AdventOfCode._2017.Day5
{
    public class CpuInstructionsHelper
    {
        public int CalculateStepsToExit(string filename)
        {
            var instructions = File
                .ReadAllLines(filename)
                .Select(int.Parse)
                .ToArray();

            var currentPosition = 0;
            var stepsTaken = 0;

            while (currentPosition < instructions.Length)
            {
                var stepsToTake = instructions[currentPosition];
                instructions[currentPosition]++;
                currentPosition += stepsToTake;

                stepsTaken++;
            }

            return stepsTaken;
        }

        public int CalculateStepsToExitWithDecreaseAbove2Offset(string filename)
        {
            var instructions = File
                .ReadAllLines(filename)
                .Select(int.Parse)
                .ToArray();

            var currentPosition = 0;
            var stepsTaken = 0;

            while (currentPosition < instructions.Length)
            {
                var stepsToTake = instructions[currentPosition];

                if (stepsToTake >= 3)
                    instructions[currentPosition]--;
                else
                    instructions[currentPosition]++;
                currentPosition += stepsToTake;

                stepsTaken++;
            }

            return stepsTaken;
        }
    }
}