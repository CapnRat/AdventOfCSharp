using System;
using System.Collections.Generic;
using System.Linq;
using Advent.Common;
using Combinatorics.Collections;

namespace Advent.AoC2015
{
    [Solution(15,21,2)]
    public class Star212 : Solution
    {
        public override string Run(string input)
        {
            (Star211.Item weapon, Star211.Item armor, IEnumerable<Star211.Item> rings, int cost) costliestLoss = (new Star211.Item(), new Star211.Item(), null, Int32.MinValue);
            var player = new Star211.Player {HitPoints = 100};
            var boss = new Star211.Player {HitPoints = 104, Damage = 8, Armor = 1};
            foreach (var weapon in Star211.Weapons)
            {
                foreach (var armor in Star211.Armors)
                {
                    foreach (var rings in new Combinations<Star211.Item>(Star211.Rings, 2))
                    {
                        player.Armor = armor.Armor + rings.Sum(r => r.Armor);
                        player.Damage = weapon.Damage + rings.Sum(r => r.Damage);

                        var cost = weapon.Cost + armor.Cost + rings.Sum(r => r.Cost);

                        if (!Star211.SimulateBattle(player, boss) && cost > costliestLoss.cost)
                            costliestLoss = (weapon, armor, rings, cost);
                    }
                }
            }
            
            Console.WriteLine($"Weapon:{costliestLoss.weapon.Name} Armor:{costliestLoss.armor.Name} Rings:{string.Join(" & ",costliestLoss.rings.Select(r => r.Name))}");
            return costliestLoss.cost.ToString();
        }
        
        public override string GetInput()
        {
            return "";
        }
    }
}