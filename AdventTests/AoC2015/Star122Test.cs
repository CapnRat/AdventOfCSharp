using Advent.AoC2015;
using NUnit.Framework;

namespace AdventTests.AoC2015
{
    public class Star122Test : SolutionTest<Star122>
    {
        [TestCase("[1,2,3]", "6")]
        [TestCase("[1,{\"c\":\"red\",\"b\":2},3]", "4")]
        [TestCase("{\"d\":\"red\",\"e\":[1,2,3,4],\"f\":5}", "0")]
        [TestCase("[1,\"red\",5]", "6")]
        public void SampleTests(string input, string expected)
        {
            Run(input, expected);
        }
    }
}