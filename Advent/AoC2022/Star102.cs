using System;
using System.Text;
using Advent.Common;

namespace Advent.AoC2022
{
    [Solution(22, 10, 2)]
    public class Star102 : Solution<string>
    {
        public const int CrtWidth = 40;
        public const int CrtHeight = 6;
        
        public override string Run(string input)
        {
            var output = new StringBuilder();
            
            int registerX = 1;
            int cycleCount = 1;
            
            foreach (var instruction in Utility.InputTo(Star101.LineToInstruction, input))
            {
                for (int cycleEnd = cycleCount + Star101.CyclesLookup[(int)instruction.operation];
                     cycleCount < cycleEnd;
                     cycleCount++)
                {
                    int position = ((cycleCount - 1) % CrtWidth);
                    output.Append(Math.Abs(registerX - position) <= 1 ? '#' : '.');

                    if (cycleCount == CrtWidth * CrtHeight)
                        return output.ToString();
                    
                    if (position == CrtWidth - 1)
                        output.Append('\n');
                }
                
                switch (instruction.operation)
                {
                    case Star101.Op.Noop:
                        break;
                    case Star101.Op.AddX:
                        registerX += instruction.value;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return "";
        }
    }
}