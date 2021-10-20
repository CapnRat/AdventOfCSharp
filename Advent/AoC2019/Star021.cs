using Advent.Common;

namespace Advent.AoC2019
{
    [Solution(19,2,1)]
    public class Star021 : Solution<int>
    {
        public override int Run(string input)
        {
            var program = Utility.InputToIntCode(input);
            program[1] = 12;
            program[2] = 2;
            var runner = new IntCodeRunner(program);
            runner.Run();
            return runner.Program[0];
        }
    }
}