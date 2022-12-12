using System.Linq;
using Advent.Common;

namespace Advent.AoC2022
{
    [Solution(22, 11, 2)]
    public class Star112 : Solution<ulong>
    {
        public override ulong Run(string input)
        {
            var monkeys = Star111.InputToMonkeys(input);

            var divisor = monkeys.Select(m => m.TestValue).Aggregate((ulong)1, (x, y) => x * y);

            for (int i = 0; i < 10000; i++)
            {
                foreach (var monkey in monkeys)
                {
                    while (monkey.Items.Count > 0)
                    {
                        var item = monkey.Items.Dequeue();
                        monkey.ApplyOperation(ref item);
                        item %= divisor;
                        var target = monkey.GetTargetMonkey(item);
                        monkeys[target].Items.Enqueue(item);
                    }
                }
            }

            return Star111.GetMonkeyBusinessLevel(monkeys);
        }
    }
}