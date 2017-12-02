using System.Collections.Generic;

namespace Jansson.AdventOfCode.DayTen
{
    public class OutputBin
    {
        public OutputBin(string name)
        {
            Name = name;
        }

        public List<int> Values { get; set; } = new List<int>();
        public string Name { get; }

        public void GiveValue(int newValue)
        {
            Values.Add(newValue);
        }
    }
}