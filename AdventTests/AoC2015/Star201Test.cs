using System.Diagnostics;
using Advent.AoC2015;
using NUnit.Framework;

namespace AdventTests.AoC2015
{
    public class Star201Test : SolutionTest<Star201>
    {
        [TestCase("10", "1")]
        [TestCase("70", "4")]
        [TestCase("60", "4")]
        [TestCase("150", "8")]
        [TestCase("135", "8")]
        public void SampleTests(string input, string expected)
        {
            Run(input, expected);
        }
    }
}