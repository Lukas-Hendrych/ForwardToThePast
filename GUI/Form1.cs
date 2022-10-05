using GUI.Properties;
using Library;
using Library.Person;
using Library.Weapons;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;

namespace GUI {
    public partial class Form1 : Form {
        Controller Controller;
        BtOption btOption1;
        BtOption btOption2;
        BtOption btOption3;
        BtOption btOption4;
        Weapon weapon;
        private string btWithWeapon;
        private bool gameStarted;

        public string BtWithWeapon { get => btWithWeapon; set => btWithWeapon = value; }
        public bool GameStarted { get => gameStarted; set => gameStarted = value; }

        public Form1() {
            InitializeComponent();
            lbTeller.Click += new EventHandler(teller_MouseClick);
            lbContinue.Click += new EventHandler(teller_MouseClick);
            gbTeller1.Click += new EventHandler(teller_MouseClick);
            btStab.Click += new System.EventHandler(btFight_Click);
            btSlash.Click += new System.EventHandler(btFight_Click);
            btBlock.Click += new System.EventHandler(btFight_Click);
            btEvade.Click += new System.EventHandler(btFight_Click);
            btEquip.Click += new System.EventHandler(btObtainedItem_Click);
            btLeaveIt.Click += new System.EventHandler(btObtainedItem_Click);
            btTake.Click += new System.EventHandler(btObtainedItem_Click);
            gbTeller1.Visible = false;
            btPlay.Click += new System.EventHandler(btGameStart_Click);
            btRestart.Click += new System.EventHandler(btGameStart_Click);
            btMaxHealth.Click += new System.EventHandler(btAttribute_Click);
            btStrength.Click += new System.EventHandler(btAttribute_Click);
            btDexterity.Click += new System.EventHandler(btAttribute_Click);
            btCritChance.Click += new System.EventHandler(btAttribute_Click);
            btCritDamage.Click += new System.EventHandler(btAttribute_Click);
            btBlockChance.Click += new System.EventHandler(btAttribute_Click);
            btEvasionChance.Click += new System.EventHandler(btAttribute_Click);
            GameStarted = false;
        }

        public void btOption_Click(object sender, EventArgs e) {
            if (weapon != null && BtWithWeapon.Equals(((BtOption)sender).Name)) {
                PlayerObtainedItem();
            }
            Controller.MainController(((BtOption)sender).Name.ToString(), this);
        }

        private void btGameStart_Click(object sender, EventArgs e) {
            Controller = new Controller();
            tabMother.TabPages[0].Controls.Remove(btPlay);
            btExit.Visible = false;
            tabMother.SelectedIndex = 0;
            gbTeller1.Visible = true;
            GameStarted = true;
            Controller.MainController("1_1", this);
        }

        public void BtExitVisible() {
            btExit.Visible = true;
        }

        public void UpdateAttributes(int maxHealth, int strength, int dexterity, int critChance, int critDamage, int blockChance, int evasionChance, string stabDamage, string slashDamage, int maxActionPoints, int attributePoints) {
            lbMaxHealth.Text = "Max health: " + maxHealth;
            lbStrength.Text = "Strength: " + strength;
            lbDexterity.Text = "Dexterity: " + dexterity;
            lbCritChance.Text = "Critical chance: " + critChance + "%";
            lbCritDamage.Text = "Critical damage: " + (float)critDamage / 100 + "x";
            lbBlockChance.Text = "Block chance: " + blockChance + "%";
            lbEvasionChance.Text = "Evasion chance: " + evasionChance + "%";
            lbStabDamage.Text = "Stab damage: " + stabDamage;
            lbSlashDamage.Text = "Slash damage: " + slashDamage;
            lbActionPoints.Text = "Action points: " + maxActionPoints;
            lbAttributePoints.Text = "Unspent attribute points: " + attributePoints;
            attackTip.SetToolTip(picPlayerWeaponInv, Controller.Player.Weapon.ToString());
            picPlayerWeaponInv.Image = (Image)Resources.ResourceManager.GetObject(Controller.Player.Weapon.WeaponImg);

            try {
                picPlayerWeaponInv.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
            }
            catch (NullReferenceException) {
                picPlayerWeaponInv.Image = Properties.Resources.old_club;
                picPlayerWeaponInv.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
            }
        }

