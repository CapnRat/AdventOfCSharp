using System.Linq;
using Advent.Common;

namespace Advent.AoC2015
{
    [Solution(15,5,2)]
    public class Star052 : Solution
    {
        public override string Run(string input)
        {
            return Utility.InputToLines(input).Count(l =>
            {
                var doubled = false;
                var sandwiched = false;
                for (var i = 0; i < l.Length - 2; i++)
                {
                    if (!doubled)
                    {
                        doubled = string.Concat(l.Skip(i + 2)).Contains($"{l[i]}{l[i+1]}");
                    }

                    if (!sandwiched)
                    {
                        sandwiched = l[i] == l[i + 2];
                    }
                }

                return doubled && sandwiched;
            }).ToString();
        }
    }
}