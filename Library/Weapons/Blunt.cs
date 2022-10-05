using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Weapons {
    public class Blunt : Weapon {
        private string name;

        public string Name { get => name; set => name = value; }

        Dictionary<string, Tuple<int,string>> Blunts = new Dictionary<string, Tuple <int, string>>() {
            { "Fists", Tuple.Create(2,"fists") },
            { "Stick", Tuple.Create(5,"stick") },
            { "Old club", Tuple.Create(6,"old_club") }
        };

        public Blunt(string name) : base () {
            Name = name;
            base.MaxStabDmg = (int)(0.5 * Blunts[name].Item1);
            base.MaxSlashDmg = (int)(1.8 * Blunts[name].Item1);
            base.WeaponImg = Blunts[name].Item2;
        }

        public override string ToString() {
            return Name + "\n" + base.ToString();
        }
    }
}
