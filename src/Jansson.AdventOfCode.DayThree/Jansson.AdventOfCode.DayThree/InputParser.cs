using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Jansson.AdventOfCode.DayThree
{
    public static class InputParser
    {
        public static Triangle[] ParseInputToTriangles(string filename)
        {
            var input = File.ReadAllLines(filename);

            var triangles = new List<Triangle>();
            var row1 = new List<string>();
            var row2 = new List<string>();
            var row3 = new List<string>();

            SetRows(input, row1, row2, row3);
            CreateTriangles(input, triangles, row1, row2, row3);
            return triangles.ToArray();
        }

        private static void SetRows(string[] input, List<string> row1, List<string> row2, List<string> row3)
        {
            foreach (var line in input)
            {
                var arrline = line.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                arrline = arrline.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                row1.Add(arrline[0]);
                row2.Add(arrline[1]);
                row3.Add(arrline[2]);
            }
        }

        private static void CreateTriangles(string[] input, List<Triangle> triangles, List<string> row1,
            List<string> row2, List<string> row3)
        {
            for (var i = 0; i < input.Length / 3; i++)
            {
                triangles.Add(new Triangle(row1[0], row1[1], row1[2]));
                triangles.Add(new Triangle(row2[0], row2[1], row2[2]));
                triangles.Add(new Triangle(row3[0], row3[1], row3[2]));
                row1.RemoveRange(0, 3);
                row2.RemoveRange(0, 3);
                row3.RemoveRange(0, 3);
            }
        }
    }
}