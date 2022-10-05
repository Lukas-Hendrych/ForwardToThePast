using Library.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Person {
    public class AI : Person {
        private bool gameOver;
        private string enemyImage;

        public bool GameOver { get => gameOver; set => gameOver = value; }
        public string EnemyImage { get => enemyImage; set => enemyImage = value; }

        public AI(string name, string image, int health, int maxHealth, int strength, int dexterity, int critChance, int critDamage, byte blockChance, byte evasionChance, byte actionPoints, Weapon weapon, bool gameOver) 
            : base(name,health,maxHealth,strength,dexterity,critChance,critDamage,blockChance,evasionChance,actionPoints, weapon) {
            GameOver = gameOver;
            enemyImage = image;
        }

        public override string ToString() {
            return base.ToString();
        }

    }
}
