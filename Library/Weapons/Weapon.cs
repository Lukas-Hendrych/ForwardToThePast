using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Weapons {
    public abstract class Weapon {
        private int maxStabDmg;
        private int maxSlashDmg;
        private string weaponImg;

        public int MaxStabDmg { get => maxStabDmg; set => maxStabDmg = value; }
        public int MaxSlashDmg { get => maxSlashDmg; set => maxSlashDmg = value; }
        public string WeaponImg { get => weaponImg; set => weaponImg = value; }

        public Weapon() {

        }

        public override string ToString() {
            return "Max stab damage: " + MaxStabDmg + "\nMax slash damage: " + MaxSlashDmg;
        }
    }
}