        public void AttributesBtShow() {
            btMaxHealth.Visible = true;
            btStrength.Visible = true;
            btDexterity.Visible = true;
            btCritChance.Visible = true;
            btCritDamage.Visible = true;
            btBlockChance.Visible = true;
            btEvasionChance.Visible = true;
        }

        public void AttributesBtHide() {
            btMaxHealth.Visible = false;
            btStrength.Visible = false;
            btDexterity.Visible = false;
            btCritChance.Visible = false;
            btCritDamage.Visible = false;
            btBlockChance.Visible = false;
            btEvasionChance.Visible = false;
        }

        private void btAttribute_Click(object sender, EventArgs e) {
            Controller.AttributePointSpent(((Button)sender).Name);
        }

        public void UnspentPointsInfoShow() {
            lbInfoUnspent.Visible = true;
        }

        public void UnspentPointsInfoHide() {
            lbInfoUnspent.Visible = false;
        }

        public void DeleteAllBtOption() {
            for (int i = tabMother.TabPages[0].Controls.Count - 1; i >= 0; --i) if (tabMother.TabPages[0].Controls[i] is BtOption) tabMother.TabPages[0].Controls.RemoveAt(i);
        }

        public void TellerUpdate(string name, string text, bool tellerContinue) {
            gbTeller1.Text = name;
            lbTeller.Text = text;
            lbContinue.Visible = tellerContinue ? true : false;
        }

        public void SetPictureScenery(string imageScenery) {
            picScenery.Image = (Image)Resources.ResourceManager.GetObject(imageScenery);
        }

        public void CreateBtOption1(string btText, string btName, int locX, int locY, Weapon weaponObtained) {
            btOption1 = new BtOption();
            tabMother.TabPages[0].Controls.Add(btOption1);
            btOption1.Name = btName;
            btOption1.Text = btText;
            btOption1.Location = new Point(locX, locY);
            btOption1.Click += new System.EventHandler(btOption_Click);
            this.weapon = weaponObtained;
            BtWithWeapon = btName;
        }

        public void CreateBtOption1(string btText, string btName, int locX, int locY) {
            btOption1 = new BtOption();
            tabMother.TabPages[0].Controls.Add(btOption1);
            btOption1.Name = btName;
            btOption1.Text = btText;
            btOption1.Location = new Point(locX, locY);
            btOption1.Click += new System.EventHandler(btOption_Click);
        }

        public void CreateBtOption2(string btText, string btName, int locX, int locY) {
            btOption2 = new BtOption();
            tabMother.TabPages[0].Controls.Add(btOption2);
            btOption2.Name = btName;
            btOption2.Text = btText;
            btOption2.Location = new Point(locX, locY);
            btOption2.Click += new System.EventHandler(btOption_Click);
            //DoDragDrop(btOption2, DragDropEffects.Move);
        }

        public void CreateBtOption3(string btText, string btName, int locX, int locY) {
            btOption3 = new BtOption();
            tabMother.TabPages[0].Controls.Add(btOption3);
            btOption3.Name = btName;
            btOption3.Text = btText;
            btOption3.Location = new Point(locX, locY);
            btOption3.Click += new System.EventHandler(btOption_Click);
        }

        public void CreateBtOption4(string btText, string btName, int locX, int locY) {
            btOption4 = new BtOption();
            tabMother.TabPages[0].Controls.Add(btOption4);
            btOption4.Name = btName;
            btOption4.Text = btText;
            btOption4.Location = new Point(locX, locY);
            btOption4.Click += new System.EventHandler(btOption_Click);
        }

