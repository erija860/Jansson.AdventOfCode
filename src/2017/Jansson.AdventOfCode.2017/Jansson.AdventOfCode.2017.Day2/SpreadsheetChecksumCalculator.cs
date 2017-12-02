using System.IO;
using System.Linq;

namespace Jansson.AdventOfCode._2017.Day2
{
    public class SpreadsheetChecksumCalculator
    {
        public int CalculateChecksum(string fileName)
        {
            var lines = File.ReadAllLines(fileName);

            return lines
                .Select(line => new Line(line))
                .Sum(line => line.Checksum);
        }

        public int CalculateDivisibleChecksum(string fileName)
        {
            var lines = File.ReadAllLines(fileName);

            return lines
                .Select(line => new Line(line))
                .Sum(line => line.GetDivisibleResult());
        }
    }
}