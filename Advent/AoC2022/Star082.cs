using System.Linq;
using Advent.Common;

namespace Advent.AoC2022
{
    [Solution(22, 8, 2)]
    public class Star082 : Solution<int>
    {
        public enum Direction
        {
            Up,
            Left,
            Down,
            Right
        }
        
        public struct Tree
        {
            public int Height;
            public int[] Scores;
        }
        
        public override int Run(string input)
        {
            var grid = Utility.InputTo(l => l.Select(c => new Tree { Height = c - '0', Scores = new int[4]}).ToArray(), input).ToArray();

            // Assume square grid
            for (int y = 0; y < grid.Length; y++)
            {
                for (int x = 0; x < grid.Length; x++)
                {
                    var done = new bool[4];
                    
                    for (int i = 1;; i++)
                    {
                        bool changed = false;

                        TestTree(done, (int)Direction.Up, grid, y, x, ref changed, y - i, x);
                        TestTree(done, (int)Direction.Down, grid, y, x, ref changed, y + i, x);
                        TestTree(done, (int)Direction.Left, grid, y, x, ref changed, y, x - i);
                        TestTree(done, (int)Direction.Right, grid, y, x, ref changed, y, x + i);

                        if (!changed)
                            break;
                    }
                }
            }
            
            return grid.Max(l => l.Max(t => t.Scores.Aggregate(1, (x, y) => x * y)));
        }

        private static void TestTree(bool[] done, int dir, Tree[][] grid, int y, int x, ref bool changed, int testY, int testX)
        {
            if (testY < 0 || testY >= grid.Length || testX < 0 || testX >= grid.Length)
                return;

            if (done[dir]) return;
            
            grid[y][x].Scores[dir]++;
            changed = true;
            if (grid[testY][testX].Height >= grid[y][x].Height)
                done[dir] = true;
        }
    }
}