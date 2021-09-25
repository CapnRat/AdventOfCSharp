using System;
using System.Collections.Generic;
using System.Linq;
using Advent.Common;
using Combinatorics.Collections;

namespace Advent.AoC2015
{
    [Solution(15,21,1)]
    public class Star211 : Solution
    {
        public struct Player
        {
            public int HitPoints;
            public int Damage;
            public int Armor;
        }
        
        public struct Item
        {
            public string Name;
            public int Cost;
            public int Damage;
            public int Armor;
        }

        public static readonly Item[] Weapons =
        {
            new() {Name = "Dagger", Cost = 8, Damage = 4},
            new() {Name = "Shortsword", Cost = 10, Damage = 5},
            new() {Name = "Warhammer", Cost = 25, Damage = 6},
            new() {Name = "Longsword", Cost = 40, Damage = 7},
            new() {Name = "Greataxe", Cost = 74, Damage = 8}
        };

        public static readonly Item[] Armors =
        {
            new() {Name = "None"},
            new() {Name = "Leather", Cost = 13, Armor = 1},
            new() {Name = "Chainmail", Cost = 31, Armor = 2},
            new() {Name = "Splintmail", Cost = 53, Armor = 3},
            new() {Name = "Bandedmail", Cost = 75, Armor = 4},
            new() {Name = "Platemail", Cost = 102, Armor = 5}
        };

        public static readonly Item[] Rings =
        {
            new() {Name = "None"},
            new() {Name = "Damage +1", Cost = 25, Damage = 1},
            new() {Name = "Damage +2", Cost = 50, Damage = 2},
            new() {Name = "Damage +3", Cost = 100, Damage = 3},
            new() {Name = "Defense +1", Cost = 20, Armor = 1},
            new() {Name = "Defense +2", Cost = 40, Armor = 2},
            new() {Name = "Defense +3", Cost = 80, Armor = 3}
        };
        
        public override string Run(string input)
        {
            (Item weapon, Item armor, IEnumerable<Item> rings, int cost) cheapestWin = (new Item(), new Item(), null, Int32.MaxValue);
            var player = new Player {HitPoints = 100};
            var boss = new Player {HitPoints = 104, Damage = 8, Armor = 1};
            foreach (var weapon in Weapons)
            {
                foreach (var armor in Armors)
                {
                    foreach (var rings in new Combinations<Item>(Rings, 2))
                    {
                        player.Armor = armor.Armor + rings.Sum(r => r.Armor);
                        player.Damage = weapon.Damage + rings.Sum(r => r.Damage);

                        var cost = weapon.Cost + armor.Cost + rings.Sum(r => r.Cost);

                        if (SimulateBattle(player, boss) && cost < cheapestWin.cost)
                            cheapestWin = (weapon, armor, rings, cost);
                    }
                }
            }
            
            Console.WriteLine($"Weapon:{cheapestWin.weapon.Name} Armor:{cheapestWin.armor.Name} Rings:{string.Join(" & ",cheapestWin.rings.Select(r => r.Name))}");
            return cheapestWin.cost.ToString();
        }

        public static bool SimulateBattle(Player player, Player boss)
        {
            while (player.HitPoints > 0 && boss.HitPoints > 0)
            {
                boss.HitPoints -= player.Damage - boss.Armor < 0 ? 1 : player.Damage - boss.Armor;
                player.HitPoints -= boss.Damage - player.Armor < 0 ? 1 : boss.Damage - player.Armor;
            }

            return boss.HitPoints <= 0;
        }

        public override string GetInput()
        {
            return "";
        }
    }
}