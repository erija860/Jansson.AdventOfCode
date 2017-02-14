using System.Collections.Generic;

namespace Jansson.AdventOfCode.DayTwo
{
    public abstract class KeypadBase : IKeypad
    {
        protected KeypadBase(Dictionary<string, IKeypadButton> buttons, string startingButton)
        {
            Buttons = buttons;
            CurrentPosition = Buttons[startingButton];
        }

        protected Dictionary<string, IKeypadButton> Buttons { get; set; }

        public IKeypadButton CurrentPosition { get; set; }

        public void Walk(char step)
        {
            var newPosition = string.Empty;
            if (step == 'U')
                newPosition = CurrentPosition.TryWalkUp();
            if (step == 'R')
                newPosition = CurrentPosition.TryWalkRight();
            if (step == 'D')
                newPosition = CurrentPosition.TryWalkDown();
            if (step == 'L')
                newPosition = CurrentPosition.TryWalkLeft();
            CurrentPosition = Buttons[newPosition];
        }
    }
}