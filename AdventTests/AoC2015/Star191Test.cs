using System.Diagnostics;
using Advent.AoC2015;
using NUnit.Framework;

namespace AdventTests.AoC2015
{
    public class Star191Test : SolutionTest<Star191>
    {
        [TestCase(@"H => HO
H => OH
O => HH

HOH", "4")]
        public void SampleTests(string input, string expected)
        {
            Run(input, expected);
        }
    }
}