using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Advent.Common;

namespace Advent.AoC2015
{
    [Solution(15,7,1)]
    public class Star071 : Solution
    {
        public enum Operation
        {
            Set = 0,
            And,
            Or,
            LShift,
            RShift,
            Not,
        }
        
        public struct Wire
        {
            public string Name;
            public string LeftInput;
            public string RightInput;
            public Operation Op;
            public bool Evaluated;
            public ushort Value;
        }
        
        public override string Run(string input)
        {
            return EvaluateWire(input, "a").ToString();
        }

        public static int EvaluateWire(string input, string wire)
        {
            var wires = Utility.InputToLines(input).Select(ParseWire).ToDictionary(w => w.Name);
            return ResolveWire(wires, wire);
        }

        private static ushort ResolveWire(IDictionary<string,Wire> wires, string name)
        {
            ushort value = 0;
            if (ushort.TryParse(name, out value))
                return value;
            
            var wire = wires[name];
            if (wire.Evaluated) return wire.Value;
            switch (wire.Op)
            {
                case Operation.Set:
                    value = ResolveWire(wires, wire.LeftInput);
                    break;
                case Operation.And:
                    value = (ushort) (ResolveWire(wires, wire.LeftInput) & ResolveWire(wires, wire.RightInput));
                    break;
                case Operation.Or:
                    value = (ushort) (ResolveWire(wires, wire.LeftInput) | ResolveWire(wires, wire.RightInput));
                    break;
                case Operation.LShift:
                    value = (ushort) (ResolveWire(wires, wire.LeftInput) << ResolveWire(wires, wire.RightInput));
                    break;
                case Operation.RShift:
                    value = (ushort) (ResolveWire(wires, wire.LeftInput) >> ResolveWire(wires, wire.RightInput));
                    break;
                case Operation.Not:
                    value = (ushort) ~ResolveWire(wires, wire.RightInput);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            wire.Evaluated = true;
            wire.Value = value;
            wires[name] = wire;
            return value;
        }

        public static Wire ParseWire(string line)
        {
            var match = Regex.Match(line, @"^([a-z0-9]*)\s?([A-Z]*)?\s?([a-z0-9]*)?\s->\s([a-z0-9]*)$");
            var op = match.Groups[2].Value switch
            {
                "AND" => Operation.And,
                "OR" => Operation.Or,
                "LSHIFT" => Operation.LShift,
                "RSHIFT" => Operation.RShift,
                "NOT" => Operation.Not,
                _ => Operation.Set
            };
            return new Wire{Name = match.Groups[4].Value, LeftInput = match.Groups[1].Value, RightInput = match.Groups[3].Value, Op = op};
        }
    }
}