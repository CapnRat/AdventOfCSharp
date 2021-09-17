using Advent.AoC2015;
using NUnit.Framework;

namespace AdventTests.AoC2015
{
    public class Star121Test : SolutionTest<Star121>
    {
        [TestCase("[1,2,3]", "6")]
        [TestCase("{\"a\":2,\"b\":4}", "6")]
        [TestCase("[[[3]]]", "3")]
        [TestCase("{\"a\":{\"b\":4},\"c\":-1}", "3")]
        [TestCase("{\"a\":[-1,1]}", "0")]
        [TestCase("[-1,{\"a\":1}]", "0")]
        [TestCase("[]", "0")]
        [TestCase("{}", "0")]
        public void SampleTests(string input, string expected)
        {
            Run(input, expected);
        }
    }
}