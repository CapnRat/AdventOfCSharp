using Advent.AoC2015;
using NUnit.Framework;

namespace AdventTests.AoC2015
{
    public class Star051Test : SolutionTest<Star051>
    {
        [TestCase("ugknbfddgicrmopn", "1")]
        [TestCase("aaa", "1")]
        [TestCase("jchzalrnumimnmhp", "0")]
        [TestCase("haegwjzuvuyypxyu", "0")]
        [TestCase("dvszwmarrgswjxmb", "0")]
        [TestCase("ugknbfddgicrmopn\naaa\ndvszwmarrgswjxmb", "2")]
        public void SampleTests(string input, string expected)
        {
            Run(input, expected);
        }
    }
}