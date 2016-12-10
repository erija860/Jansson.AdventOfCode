namespace Jansson.AdventOfCode.DayTwo
{
    public class KeypadButton : IKeypadButton
    {
        private readonly string _above;
        private readonly string _below;
        private readonly string _left;
        private readonly string _right;

        public KeypadButton(string name, string above, string below, string left, string right)
        {
            _above = above;
            _below = below;
            _left = left;
            _right = right;
            Name = name;
        }

        public string Name { get; }

        public string TryWalkUp() => _above;

        public string TryWalkDown() => _below;

        public string TryWalkLeft() => _left;

        public string TryWalkRight() => _right;
    }
}