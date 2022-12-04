using System.Collections.Generic;
using System.Linq;
using Advent.Common;

namespace Advent.AoC2022
{
    [Solution(22, 4,1)]
    public class Star041 : Solution<int>
    {
        public static IEnumerable<int> SplitToIDs(string split)
        {
            var range = split.Split('-').Select(int.Parse).ToArray();
            return Enumerable.Range(range[0], range[1] + 1 - range[0]);
        }
        
        public override int Run(string input)
        {
            return Utility.InputTo(l =>
            {
                var pairs = l.Split(',');
                return (SplitToIDs(pairs[0]), SplitToIDs(pairs[1]));
            }, input).Where(pair =>
            {
                var intersectCount = pair.Item1.Intersect(pair.Item2).Count();
                return (intersectCount == pair.Item1.Count() || intersectCount == pair.Item2.Count());
            }).Count();
        }
    }
}