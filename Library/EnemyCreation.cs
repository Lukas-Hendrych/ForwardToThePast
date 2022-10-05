using Library.Person;
using Library.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library {
    public class EnemyCreation {
        public static AI CreateEnemy(Dictionary<string, string> Settings) {
            Weapon enemyWeapon;

            if (Settings["enemyWeapon"].Equals("Blunt")) {
                enemyWeapon = new Blunt(Settings["enemyWeaponName"]);
            }
            else {
                enemyWeapon = new Sharp(Settings["enemyWeaponName"]);
            }

            AI Enemy = new AI(Settings["enemyName"],
                Settings["enemyImage"],
                Convert.ToInt32(Settings["enemyHealth"]),
                Convert.ToInt32(Settings["enemyMaxHealth"]),
                Convert.ToInt32(Settings["enemyStrength"]),
                Convert.ToInt32(Settings["enemyDexterity"]),
                Convert.ToInt32(Settings["enemyCritChance"]),
                Convert.ToInt32(Settings["enemyCritDamage"]),
                Convert.ToByte(Settings["enemyBlockChance"]),
                Convert.ToByte(Settings["enemyEvasionChance"]),
                Convert.ToByte(Settings["enemyActionPoints"]),
                enemyWeapon,
                Convert.ToBoolean(Settings["gameOver"]));

            return Enemy;
        }
    }
}
