using System.Collections.Generic;
using System.Linq;
using Advent.Common;

namespace Advent.AoC2022
{
    [Solution(22, 7, 2)]
    public class Star072 : Solution<int>
    {
        public void FillSizes(Star071.Dir current, int neededSize, List<int> sizes)
        {
            var size = current.Size;
            if (size > neededSize)
                sizes.Add(current.Size);
            foreach (var childDir in current.Children.Where(n => n is Star071.Dir).Cast<Star071.Dir>())
                FillSizes(childDir, neededSize, sizes);
        }
        
        public override int Run(string input)
        {
            var root = Star071.BuildFileSystemStructure(input);
            var neededSize = 30000000 - (70000000 - root.Size);

            var sizes = new List<int>();
            FillSizes(root, neededSize, sizes);

            return sizes.Min();
        }
    }
}