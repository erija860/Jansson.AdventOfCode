namespace Jansson.AdventOfCode._2017.Day1
{
    public class Number
    {
        public int Value { get; set; }
        public int ValueToCompare { get; set; }

        public static Number Create(char number, char nextNumber)
        {
            return new Number
            {
                Value = (int) char.GetNumericValue(number),
                ValueToCompare = (int) char.GetNumericValue(nextNumber)
            };
        }
    }
}