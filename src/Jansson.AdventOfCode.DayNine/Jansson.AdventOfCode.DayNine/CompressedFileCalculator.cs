using System.IO;

namespace Jansson.AdventOfCode.DayNine
{
    public class CompressedFileCalculator
    {
        private readonly string _file;

        public CompressedFileCalculator(string filename)
        {
            _file = File.ReadAllText(filename);
        }

        public int GetDecompressedLength()
        {
            var decompressedLength = 0;
            for (var i = 0; i < _file.Length; i++)
                if (_file[i] == '(')
                {
                    var lettersToRepeat = string.Empty;
                    for (var j = 1; j < 10; j++)
                    {
                        if (_file[i + j] == 'x')
                            break;
                        lettersToRepeat = lettersToRepeat + _file[i + j];
                    }
                    var timesToRepeat = string.Empty;
                    for (var j = 2; j < 10; j++)
                    {
                        if (_file[i + j + lettersToRepeat.Length] == ')')
                            break;
                        timesToRepeat = timesToRepeat + _file[i + j + lettersToRepeat.Length];
                    }
                    var lengthToAdd = int.Parse(lettersToRepeat) * int.Parse(timesToRepeat);
                    decompressedLength += lengthToAdd;
                    i += int.Parse(lettersToRepeat) + lettersToRepeat.Length + timesToRepeat.Length + 2;
                }
                else
                {
                    decompressedLength++;
                }
            return decompressedLength;
        }

        public long GetDecompressedLengthRecursive()
        {
            long decompressedLength = 0;

            for (var i = 0; i < _file.Length; i++)
                if (_file[i] == '(')
                {
                    var result = GetValueOfCompressMarker(i);
                    decompressedLength += result.Value;
                    i = result.IndexOfLast;
                }
                else
                {
                    decompressedLength++;
                }
            return decompressedLength;
        }

        public Result GetValueOfCompressMarker(int indexOfFirstBracket)
        {
            var lastindexofmarker = 0;
            var lettersToRepeat = string.Empty;
            for (var j = 1; j < 10; j++)
            {
                if (_file[indexOfFirstBracket + j] == 'x')
                    break;
                lettersToRepeat = lettersToRepeat + _file[indexOfFirstBracket + j];
            }

            var timesToRepeat = string.Empty;
            var indexOfLastBracket = 0;
            for (var j = 2; j < 10; j++)
            {
                if (_file[indexOfFirstBracket + j + lettersToRepeat.Length] == ')')
                {
                    indexOfLastBracket = indexOfFirstBracket + j + lettersToRepeat.Length;
                    break;
                }

                timesToRepeat = timesToRepeat + _file[indexOfFirstBracket + j + lettersToRepeat.Length];
            }

            long intToMultiply = 0;

            var loops = int.Parse(lettersToRepeat);

            for (var i = 1; i <= loops; i++)
                if (_file[indexOfLastBracket + i] == '(')
                {
                    var result = GetValueOfCompressMarker(indexOfLastBracket + i);
                    intToMultiply += result.Value;
                    i = result.IndexOfLast - indexOfLastBracket;
                    lastindexofmarker = indexOfLastBracket + i;
                }
                else
                {
                    intToMultiply++;
                    lastindexofmarker = indexOfLastBracket + i;
                }

            var lengthToAdd = intToMultiply * int.Parse(timesToRepeat);

            return new Result { Value = lengthToAdd, IndexOfLast = lastindexofmarker };
        }
    }
}