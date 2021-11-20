using System;
using System.Threading.Channels;

namespace Advent.AoC2019
{

    public class IntCodeRunner
    {
        private int _pointer;
        public Channel<int> Input { get; set; }
        public Channel<int> Output { get; set; }

        public int[] Program { get; private set; }


        public IntCodeRunner()
        {
            this.Program = Array.Empty<int>();
            this._pointer = 0;
            this.Output = Channel.CreateBounded<int>(1);
        }
        
        public IntCodeRunner(int[] program, Channel<int> input = null)
        {
            this.Program = program;
            this._pointer = 0;
            this.Input = input;
            this.Output = Channel.CreateBounded<int>(1);
        }

        public void Reset(int[] program)
        {
            this.Program = program;
            this._pointer = 0;
            this.Output = Channel.CreateBounded<int>(1);
        }

        public async void Run()
        {
            while (true)
            {
                var instruction = Program[_pointer];
                var opCode = GetOpCode(instruction);
                if (opCode == 99)
                    break;

                switch (GetOpWidth(opCode))
                {
                    case 4:
                    {
                        var leftPos = GetParam(instruction, 1);
                        var rightPos = GetParam(instruction, 2);
                        var outPos = GetParam(instruction, 3);
                        switch (opCode)
                        {
                            case 1:
                                Program[outPos] = Program[leftPos] + Program[rightPos];
                                break;
                            case 2:
                                Program[outPos] = Program[leftPos] * Program[rightPos];
                                break;
                            case 7:
                                Program[outPos] = Program[leftPos] < Program[rightPos] ? 1 : 0;
                                break;
                            case 8:
                                Program[outPos] = Program[leftPos] == Program[rightPos] ? 1 : 0;
                                break;
                            default:
                                throw new InvalidProgramException();
                        }

                        _pointer += 4;

                        break;
                    }
                    case 3:
                    {
                        var firstPos = GetParam(instruction, 1);
                        var secondPos = GetParam(instruction, 2);

                        switch (opCode)
                        {
                            case 5:
                                if (Program[firstPos] != 0) _pointer = Program[secondPos];
                                else _pointer += 3;
                                break;
                            case 6:
                                if (Program[firstPos] == 0) _pointer = Program[secondPos];
                                else _pointer += 3;
                                break;
                            default:
                                throw new InvalidProgramException();
                        }

                        break;
                    }
                    case 2:
                    {
                        var pos = GetParam(instruction, 1);
                        switch (opCode)
                        {
                            case 3:
                                Program[pos] = await Input.Reader.ReadAsync();
                                break;
                            case 4:
                                await Output.Writer.WriteAsync(Program[pos]);
                                break;
                            default:
                                throw new InvalidProgramException();
                        }

                        _pointer += 2;

                        break;
                    }
                }
            }
            Output.Writer.Complete();
        }

        private int GetParam(int instruction, int offset)
        {
            var mode = instruction / (int)Math.Pow(10, offset + 1) % 10;
            return mode == 0 ? Program[_pointer + offset] : _pointer + offset;
        }

        private static int GetOpCode(int instruction)
        {
            return instruction % 100;
        }

        private static int GetOpWidth(int opCode)
        {
            return opCode switch
            {
                1 or 2 or 7 or 8 => 4,
                5 or 6 => 3,
                3 or 4 => 2,
                _ => throw new InvalidProgramException()
            };
        }
    }
}