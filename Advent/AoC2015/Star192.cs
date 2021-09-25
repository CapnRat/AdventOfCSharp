using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using Advent.Common;

namespace Advent.AoC2015
{
    [Solution(15,19,2)]
    public class Star192 : Solution
    {
        public override string Run(string input)
        {
            var (molecule, replacements) = Star191.InputToData(input);
            var orderedReplacements = replacements.OrderByDescending(t => t.Item2.Length);

            int i = 0;
            for (; molecule != "e"; i++)
            {
                var replacement = orderedReplacements.First(t => molecule.Contains(t.Item2));
                var index = molecule.IndexOf(replacement.Item2);

                molecule = molecule.Substring(0, index) + replacement.Item1 + molecule.Substring(index + replacement.Item2.Length);
            }
            
            return i.ToString();
        }
    }
}