        private void teller_MouseClick(object sender, EventArgs e) {
            Controller.MainController("", this);
        }

        public void btFight_Click(object sender, EventArgs e) {
            Controller.FightController(((BtOption)sender).Name.ToString());
        }

        public void HealtBarsUpdate() {
            int playerHP = Controller.Player.Health;
            int playerMaxHP = Controller.Player.MaxHealth;
            int enemyHP = Controller.Enemy.Health;
            int enemyMaxHP = Controller.Enemy.MaxHealth;
            lbPlayerHP.Text = playerHP.ToString() + " / " + playerMaxHP.ToString();
            lbEnemyHP.Text = enemyHP.ToString() + " / " + enemyMaxHP.ToString();
            hbPlayerHP.Maximum = playerMaxHP;
            hbPlayerHP.Value = playerHP;
            hbEnemyHP.Maximum = enemyMaxHP;
            hbEnemyHP.Value = enemyHP;
        }

        public void SetDamageTips() {
            attackTip.SetToolTip(btStab, "Action point: 1\nDeal " + Controller.Player.MinStabDamage + "-" + Controller.Player.MaxStabDamage + " stab damage");
            attackTip.SetToolTip(btSlash, "Action point: 1\nDeal " + Controller.Player.MinSlashDamage + "-" + Controller.Player.MaxSlashDamage + " slash damage");
            attackTip.SetToolTip(btBlock, "Action point: 2\nActivate block: " + Controller.Player.BlockChance + "% block chance");
            attackTip.SetToolTip(btEvade, "Action point: 2\nActivate evasion: " + Controller.Player.EvasionChance + "% evasion chance");
            attackTip.SetToolTip(picPlayerBlock, "Block activated!\n" + Controller.Player.BlockChance + "% chance to block attack");
            attackTip.SetToolTip(picPlayerEvade, "Evasion activated!\n" + Controller.Player.EvasionChance + "% chance to evade attack");
            attackTip.SetToolTip(picEnemyBlock, "Block activated!\n" + Controller.Enemy.BlockChance + "% chance to block attack");
            attackTip.SetToolTip(picEnemyEvade, "Evasion activated!\n" + Controller.Enemy.EvasionChance + "% chance to evade attack");
            attackTip.SetToolTip(picEnemyWeapon, Controller.Enemy.Weapon.ToString());
            attackTip.SetToolTip(picPlayerWeapon, Controller.Player.Weapon.ToString());
            attackTip.SetToolTip(picPlayer, Controller.Player.ToString());
            attackTip.SetToolTip(picEnemy, Controller.Enemy.ToString());
        }

        public void SetScenery() {
            lbNameEnemy.Text = Controller.Enemy.Name;
            HidePlayerBlockEvasion();
            HideEnemyBlockEvasion();
            string enemyWeapon = Controller.Enemy.Weapon.WeaponImg;
            string enemyImage = Controller.Enemy.EnemyImage;
            string playerWeapon = Controller.Player.Weapon.WeaponImg;
            picEnemyWeapon.Image = (Image)Resources.ResourceManager.GetObject(enemyWeapon);
            picEnemy.Image = (Image)Resources.ResourceManager.GetObject(enemyImage);
            picPlayerWeapon.Image = (Image)Resources.ResourceManager.GetObject(playerWeapon);

            try {
                picPlayerWeapon.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
            }
            catch (NullReferenceException) {
                picPlayerWeapon.Image = Properties.Resources.old_club;
                picPlayerWeapon.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
            }
        }

        public void Turn(string str) {
            lbTurn.Text = str;
        }

        public void HidePlayerBlockEvasion() {
            picPlayerBlock.Visible = false;
            picPlayerEvade.Visible = false;
        }

        public void HideEnemyBlockEvasion() {
            picEnemyBlock.Visible = false;
            picEnemyEvade.Visible = false;
        }

