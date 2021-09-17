using System.Linq;
using Advent.Common;

namespace Advent.AoC2015
{
    [Solution(15,7,2)]
    public class Star072 : Solution
    {
        public override string Run(string input)
        {
            var wires = Utility.InputToLines(input).Select(Star071.ParseWire).ToDictionary(w => w.Name);
            var cleanWires = wires.ToDictionary(pair => pair.Key, pair => pair.Value);
            var signal = Star071.ResolveWire(wires, "a");
            cleanWires["b"] = new Star071.Wire() {Name = "b", LeftInput = signal.ToString(), Op = Star071.Operation.Set};
            return Star071.ResolveWire(cleanWires, "a").ToString();
        }
    }
}