using Advent.AoC2015;
using NUnit.Framework;

namespace AdventTests.AoC2015
{
    public class Star062Test : SolutionTest<Star062>
    {
        [TestCase("turn on 0,0 through 0,0\ntoggle 0,0 through 999,999", "2000001")]
        public void SampleTests(string input, string expected)
        {
            Run(input, expected);
        }
    }
}