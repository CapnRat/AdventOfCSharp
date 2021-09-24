using System.Linq;
using Advent.Common;

namespace Advent.AoC2015
{
    [Solution(15,18,2)]
    public class Star182 : Solution
    {
        public override string Run(string input)
        {
            return RunWithIterations(input, 100).ToString();
        }

        public int RunWithIterations(string input, int iterations)
        {
            var grid = Utility.InputTo(l => l.Select(c => c == '#').ToArray(), input).ToArray();
            (int x, int y)[] stuckCorners = {
                ( 0, 0),
                ( 0, grid[0].Length - 1),
                ( grid.Length - 1, 0),
                ( grid.Length - 1, grid[0].Length - 1),
            };

            ApplyStuckCorners(grid, stuckCorners);
            for (int i = 0; i < iterations; i++)
            {
                Star181.RunIteration(grid);
                ApplyStuckCorners(grid, stuckCorners);
            }

            return grid.Select(l => l.Count(c => c)).Sum();
        }

        private void ApplyStuckCorners(bool[][] grid, (int x, int y)[] stuckCorners)
        {
            foreach (var corner in stuckCorners)
                grid[corner.x][corner.y] = true;
        }
    }
}