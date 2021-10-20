using System;

namespace Advent.AoC2019
{
    public class IntCodeRunner
    {
        private int _pointer;
        
        public int[] Program { get; }

        public IntCodeRunner(int[] program)
        {
            this.Program = program;
            this._pointer = 0;
        }

        public void Run()
        {
            while (true)
            {
                var opCode = Program[_pointer];
                if (opCode == 99)
                    break;
                
                var leftPos = Program[_pointer + 1];
                var rightPos = Program[_pointer + 2];
                var outPos = Program[_pointer + 3];
                switch (opCode)
                {
                    case 1:
                        Program[outPos] = Program[leftPos] + Program[rightPos];
                        break;
                    case 2:
                        Program[outPos] = Program[leftPos] * Program[rightPos];
                        break;
                    default:
                        throw new InvalidProgramException();
                }

                _pointer += 4;
            }
        }
    }
}