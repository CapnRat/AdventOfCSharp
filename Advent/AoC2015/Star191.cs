using System.Collections.Generic;
using System.Linq;
using System.Text;
using Advent.Common;

namespace Advent.AoC2015
{
    [Solution(15,19,1)]
    public class Star191 : Solution
    {
        public override string Run(string input)
        {
            var (molecule, replacementTuples) = InputToData(input);

            var builder = new StringBuilder();
            var molecules = new HashSet<string>();
            foreach (var replacement in replacementTuples)
            {
                var splits = molecule.Split(replacement.Item1);
                for (var i = 0; i < splits.Length - 1; i++)
                {
                    builder.Clear();
                    for (var j = 0; j < splits.Length - 1; j++)
                    {
                        builder.Append(splits[j]);
                        builder.Append(j == i ? replacement.Item2 : replacement.Item1);
                    }
                    builder.Append(splits[^1]);

                    molecules.Add(builder.ToString());
                }
            }
            return molecules.Count.ToString();
        }

        public static (string molecule, IEnumerable<(string, string)> replacementTuples) InputToData(string input)
        {
            var lines = Utility.InputToLines(input).ToArray();
            var molecule = lines[^1];
            var replacementTuples = lines[..^2].Select(l =>
            {
                var splits = l.Split(" => ");
                return (splits[0], splits[1]);
            });
            return (molecule, replacementTuples);
        }
    }
}