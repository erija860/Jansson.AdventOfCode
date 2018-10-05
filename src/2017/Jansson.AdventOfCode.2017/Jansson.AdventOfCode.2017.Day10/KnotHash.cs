using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jansson.AdventOfCode._2017.Day10
{
    public class KnotHash
    {
        public KnotHashResult Calculate(
            CircularList circularList,
            int[] inputLengths)
        {
            foreach (var inputLength in inputLengths)
            {
                if (!circularList.IsValidLength(inputLength))
                    continue;

                circularList.Reverse(inputLength);
                circularList.Move(inputLength);
                circularList.IncreaseSkipSize();
            }

            return new KnotHashResult
            {
                FirstTwoNumbersMultiplied = circularList.GetFirstTwoValuesMultiplied()
            };
        }

        public KnotHashResult CalculatePart2(
            CircularList circularList,
            string inputLengths)
        {
            var bytes = Encoding.ASCII.GetBytes(inputLengths).Select(x => (int)x).ToList();
            bytes.AddRange(new[] { 17, 31, 73, 47, 23 });

            for (var i = 0; i < 64; i++)
                foreach (var inputLength in bytes)
                {
                    if (!circularList.IsValidLength(inputLength))
                        continue;

                    circularList.Reverse(inputLength);
                    circularList.Move(inputLength);
                    circularList.IncreaseSkipSize();
                }

            return new KnotHashResult
            {
                FirstTwoNumbersMultiplied = circularList.GetFirstTwoValuesMultiplied()
            };
        }

        public class KnotHashResult
        {
            public int FirstTwoNumbersMultiplied { get; set; }
            public string DenseHash { get; set; }
        }
    }

    public class CircularList
    {
        private readonly IList<int> _circularList;
        private int _position;
        private int _skipSize;

        public CircularList(int length)
        {
            _circularList = new List<int>();

            for (var i = 0; i < length; i++)
                _circularList.Add(i);
        }

        public void Reverse(int inputLength)
        {
            var numbersToReverse = new List<int>();

            var position = _position;

            for (var i = 0; i < inputLength; i++)
            {
                if (position >= _circularList.Count)
                    position = 0;

                numbersToReverse.Add(_circularList[position]);
                position++;
            }

            numbersToReverse.Reverse();

            position = _position;


            foreach (var reversedNumber in numbersToReverse)
            {
                if (position >= _circularList.Count)
                    position = 0;

                _circularList[position] = reversedNumber;
                position++;
            }
        }

        public void Move(int inputLength)
        {
            var stepsToMove = inputLength + _skipSize;

            if (stepsToMove + _position >= _circularList.Count)
            {
                _position = stepsToMove + _position - _circularList.Count;
                return;
            }

            _position = stepsToMove + _position;
        }

        public void IncreaseSkipSize()
        {
            _skipSize++;
        }

        public bool IsValidLength(int inputLength)
        {
            return inputLength <= _circularList.Count;
        }

        public int GetFirstTwoValuesMultiplied()
        {
            return _circularList[0] * _circularList[1];
        }
    }
}