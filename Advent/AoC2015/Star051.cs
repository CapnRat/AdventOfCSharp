using System.Collections.Generic;
using System.IO;
using System.Linq;
using Advent.Common;

namespace Advent.AoC2015
{
    [Solution(15,5,1)]
    public class Star051 : Solution
    {
        static readonly char[] Vowels = {'a', 'e', 'i', 'o', 'u'};
        static readonly string[] Naughty = {"ab", "cd", "pq", "xy"};

        public override string Run(string input)
        {
            var doubles = Enumerable.Range('a', 'z' - 'a' + 1).Select(i => $"{(char)i}{(char)i}");
            return InputToLines(input).Count(l => Vowels.Select(v => l.Count(c => c == v)).Sum() >= 3
                                                  && doubles.Any(l.Contains)
                                                  && !Naughty.Any(l.Contains)).ToString();
        }

        public static IEnumerable<string> InputToLines(string input)
        {
            using var reader = new StringReader(input);
            string line;
            while ((line = reader.ReadLine()) != null)
                yield return line;
        }
    }
}