using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Jansson.AdventOfCode._2017.Day4
{
    public class PassphraseValidator
    {
        public int CalculateValidPassphraseCount(string fileName, bool allowAnagrams = true)
        {
            var passphrases = ParsePassphrases(fileName);

            return allowAnagrams
                ? passphrases.Count(x => x.IsValid())
                : passphrases.Count(x => x.IsValidAnagramStyle());
        }

        private static IEnumerable<Passphrase> ParsePassphrases(string fileName)
        {
            return File
                .ReadAllLines(fileName)
                .Select(x => new Passphrase(x))
                .ToList();
        }
    }
}