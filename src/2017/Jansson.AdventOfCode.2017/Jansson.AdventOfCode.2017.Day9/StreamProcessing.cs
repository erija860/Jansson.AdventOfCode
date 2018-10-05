using System;
using System.IO;

namespace Jansson.AdventOfCode._2017.Day9
{
    public class StreamProcessing
    {
        public StreamProcessingResult Cleanup(char[] input)
        {
            var score = 0;
            var groupNestLevel = 0;
            var isInGarbage = false;
            var skipNext = false;
            var removedCharacters = 0;

            foreach (var character in input)
            {
                if (skipNext)
                {
                    skipNext = false;
                    continue;
                }

                switch (character)
                {
                    case '!':
                        skipNext = true;
                        continue;
                    case '<' when !isInGarbage:
                        isInGarbage = true;
                        continue;
                    case '>':
                        isInGarbage = false;
                        continue;
                    case '{' when !isInGarbage:
                        groupNestLevel++;
                        continue;
                    case '}' when !isInGarbage:
                        score += groupNestLevel;
                        groupNestLevel--;
                        continue;
                }

                if (isInGarbage)
                {
                    removedCharacters++;
                }
            }

            return new StreamProcessingResult
            {
                Score = score,
                RemovedCharacters = removedCharacters
            };
        }

        public class StreamProcessingResult
        {
            public int Score { get; set; }
            public int RemovedCharacters { get; set; }
        }
    }
}