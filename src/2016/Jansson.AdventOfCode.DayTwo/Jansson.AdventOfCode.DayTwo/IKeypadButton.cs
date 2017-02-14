namespace Jansson.AdventOfCode.DayTwo
{
    public interface IKeypadButton
    {
        string Name { get; }

        string TryWalkUp();
        string TryWalkDown();
        string TryWalkLeft();
        string TryWalkRight();
    }
}