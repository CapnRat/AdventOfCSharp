using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Advent.Common;

namespace Advent.AoC2022
{
    [Solution(22, 13, 2)]
    public class Star132 : Solution<int>
    {
        public override int Run(string input)
        {
            var token1 = JArray.Parse("[[2]]");
            var token2 = JArray.Parse("[[6]]");
            
            var list = Utility.InputToLines(input)
                .Where(l => !string.IsNullOrEmpty(l))
                .Select(JArray.Parse)
                .Append(token1)
                .Append(token2)
                .OrderBy(x => x, Comparer<JArray>.Create(Star131.Compare))
                .ToList();

            return (list.IndexOf(token1) + 1) * (list.IndexOf(token2) + 1);
        }
    }
}