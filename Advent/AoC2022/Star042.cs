using System.Linq;
using Advent.Common;

namespace Advent.AoC2022
{
    [Solution(22, 4, 2)]
    public class Star042 : Solution<int>
    {
        public override int Run(string input)
        {
            return Utility.InputTo(l =>
            {
                var pairs = l.Split(',');
                return (Star041.SplitToIDs(pairs[0]), Star041.SplitToIDs(pairs[1]));
            }, input).Count(pair => pair.Item1.Intersect(pair.Item2).Any());
        }
    }
}