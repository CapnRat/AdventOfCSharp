using System;
using System.IO;
using System.Linq;
using Advent.Common;

namespace Advent.AoC2015
{
    [Solution(15, 02, 1)]
    public class Star021 : Solution
    {
        public override string Run(string input)
        {
            var result = RunWithAccum(input, (l,w,h) =>
            {
                var sides = new[] {l * w, w * h, h * l};
                return 2 * sides.Sum() + sides.Min();
            });

            return result.ToString();
        }

        public static int RunWithAccum(string input, Func<int, int, int, int> func)
        {
            var result = 0;
            using var reader = new StringReader(input);
            while (true)
            {
                var line = reader.ReadLine();
                if (String.IsNullOrEmpty(line))
                {
                    return result;
                }

                var (l, w, h) = SplitsToTuple(line.Split('x'));
                result += func(l,w,h);
            }
        }

        public static (int, int, int) SplitsToTuple(string[] splits)
        {
            return (int.Parse(splits[0]),
                int.Parse(splits[1]),
                int.Parse(splits[2]));
        }
    }
}