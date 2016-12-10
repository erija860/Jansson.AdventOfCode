using System.Collections.Generic;
using System.Linq;

namespace Jansson.AdventOfCode.DayOne
{
    public class InputParser
    {
        public static List<List<string>> ParseInput(string input)
        {
            var dir = input.Split(',').ToList();
            dir = dir.Select(direction =>
                    direction.Trim()).ToList();
            return
                dir.Select(direction => new List<string> {char.ToString(direction[0]), direction.Remove(0, 1)})
                    .ToList();
        }
    }
}