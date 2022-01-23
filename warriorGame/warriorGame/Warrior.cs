using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace warriorGame
{
    internal abstract class Warrior
    {
        public int Health { get; set; } = 100;
        public int AttDmg { get; set; } = 20;
        public int AttSpeed { get; set; }
        public int AttRange { get; set; } = 15;
        public abstract bool CanDamage(int opponentPos);
        public bool CanTakeDamage()
        {
            return Health > 0;
        }
    }
}
