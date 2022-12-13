using System.Linq;
using Advent.Common;
using Newtonsoft.Json.Linq;

namespace Advent.AoC2022
{
    [Solution(22, 13, 2)]
    public class Star132 : Solution<int>
    {
        public override int Run(string input)
        {
            var token1 = JArray.Parse("[[2]]");
            var token2 = JArray.Parse("[[6]]");
            
            var list = Utility.InputToLines(input).Where(l => !string.IsNullOrEmpty(l)).Select(JArray.Parse).ToList();
            list.Add(token1);
            list.Add(token2);
            list.Sort(Star131.Compare);

            return (list.IndexOf(token1) + 1) * (list.IndexOf(token2) + 1);
        }
    }
}