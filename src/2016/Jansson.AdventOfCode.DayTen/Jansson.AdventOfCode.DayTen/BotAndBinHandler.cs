using System.Collections.Generic;

namespace Jansson.AdventOfCode.DayTen
{
    public class BotAndBinHandler
    {
        private readonly int _lowNumber;
        private readonly int _highNumber;
        public readonly Dictionary<string, OutputBin> Bins = new Dictionary<string, OutputBin>();
        public readonly Dictionary<string, Bot> Bots = new Dictionary<string, Bot>();
        public Bot BotThatHandlesGivenNumbers { get; set; }

        public BotAndBinHandler(int lowNumber, int highNumber)
        {
            _lowNumber = lowNumber;
            _highNumber = highNumber;
        }

        public void ParseCommands(Instruction instruction, List<Instruction> awaitedInstructions)
        {
            if (instruction.SplitInstructions[0] == "value")
            {
                GetBot(instruction.SplitInstructions[5]).GiveValue(int.Parse(instruction.SplitInstructions[1]));
                CheckForBotHandlingGivenNumbers(GetBot(instruction.SplitInstructions[5]));
            }
            else
            {
                awaitedInstructions.Add(instruction);
            }
        }

        public void ExecuteGiveInstructions(Instruction instruction)
        {
            var bot = GetBot(instruction.SplitInstructions[1]);
            CheckForBotHandlingGivenNumbers(bot);
            if (bot.Values.Count >= 2)
            {
                if (instruction.SplitInstructions[5] == "bot")
                {
                    GetBot(instruction.SplitInstructions[6]).GiveValue(bot.GetLowValue());
                }
                else
                {
                    GetBin(instruction.SplitInstructions[6]).GiveValue(bot.GetLowValue());
                }
                if (instruction.SplitInstructions[10] == "bot")
                {
                    GetBot(instruction.SplitInstructions[11]).GiveValue(bot.GetHighValue());
                }
                else
                {
                    GetBin(instruction.SplitInstructions[11]).GiveValue(bot.GetHighValue());
                }
                bot.Values.RemoveRange(0, bot.Values.Count); //.RemoveRange(0, 2);
            }
        }

        private OutputBin GetBin(string name)
        {
            Bins.TryGetValue(name, out var tryGet);
            if (tryGet == null)
                Bins.Add(name, new OutputBin(name));
            return Bins[name];
        }

        private void CheckForBotHandlingGivenNumbers(Bot botToCheck)
        {
            if (botToCheck.Values.Count == 2)
                if (botToCheck.GetLowValue() == _lowNumber && botToCheck.GetHighValue() == _highNumber)
                    BotThatHandlesGivenNumbers = botToCheck;
        }

        private Bot GetBot(string name)
        {
            Bots.TryGetValue(name, out var tryGet);
            if (tryGet == null)
                Bots.Add(name, new Bot(name));
            return Bots[name];
        }
    }
}