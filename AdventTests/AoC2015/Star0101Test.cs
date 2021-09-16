using Advent.AoC2015;
using NUnit.Framework;

namespace AdventTests.AoC2015
{
    public class Star0101Test : SolutionTest<Star011>
    {
        [TestCase("(())", "0")]
        [TestCase("()()", "0")]
        [TestCase("(((", "3")]
        [TestCase("(()(()(", "3")]
        [TestCase("))(((((", "3")]
        [TestCase("())", "-1")]
        [TestCase("))(", "-1")]
        [TestCase(")))", "-3")]
        [TestCase(")())())", "-3")]
        public void SampleTests(string input, string expected)
        {
            Run(input, expected);
        }
    }
}