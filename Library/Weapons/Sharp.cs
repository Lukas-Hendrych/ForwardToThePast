using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Weapons {
    public class Sharp : Weapon {
        private string name;

        public string Name { get => name; set => name = value; }

        Dictionary<string, Tuple<int, string>> Sharps = new Dictionary<string, Tuple<int, string>>() {
            { "Rusty dagger", Tuple.Create(10,"rusty_dagger") },
            { "Excalibur", Tuple.Create(30,"excalibur") }            
        };
        public Sharp(string name) : base() {
            Name = name;
            base.MaxStabDmg = (int)(1.1 * Sharps[name].Item1);
            base.MaxSlashDmg = (int)(1.2 * Sharps[name].Item1);
            base.WeaponImg = Sharps[name].Item2;
        }

        public override string ToString() {
            return Name + "\n" + base.ToString();
        }
    }
}
