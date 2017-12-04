using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Jansson.AdventOfCode._2017.Day4
{
    public class PassphraseValidator
    {
        public int CalculateValidPassphraseCountWordLimit(string fileName)
        {
            var passphrases = ParsePassphrases(fileName);

            return passphrases.Count(x => x.IsValid());
        }

        private static IEnumerable<Passphrase> ParsePassphrases(string fileName)
        {
            return File
                .ReadAllLines(fileName)
                .Select(x => new Passphrase(x))
                .ToList();
        }

        public int CalculateValidPassphraseCountWordLimitWithAnagram(string fileName)
        {
            var passphrases = ParsePassphrases(fileName);

            return passphrases.Count(x => x.IsValidAnagramStyle());
        }
    }

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