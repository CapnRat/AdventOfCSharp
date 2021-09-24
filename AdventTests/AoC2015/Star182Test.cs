using Advent.AoC2015;
using NUnit.Framework;

namespace AdventTests.AoC2015
{
    public class Star182Test : SolutionTest<Star182>
    {
        private const string input = @"##.#.#
...##.
#....#
..#...
#.#..#
####.#";
        
        [TestCase(1, 18)]
        [TestCase(5, 17)]
        public void SampleTests(int iterations, int expected)
        {
            Assert.AreEqual(expected, solution.RunWithIterations(input, iterations));
        }
    }
}