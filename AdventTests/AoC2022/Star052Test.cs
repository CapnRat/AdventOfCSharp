using Advent.AoC2022;
using NUnit.Framework;

namespace AdventTests.AoC2022
{
    public class Star052Test : SolutionTest<Star052>
    {
        [TestCase(@"    [D]    
[N] [C]    
[Z] [M] [P]
 1   2   3 

move 1 from 2 to 1
move 3 from 1 to 3
move 2 from 2 to 1
move 1 from 1 to 2", "MCD")]
        public void ExampleTests(string input, string expected)
        {
            Run(input, expected);
        }
    }
}