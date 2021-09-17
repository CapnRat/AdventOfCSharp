using Advent.AoC2015;
using NUnit.Framework;

namespace AdventTests.AoC2015
{
    public class Star041Test : SolutionTest<Star041>
    {
        [TestCase("abcdef", "609043")]
        [TestCase("pqrstuv", "1048970")]
        public void SampleTests(string input, string expected)
        {
            Run(input, expected);
        }
    }
}