using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Jansson.AdventOfCode.DaySix
{
    public class MessageSignalCalculator
    {
        public string CalculateMessage(string filename)
        {
            var lines = File.ReadAllLines(filename);


            var array = new List<char>[8];
            for (var i = 0; i < array.Length; i++)
                array[i] = new List<char>();

            foreach (var line in lines)
                for (var i = 0; i < array.Length; i++)
                    array[i].Add(line[i]);

            var builder = new StringBuilder();
            foreach (var list in array)
                builder.Append(list.GroupBy(x => x).OrderBy(x => x.Count()).First().Key);

            return builder.ToString();
        }
    }
}