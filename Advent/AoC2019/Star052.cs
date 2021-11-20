using System;
using System.Threading.Channels;
using System.Threading.Tasks;
using Advent.Common;

namespace Advent.AoC2019
{
    [Solution(19,5, 2)]
    public class Star052 : Solution<int>
    {
        public override int Run(string input)
        {
            var inputChannel = Channel.CreateBounded<int>(1);
            var runner = new IntCodeRunner(Utility.InputToIntCode(input), inputChannel);

            var runnerTask = Task.Run(runner.Run);
            var ioTask = Task.Run(async () =>
            {
                await inputChannel.Writer.WriteAsync(5);
                return await runner.Output.Reader.ReadAsync();
            });

            Task.WaitAll(runnerTask, ioTask);

            return ioTask.Result;
        }
    }
}