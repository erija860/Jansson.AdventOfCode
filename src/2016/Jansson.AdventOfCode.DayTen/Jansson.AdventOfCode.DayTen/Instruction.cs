namespace Jansson.AdventOfCode.DayTen
{
    public class Instruction
    {
        public Instruction(string[] splitInstructions)
        {
            SplitInstructions = splitInstructions;
        }

        public string[] SplitInstructions { get; set; }
    }
}