using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Jansson.AdventOfCode._2018.Day3
{
    public class FabricCalculator
    {
        public int CalculateOverlappingSquareInches(string[] input)
        {
            var claims = input.Select(SantaSuitClaim.Create).ToList();
            var fabric = new Dictionary<Point, int>();
            claims.ForEach(c=>c.AddClaimArea(fabric));

            return fabric.Count(c=>c.Value>1);
        }

        public string FindNonOverlappingClaim(string[] input)
        {
            var claims = input.Select(SantaSuitClaim.Create).ToList();
            var fabric = new Dictionary<Point, int>();
            claims.ForEach(c => c.AddClaimArea(fabric));

            return claims.FirstOrDefault(c => !c.Overlaps(fabric))?.Id;
        }

        private class SantaSuitClaim
        {
            public string Id { get; set; }
            public int LeftPadding { get; set; }
            public int TopPadding { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }

            public static SantaSuitClaim Create(string input)
            {
                input = input
                    .Replace("@ ", "")
                    .Replace(":", "")
                    .Replace("#", "");

                var split = input.Split(null);

                return new SantaSuitClaim
                {
                    Id = split[0],
                    LeftPadding = int.Parse(split[1].Split(",")[0]),
                    TopPadding = int.Parse(split[1].Split(",")[1]),
                    Width = int.Parse(split[2].Split("x")[0]),
                    Height = int.Parse(split[2].Split("x")[1])
                };
            }

            public void AddClaimArea(Dictionary<Point, int> fabric)
            {
                for (var i = LeftPadding; i < LeftPadding + Width; i++)
                {
                    for (var j = TopPadding; j < TopPadding + Height; j++)
                    {
                        var squareInch = fabric.GetValueOrDefault(new Point(i, j));
                        fabric[new Point(i, j)] = ++squareInch;
                    }
                }
            }

            public bool Overlaps(Dictionary<Point, int> fabric)
            {
                for (var i = LeftPadding; i < LeftPadding + Width; i++)
                {
                    for (var j = TopPadding; j < TopPadding + Height; j++)
                    {
                        var squareInch = fabric.GetValueOrDefault(new Point(i, j));
                        if (squareInch>1)
                        {
                            return true;
                        }
                    }
                }

                return false;
            }
        }
    }
}
