using System.Collections.Generic;
using System.Linq;

namespace Jansson.AdventOfCode._2017.Day3
{
    public class Square
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Value { get; set; }

        public int CalculateAndSetValue(List<Square> squares)
        {
            Value =
                squares
                    .Where(
                        square => square.X == X + 1 && square.Y == Y
                                  || square.X == X + 1 && square.Y == Y + 1
                                  || square.X == X && square.Y == Y + 1
                                  || square.X == X - 1 && square.Y == Y + 1
                                  || square.X == X - 1 && square.Y == Y
                                  || square.X == X - 1 && square.Y == Y - 1
                                  || square.X == X && square.Y == Y - 1
                                  || square.X == X + 1 && square.Y == Y - 1
                    )
                    .Sum(x => x.Value);
            return Value;
        }
    }
}