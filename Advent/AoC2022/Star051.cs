using System.Collections.Generic;
using System.Linq;
using System.Text;
using Advent.Common;

namespace Advent.AoC2022
{
    [Solution(22, 5, 1)]
    public class Star051 : Solution<string>
    {
        public static string RunPuzzle(string input, bool multistack)
        {
            var lines = Utility.InputToLines(input).ToArray();
            var numStacks = (lines[0].Length + 1) / 4;
            var separatorLine = 0;
            while (!string.IsNullOrEmpty(lines[separatorLine])) separatorLine++; // seek to empty line separator

            // Init Stacks
            var stackHeight = separatorLine - 1; // remove the labels line
            var stacks = new Stack<char>[numStacks];
            for (int l = stackHeight - 1; l >= 0; l--)
            {
                for (int s = 0; s < numStacks; s++)
                {
                    stacks[s] ??= new Stack<char>();
                    
                    var character = lines[l][(s * 4) + 1];
                    if (character == ' ')
                        continue;
                    
                    stacks[s].Push(character);
                }
            }
            
            // Run Instructions
            var movedCrates = new List<char>();
            for (int l = separatorLine + 1; l < lines.Length; l++)
            {
                movedCrates.Clear();
                
                var splits = lines[l].Split(' ');
                var count = int.Parse(splits[1]);
                var from = int.Parse(splits[3]) - 1; // 1 indexed to 0 indexed
                var to = int.Parse(splits[5]) - 1; // 1 indexed to 0 indexed

                if (multistack)
                {
                    for (int p = 0; p < count; p++)
                        movedCrates.Add(stacks[from].Pop());
                    
                    for (int p = count - 1; p >= 0; p--)
                        stacks[to].Push(movedCrates[p]);
                }
                else
                {
                    for (int p = 0; p < count; p++)
                        stacks[to].Push(stacks[from].Pop());
                }
            }

            // Read Top Line
            var builder = new StringBuilder();
            foreach (var stack in stacks)
            {
                builder.Append(stack.Peek());
            }
            
            return builder.ToString();
        }
        
        public override string Run(string input)
        {
            return RunPuzzle(input, false);
        }
    }
}