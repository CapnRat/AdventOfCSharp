using Advent.AoC2021;
using NUnit.Framework;

namespace AdventTests.AoC2021
{
    public class Star022Test : SolutionTest<Star022>
    {
        [TestCase(@"forward 5
down 5
forward 8
up 3
down 8
forward 2", 900)]
        public void ExampleTest(string commands, int expected)
        {
            Run(commands, expected);
        }       
    }
}