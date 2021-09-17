using System.Linq;
using Advent.Common;

namespace Advent.AoC2015
{
    [Solution(15,6,2)]
    public class Star062 : Solution
    {
        private readonly int[] _data = new int[1000*1000];
        
        public override string Run(string input)
        {
            foreach (var line in Utility.InputToLines(input))
            {
                RunConstruction(Star061.ParseConstruction(line));
            }

            return _data.Sum().ToString();
        }

        private void RunConstruction(Star061.Construction construction)
        {
            for (var x = construction.Start.Item1; x <= construction.End.Item1; x++)
            {
                for (var y = construction.Start.Item2; y <= construction.End.Item2; y++)
                {
                    var index = x * 1000 + y;
                    switch (construction.State)
                    {
                        case Star061.State.On:
                            _data[index]++;
                            break;
                        case Star061.State.Off:
                            if (--_data[index] < 0) _data[index] = 0;
                            break;
                        case Star061.State.Toggle:
                            _data[index] += 2;
                            break;
                    }
                }
            }
        }
    }
}