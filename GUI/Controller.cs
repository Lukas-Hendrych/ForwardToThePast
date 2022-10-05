using Library;
using Library.Fight;
using Library.Person;
using Library.Weapons;
using System.Reflection;
using System.Security;

namespace GUI {
    public class Controller {
        private string storyLevel;
        private int locX;
        private int locY;
        private int btnWidth;
        private int btnHeight;
        private int btnSpace;
        private Dictionary<string, string> settings;
        private AI enemy;
        private bool fight;
        private bool enemyBlocking;
        private bool enemyEvading;
        private bool playerBlocking;
        private bool playerEvading;
        private bool criticalHit;

        private byte tempPlayerPoints;
        private byte tempEnemyPoints;

        Weapon enemyWeapon;
        Dialogs dialog = new Dialogs();
        Player player = new Player("You", health: 32, maxHealth: 40, strength: 10, dexterity: 5, critChance: 30, critDamage: 20, blockChance: 30, evasionChance: 40, actionPoints: 2, new Blunt("Fists"));
        Form1 form;

        public string StoryLevel { get => storyLevel; set => storyLevel = value; }
        public int LocX { get => locX; set => locX = value; }
        public int LocY { get => locY; set => locY = value; }
        public int BtnWidth { get => btnWidth; set => btnWidth = value; }
        public int BtnSpace { get => btnSpace; set => btnSpace = value; }
        public int BtnHeight { get => btnHeight; set => btnHeight = value; }
        public Dictionary<string, string> Settings { get => settings; set => settings = value; }
        public AI Enemy { get => enemy; set => enemy = value; }
        public bool Fight { get => fight; set => fight = value; }
        public Player Player { get => player; set => player = value; }
        public byte TempPlayerPoints { get => tempPlayerPoints; set => tempPlayerPoints = value; }
        public byte TempEnemyPoints { get => tempEnemyPoints; set => tempEnemyPoints = value; }
        public bool EnemyBlocking { get => enemyBlocking; set => enemyBlocking = value; }
        public bool EnemyEvading { get => enemyEvading; set => enemyEvading = value; }
        public bool PlayerBlocking { get => playerBlocking; set => playerBlocking = value; }
        public bool PlayerEvading { get => playerEvading; set => playerEvading = value; }
        public bool CriticalHit { get => criticalHit; set => criticalHit = value; }

        public Controller() {
            StoryLevel = "1_1";
            LocX = 336;
            LocY = 430;
            BtnWidth = 124;
            BtnSpace = 6;
            BtnHeight = 46;
            Fight = false;
        }

        public void MainController(string dialogClicked, Form1 f) {
            form = f;
            form.DeleteAllBtOption();
            AttributesController();

            if (!dialogClicked.Equals("")) StoryLevel = dialogClicked;
            Settings = dialog.DialogsData(StoryLevel);
            form.SetPictureScenery(StoryLevel);

            if (Settings.ContainsKey("enemyName")) {
                Enemy = EnemyCreation.CreateEnemy(Settings);
                TempPlayerPoints = Player.ActionPoints;
                TempEnemyPoints = Enemy.ActionPoints;
                Fight = true;
                form.UpdateActionPoints(Player.ActionPoints, Enemy.ActionPoints);
                form.HealtBarsUpdate();
                form.SetDamageTips();
                form.SetScenery();
                form.HideDamageDealt();
                form.VisibilityFightBts();
                form.EnabledBlockEvade();
                form.StoryFightSwitch();
            }
            else if(Settings.ContainsKey("attributePoints")) {
                Player.AttributePoints += Convert.ToInt32(Settings["attributePoints"]);
                AttributesController();
                FormController();
                Settings.Clear();
            }
            else if (Settings.ContainsKey("actionPoints")) {
                Player.ActionPoints += Convert.ToByte(Settings["actionPoints"]);
                FormController();
                Settings.Clear();
            }
            else {
                FormController();
                if (StoryLevel.Equals("1_32")) form.BtExitVisible();
                Settings.Clear();
            }
        }

