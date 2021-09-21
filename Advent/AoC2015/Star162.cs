using System.Linq;
using Advent.Common;

namespace Advent.AoC2015
{
    [Solution(15,16, 2)]
    public class Star162 : Solution
    {
        public override string Run(string input)
        {
            return Star161.InputToSues(input).First(s => s.Item2.All(i =>
                i.Item1 switch
                {
                    1 or 7 => Star161.Requirements[i.Item1] < i.Item2,
                    3 or 6 => Star161.Requirements[i.Item1] > i.Item2,
                    _ => Star161.Requirements[i.Item1] == i.Item2
                })).Item1.ToString();
        }
    }
}