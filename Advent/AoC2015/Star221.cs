using System;
using System.Collections.Generic;
using System.Linq;
using Advent.Common;

namespace Advent.AoC2015
{
    [Solution(15,22,1)]
    public class Star221 : Solution
    {
        public struct Spell
        {
            public string Name { get; init; }
            public int Duration { get; init; }
            public int ManaCost { get; init; }
            public int ManaGain { get; init; }
            public int Damage { get; init; }
            public int Healing { get; init; }
            public int Armor { get; init; }
        }

        public struct SpellList
        {
            public static Spell MagicMissile = new() {Name = "Magic Missile", ManaCost = 53, Damage = 4};
            public static Spell Drain = new() {Name = "Drain", ManaCost = 73, Damage = 2, Healing = 2};
            public static Spell Shield = new() {Name = "Shield", ManaCost = 113, Duration = 6, Armor = 7};
            public static Spell Poison = new() {Name = "Poison", ManaCost = 173, Duration = 6, Damage = 3};
            public static Spell Recharge = new() {Name = "Recharge", ManaCost = 229, Duration = 5, ManaGain = 101};
        }

        
        public override string Run(string input)
        {
            var player = new Star211.Player {HitPoints = 50, Mana = 500};
            var boss = new Star211.Player {HitPoints = 71, Damage = 10};
            
            return SimulateBattle(player, boss).ToString();
        }

        public static int SimulateBattle(Star211.Player player, Star211.Player boss)
        {
            var manaSpent = 0;

            var effects = new Dictionary<Spell, int>
            {
                {SpellList.Shield, 0},
                {SpellList.Poison, 0},
                {SpellList.Recharge, 0}
            };
            while (player.HitPoints > 0)
            {
                Console.WriteLine(string.Join(", ", effects.Select(e => $"{e.Key.Name}: {e.Value}")));
                Console.WriteLine($"Player: HP:{player.HitPoints} Mana:{player.Mana} Armor:{player.Armor}");
                Console.WriteLine($"Boss: HP:{boss.HitPoints}");
                
                ApplyEffects(ref player, ref boss, effects);
                var spell = GetNextSpell(player, boss, effects);

                manaSpent += spell.ManaCost;
                player.Mana -= spell.ManaCost;

                Console.WriteLine($"Player casts {spell.Name}");
                
                if (player.Mana < 0)
                    throw new Exception("Mana below zero");
                
                if (spell.Duration > 0)
                    effects[spell] = spell.Duration;
                else
                {
                    boss.HitPoints -= spell.Damage;
                    player.HitPoints += spell.Healing;
                }
                
                Console.WriteLine(string.Join(", ", effects.Select(e => $"{e.Key.Name}: {e.Value}")));
                Console.WriteLine($"Player: HP:{player.HitPoints} Mana:{player.Mana} Armor:{player.Armor}");
                Console.WriteLine($"Boss: HP:{boss.HitPoints}");

                if (boss.HitPoints <= 0)
                    break;
                
                ApplyEffects(ref player, ref boss, effects);
                var bossDamage = boss.Damage - player.Armor;
                bossDamage = bossDamage <= 0 ? 1 : bossDamage;
                player.HitPoints -= bossDamage;
                
                Console.WriteLine($"Boss attacks for {bossDamage}");
            }

            var winner = boss.HitPoints <= 0 ? "player" : "boss";
            Console.WriteLine($"{winner} Won!");
            
            return manaSpent;
        }

        public static void ApplyEffects(ref Star211.Player player, ref Star211.Player boss, Dictionary<Spell, int> effects)
        {
            foreach (var effect in effects)
            {
                var effectSpell = effect.Key;
                var remainingDuration = effect.Value;

                if (effectSpell.Armor > 0)
                    player.Armor = remainingDuration > 0 ? effectSpell.Armor : 0;

                if (remainingDuration > 0)
                {
                    effects[effectSpell]--;
                    boss.HitPoints -= effectSpell.Damage;
                    player.Mana += effectSpell.ManaGain;
                }
            }
        }

        public static Spell GetNextSpell(Star211.Player player, Star211.Player boss, Dictionary<Spell, int> effects)
        {
            var turnsRemaining = boss.HitPoints / SpellList.MagicMissile.Damage;
            
            if (effects[SpellList.Poison] == 0)
                return SpellList.Poison;
            
            if (effects[SpellList.Recharge] == 0 && turnsRemaining > SpellList.Recharge.Duration)
                return SpellList.Recharge;
            
            if (effects[SpellList.Shield] == 0 && boss.HitPoints > SpellList.MagicMissile.Damage)
                return SpellList.Shield;
            
            if (boss.HitPoints / SpellList.MagicMissile.Damage < player.HitPoints / (boss.Damage - player.Armor))
                return SpellList.MagicMissile;

            if (player.HitPoints <= boss.Damage - SpellList.Shield.Armor)
                return SpellList.Drain;

            return SpellList.MagicMissile;
        }

        public override string GetInput()
        {
            return "";
        }
    }
}