        public void AttributesController() {
            string stabDamage = Player.MinStabDamage + "-" + Player.MaxStabDamage;
            string slashDamage = Player.MinSlashDamage + "-" + Player.MaxSlashDamage;
            form.UpdateAttributes(Player.MaxHealth, Player.Strength, Player.Dexterity, Player.CritChance, Player.CritDamage, Player.BlockChance, Player.EvasionChance, stabDamage, slashDamage, Player.ActionPoints, Player.AttributePoints);
            
            if(Player.AttributePoints>0) {
                form.UnspentPointsInfoShow();
                form.AttributesBtShow();
            } else {
                form.UnspentPointsInfoHide();
                form.AttributesBtHide();
            }
        }

        public void AttributePointSpent(string buttonClicked) {
            switch (buttonClicked) {
                case "btMaxHealth": {
                    Player.MaxHealth+=5;
                    break;
                }
                case "btStrength": {
                    Player.Strength++;
                    Player.RecalculateDamage();
                    break;
                }
                case "btDexterity": {
                    Player.Dexterity++;
                    Player.RecalculateDamage();
                    break;
                }
                case "btCritChance": {
                    Player.CritChance++;
                    break;
                }
                case "btCritDamage": {
                    Player.CritDamage++;
                    break;
                }
                case "btBlockChance": {
                    Player.BlockChance++;
                    break;
                }
                case "btEvasionChance": {
                    Player.EvasionChance++;
                    break;
                }                
            }
            Player.AttributePoints--;
            AttributesController();
        }

        public void FormController() {
            if (Convert.ToBoolean(Settings["tellerContinue"])) StoryLevel = Settings["tellerLevel"];
            form.TellerUpdate(Settings["tellerName"], Settings["tellerText"], Convert.ToBoolean(Settings["tellerContinue"]));

            Weapon weaponTemp = null;

            if (Settings.ContainsKey("bt1Blunt")) {
                weaponTemp = new Blunt(Settings["bt1Blunt"]);
            }
            if (Settings.ContainsKey("bt1Sharp")) {
                weaponTemp = new Sharp(Settings["bt1Sharp"]);
            }

            switch (Settings["buttonsCount"]) {
                case "1": {
                    if (weaponTemp != null) {
                        form.CreateBtOption1(Settings["bt1Text"], Settings["bt1Name"], LocX, LocY, weaponTemp);
                    }
                    else {
                        form.CreateBtOption1(Settings["bt1Text"], Settings["bt1Name"], LocX, LocY);
                    }
                    break;
                }
                case "2": {
                    if (weaponTemp != null) {
                        form.CreateBtOption1(Settings["bt1Text"], Settings["bt1Name"], LocX - BtnWidth / 2 - BtnSpace, LocY, weaponTemp);
                    }
                    else {
                        form.CreateBtOption1(Settings["bt1Text"], Settings["bt1Name"], LocX - BtnWidth / 2 - BtnSpace, LocY);
                    }
                    form.CreateBtOption2(Settings["bt2Text"], Settings["bt2Name"], LocX + BtnWidth / 2, LocY);
                    break;
                }
                case "3": {
                    form.CreateBtOption1(Settings["bt1Text"], Settings["bt1Name"], LocX - BtnWidth - BtnSpace, LocY);
                    form.CreateBtOption2(Settings["bt2Text"], Settings["bt2Name"], LocX, LocY);
                    form.CreateBtOption3(Settings["bt3Text"], Settings["bt3Name"], LocX + BtnWidth + BtnSpace, LocY);
                    break;
                }
                case "4": {
                    form.CreateBtOption1(Settings["bt1Text"], Settings["bt1Name"], LocX - (3 * BtnWidth / 2) - 2 * BtnSpace, LocY);
                    form.CreateBtOption2(Settings["bt2Text"], Settings["bt2Name"], LocX - BtnWidth / 2 - BtnSpace, LocY);
                    form.CreateBtOption3(Settings["bt3Text"], Settings["bt3Name"], LocX + BtnWidth / 2, LocY);
                    form.CreateBtOption4(Settings["bt4Text"], Settings["bt4Name"], LocX + (3 * BtnWidth / 2) + BtnSpace, LocY);
                    break;
                }
            }
        }

