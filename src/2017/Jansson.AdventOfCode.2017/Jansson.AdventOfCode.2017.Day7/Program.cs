using System.Collections.Generic;
using System.Linq;

namespace Jansson.AdventOfCode._2017.Day7
{
    public class Program
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public Program StandingOn { get; set; }
        public string[] ProgramsImmediatelyAboveNames { get; set; }
        public List<Program> ReferencedProgramsAbove { get; set; }

        public Program()
        {
            ReferencedProgramsAbove = new List<Program>();
        }

        public bool AboveProgramsIsCorrectWeight()
        {
            return ReferencedProgramsAbove
                       .GroupBy(x => x.GetTotalWeight())
                       .Count() == 1;
        }

        public CorrectWeightReturnModel FindIncorrectProgram()
        {
            var isCorrect = ReferencedProgramsAbove
                                .GroupBy(x => x.GetTotalWeight())
                                .Count() == 1;

            var aboveAboveIsCorrect = ReferencedProgramsAbove
                                          .GroupBy(x => x.AboveProgramsIsCorrectWeight())
                                          .Count() == 1;

            if (!isCorrect && aboveAboveIsCorrect)
            {
                var find = ReferencedProgramsAbove
                    .GroupBy(x => x.GetTotalWeight())
                    .FirstOrDefault(x => x.Count() == 1)
                    ?.FirstOrDefault();

                var targetWeight = ReferencedProgramsAbove
                    .GroupBy(x => x.GetTotalWeight())
                    .FirstOrDefault(x => x.Count() >= 2)
                    ?.FirstOrDefault()
                    ?.GetTotalWeight();

                var difference = targetWeight - find?.GetTotalWeight();

                return new CorrectWeightReturnModel
                {
                    NewWeight = find.Weight + difference.Value,
                    IsCorrect = false
                };
            }

            var returnModel = new CorrectWeightReturnModel
            {
                IsCorrect = true,
                NewWeight = 0
            };

            return returnModel;
        }

        public int GetTotalWeight()
        {
            return ReferencedProgramsAbove
                       .Sum(x => x.GetTotalWeight()) + Weight;
        }

        public static Program Create(string line)
        {
            var items = line
                .Replace(",", "")
                .Replace("(", "")
                .Replace(")", "")
                .Split(null);

            var programsAbove = new List<string>();
            for (var i = 3; i < items.Length; i++)
            {
                programsAbove.Add(items[i]);
            }

            return new Program
            {
                Name = items[0],
                Weight = int.Parse(items[1]),
                ProgramsImmediatelyAboveNames = programsAbove.ToArray()
            };
        }
    }
}