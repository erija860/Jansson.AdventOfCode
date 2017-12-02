using System.Collections.Generic;
using System.Linq;

namespace Jansson.AdventOfCode.DayTen
{
    public class BalanceBotsCalculator
    {
        private readonly BotAndBinHandler _botAndBinHandler;
        private readonly List<Instruction> _instructions;
        private readonly List<Instruction> _moveInstructions = new List<Instruction>();

        public BalanceBotsCalculator(string filename, int lowNumber, int highNumber)
        {
            _instructions = InputParser.GetInstructionsFromFile(filename);
            _botAndBinHandler = new BotAndBinHandler(lowNumber, highNumber);
        }

        public string GetBotThatHandlesGivenNumbers()
        {
            foreach (var instruction in _instructions)
                _botAndBinHandler.ParseCommands(instruction, _moveInstructions);

            while (IsNotDone())
                foreach (var instruction in _moveInstructions)
                {
                    _botAndBinHandler.ExecuteGiveInstructions(instruction);
                }

            return _botAndBinHandler.BotThatHandlesGivenNumbers?.Name;
        }

        private bool IsNotDone()
        {
            return _botAndBinHandler.Bots.Any(x => x.Value.Values.Count == 2);
        }

        public string Part2Result()
        {
            var bins = (from keyValuePair in _botAndBinHandler.Bins
                        where keyValuePair.Key == "0" || keyValuePair.Key == "1" || keyValuePair.Key == "2"
                        select keyValuePair.Value.Values.First()).ToList();

            var result = bins.Aggregate(1, (current, bin) => current * bin);

            return result.ToString();
        }
    }
}