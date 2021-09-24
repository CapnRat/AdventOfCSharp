using System.Linq;
using Advent.Common;

namespace Advent.AoC2015
{
    [Solution(15,18,1)]
    public class Star181 : Solution
    {
        public override string Run(string input)
        {
            return RunWithIterations(input, 100).ToString();
        }

        public int RunWithIterations(string input, int iterations)
        {
            var grid = Utility.InputTo(l => l.Select(c => c == '#').ToArray(), input).ToArray();

            for (int i = 0; i < iterations; i++)
            {
                RunIteration(grid);
            }

            return grid.Select(l => l.Count(c => c)).Sum();
        }

        static readonly (int x, int y)[] Neighbors = {
            ( 1, 0),
            ( 1, 1),
            ( 0, 1),
            (-1, 1),
            (-1, 0),
            (-1,-1),
            ( 0,-1),
            ( 1,-1)
        };
        
        public static void RunIteration(bool[][] grid)
        {
            var input = grid.Select(l => l.ToArray()).ToArray();

            for (int x = 0; x < grid.Length; x++)
            {
                for (int y = 0; y < grid[x].Length; y++)
                {
                    var state = input[x][y];
                    var count = Neighbors.Count(n => TryGetNeighbor(input, x + n.x, y + n.y));
                    grid[x][y] = state switch
                    {
                        true when count is not 2 and not 3 => false,
                        false when count is 3 => true,
                        _ => grid[x][y]
                    };
                }
            }
        }

        private static bool TryGetNeighbor(bool[][] grid, int x, int y)
        {
            if (x < 0 || x >= grid.Length)
                return false;

            if (y < 0 || y >= grid[x].Length)
                return false;

            return grid[x][y];
        }
    }
}