using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

        public static int[] InputToIntCode(string input)
        {
            return input.Split(',').Select(int.Parse).ToArray();
        }

        public static IEnumerable<TResult> InputTo<TResult>(Func<string, TResult> func, string input)
        {
            return InputToLines(input).Select(func);
        }
    }
}