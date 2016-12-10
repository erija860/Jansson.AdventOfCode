using System;
using System.Collections.Generic;
using TinyIoC;

namespace Jansson.AdventOfCode.DayTwo.Runner
{
    internal class Program
    {
        private static void Main()
        {
            var container = TinyIoCContainer.Current;


            var codeCalculator =
                new BathroomCodeCalculator(
                    new List<IKeypad>
                    {
                        new KeypadPartOne(),
                        new KeypadPartTwo()
                    });

            container.Register<ICodeCalculator>(codeCalculator);

            var calculator = container.Resolve<ICodeCalculator>();
            var results = calculator.CalculateCode(Environment.CurrentDirectory + "/BathroomInput.txt");


            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }
    }
}