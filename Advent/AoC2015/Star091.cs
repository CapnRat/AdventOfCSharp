using System.Collections.Generic;
using System.Linq;
using Advent.Common;
using Combinatorics.Collections;

namespace Advent.AoC2015
{
    [Solution(15,9,1)]
    public class Star091 : Solution
    {
        public override string Run(string input)
        {
            var locations = new HashSet<string>();
            var distances = new Dictionary<string, int>();
            var lines = Utility.InputToLines(input);
            foreach (var line in lines)
            {
                var splits = line.Split(" ");
                var locLeft = splits[0];
                var locRight = splits[2];
                var distance = int.Parse(splits[4]);

                locations.Add(locLeft);
                locations.Add(locRight);
                distances.Add(locLeft + locRight, distance);
                distances.Add(locRight + locLeft, distance);
            }

            return new Permutations<string>(locations, GenerateOption.WithoutRepetition).Select(route =>
            {
                var distance = 0;
                for (var i = 0; i < route.Count - 1; i++)
                {
                    distance += distances[route[i] + route[i + 1]];
                }

                return distance;
            }).Min().ToString();
        }
    }
}