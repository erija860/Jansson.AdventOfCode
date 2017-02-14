using System.Collections.Generic;

namespace Jansson.AdventOfCode.DayTwo
{
    public class KeypadPartTwo : KeypadBase
    {
        public KeypadPartTwo()
            : base(new Dictionary<string, IKeypadButton>
                {
                    {"1", new KeypadButton("1", "1", "3", "1", "1")},
                    {"2", new KeypadButton("2", "2", "6", "2", "3")},
                    {"3", new KeypadButton("3", "1", "7", "2", "4")},
                    {"4", new KeypadButton("4", "4", "8", "3", "4")},
                    {"5", new KeypadButton("5", "5", "5", "5", "6")},
                    {"6", new KeypadButton("6", "2", "A", "5", "7")},
                    {"7", new KeypadButton("7", "3", "B", "6", "8")},
                    {"8", new KeypadButton("8", "4", "C", "7", "9")},
                    {"9", new KeypadButton("9", "9", "9", "8", "9")},
                    {"A", new KeypadButton("A", "6", "A", "A", "B")},
                    {"B", new KeypadButton("B", "7", "D", "A", "C")},
                    {"C", new KeypadButton("C", "8", "C", "B", "C")},
                    {"D", new KeypadButton("D", "B", "D", "D", "D")}
                },
                "5")
        {
        }
    }
}