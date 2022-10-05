using Library.Person;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Library.Fight {
    public class FightPlayer {

        private string buttonClicked;
        private Player Player;
        private AI Enemy;

        private bool criticalHit;
        private byte tempPlayerPoints;
        private int attack;
        private string showDamageDealt;
        private bool playerBlocking;
        private bool playerEvading;

        public bool CriticalHit { get => criticalHit; set => criticalHit = value; }
        public byte TempPlayerPoints { get => tempPlayerPoints; set => tempPlayerPoints = value; }
        public int Attack { get => attack; set => attack = value; }
        public string ShowDamageDealt { get => showDamageDealt; set => showDamageDealt = value; }
        public bool PlayerBlocking { get => playerBlocking; set => playerBlocking = value; }
        public bool PlayerEvading { get => playerEvading; set => playerEvading = value; }

        public FightPlayer(string buttonClicked, Player Player, AI Enemy) {
            this.buttonClicked = buttonClicked;
            this.Player = Player;
            this.Enemy = Enemy;
            this.Attack = 0;
            AttackPlayerResult();
            BlockEvadePlayer();
        }

        private void BlockEvadePlayer() {
            if (buttonClicked.Equals("btBlock")) {
                PlayerBlocking = true;
                ShowDamageDealt = "You prepared to block!";
                TempPlayerPoints -= 2;
            }
            else if (buttonClicked.Equals("btEvade")) {
                PlayerEvading = true;
                ShowDamageDealt = "You prepared to evade!";
                TempPlayerPoints -= 2;
            }
        }

        public void AttackPlayerResult() {
            Random rndAttack = new Random();
            Random rndCrit = new Random();
            bool enemyBlocked = false; bool enemyEvaded = false;

            if (Enemy.Blocking) {
                Random rndBlock = new Random();
                if (rndBlock.Next(0, 101) <= Enemy.BlockChance) {
                    enemyBlocked = true;
                    ShowDamageDealt = "Damage blocked!";
                    Attack = 0;
                }
            }
            else if (!enemyBlocked && Enemy.Evading) {
                Random rndEvasion = new Random();
                if (rndEvasion.Next(0, 101) <= Enemy.EvasionChance) {
                    enemyEvaded = true;
                    ShowDamageDealt = "Damage evaded!";
                    Attack = 0;
                }
            }
            else if (!enemyBlocked && !enemyEvaded) {
                switch (buttonClicked) {
                    case "btStab": {
                        if (rndCrit.Next(0, 101) <= Player.CritChance) {
                            Attack = (Player.MaxStabDamage) + (Player.CritDamage * Player.MaxStabDamage / 100);
                            CriticalHit = true;
                        }
                        else {
                            Attack = rndAttack.Next(Player.MinStabDamage, Player.MaxStabDamage + 1);
                        }
                        TempPlayerPoints--;
                        break;
                    }
                    case "btSlash": {
                        if (rndCrit.Next(0, 101) <= Player.CritChance) {
                            Attack = (Player.MaxSlashDamage) + (Player.CritDamage * Player.MaxSlashDamage / 100);
                            CriticalHit = true;
                        }
                        else {
                            Attack = rndAttack.Next(Player.MinSlashDamage, Player.MaxSlashDamage + 1);
                        }
                        TempPlayerPoints--;
                        break;
                    }
                }
                ShowDamageDealt = "-" + Attack.ToString();
            }
        }
    }
}
