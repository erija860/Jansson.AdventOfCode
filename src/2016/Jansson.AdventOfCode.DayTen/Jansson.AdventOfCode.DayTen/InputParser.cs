using System.Collections.Generic;
using System.IO;

namespace Jansson.AdventOfCode.DayTen
{
    public static class InputParser
    {
        public static List<Instruction> GetInstructionsFromFile(string filename)
        {
            var lines = File.ReadAllLines(filename);
            var instructions = new List<Instruction>();

            foreach (var line in lines)
            {
                var instructionLine = line.Trim().Split(' ');
                instructions.Add(new Instruction(instructionLine));
            }
            return instructions;
        }
    }
}