        public async Task FightController(string buttonClicked) {
            TempEnemyPoints = Enemy.ActionPoints;
            CriticalHit = false;
            if (buttonClicked.Equals("btEndTurn")) {
                form.HideDamageDealt();
                form.InvisibilityFightBts();
                form.EnabledBlockEvade();
                form.HideEnemyBlockEvasion();
                form.Turn("Enemy's turn");
                EnemyBlocking = false;
                EnemyEvading = false;
                FightEnemyTurn();
            }
            else {
                FightPlayer fp = new FightPlayer(buttonClicked, Player, Enemy);
                Player.Evading = fp.PlayerEvading;
                Player.Blocking = fp.PlayerBlocking;

                if (Player.Blocking) {
                    form.PlayerBlockVisible();
                    form.ShowDamageDealt(fp.ShowDamageDealt, true);
                }
                else if (Player.Evading) {
                    form.PlayerEvadeVisible();
                    form.ShowDamageDealt(fp.ShowDamageDealt, true);
                }
                else {
                    form.ShowDamageDealt(fp.ShowDamageDealt);
                }

                if (fp.CriticalHit) form.ShowCriticalHit();

                if (Enemy.Health - fp.Attack <= 0) {
                    Enemy.Health = 0;
                }
                else {
                    Enemy.Health = Enemy.Health - fp.Attack;
                }

                form.HealtBarsUpdate();
                TempPlayerPoints += fp.TempPlayerPoints;

                if (TempPlayerPoints == 0) {
                    form.InvisibilityFightBts();
                }

                if (TempPlayerPoints < 2) {
                    form.DisabledBlockEvade();
                }
                else {
                    form.EnabledBlockEvade();
                }

                if (Enemy.Health <= 0) {
                    form.InvisibilityFightBts();
                    form.HideEndTurnBt();
                    await Task.Delay(1500);
                    Fight = false; AfterFightController();
                }

                form.UpdateActionPoints(TempPlayerPoints, TempEnemyPoints);
                Application.DoEvents();
                await Task.Delay(1500);
                form.HideDamageDealt();
                Application.DoEvents();
                await Task.Delay(1500);
            }
        }

        public void AfterFightController() {
            if (Enemy.GameOver && Player.Health<=0) {
                form.GameOverScreen();
                StoryLevel = Settings["fightLost"];
            }
            else {
                form.StoryFightSwitch();
                if (Player.Health > 0) {
                    Player.AttributePoints += 10;
                    AttributesController();
                    StoryLevel = Settings["fightWon"];
                    form.PlayerWonFight(Enemy.Weapon);
                    form.PlayerObtainedItem();
                }
                else {
                    StoryLevel = Settings["fightLost"];
                }
            }
            Settings.Clear();
            Player.Health = Player.MaxHealth;
            MainController("", form);
        }

        public void GameOverController(string buttonClicked) {
            if (buttonClicked.Equals("btLastCheckpoint")) {
                StoryLevel = Settings["fightLost"];
                MainController("", form);
            }
        }

        public void ObtainedItemController(string buttonClicked, Weapon obtainedWeapon) {
            if (buttonClicked.Equals("btEquip")) {
                Player.EquipWeapon(obtainedWeapon);
            }
        }

