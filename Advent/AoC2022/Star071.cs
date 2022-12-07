using System.Collections.Generic;
using System.Linq;
using Advent.Common;

namespace Advent.AoC2022
{
    [Solution(22, 7, 1)]
    public class Star071 : Solution<int>
    {
        public interface IFSNode
        {
            public string Name { get; }
            public int Size { get; }
            public Dir Parent { get; }
        }

        public class File : IFSNode
        {
            public string Name { get; init; }
            public int Size { get; init; }
            public Dir Parent { get; init; }
        }
        
        public class Dir : IFSNode
        {
            public Dir()
            {
                Children = new List<IFSNode>();
            }

            public string Name { get; init; }
            public int Size => Children.Sum(n => n.Size);
            public Dir Parent { get; init; }
            public List<IFSNode> Children { get; }

            public Dir GetChildDir(string targetDirName)
            {
                return Children.Where(n => n is Dir).First(n => n.Name == targetDirName) as Dir;
            }
        }

        public enum TermLineType
        {
            ChangeDir,
            List,
            DirNode,
            FileNode,
        }

        public void GetTotalSizes(Dir dir, int maxSize, ref int totalSize)
        {
            var size = dir.Size;
            if (dir.Size <= maxSize)
                totalSize += size;
            foreach (var child in dir.Children.Where(n => n is Dir).Cast<Dir>())
                GetTotalSizes(child, maxSize, ref totalSize);
        }
        
        public override int Run(string input)
        {
            var root = new Dir {Name = "/"};
            var currentDir = root;
            foreach (var line in Utility.InputToLines(input))
            {
                var lineType = line switch
                {
                    _ when line.StartsWith("$ cd") => TermLineType.ChangeDir,
                    _ when line.StartsWith("$ ls") => TermLineType.List,
                    _ when line.StartsWith("dir") => TermLineType.DirNode,
                    _ => TermLineType.FileNode
                };

                var splits = line.Split(' ');
                var targetName = splits.Last();
                switch (lineType)
                {
                    case TermLineType.ChangeDir:
                        if (targetName == "..")
                        {
                            currentDir = currentDir.Parent;
                            break;
                        }

                        if (targetName == "/")
                        {
                            currentDir = root;
                            break;
                        }

                        currentDir = currentDir.GetChildDir(targetName);
                        break;
                    case TermLineType.List: break;
                    case TermLineType.DirNode:
                        currentDir.Children.Add(new Dir{Name = targetName, Parent = currentDir});
                        break;
                    case TermLineType.FileNode:
                        var size = int.Parse(splits.First());
                        currentDir.Children.Add(new File{Name = targetName, Parent = currentDir, Size = size});
                        break;
                }
            }

            int totalSizes = 0;
            GetTotalSizes(root, 100000, ref totalSizes);
            return totalSizes;
        }
    }
}