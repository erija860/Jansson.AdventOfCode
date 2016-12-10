using System.Collections.Generic;

namespace Jansson.AdventOfCode.DayTwo
{
    public class KeypadPartOne : KeypadBase
    {
        public KeypadPartOne()
            : base(new Dictionary<string, IKeypadButton>
            {
                {"1", new KeypadButton("1", "1", "4", "1", "2")},
                {"2", new KeypadButton("2", "2", "5", "1", "3")},
                {"3", new KeypadButton("3", "3", "6", "2", "3")},
                {"4", new KeypadButton("4", "1", "7", "4", "5")},
                {"5", new KeypadButton("5", "2", "8", "4", "6")},
                {"6", new KeypadButton("6", "3", "9", "5", "6")},
                {"7", new KeypadButton("7", "4", "7", "7", "8")},
                {"8", new KeypadButton("8", "5", "8", "7", "9")},
                {"9", new KeypadButton("9", "6", "9", "8", "9")}
            }, "5")
        {
        }
    }
}