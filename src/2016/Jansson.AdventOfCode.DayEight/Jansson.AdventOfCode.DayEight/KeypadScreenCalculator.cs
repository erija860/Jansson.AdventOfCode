using System;
using System.Collections.Generic;
using System.IO;

namespace Jansson.AdventOfCode.DayEight
{
    public class KeypadScreenCalculator
    {
        private readonly List<Instruction> _instructions = new List<Instruction>();
        private readonly Screen _screen;

        public KeypadScreenCalculator()
        {
            _screen = new Screen();
        }

        public void ExecuteCommands()
        {
            foreach (var instruction in _instructions)
                switch (instruction.SplitString[0])
                {
                    case "rect":
                        var yAndx = instruction.SplitString[1].Split('x');
                        _screen.TurnOnRectangle(int.Parse(yAndx[1]), int.Parse(yAndx[0]));
                        break;
                    case "rotate":
                        switch (instruction.SplitString[1])
                        {
                            case "row":
                                var row = instruction.SplitString[2].Split('=');
                                _screen.RotateRow(int.Parse(row[1]),
                                    int.Parse(instruction.SplitString[4]));
                                break;
                            case "column":
                                var column = instruction.SplitString[2].Split('=');
                                _screen.RotateColumn(int.Parse(column[1]),
                                    int.Parse(instruction.SplitString[4]));
                                break;
                        }
                        break;
                }
        }

        public int GetCountOfPixelsLit() => _screen.GetPixelsLit();

        public void ParseInput(string filename)
        {
            var lines = File.ReadAllLines(filename);
            foreach (var line in lines)
            {
                var splitLine = line.Trim().Split(' ');
                _instructions.Add(new Instruction(splitLine));
            }
        }

        public void PrintCompleteScreen()
        {
            for (var i = 0; i < 6; i++)
            {
                for (var j = 0; j < 50; j++)
                    Console.Write(_screen._screen[i, j]);
                Console.Write("\n");
            }
        }
    }
}