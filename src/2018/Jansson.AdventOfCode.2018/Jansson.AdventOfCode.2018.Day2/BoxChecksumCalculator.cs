using System.Collections.Generic;
using System.Linq;

namespace Jansson.AdventOfCode._2018.Day2
{
    public class BoxChecksumCalculator
    {
        public int CalculateChecksum(string[] boxIds)
        {
            var twos = 0;
            var threes = 0;

            foreach (var boxId in boxIds)
            {
                var counts = boxId
                    .GroupBy(c => c)
                    .Select(g => g.Count())
                    .ToList();

                if (counts.Any(c => c == 2))
                    twos++;

                if (counts.Any(c => c == 3))
                    threes++;
            }

            return twos*threes;
        }

        public string GetCommonCharactersOfSingleDifferingId(string[] boxIds)  
        {
            var @checked = new List<string>();

            foreach (var boxId in boxIds)
            {
                foreach (var old in @checked)
                {
                    if (DiffersByOne(boxId, old, out var common))
                        return common;
                }

                @checked.Add(boxId);
            }

            return "";
        }

        private bool DiffersByOne(string one, string two, out string common)
        {
            common = "";

            if (one.Length != two.Length)
            {
                return false;
            }

            int counter = 0;
            int differIndex = 0;
            for (var i = 0; i < one.Length; i++)
            {
                if (one[i] != two[i])
                {
                    counter++;
                    differIndex = i;
                }
            }
            if (counter > 1)
            {
                return false;
            }

            common = one.Remove(differIndex, 1);
            return true;
        }
    }
}
