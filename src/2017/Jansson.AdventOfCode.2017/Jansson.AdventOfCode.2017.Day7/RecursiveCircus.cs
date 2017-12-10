using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Jansson.AdventOfCode._2017.Day7
{
    public class RecursiveCircus
    {
        public string CalculateBottomProgram(string filename)
        {
            var programs = ParseInput(filename);

            return programs
                .First(x => x.StandingOn == null)
                .Name;
        }

        public int CalculateNewWeightForProgramWithWrongWeight(string filename)
        {
            var programs = ParseInput(filename);

            foreach (var program in programs)
            {
                var isCorrectModel = program.FindIncorrectProgram();
                if (!isCorrectModel.IsCorrect)
                {
                    return isCorrectModel.NewWeight;
                }
            }
            return 1;
        }

        private static IEnumerable<Program> ParseInput(string filename)
        {
            var programs = File
                .ReadAllLines(filename)
                .Select(Program.Create)
                .ToList();

            foreach (var program in programs)
            {
                foreach (var programAbove in program.ProgramsImmediatelyAboveNames)
                {
                    program.ReferencedProgramsAbove.Add(
                        programs
                            .First(x => x.Name == programAbove));
                }
            }

            foreach (var program in programs)
            {
                foreach (var programAbove in program.ProgramsImmediatelyAboveNames)
                {
                    programs.First(x => x.Name == programAbove).StandingOn = program;
                }
            }
            return programs;
        }
    }
}