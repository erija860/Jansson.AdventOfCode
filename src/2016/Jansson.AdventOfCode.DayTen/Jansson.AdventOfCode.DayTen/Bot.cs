using System.Collections.Generic;

namespace Jansson.AdventOfCode.DayTen
{
    public class Bot
    {
        public Bot(string name)
        {
            Name = name;
        }

        public List<int> Values { get; set; } = new List<int>();

        public string Name { get; }

        public void GiveValue(int newValue)
        {
            if (Values.Count < 2)
                Values.Add(newValue);
        }

        public int GetLowValue()
        {
            return Values[1] > Values[0] ? Values[0] : Values[1];
        }

        public int GetHighValue()
        {
            return Values[1] > Values[0] ? Values[1] : Values[0];
        }
    }
}