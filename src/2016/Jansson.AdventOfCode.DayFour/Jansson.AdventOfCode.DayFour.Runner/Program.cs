using System;

namespace Jansson.AdventOfCode.DayFour.Runner
{
    internal class Program
    {
        private static void Main()
        {
            var validator = new RoomValidator();
            Console.WriteLine(validator.GetSumOfSectorIdsOfRealRooms("InputFile.txt"));
            Console.WriteLine(validator.GetSectorIdOfNorthPoleObjectStorage());
        }
    }
}