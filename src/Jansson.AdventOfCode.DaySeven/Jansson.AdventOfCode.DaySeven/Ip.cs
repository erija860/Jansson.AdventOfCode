namespace Jansson.AdventOfCode.DaySeven
{
    public class Ip
    {
        private readonly string[] _splitLine;
        private char _innerAba;
        private char _outerAba;

        public Ip(string line)
        {
            _splitLine = line.Split('[', ']');
        }

        public bool SupportsSsl()
        {
            var supportsSsl = false;
            for (var i = 0; i < _splitLine.Length - 1; i += 2)
                if (HasAbaAndBab(_splitLine[i]))
                    supportsSsl = true;

            if (HasAbaAndBab(_splitLine[_splitLine.Length - 1]))
                supportsSsl = true;

            return supportsSsl;
        }

        private bool HasBab()
        {
            var hasBab = false;
            for (var i = 0; i < _splitLine.Length - 1; i += 2)
                for (var y = 0; y < _splitLine[i + 1].Length - 2; y++)
                    if (_splitLine[i + 1][y].Equals(_innerAba) && _splitLine[i + 1][y + 2].Equals(_innerAba) &&
                        _splitLine[i + 1][y + 1].Equals(_outerAba))
                        hasBab = true;

            return hasBab;
        }

        private bool HasAbaAndBab(string line)
        {
            var hasAba = false;

            for (var i = 0; i < line.Length - 2; i++)
                if (line[i].Equals(line[i + 2]) && !line[i].Equals(line[i + 1]))
                {
                    _outerAba = line[i];
                    _innerAba = line[i + 1];
                    if (HasBab())
                        hasAba = true;
                }

            return hasAba;
        }


        public bool SupportsTls()
        {
            var hasAbba = false;
            var hasAbbaInsideBrackets = false;

            for (var i = 0; i < _splitLine.Length - 1; i += 2)
            {
                if (HasAbba(_splitLine[i]))
                    hasAbba = true;
                if (HasAbba(_splitLine[i + 1]))
                    hasAbbaInsideBrackets = true;
            }
            if (HasAbba(_splitLine[_splitLine.Length - 1]))
                hasAbba = true;
            if (hasAbbaInsideBrackets)
                return false;
            return hasAbba;
        }

        private bool HasAbba(string line)
        {
            var hasAbba = false;

            for (var i = 0; i < line.Length - 3; i++)
                if (line[i].Equals(line[i + 3]) && line[i + 1].Equals(line[i + 2]) && !line[i].Equals(line[i + 1]))
                    hasAbba = true;
            return hasAbba;
        }
    }
}