namespace Jansson.AdventOfCode.DayEight
{
    public class Screen
    {
        public readonly char[,] _screen;

        public Screen()
        {
            _screen = new char[6, 50];
            for (var i = 0; i < 6; i++)
                for (var j = 0; j < 50; j++)
                    _screen[i, j] = '.';
        }

        public void TurnOnRectangle(int y, int x)
        {
            for (var i = 0; i < y; i++)
                for (var j = 0; j < x; j++)
                    _screen[i, j] = '#';
        }

        public void RotateRow(int yRow, int bySteps)
        {
            for (var i = 0; i < bySteps; i++)
                RotateRowOneStep(yRow);
        }

        private void RotateRowOneStep(int row)
        {
            var lastChar = _screen[row, 49];
            var newArray = new char[50];
            for (var i = 0; i < 49; i++)
                newArray[i + 1] = _screen[row, i];
            for (var i = 1; i < 50; i++)
                _screen[row, i] = newArray[i];
            _screen[row, 0] = lastChar;
        }

        public void RotateColumn(int xColumn, int bySteps)
        {
            for (var i = 0; i < bySteps; i++)
                RotateColumnOneStep(xColumn);
        }

        private void RotateColumnOneStep(int column)
        {
            var lastChar = _screen[5, column];
            var newArray = new char[6];
            for (var i = 0; i < 5; i++)
                newArray[i + 1] = _screen[i, column];
            for (var i = 1; i < 6; i++)
                _screen[i, column] = newArray[i];
            _screen[0, column] = lastChar;
        }

        public int GetPixelsLit()
        {
            var pixels = 0;
            for (var i = 0; i < 50; i++)
                for (var j = 0; j < 6; j++)
                    if (_screen[j, i] == '#')
                        pixels++;
            return pixels;
        }
    }
}