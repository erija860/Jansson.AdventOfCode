namespace Jansson.AdventOfCode.DayTwo
{
    public interface IKeypad
    {
        IKeypadButton CurrentPosition { get; }
        void Walk(char step);
    }
}