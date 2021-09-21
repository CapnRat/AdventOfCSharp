using System.Collections.Generic;
using System.Linq;
using Advent.Common;

namespace Advent.AoC2015
{
    [Solution(15,16,1)]
    public class Star161 : Solution
    {
        public static readonly Dictionary<string, int> KeyToIndex = new Dictionary<string, int>()
        {
            ["children"] = 0,
            ["cats"] = 1,
            ["samoyeds"] = 2,
            ["pomeranians"] = 3,
            ["akitas"] = 4,
            ["vizslas"] = 5,
            ["goldfish"] = 6,
            ["trees"] = 7,
            ["cars"] = 8,
            ["perfumes"] = 9
        };

        public static readonly int[] Requirements = {3, 7, 2, 3, 0, 0, 5, 3, 2, 1};

        public override string Run(string input)
        {
            return InputToSues(input).First(s => s.Item2.All(i => Requirements[i.Item1] == i.Item2)).Item1.ToString();
        }

        public static IEnumerable<(int, List<(int, int)>)> InputToSues(string input)
        {
            return Utility.InputToLines(input).Select(l =>
            {
                var splits = l.Split(" ").Select(s => s.Trim(':').Trim(',')).ToArray();

                var sue = int.Parse(splits[1]);
                var items = new List<(int, int)>();
                for (int i = 0; i < 3; i++)
                {
                    items.Add((KeyToIndex[splits[2 * i + 2]], int.Parse(splits[2 * i + 3])));
                }

                return (sue, items);
            });
        }
    }
}