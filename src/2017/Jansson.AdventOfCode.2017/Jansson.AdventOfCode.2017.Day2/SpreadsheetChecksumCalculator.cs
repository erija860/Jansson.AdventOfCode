using System.Collections.Generic;
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