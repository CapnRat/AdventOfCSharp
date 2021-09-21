using Advent.AoC2015;
using NUnit.Framework;

namespace AdventTests.AoC2015
{
    public class Star172Test : SolutionTest<Star172>
    {
        [Test]
        public void SampleTest()
        {
            var containers = new[] {20, 15, 10, 5, 5};
            var liters = 25;
            var expectedCombinations = 3;

            Assert.AreEqual(expectedCombinations, solution.RunWithLiters(containers, liters));
        }
    }
}