        public async Task FightEnemyTurn() {
            Random rndAttack = new Random();
            Random rndAttackChoise = new Random();
            Random rndCrit = new Random();
            int attackChoise;
            int playerNewHealth;
            int attack = 0;
            bool playerBlocked = false; bool playerEvaded = false;

            do {
                attackChoise = rndAttackChoise.Next(1, 4 + 1);
                if (attackChoise > 2 && TempEnemyPoints < 2) attackChoise = rndAttackChoise.Next(1, 2 + 1);

                switch (attackChoise) {
                    case 1: {
                        if (rndCrit.Next(0, 101) <= Enemy.CritChance) {
                            attack = (Enemy.MaxStabDamage) + (Enemy.CritDamage * Enemy.MaxStabDamage / 100);
                            CriticalHit = true;
                        }
                        else {
                            attack = rndAttack.Next(Enemy.MinStabDamage, Enemy.MaxStabDamage + 1);
                        }
                        TempEnemyPoints--;
                        break;
                    }
                    case 2: {
                        if (rndCrit.Next(0, 101) <= Enemy.CritChance) {
                            attack = (Enemy.MaxSlashDamage) + (Enemy.CritDamage * Enemy.MaxSlashDamage / 100);
                            CriticalHit = true;
                        }
                        else {
                            attack = rndAttack.Next(Enemy.MinSlashDamage, Enemy.MaxSlashDamage + 1);
                        }
                        TempEnemyPoints--;
                        break;
                    }
                    case 3: {
                        EnemyBlocking = true;
                        form.EnemyBlockVisible();
                        form.ShowDamageDealt("Enemy prepared to block!", true);
                        TempEnemyPoints -= 2;
                        break;
                    }
                    case 4: {
                        EnemyEvading = true;
                        form.EnemyEvadeVisible();
                        form.ShowDamageDealt("Enemy prepared to evade!", true);
                        TempEnemyPoints -= 2;
                        break;
                    }
                }

                if (attackChoise < 3) {
                    if (Player.Blocking) {
                        Random rndBlock = new Random();
                        playerBlocked = (rndBlock.Next(0, 101) <= Player.BlockChance) ? true : false;
                        form.ShowDamageDealt("Enemy attack blocked!");
                    }

                    if (!playerBlocked && Player.Evading) {
                        Random rndEvasion = new Random();
                        playerEvaded = (rndEvasion.Next(0, 101) <= Player.EvasionChance) ? true : false;
                        form.ShowDamageDealt("Enemy attack evaded!");
                    }

                    if (!playerBlocked && !playerEvaded) {
                        if (Player.Health - attack <= 0) {
                            playerNewHealth = 0;
                            TempEnemyPoints = 0;
                        }
                        else {
                            playerNewHealth = Player.Health - attack;
                        }
                        Player.Health = playerNewHealth;
                        form.HealtBarsUpdate();
                        form.ShowDamageDealt("-" + attack.ToString());
                        if (CriticalHit) {
                            form.ShowCriticalHit();
                            CriticalHit = false;
                        }
                    }
                }
                form.UpdateActionPoints(TempPlayerPoints, TempEnemyPoints);
                Application.DoEvents();
                await Task.Delay(1500);
                form.HideDamageDealt();
                Application.DoEvents();
                await Task.Delay(1500);
                if (Player.Health <= 0) Fight = false;
            } while (TempEnemyPoints > 0);

            PlayerEvading = false;
            PlayerBlocking = false;
            form.HidePlayerBlockEvasion();
            form.VisibilityFightBts();
            TempPlayerPoints = Player.ActionPoints;
            form.UpdateActionPoints(TempPlayerPoints, TempEnemyPoints);
            if (!Fight) AfterFightController();
            form.Turn("Your turn");
        }
    }
}

//Type type = typeof(Library.Dialogs);
//MethodInfo methodInfo = type.GetMethod(dialogMethod);
//string a = (string)methodInfo.Invoke(dialogMethod, new object[] { StoryLevel });
//if (dialogMethod.Equals("btOption1")) form.CreateBtOption2(a);
//if (dialogMethod.Equals("btOption2")) form.CreateBtOption1("H");
//if (dialogMethod.Equals("DialogsData")) form.CreateBtOption2(a);