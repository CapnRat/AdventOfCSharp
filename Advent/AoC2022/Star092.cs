using System;
using System.Collections.Generic;
using Advent.Common;

namespace Advent.AoC2022
{
    [Solution(22, 9, 2)]
    public class Star092 : Solution<int>
    {
        public override int Run(string input)
        {
            var visited = new HashSet<Star091.Position>();

            var rope = new Star091.Position[10];
            var prev = new Star091.Position[10];

            foreach (var movement in Utility.InputTo(Star091.LineToMovement, input))
            {
                for (int i = 0; i < movement.Distance; i++)
                {
                    rope.CopyTo(prev, 0);
                    rope[0].Add(movement.Direction);

                    for (int r = 1; r < rope.Length; r++)
                    {
                        var last = rope[r - 1];
                        var knot = rope[r];

                        if (Math.Abs(last.X - knot.X) <= 1 && Math.Abs(last.Y - knot.Y) <= 1) break;
                        
                        rope[r].Add((Math.Sign(last.X - knot.X), Math.Sign(last.Y - knot.Y)));
                    }

                    visited.Add(rope[^1]);
                }
            }
            
            return visited.Count;
        }
    }
}