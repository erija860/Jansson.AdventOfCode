using System.Collections.Generic;
using System.Linq;

namespace Jansson.AdventOfCode._2017.Day2
{
    public class Line
    {
        public Line(string line)
        {
            Numbers = line
                .Split(null)
                .Select(int.Parse)
                .ToList();
        }

        public List<int> Numbers { get; set; }

        public int Checksum => Numbers.Max() - Numbers.Min();

        public int GetDivisibleResult()
        {
            return (from currentNumber in Numbers
                    from number in Numbers
                    where currentNumber != number && currentNumber % number == 0
                    select currentNumber / number).FirstOrDefault();
        }
    }
}