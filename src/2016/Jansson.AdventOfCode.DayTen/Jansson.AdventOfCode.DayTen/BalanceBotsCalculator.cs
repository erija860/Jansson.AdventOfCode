using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace Jansson.AdventOfCode.DayTen
{
    public class BalanceBotsCalculator
    {
        private readonly BotAndBinHandler _botAndBinHandler;
        private readonly List<Instruction> _instructions;
        private readonly List<Instruction> _moveInstructions = new List<Instruction>();

        public BalanceBotsCalculator(string filename)
        {
            _instructions = InputParser.GetInstructionsFromFile(filename);
            _botAndBinHandler = new BotAndBinHandler();
        }

        public string GetBotThatHandles61And17()
        {
            foreach (var instruction in _instructions)
                _botAndBinHandler.ParseCommands(instruction, _moveInstructions);

            foreach (var instruction in _moveInstructions)
            {
                _botAndBinHandler.ExecuteGiveInstructions(instruction);
                if (_botAndBinHandler.BotThatHandles61And17 != null)
                    return _botAndBinHandler.BotThatHandles61And17.Name;
            }
            return "Done without finding the wanted result";
        }
    }

    public class BotAndBinHandler
    {
        private readonly Dictionary<string, OutputBin> _bins = new Dictionary<string, OutputBin>();
        private readonly Dictionary<string, Bot> _bots = new Dictionary<string, Bot>();
        public Bot BotThatHandles61And17 { get; set; }

        public void ParseCommands(Instruction instruction, List<Instruction> awaitedInstructions)
        {
            if (instruction.SplitInstructions[0] == "value")
            {
                GetBot(instruction.SplitInstructions[5]).GiveValue(int.Parse(instruction.SplitInstructions[1]));
                CheckFor61And17(GetBot(instruction.SplitInstructions[5]));
            }
            else
            {
                awaitedInstructions.Add(instruction);
                //var bot = GetBot(instruction.SplitInstructions[1]);
                //if (bot.Values.Count == 2)
                //{
                //    if (instruction.SplitInstructions[5] == "bot")
                //    {
                //        GetBot(instruction.SplitInstructions[6]).GiveValue(bot.GetLowValue());
                //        CheckFor61And17(GetBot(instruction.SplitInstructions[6]));
                //    }
                //    else
                //    {
                //        GetBin(instruction.SplitInstructions[6]).GiveValue(bot.GetLowValue());
                //    }
                //    if (instruction.SplitInstructions[10] == "bot")
                //    {
                //        GetBot(instruction.SplitInstructions[11]).GiveValue(bot.GetHighValue());
                //        CheckFor61And17(GetBot(instruction.SplitInstructions[11]));
                //    }
                //    else
                //    {
                //        GetBin(instruction.SplitInstructions[11]).GiveValue(bot.GetHighValue());
                //    }
                //    bot.Values.RemoveRange(0, 2);
                //}
            }
        }

        public void ExecuteGiveInstructions(Instruction instruction)
        {
            var bot = GetBot(instruction.SplitInstructions[1]);
            CheckFor61And17(bot);
            if (bot.Values.Count == 2)
            {
                if (instruction.SplitInstructions[5] == "bot")
                {
                    GetBot(instruction.SplitInstructions[6]).GiveValue(bot.GetLowValue());
                 //   CheckFor61And17(GetBot(instruction.SplitInstructions[6]));
                }
                else
                {
                    GetBin(instruction.SplitInstructions[6]).GiveValue(bot.GetLowValue());
                }
                if (instruction.SplitInstructions[10] == "bot")
                {
                    GetBot(instruction.SplitInstructions[11]).GiveValue(bot.GetHighValue());
                  //  CheckFor61And17(GetBot(instruction.SplitInstructions[11]));
                }
                else
                {
                    GetBin(instruction.SplitInstructions[11]).GiveValue(bot.GetHighValue());
                }
                bot.Values.RemoveRange(0, 2);
            }
        }

        private OutputBin GetBin(string name)
        {
            OutputBin tryGet;
            _bins.TryGetValue(name, out tryGet);
            if (tryGet == null)
                _bins.Add(name, new OutputBin(name));
            return _bins[name];
        }

        private void CheckFor61And17(Bot botToCheck)
        {
            if (botToCheck.Values.Count == 2)
                if ((botToCheck.GetLowValue() == 17) && (botToCheck.GetHighValue() == 61))
                    BotThatHandles61And17 = botToCheck;
        }

        private Bot GetBot(string name)
        {
            Bot tryGet;
            _bots.TryGetValue(name, out tryGet);
            if (tryGet == null)
                _bots.Add(name, new Bot(name));
            return _bots[name];
        }
    }

    public static class InputParser
    {
        public static List<Instruction> GetInstructionsFromFile(string filename)
        {
            var lines = File.ReadAllLines(filename);
            var instructions = new List<Instruction>();

            foreach (var line in lines)
            {
                var instructionLine = line.Trim().Split(' ');
                instructions.Add(new Instruction(instructionLine));
            }
            return instructions;
        }
    }

    public class Bot
    {
        public Bot(string name)
        {
            Name = name;
        }

        public List<int> Values { get; set; } = new List<int>();

        public string Name { get; }

        public void GiveValue(int newValue)
        {
            if (Values.Count < 2)
                Values.Add(newValue);
        }

        public int GetLowValue()
        {
            return Values[1] > Values[0] ? Values[0] : Values[1];
        }

        public int GetHighValue()
        {
            return Values[1] > Values[0] ? Values[1] : Values[0];
        }
    }

    public class OutputBin
    {
        public OutputBin(string name)
        {
            Name = name;
        }

        public List<int> Values { get; set; } = new List<int>();
        public string Name { get; }

        public void GiveValue(int newValue)
        {
            Values.Add(newValue);
        }
    }

    public class Instruction
    {
        public Instruction(string[] splitInstructions)
        {
            SplitInstructions = splitInstructions;
        }

        public string[] SplitInstructions { get; set; }
    }

    [TestFixture]
    public class BalanceBotsCalculatorTests
    {
        [Test]
        public void SomeTest()
        {
            var calculator =
                new BalanceBotsCalculator(
                    @"C:\dev\Jansson.AdventOfCode\src\Jansson.AdventOfCode.DayTen\Jansson.AdventOfCode.DayTen\InputFile.txt");
            Console.WriteLine(calculator.GetBotThatHandles61And17());
        }
    }
}