using System.Collections.Generic;
using System.IO;

namespace Advent.Common
{
    public static class Utility
    {
        public static IEnumerable<string> InputToLines(string input)
        {
            using var reader = new StringReader(input);
            string line;
            while ((line = reader.ReadLine()) != null)
                yield return line;
        }
    }
}