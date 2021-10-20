using System;
using Advent.Common;

namespace Advent.AoC2019
{
    [Solution(19,2,2)]
    public class Star022 : Solution<int>
    {
        public override int Run(string input)
        {
            var program = Utility.InputToIntCode(input);
            var runner = new IntCodeRunner();
            for (int noun = 0; noun < 99; noun++)
            {
                for (int verb = 0; verb < 99; verb++)
                {
                    var testProgram = new int[program.Length];
                    Array.Copy(program, testProgram, program.Length);

                    testProgram[1] = noun;
                    testProgram[2] = verb;
                    
                    runner.Reset(testProgram);
                    runner.Run();

                    if (runner.Program[0] == 19690720)
                        return 100 * noun + verb;
                }
            }

            throw new InvalidProgramException();
        }
    }
}