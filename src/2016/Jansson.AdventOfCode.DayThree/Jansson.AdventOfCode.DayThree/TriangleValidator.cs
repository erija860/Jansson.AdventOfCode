using System.Linq;

namespace Jansson.AdventOfCode.DayThree
{
    public class TriangleValidator
    {
        public int GetNumberOfValidTriangles(string fileName)
        {
            var input = InputParser.ParseInputToTriangles(fileName);
            var validRectangles = input.Where(triangle => triangle.IsValid()).ToList();
            return validRectangles.Count;
        }
    }
}