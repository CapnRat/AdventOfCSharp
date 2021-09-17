using Advent.AoC2015;
using NUnit.Framework;

namespace AdventTests.AoC2015
{
    public class Star061Test : SolutionTest<Star061>
    {
        [TestCase("turn on 0,0 through 999,999", "On (0, 0) (999, 999)")]
        [TestCase("toggle 0,0 through 999,0", "Toggle (0, 0) (999, 0)")]
        [TestCase("turn off 499,499 through 500,500", "Off (499, 499) (500, 500)")]
        public void ParseConstructionTests(string input, string expected)
        {
            Assert.AreEqual(expected, Star061.ParseConstruction(input).ToString());
        }

        [TestCase(@"turn on 0,0 through 999,999
toggle 0,0 through 999,0
turn off 499,499 through 500,500", "998996")]
        public void SampleTests(string input, string expected)
        {
            Run(input, expected);
        }
    }
}