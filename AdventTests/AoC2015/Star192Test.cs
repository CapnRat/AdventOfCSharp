using System.Diagnostics;
using Advent.AoC2015;
using NUnit.Framework;

namespace AdventTests.AoC2015
{
    public class Star192Test : SolutionTest<Star192>
    {
        [TestCase(@"e => H
e => O
H => HO
H => OH
O => HH

HOH", "3")]
        [TestCase(@"e => H
e => O
H => HO
H => OH
O => HH

HOHOHO", "6")]
        public void SampleTests(string input, string expected)
        {
            Run(input, expected);
        }
    }
}