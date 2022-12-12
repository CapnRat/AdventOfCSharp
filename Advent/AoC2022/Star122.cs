using System.Collections.Generic;
using Advent.Common;

namespace Advent.AoC2022
{
    [Solution(22, 12, 2)]
    public class Star122 : Solution<int>
    {
        public override int Run(string input)
        {
            var grid = Star121.InputToGrid(input, out var width, out var height, out var start, out var end);
            
            var visited = new HashSet<int> { end };
            var heads = new HashSet<int> { end };
            for (int steps = 1;; steps++)
            {
                var newHeads = new HashSet<int>();
                foreach (var head in heads)
                {
                    for (int d = 0; d < 4; d++)
                    {
                        var dir = (Direction)d;
                        if (!Star121.ValidDirection(head, width, height, dir)) continue;
                        var target = Star121.GetIndexFromDirection(head, width, dir);
                        
                        if (visited.Contains(target) || !Star121.ValidSlope(grid[target], grid[head])) continue;
                        if (grid[target] == 'a')
                            return steps;
                                
                        visited.Add(target);
                        newHeads.Add(target);
                    }
                }

                heads = newHeads;
            }
        }
    }
}