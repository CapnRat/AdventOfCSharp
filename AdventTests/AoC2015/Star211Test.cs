using System.Diagnostics;
using Advent.AoC2015;
using NUnit.Framework;

namespace AdventTests.AoC2015
{
    public class Star211Test
    {
        [Test]
        public void SampleTests()
        {
            var result = Star211.SimulateBattle(new Star211.Player() {HitPoints = 8, Damage = 5, Armor = 5},
                new Star211.Player() {HitPoints = 12, Damage = 7, Armor = 2});
            
            Assert.IsTrue(result);
        }
    }
}