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
            var (people, happiness) = ProcessInput(input);

            return GetBestValue(people, happiness).ToString();
        }

        public static int GetBestValue(HashSet<string> people, Dictionary<string, int> happiness)
        {
            var bestValue = new Permutations<string>(people).Max(table =>
            {
                var sum = 0;
                for (int i = 0; i < table.Count; i++)
                {
                    var leftIndex = i == 0 ? table.Count - 1 : i - 1;
                    var rightIndex = i == table.Count - 1 ? 0 : i + 1;

                    var leftKey = table[i] + table[leftIndex];
                    var rightKey = table[i] + table[rightIndex];
                    sum += (happiness.ContainsKey(leftKey) ? happiness[leftKey] : 0) + (happiness.ContainsKey(rightKey) ? happiness[rightKey] : 0);
                }

                return sum;
            });
            return bestValue;
        }

        public static (HashSet<string> people, Dictionary<string, int> happiness) ProcessInput(string input)
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

            return (people, happiness);
        }
    }
}