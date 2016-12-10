using System.Collections.Generic;

namespace Jansson.AdventOfCode.DayThree
{
    public class Triangle
    {
        public Triangle(string side1, string side2, string side3)
        {
            Sides = new List<int> { int.Parse(side1), int.Parse(side2), int.Parse(side3) };
            Sides.Sort();
        }

        public List<int> Sides { get; set; }

        public bool IsValid() => Sides[0] + Sides[1] > Sides[2];
    }
}