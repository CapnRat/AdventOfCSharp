using Advent.AoC2015;
using NUnit.Framework;

namespace AdventTests.AoC2015
{
    public class Star052Test : SolutionTest<Star052>
    {
        [TestCase("qjhvhtzxzqqjkmpb", "1")]
        [TestCase("xxyxx", "1")]
        [TestCase("uurcxstgmygtbstg", "0")]
        [TestCase("ieodomkazucvgmuy", "0")]
        [TestCase("qjhvhtzxzqqjkmpb\nxxyxx\nuurcxstgmygtbstg", "2")]
        public void SampleTests(string input, string expected)
        {
            Run(input, expected);
        }
    }
}