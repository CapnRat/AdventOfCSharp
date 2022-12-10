using System;
using System.Collections.Generic;
using Advent.Common;

namespace Advent.AoC2022
{
    [Solution(22, 10, 1)]
    public class Star101 : Solution<int>
    {
        public enum Op
        {
            Noop = 0,
            AddX = 1
        }

        public static int[] CyclesLookup = { 1, 2 };
        public static HashSet<int> Samples = new() { 20, 60, 100, 140, 180, 220 };
        
        public override int Run(string input)
        {
            int registerX = 1;
            int cycleCount = 1;
            int signalStrength = 0;
            
            foreach (var instruction in Utility.InputTo(LineToInstruction, input))
            {
                for (int cycleEnd = cycleCount + CyclesLookup[(int)instruction.operation];
                     cycleCount < cycleEnd;
                     cycleCount++)
                {
                    if (Samples.Contains(cycleCount))
                        signalStrength += cycleCount * registerX;
                }
                
                switch (instruction.operation)
                {
                    case Op.Noop:
                        break;
                    case Op.AddX:
                        registerX += instruction.value;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return signalStrength;
        }

        public static (Op operation, int value) LineToInstruction(string l)
        {
            var splits = l.Split(' ');
            return splits.Length == 1 ? (Op.Noop, 0) : (Op.AddX, int.Parse(splits[1]));
        }
    }
}