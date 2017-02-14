using System;

namespace Jansson.AdventOfCode.DayThree.Runner
{
    internal class Program
    {
        private static void Main()
        {
            var validator = new TriangleValidator();
            Console.WriteLine(validator.GetNumberOfValidTriangles("Input.txt"));
        }
    }
}