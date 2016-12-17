namespace Jansson.AdventOfCode.DayEight.Runner
{
    internal class Program
    {
        private static void Main()
        {
            var validator = new KeypadScreenCalculator();
            validator.ParseInput("InputFile.txt");
            validator.ExecuteCommands();
            validator.PrintCompleteScreen();
        }
    }
}