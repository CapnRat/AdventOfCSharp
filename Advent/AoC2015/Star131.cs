using System.Collections.Generic;
using System.Linq;
using Advent.Common;
using Combinatorics.Collections;

namespace Advent.AoC2015
{
    [Solution(15,13,1)]
    public class Star131 : Solution
    {
        public override string Run(string input)
        {
            var people = new HashSet<string>();
            var happiness = new Dictionary<string, int>();
            foreach (var line in Utility.InputToLines(input))
            {
                var splits = line.Split(" ");

                var person = splits[0];
                var otherPerson = splits[10].Trim('.');
                var value = int.Parse(splits[3]) * (splits[2] == "gain" ? 1 : -1);

                people.Add(person);
                happiness.Add(person + otherPerson, value);
            }
            
            return new Permutations<string>(people).Max(table =>
            {
                var sum = 0;
                for (int i = 0; i < table.Count; i++)
                {
                    var leftIndex = i == 0 ? table.Count - 1 : i - 1;
                    var rightIndex = i == table.Count - 1 ? 0 : i + 1;

                    sum += happiness[table[i] + table[leftIndex]] + happiness[table[i] + table[rightIndex]];
                }

                return sum;
            }).ToString();
        }
    }
}