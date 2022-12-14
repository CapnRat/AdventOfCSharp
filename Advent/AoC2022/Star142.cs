using Advent.Common;

namespace Advent.AoC2022
{
    [Solution(22, 14, 2)]
    public class Star142 : Solution<int>
    {
        public override int Run(string input)
        {
            
            var rocks = Star141.ConstructRockGrid(input, out var bounds);
            
            var floor = bounds.BottomRight.Y + 2;
            
            var sand = Star141.SimulateSand(ref bounds, rocks, floor);
            
            Star141.PrintGrid(bounds, rocks, sand, Star141.SandEmitPosition, floor);

            return sand.Count;
        }
    }
}