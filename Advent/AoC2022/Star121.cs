using System;
using System.Collections.Generic;
using System.Linq;
using Advent.Common;

namespace Advent.AoC2022
{
    [Solution(22, 12, 1)]
    public class Star121 : Solution<int>
    {
        public static bool ValidDirection(int index, int width, int height, Direction dir) => dir switch
        {
            Direction.Up => index >= width,
            Direction.Right => (index + 1) % width != 0,
            Direction.Down => index < width * (height - 1),
            Direction.Left => index % width != 0,
            _ => throw new ArgumentOutOfRangeException(nameof(dir), dir, null)
        };

        public static bool ValidSlope(int from, int to) => to - from <= 1;
        
        public static int GetIndexFromDirection(int index, int width, Direction dir) => dir switch
        {
            Direction.Up => index - width,
            Direction.Right => index + 1,
            Direction.Down => index + width,
            Direction.Left => index - 1,
            _ => throw new ArgumentOutOfRangeException(nameof(dir), dir, null)
        };

        public static int PositionToIndex(int x, int y, int width) => y * width + x;
        
        public override int Run(string input)
        {
            int y = 0;
            int width = 0;
            int height = 0;
            int start = 0;
            int end = 0;

            var grid = new List<int>();
            foreach (var line in Utility.InputToLines(input))
            {
                if (y == 0)
                    width = line.Length;

                for (var i = 0; i < line.Length; i++)
                {
                    int elevation = line[i];
                    switch (line[i])
                    {
                        case 'S':
                            start = PositionToIndex(i, y, width);
                            elevation = 'a';
                            break;
                        case 'E':
                            end = PositionToIndex(i, y, width);
                            elevation = 'z';
                            break;
                    }
                    grid.Add(elevation);
                }

                y++;
            }
            height = y;

            var visited = new HashSet<int> { start };
            var heads = new HashSet<int> { start };
            for (int steps = 1;; steps++)
            {
                var newHeads = new HashSet<int>();
                foreach (var head in heads)
                {
                    for (int d = 0; d < 4; d++)
                    {
                        var dir = (Direction)d;
                        if (!ValidDirection(head, width, height, dir)) continue;
                        var target = GetIndexFromDirection(head, width, dir);
                        
                        if (visited.Contains(target) || !ValidSlope(grid[head], grid[target])) continue;
                        if (target == end)
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