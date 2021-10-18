using System;
using System.Linq;
using Advent.Common;

namespace Advent.AoC2015
{
    [Solution(15,23,1)]
    public class Star231 : Solution
    {
        public override string Run(string input)
        {
            return RunProgram(input, new uint[]{0, 0});
        }

        public static string RunProgram(string input, uint[] registers)
        {
            var program = Utility.InputToLines(input).ToArray();

            int pointer = 0;

            while (pointer < program.Length)
            {
                var line = program[pointer];
                var parts = line.Split(' ');
                var r = parts[1].Trim(',') == "a" ? 0 : 1;

                switch (parts[0])
                {
                    case "hlf":
                        registers[r] /= 2;
                        pointer++;
                        break;
                    case "tpl":
                        registers[r] *= 3;
                        pointer++;
                        break;
                    case "inc":
                        registers[r]++;
                        pointer++;
                        break;
                    case "jmp":
                        pointer += int.Parse(parts[1]);
                        break;
                    case "jie":
                        if (registers[r] % 2 == 0)
                            pointer += int.Parse(parts[2]);
                        else
                            pointer++;
                        break;
                    case "jio":
                        if (registers[r] == 1)
                            pointer += int.Parse(parts[2]);
                        else
                            pointer++;
                        break;
                    default:
                        throw new InvalidProgramException();
                }
            }

            return registers[1].ToString();
        }
    }
}