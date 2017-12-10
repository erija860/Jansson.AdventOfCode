namespace Jansson.AdventOfCode._2017.Day8
{
    public class Instruction
    {
        public string RegisterToManipulate { get; set; }
        public string RegisterToCheck { get; set; }
        public int ValueToManipulateWith { get; set; }
        public int ValueToCompareWith { get; set; }
        public string Operator { get; set; }
        public string TypeOfManipulation { get; set; }

        public static Instruction Create(string[] line)
        {
            return new Instruction
            {
                RegisterToManipulate = line[0],
                TypeOfManipulation = line[1],
                ValueToManipulateWith = int.Parse(line[2]),
                RegisterToCheck = line[4],
                Operator = line[5],
                ValueToCompareWith = int.Parse(line[6])
            };
        }
    }
}