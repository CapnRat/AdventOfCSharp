using Advent.AoC2021;
using NUnit.Framework;

namespace AdventTests.AoC2021
{
    public class Star011Test : SolutionTest<Star011>
    {
        [TestCase(@"199
200
208
210
200
207
240
269
260
263", 7)]
        public void CalcTests(string input, int expected)
        {
            Run(input, expected);
        }
    }
}