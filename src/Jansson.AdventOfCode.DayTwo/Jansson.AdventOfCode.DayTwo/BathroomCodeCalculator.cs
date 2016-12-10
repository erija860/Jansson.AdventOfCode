using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Jansson.AdventOfCode.DayTwo
{
    public class BathroomCodeCalculator : ICodeCalculator
    {
        private readonly List<IKeypad> _keypads;
        private List<string> _bathroomCode;

        public BathroomCodeCalculator(List<IKeypad> keypads)
        {
            _keypads = keypads;
        }

        public string[] CalculateCode(string filename)
        {
            ParseInput(filename);
            return GetCode();
        }

        private string[] GetCode()
        {
            var result = new List<string>();
            foreach (var keypad in _keypads)
                CalculateKeypadCode(result, keypad);
            return result.ToArray();
        }

        private void CalculateKeypadCode(ICollection<string> codes, IKeypad keypad)
        {
            var code = _bathroomCode.Aggregate(string.Empty,
                (current, s) => CalculateInstructionsLine(keypad, current, s));
            codes.Add(code);
        }

        private static string CalculateInstructionsLine(IKeypad keypad, string code, string instruction)
        {
            foreach (var step in instruction)
                keypad.Walk(step);

            code = code + keypad.CurrentPosition.Name;
            return code;
        }

        private void ParseInput(string filename)
        {
            var reader = File.OpenText(filename);

            string line;
            _bathroomCode = new List<string>();
            while ((line = reader.ReadLine()) != null)
                _bathroomCode.Add(line);
        }
    }
}