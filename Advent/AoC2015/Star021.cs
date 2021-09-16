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
            var result = 0;
            using var reader = new StringReader(input);
            while (true)
            {
                var line = reader.ReadLine();
                if (String.IsNullOrEmpty(line))
                {
                    return result.ToString();
                }

                var (l, w, h) = SplitsToTuple(line.Split('x'));
                var sides = new[] {l * w, w * h, h * l};
                result += 2 * sides.Sum() + sides.Min();
            }
        }

        private (int, int, int) SplitsToTuple(string[] splits)
        {
            return (int.Parse(splits[0]),
                int.Parse(splits[1]),
                int.Parse(splits[2]));
        }
    }
}