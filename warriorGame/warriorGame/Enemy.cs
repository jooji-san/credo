using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace warriorGame
{
    internal class Enemy : Warrior
    {
        public int Pos { get; set; }

        public Enemy()
        {
            AttSpeed = 1;
        }
        public override bool CanDamage(int heroPos)
        {
            return Pos - AttRange <= heroPos;
        }
    }
}