        public void PlayerBlockVisible() {
            picPlayerBlock.Visible = true;
        }

        public void PlayerEvadeVisible() {
            picPlayerEvade.Visible = true;
        }

        public void EnemyBlockVisible() {
            picEnemyBlock.Visible = true;
        }

        public void EnemyEvadeVisible() {
            picEnemyEvade.Visible = true;
        }

        public void UpdateActionPoints(byte playerPoints, byte enemyPoints) {
            lbActionPlayer.Text = playerPoints.ToString();
            lbActionEnemy.Text = enemyPoints.ToString();
        }

        public void StoryFightSwitch() {
            if (Controller.Fight) {
                tabMother.SelectedIndex = 1;
            }
            else {
                tabMother.SelectedIndex = 0;
            }
        }

        public void InvisibilityFightBts() {
            btStab.Visible = false;
            btSlash.Visible = false;
            btBlock.Visible = false;
            btEvade.Visible = false;
        }

        public void VisibilityFightBts() {
            btStab.Visible = true;
            btSlash.Visible = true;
            btBlock.Visible = true;
            btEvade.Visible = true;
            btEndTurn.Visible = true;
        }

        public void DisabledBlockEvade() {
            btEvade.Enabled = false;
            btBlock.Enabled = false;
        }

        public void EnabledBlockEvade() {
            btEvade.Enabled = true;
            btBlock.Enabled = true;
        }

        public void HideEndTurnBt() {
            btEndTurn.Visible = false;
        }

        private void btEndTurn_Click(object sender, EventArgs e) {
            HideEndTurnBt();
            Controller.FightController(((BtOption)sender).Name.ToString());
        }

        public void ShowDamageDealt(string damage) {
            lbDamageTaken.ForeColor = Color.Red;
            lbDamageTaken.Text = damage;
        }

        public void ShowDamageDealt(string action, bool isAction) {
            lbDamageTaken.ForeColor = Color.MediumBlue;
            lbDamageTaken.Text = action;
        }

        public void ShowCriticalHit() {
            lbCriticalHit.Visible = true;
        }

        public void HideDamageDealt() {
            lbDamageTaken.Text = "";
            lbCriticalHit.Visible = false;
        }

        public void PlayerWonFight(Weapon wep) {
            this.weapon = wep;
        }

        public void PlayerObtainedItem() {
            gbPlayerObtainedItem.Visible = true;
            string weaponObtained = this.weapon.WeaponImg;
            picObtainedItem.Image = (Image)Resources.ResourceManager.GetObject(weaponObtained);
            attackTip.SetToolTip(picObtainedItem, weapon.ToString() + "\n\nYou have\n" + Controller.Player.Weapon.ToString());
            gbTeller1.Visible = false;
        }

        private void btObtainedItem_Click(object sender, EventArgs e) {
            Controller.ObtainedItemController(((Button)sender).Name.ToString(), weapon);
            gbPlayerObtainedItem.Visible = false;
            gbTeller1.Visible = true;
            weapon = null;
            BtWithWeapon = "";
        }

        public void GameOverScreen() {
            tabMother.SelectedIndex = 2;
        }

        public void StoryScreen() {
            tabMother.SelectedIndex = 0;
        }

        private void btLastCheckpoint_Click(object sender, EventArgs e) {
            StoryScreen();
            Controller.MainController("", this);
        }

        private void btExit_Click(object sender, EventArgs e) {
            this.Close();
        }

        protected override bool ProcessDialogKey(Keys keyData) {
            if (GameStarted) {
                if (keyData == Keys.Tab) {
                    if (tabMother.SelectedIndex == 0) {
                        Controller.AttributesController();
                        tabMother.SelectedIndex = 3;
                    }
                    else if (tabMother.SelectedIndex == 3) {
                        tabMother.SelectedIndex = 0;
                    }
                    return true;
                }
            }
            return base.ProcessDialogKey(keyData);
        }
    }
}
