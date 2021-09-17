using Advent.AoC2015;
using NUnit.Framework;

namespace AdventTests.AoC2015
{
    public class Star091Test : SolutionTest<Star091>
    {
        [TestCase(@"London to Dublin = 464
London to Belfast = 518
Dublin to Belfast = 141", "605")]
        public void SampleTests(string input, string expected)
        {
            Run(input, expected);
        }
    }
}