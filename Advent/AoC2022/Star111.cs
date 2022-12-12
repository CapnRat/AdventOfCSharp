using System;
using System.Collections.Generic;
using System.Linq;
using Advent.Common;

namespace Advent.AoC2022
{
    [Solution(22, 11, 1)]
    public class Star111 : Solution<ulong>
    {
        public override ulong Run(string input)
        {
            var monkeys = InputToMonkeys(input);

            for (int i = 0; i < 20; i++)
            {
                foreach (var monkey in monkeys)
                {
                    while (monkey.Items.Count > 0)
                    {
                        var item = monkey.Items.Dequeue();
                        monkey.ApplyOperation(ref item);
                        item /= 3;
                        var target = monkey.GetTargetMonkey(item);
                        monkeys[target].Items.Enqueue(item);
                    }
                }
            }

            return GetMonkeyBusinessLevel(monkeys);
        }

        public static ulong GetMonkeyBusinessLevel(List<Monkey> monkeys)
        {
            return monkeys.Select(m => m.InspectionCount).OrderBy(x => x).TakeLast(2).Aggregate((ulong)1, (x, y) => x * y);
        }

        public static List<Monkey> InputToMonkeys(string input)
        {
            var monkeys = new List<Monkey>();

            foreach (var line in Utility.InputToLines(input))
            {
                var splits = line.Trim().Split(' ');
                switch (splits[0])
                {
                    case "Monkey":
                        monkeys.Add(new Monkey());
                        break;
                    case "Starting":
                        foreach (var i in splits[2..].Select(item => ulong.Parse(item.Trim(','))))
                            monkeys[^1].Items.Enqueue(i);
                        break;
                    case "Operation:":
                        var op = splits[^2] == "+" ? Monkey.Op.Sum : Monkey.Op.Mult;
                        op += splits[^1] == "old" ? 2 : 0;
                        monkeys[^1].Operator = op;
                        monkeys[^1].OpValue = ulong.TryParse(splits[^1], out var result) ? result : 0;
                        break;
                    case "Test:":
                        monkeys[^1].TestValue = ulong.Parse(splits[^1]);
                        break;
                    case "If":
                        if (splits[1] == "true:")
                            monkeys[^1].TrueValue = int.Parse(splits[^1]);
                        if (splits[1] == "false:")
                            monkeys[^1].FalseValue = int.Parse(splits[^1]);
                        break;
                    case "":
                        break;
                    default:
                        throw new ArgumentException();
                }
            }

            return monkeys;
        }

        public class Monkey
        {
            public enum Op
            {
                Sum,
                Mult,
                SumSelf,
                MultSelf
            }
            
            public ulong InspectionCount { get; private set; }
            public Queue<ulong> Items { get; } = new();
            public Op Operator { get; set; }
            public ulong OpValue { get; set; }
            public ulong TestValue { get; set; }
            public int TrueValue { get; set; }
            public int FalseValue { get; set; }

            public void ApplyOperation(ref ulong item)
            {
                InspectionCount++;
                
                switch (Operator)
                {
                    case Op.Sum:
                        item += OpValue;
                        break;
                    case Op.Mult:
                        item *= OpValue;
                        break;
                    case Op.SumSelf:
                        item += item;
                        break;
                    case Op.MultSelf:
                        item *= item;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            public int GetTargetMonkey(ulong item)
            {
                return item % TestValue == 0 ? TrueValue : FalseValue;
            }
        }
    }
}