using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace warriorGame
{
    internal class Game
    {
        // think about making every property private
        public bool isGameOver { get; private set; }
        private Enemy[] enemies = new Enemy[3] { new Enemy(), new Enemy(), new Enemy() };
        private Hero hero = new Hero();
        private int[] healthPos = new int[3];
        private int PathLength { get; set; } = 40;

        public Game()
        {
            Random rand = new Random();
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].Pos = rand.Next(0, PathLength);
            }
            for (int i = 0; i < healthPos.Length; i++)
            {
                healthPos[i] = rand.Next(0, PathLength);
            }

        }
        public void EachPathStep()
        {
            if (hero.Pos == PathLength)
            {
                Console.WriteLine("you won!");
                isGameOver = true;
                return;
            }
            
            hero.Pos++;
            Console.WriteLine($"made a new step. Hero position is now {hero.Pos}");

            // health power up
            foreach (int oneHealthPos in healthPos)
            {
                if (oneHealthPos == hero.Pos)
                {
                    Console.WriteLine("found health");
                    if (hero.CanBeHealed())
                    {
                        Console.WriteLine("health increased");
                        hero.Health += 20;
                    } else
                    {
                        Console.WriteLine("health couldn't be increased");
                    }

                }
            }

            // combat
            while (!hero.CanMove(enemies))
            {
                foreach (var enemy in enemies)
                {
                    if (enemy.Health <= 0) continue;

                    for (int i = 0; i < hero.AttSpeed; i++)
                    {
                        if (hero.CanDamage(enemy.Pos))
                        {
                            enemy.Health -= hero.AttDmg;
                            Console.WriteLine($"Damaged enemy by {hero.AttDmg} points. Remaining enemy health: {enemy.Health}");
                            if (!enemy.CanTakeDamage())
                            {
                                Console.WriteLine("one enemy is down.");
                                break;
                            }
                        }
                    }


                    for (int i = 0; i < enemy.AttSpeed; i++)
                    {
                        if (enemy.CanDamage(hero.Pos) && enemy.CanTakeDamage())
                        {
                            hero.Health -= enemy.AttDmg;
                            if (!hero.CanTakeDamage())
                            {
                                Console.WriteLine("hero is dead. Game over");
                                isGameOver = true;
                                return;
                            }
                            Console.WriteLine($"Hero was damaged by the enemy by {enemy.AttDmg}. Remaining hero health: {hero.Health}");
                        }
                    } 
                }
            }
        }
    }
}
