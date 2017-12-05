using System.Linq;

namespace Jansson.AdventOfCode._2017.Day4
{
    public class Passphrase
    {
        public Passphrase(string words)
        {
            Words = words.Split(null);
        }

        public string[] Words { get; set; }

        public bool IsValid()
        {
            return !Words
                .GroupBy(x => x)
                .Any(x => x.Count() > 1);
        }

        public bool IsValidAnagramStyle()
        {
            return !Words
                .GroupBy(x => string.Concat(x.OrderBy(s => s)))
                .Any(x => x.Count() > 1);
        }
    }
}