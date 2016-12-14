using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Jansson.AdventOfCode.DaySix
{
    public class MessageSignalCalculator
    {
        public string CalculateMessage(string filename)
        {
            var lines = File.ReadAllLines(filename);
            var place0 = new List<char>();
            var place1 = new List<char>();
            var place2 = new List<char>();
            var place3 = new List<char>();
            var place4 = new List<char>();
            var place5 = new List<char>();
            var place6 = new List<char>();
            var place7 = new List<char>();
            foreach (var line in lines)
            {
                place0.Add(line[0]);
                place1.Add(line[1]);
                place2.Add(line[2]);
                place3.Add(line[3]);
                place4.Add(line[4]);
                place5.Add(line[5]);
                place6.Add(line[6]);
                place7.Add(line[7]);
            }

            var result = place0.GroupBy(x => x).OrderBy(x => x.Count()).First().Key +
                         place1.GroupBy(x => x).OrderBy(x => x.Count()).First().Key.ToString() +
                         place2.GroupBy(x => x).OrderBy(x => x.Count()).First().Key +
                         place3.GroupBy(x => x).OrderBy(x => x.Count()).First().Key +
                         place4.GroupBy(x => x).OrderBy(x => x.Count()).First().Key +
                         place5.GroupBy(x => x).OrderBy(x => x.Count()).First().Key +
                         place6.GroupBy(x => x).OrderBy(x => x.Count()).First().Key +
                         place7.GroupBy(x => x).OrderBy(x => x.Count()).First().Key;


            return result;
        }
    }
}