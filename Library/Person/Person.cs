using Library.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Person {
    public class Person {
        private string name;
        private int strength;
        private int dexterity;
        private int health;
        private int maxHealth;
        private int critChance;
        private int critDamage;
        private Weapon weapon;
        private int minStabDamage;
        private int maxStabDamage;
        private int minSlashDamage;
        private int maxSlashDamage;
        private byte actionPoints;
        private byte blockChance;
        private byte evasionChange;
        private bool evading;
        private bool blocking;

        public int Strength { get => strength; set => strength = value; }
        public int Dexterity { get => dexterity; set => dexterity = value; }
        public int Health { get => health; set => health = value; }
        public int CritChance { get => critChance; set => critChance = value; }
        public int CritDamage { get => critDamage; set => critDamage = value; }
        public string Name { get => name; set => name = value; }
        public int MaxHealth { get => maxHealth; set => maxHealth = value; }
        public Weapon Weapon { get => weapon; set => weapon = value; }
        public int MinStabDamage { get => minStabDamage; set => minStabDamage = value; }
        public int MaxStabDamage { get => maxStabDamage; set => maxStabDamage = value; }
        public int MinSlashDamage { get => minSlashDamage; set => minSlashDamage = value; }
        public int MaxSlashDamage { get => maxSlashDamage; set => maxSlashDamage = value; }
        public byte ActionPoints { get => actionPoints; set => actionPoints = value; }
        public byte BlockChance { get => blockChance; set => blockChance = value; }
        public byte EvasionChance { get => evasionChange; set => evasionChange = value; }
        public bool Evading { get => evading; set => evading = value; }
        public bool Blocking { get => blocking; set => blocking = value; }

        public Person(string name, int health, int maxHealth, int strength, int dexterity, int critChance, int critDamage, byte blockChance, byte evasionChance, byte actionPoints, Weapon weapon) {
            Name = name;
            Health = health;
            MaxHealth = maxHealth;
            Strength = strength;
            Dexterity = dexterity;
            CritChance = critChance;
            CritDamage = critDamage;
            ActionPoints = actionPoints;
            BlockChance = blockChance;
            EvasionChance = evasionChance;
            Weapon = weapon;
            CalculateMaxStabDamage();
            CalculateMinStabDamage();
            CalculateMaxSlashDamage();
            CalculateMinSlashDamage();
            Evading = false;
            Blocking = false;
        }

        public void CalculateMaxStabDamage() {
            if (Dexterity * 2 >= 50) {
                MaxStabDamage = (int)(Weapon.MaxStabDmg + (Strength * 1.2)) + (Dexterity - 25);
            }
            else {
                MaxStabDamage = (int)(Weapon.MaxStabDmg + (Strength * 1.2));
            }
        }

        public void CalculateMinStabDamage() {
            if (Dexterity * 2 >= 25) {
                MinStabDamage = MaxStabDamage - 1;
            }
            else {
                if (MaxStabDamage - (25 - (Dexterity * 2)) < 1) {
                    MinStabDamage = 1;
                }
                else {
                    MinStabDamage = MaxStabDamage - (25 - (Dexterity * 2));
                }
            }
        }

        public void CalculateMaxSlashDamage() {
            if (Dexterity * 2 >= 50) {
                MaxSlashDamage = (int)(Weapon.MaxSlashDmg + (Strength * 1.2)) + (Dexterity - 25);
            }
            else {
                MaxSlashDamage = (int)(Weapon.MaxSlashDmg + (Strength * 1.2));
            }
        }

        public void CalculateMinSlashDamage() {
            if (Dexterity * 2 >= 25) {
                MinSlashDamage = MaxSlashDamage - 1;
            }
            else {
                if (MaxSlashDamage - (25 - (Dexterity * 2)) < 1) {
                    MinSlashDamage = 1;
                }
                else {
                    MinSlashDamage = MaxSlashDamage - (25 - (Dexterity * 2));
                }
            }
        }

        public override string ToString() {
            return Name + "\nStrength: " + Strength + "\nDexterity: " + Dexterity + "\nCritical chance: " + CritChance + "\nCritical damage multiplier: " + ((float)CritDamage/100) + "x\nBlock chance: " + BlockChance +
                "%\nEvasion chance: " + EvasionChance + "%\nStab damage: " + MinStabDamage +  "-" + MaxStabDamage + "\nSlash damage: " + MinSlashDamage + "-" + MaxSlashDamage;
        }
    }
}
