using Advent.AoC2015;
using NUnit.Framework;

namespace AdventTests.AoC2015
{
    public class Star181Test : SolutionTest<Star181>
    {
        private const string input = @".#.#.#
...##.
#....#
..#...
#.#..#
####..";
        
        [TestCase(1, 11)]
        [TestCase(2, 8)]
        [TestCase(3, 4)]
        [TestCase(4, 4)]
        public void SampleTests(int iterations, int expected)
        {
            Assert.AreEqual(expected, solution.RunWithIterations(input, iterations));
        }
    }
}