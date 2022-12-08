using System;
using System.Linq;
using Advent.Common;

namespace Advent.AoC2022
{
    [Solution(22, 8, 1)]
    public class Star081 : Solution<int>
    {
        public struct Tree
        {
            public int Height;
            public bool Visible;
        }
        
        public override int Run(string input)
        {
            var grid = Utility.InputTo(l => l.Select(c => new Tree { Height = c - '0' }).ToArray(), input).ToArray();

            // Assume square grid
            var maxTops = new int[grid.Length];
            var maxBottoms = new int[grid.Length];
            for (int top = 0; top < grid.Length; top++)
            {
                int maxLeft = 0;
                int maxRight = 0;

                var bottom = grid.Length - 1 - top;
                
                for (int left = 0; left < grid.Length; left++)
                {
                    // Left to Right
                    if (grid[top][left].Height > maxLeft || left == 0)
                    {
                        grid[top][left].Visible = true;
                        maxLeft = grid[top][left].Height;
                    }

                    // Right to Left
                    var right = grid.Length - 1 - left;
                    if (grid[top][right].Height > maxRight || right == grid.Length - 1)
                    {
                        grid[top][right].Visible = true;
                        maxRight = grid[top][right].Height;
                    }

                    // Top to Bottom
                    if (grid[top][left].Height > maxTops[left] || top == 0)
                    {
                        grid[top][left].Visible = true;
                        maxTops[left] = grid[top][left].Height;
                    }

                    // Bottom to Top
                    if (grid[bottom][left].Height > maxBottoms[left] || bottom == grid.Length - 1)
                    {
                        grid[bottom][left].Visible = true;
                        maxBottoms[left] = grid[bottom][left].Height;
                    }
                }
            }

            return grid.Sum(l => l.Count(t => t.Visible));
        }
    }
}