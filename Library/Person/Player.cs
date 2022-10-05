using Library.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Person {
    public class Player : Person {
        private int attributePoints;

        public int AttributePoints { get => attributePoints; set => attributePoints = value; }

        public Player(string name, int health, int maxHealth, int strength, int dexterity, int critChance, int critDamage, byte blockChance, byte evasionChance, byte actionPoints, Weapon weapon)
            : base(name, health, maxHealth, strength, dexterity, critChance, critDamage, blockChance, evasionChance, actionPoints, weapon) {
            AttributePoints = 0;
        }

        public void EquipWeapon(Weapon newWeapon) {
            base.Weapon = newWeapon;
            base.CalculateMinSlashDamage();
            base.CalculateMaxSlashDamage();
            base.CalculateMinStabDamage();
            base.CalculateMaxStabDamage();
        }

        public void RecalculateDamage() {
            base.CalculateMinSlashDamage();
            base.CalculateMaxSlashDamage();
            base.CalculateMinStabDamage();
            base.CalculateMaxStabDamage();
        }

        public override string ToString() {
            return base.ToString();
        }

    }
}
