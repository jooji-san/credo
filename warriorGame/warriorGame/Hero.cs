using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace warriorGame
{
    internal class Hero : Warrior
    {
        public int MaxHealth { get; set; } = 100;
        public string Name { get; set; } = "Giorgi";
        public int Pos { get; set; } = 0;

        public Hero()
        {
            AttSpeed = 2;
        }

        // until Health is less or equal to MaxHealth
        public bool CanBeHealed() {
            return Health + 20 <= MaxHealth;
        }
        
        // if There is no enemy in range
        public bool CanMove(Enemy[] enemies) {
            foreach (var enemy in enemies)
            {
                if (Pos + AttRange >= enemy.Pos && enemy.CanTakeDamage())
                {
                    return false;
                }
            }
            return true;
        }

        public override bool CanDamage(int enemyPos)
        {
            return Pos + AttRange >= enemyPos;
        }
    }
}
