using System;
using System.Threading.Channels;
using System.Threading.Tasks;
using Advent.Common;

namespace Advent.AoC2019
{
    [Solution(19,5, 1)]
    public class Star051 : Solution<int>
    {
        public override int Run(string input)
        {
            var inputChannel = Channel.CreateBounded<int>(1);
            var runner = new IntCodeRunner(Utility.InputToIntCode(input), inputChannel);

            var runnerTask = Task.Run(runner.Run);
            var ioTask = Task.Run(async () =>
            {
                await inputChannel.Writer.WriteAsync(1);
                await foreach (int output in runner.Output.Reader.ReadAllAsync())
                {
                    if (output == 0) continue;
                    return output;
                }

                return -1;
            });

            Task.WaitAll(runnerTask, ioTask);

            return ioTask.Result;
        }
    }
}