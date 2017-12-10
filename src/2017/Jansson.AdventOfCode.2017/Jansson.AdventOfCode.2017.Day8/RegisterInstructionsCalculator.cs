using System.IO;
using System.Linq;

namespace Jansson.AdventOfCode._2017.Day8
{
    public class RegisterInstructionsCalculator
    {
        private readonly RegisterHandler _registerHandler;

        public RegisterInstructionsCalculator()
        {
            _registerHandler = new RegisterHandler();
        }

        public MaxRegisterValueModel CalculateLagestRegisterValue(string filename)
        {
            var instructions = File
                .ReadAllLines(filename)
                .Select(x => x.Split(null))
                .Select(Instruction.Create);

            foreach (var instruction in instructions)
            {
                _registerHandler.ExecuteInstruction(instruction);
            }

            return _registerHandler.MaxRegisterValue();
        }
    }
}