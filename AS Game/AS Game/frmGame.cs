using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace AS_Game
{
    public partial class frmGame : Form
    {
        public frmGame()
        {
            InitializeComponent();
        }

        public class Unit
        {
            private int type;
            private Random attack;
            private int health;
            private int moveRange;
            private int attackRange;
            private PictureBox icon;
            private bool moved;

            public Unit(int type, Random attack, int health, int moveRange, int attackRange, PictureBox icon, bool moved)
            {
                this.type = type;
                this.attack = attack;
                this.health = health;
                this.moveRange = moveRange;
                this.attackRange = attackRange;
                this.icon = icon;
                this.moved = moved;
            }

            public int Type
            {
                get { return type; }
                set { type = value; }
            }

            public Random Attack
            {
                get { return attack; }
                set { attack = value; }
            }

            public int Health
            {
                get { return health; }
                set { health = value; }
            }

            public int MoveRange
            {
                get { return moveRange; }
                set { moveRange = value; }
            }

            public int AttackRange
            {
                get { return attackRange; }
                set { attackRange = value; }
            }

            public PictureBox Icon
            {
                get { return icon; }
                set { icon = value; }
            }

            public bool Moved
            {
                get { return moved; }
                set { moved = value; }
            }
        }

        public class EnemyUnit : Unit
        {
            private Point target;
            private char targetType;
            private int lastTurnCaptured;

            public EnemyUnit(int type, Random attack, int health, int moveRange, int attackRange, PictureBox icon, bool moved, Point target, char targetType, int lastTurnCaptured) : base(type, attack, health, moveRange, attackRange, icon, moved)
            {
                this.target = target;
            }

            public Point Target
            {
                get { return target; }
                set { target = value; }
            }

            public char TargetType
            {
                get { return targetType; }
                set { targetType = value; }
            }

            public int LastTurnCaptured
            {
                get { return lastTurnCaptured; }
                set { lastTurnCaptured = value; }
            }
        }

        int turn;
        int playerMoney;
        int cpuMoney;
        int finalScore;
        int cpuRan;
        int enemyHP;
        int damageDealt;
        int damageTaken;

        Random def = new Random();

        public Unit aUnit;
        public EnemyUnit tUnit;

        public List<Button> cities = new List<Button>();
        public List<PictureBox> playerCities = new List<PictureBox>();
        public List<PictureBox> enemyCities = new List<PictureBox>();

        public List<Unit> pUnits = new List<Unit>();
        public List<EnemyUnit> eUnits = new List<EnemyUnit>();
        public List<Button> movement = new List<Button>();
        public List<Point> possibleEnemyMovement = new List<Point>();
        public List<PictureBox> enemiesInRange = new List<PictureBox>();

        int citySelected;
        bool btnMoveVisible = false;
        public PictureBox selectedPicBox;
        Random cpuStartingMoney = new Random();

        Random cpuPathRan = new Random();
        public void frmGame_Load(object sender, EventArgs e)
        {
            turn = 1;                       //Setting up variables
            playerMoney = GlobalVariables.moneyFromQuiz;
            lblMoney.Text = playerMoney.ToString();
            playerCities.Add(picCity1);
            enemyCities.Add(picCity7);
            pnlCreateUnit.Location = new Point(223, 51);
            citySelected = 0;
            lblTurn.Text = turn.ToString();
            cpuRan = cpuStartingMoney.Next(1, 4);
            cpuMoney = cpuRan * 3;

            movement.Add(btnProvince1);
            movement.Add(btnProvince2);
            movement.Add(btnProvince3);
            movement.Add(btnProvince4);
            movement.Add(btnProvince5);
            movement.Add(btnProvince6);
            movement.Add(btnProvince7);
            movement.Add(btnProvince8);
            movement.Add(btnProvince9);
            movement.Add(btnProvince10);
            movement.Add(btnProvince11);
            movement.Add(btnProvince12);
            movement.Add(btnProvince13);
            movement.Add(btnProvince14);
            movement.Add(btnProvince15);
            movement.Add(btnProvince16);
            movement.Add(btnProvince17);
            movement.Add(btnProvince18);
            movement.Add(btnProvince19);

            cities.Add(btnProvince2);
            cities.Add(btnProvince4);
            cities.Add(btnProvince7);
            cities.Add(btnProvince10);
            cities.Add(btnProvince12);
            cities.Add(btnProvince16);
            cities.Add(btnProvince17);
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            turn++;
            foreach (EnemyUnit eUnit in eUnits)
            {
                eUnit.Moved = false;
            }

            foreach (PictureBox city in enemyCities)
            {
                city.BackColor = Color.Red;
            }

            if (eUnits.Count > 0)
            {
                Random ran = new Random();
                List<Unit> targets = new List<Unit>();
                targets.Clear();
                for (int i = 0; i < eUnits.Count; i++)
                {
                    if((eUnits[i].Target == new Point(3000, 3000)) || (eUnits[i].Icon.Location == eUnits[i].Target))
                    {
                        FindTarget(eUnits[i]);
                    }

                    if ((eUnits[i].Moved != true) && (eUnits[i].LastTurnCaptured != turn - 1))
                    {
                        eUnits[i].Icon.Location = FindPath(eUnits[i].Icon.Location, eUnits[i].Target, eUnits[i]);
                        eUnits[i].Moved = true;
                    }

                    foreach (EnemyUnit eUnit in eUnits)
                    {
                        foreach (Unit unit in pUnits)
                        {
                            if (Math.Sqrt(((eUnit.Icon.Location.X - unit.Icon.Location.X) * (eUnit.Icon.Location.X - unit.Icon.Location.X)) + (eUnit.Icon.Location.Y - unit.Icon.Location.Y) * (eUnit.Icon.Location.Y - unit.Icon.Location.Y)) <= eUnit.AttackRange)
                            {
                                targets.Add(unit);
                                int target = ran.Next(0, targets.Count - 1);
                                Attack(eUnit, targets[target]);
                            }
                        }
                        
                    }
                        
                    Thread.Sleep(250);
                }
            }
            playerMoney = playerMoney + playerCities.Count * 3;
            cpuMoney = cpuMoney + enemyCities.Count * 3;
            lblTurn.Text = turn.ToString();
            lblMoney.Text = playerMoney.ToString();
            CPUSpawn();

            foreach (EnemyUnit eUnit in eUnits)
            {
                if ((eUnit.Icon.Location == new Point(btnProvince2.Location.X - 12, btnProvince2.Location.Y - 21)) & (!enemyCities.Contains(picCity1)))
                {
                    enemyCities.Add(picCity1);
                    if (playerCities.Contains(picCity1))
                    {
                        playerCities.Remove(picCity1);
                    }
                    eUnit.LastTurnCaptured = turn;
                }

                if ((eUnit.Icon.Location == new Point(btnProvince4.Location.X - 12, btnProvince4.Location.Y - 21)) & (!enemyCities.Contains(picCity2)))
                {
                    enemyCities.Add(picCity2);
                    if (playerCities.Contains(picCity2))
                    {
                        playerCities.Remove(picCity2);
                    }
                    eUnit.LastTurnCaptured = turn;
                }

                if ((eUnit.Icon.Location == new Point(btnProvince7.Location.X - 12, btnProvince7.Location.Y - 21)) & (!enemyCities.Contains(picCity3)))
                {
                    enemyCities.Add(picCity3);
                    if (playerCities.Contains(picCity3))
                    {
                        playerCities.Remove(picCity3);
                    }
                    eUnit.LastTurnCaptured = turn;
                }

                if ((eUnit.Icon.Location == new Point(btnProvince10.Location.X - 12, btnProvince10.Location.Y - 21)) & (!enemyCities.Contains(picCity4)))
                {
                    enemyCities.Add(picCity4);
                    if (playerCities.Contains(picCity4))
                    {
                        playerCities.Remove(picCity4);
                    }
                    eUnit.LastTurnCaptured = turn;
                }

                if ((eUnit.Icon.Location == new Point(btnProvince12.Location.X - 12, btnProvince12.Location.Y - 21)) & (!enemyCities.Contains(picCity5)))
                {
                    enemyCities.Add(picCity5);
                    if (playerCities.Contains(picCity5))
                    {
                        playerCities.Remove(picCity5);
                    }
                    eUnit.LastTurnCaptured = turn;
                }

                if ((eUnit.Icon.Location == new Point(btnProvince16.Location.X - 12, btnProvince16.Location.Y - 21)) & (!enemyCities.Contains(picCity6)))
                {
                    enemyCities.Add(picCity6);
                    if (playerCities.Contains(picCity6))
                    {
                        playerCities.Remove(picCity6);
                    }
                    eUnit.LastTurnCaptured = turn;
                }

                if ((eUnit.Icon.Location == new Point(btnProvince17.Location.X - 12, btnProvince17.Location.Y - 21)) & (!enemyCities.Contains(picCity7)))
                {
                    enemyCities.Add(picCity7);
                    if (playerCities.Contains(picCity7))
                    {
                        playerCities.Remove(picCity7);
                    }
                    eUnit.LastTurnCaptured = turn;
                }
            }

            foreach (Unit unit in pUnits)
            {
                unit.Moved = false;
                if ((unit.Icon.Location == new Point(btnProvince2.Location.X - 9, btnProvince2.Location.Y - 19)) & (!playerCities.Contains(picCity1)))
                {
                    playerCities.Add(picCity1);
                    if (enemyCities.Contains(picCity1))
                    {
                        enemyCities.Remove(picCity1);
                    }
                }

                if ((unit.Icon.Location == new Point(btnProvince4.Location.X - 9, btnProvince4.Location.Y - 19)) & (!playerCities.Contains(picCity2)))
                {
                    playerCities.Add(picCity2);
                    if (enemyCities.Contains(picCity2))
                    {
                        enemyCities.Remove(picCity2);
                    }
                }

                if ((unit.Icon.Location == new Point(btnProvince7.Location.X - 9, btnProvince7.Location.Y - 19)) & (!playerCities.Contains(picCity3)))
                {
                    playerCities.Add(picCity3);
                    if (enemyCities.Contains(picCity3))
                    {
                        enemyCities.Remove(picCity3);
                    }
                }

                if ((unit.Icon.Location == new Point(btnProvince10.Location.X - 9, btnProvince10.Location.Y - 19)) & (!playerCities.Contains(picCity4)))
                {
                    playerCities.Add(picCity4);
                    if (enemyCities.Contains(picCity4))
                    {
                        enemyCities.Remove(picCity4);
                    }
                }

                if ((unit.Icon.Location == new Point(btnProvince12.Location.X - 9, btnProvince12.Location.Y - 19)) & (!playerCities.Contains(picCity5)))
                {
                    playerCities.Add(picCity5);
                    if (enemyCities.Contains(picCity5))
                    {
                        enemyCities.Remove(picCity5);
                    }
                }

                if ((unit.Icon.Location == new Point(btnProvince16.Location.X - 9, btnProvince16.Location.Y - 19)) & (!playerCities.Contains(picCity6)))
                {
                    playerCities.Add(picCity6);
                    if (enemyCities.Contains(picCity6))
                    {
                        enemyCities.Remove(picCity6);
                    }
                }

                if ((unit.Icon.Location == new Point(btnProvince17.Location.X - 9, btnProvince17.Location.Y - 19)) & (!playerCities.Contains(picCity7)))
                {
                    playerCities.Add(picCity7);
                    if (enemyCities.Contains(picCity7))
                    {
                        enemyCities.Remove(picCity7);
                    }
                }

                foreach(PictureBox city in playerCities)
                {
                    city.BackColor = Color.DodgerBlue;
                }
            }

            if ((turn == 21) || ((pUnits.Count == 0) && (playerCities.Count == 0)) || ((eUnits.Count == 0) && (enemyCities.Count == 0)))
            {
                foreach (Unit unit in pUnits)
                {
                    if (unit.Type == 1)
                    {
                        finalScore += 3;
                    }

                    if (unit.Type == 2)
                    {
                        finalScore += 5;
                    }

                    if (unit.Type == 3)
                    {
                        finalScore += 10;
                    }
                }

                foreach (PictureBox city in playerCities)
                {
                    finalScore += 15;
                }

                finalScore += playerMoney;

                string username = GlobalVariables.usernameLoggedIn;
                int newScore = finalScore;

                SaveAndQuit(username, newScore);
                frmLeaderboard lead = new frmLeaderboard();
                lead.Show();
                this.Close();
            }
        }

        private void lblCity1_MouseEnter(object sender, EventArgs e) //Changes back colour of labels when the mouse hovers over them
        {
            if (playerCities.Contains(picCity1))
            {
                lblCity1.BackColor = Color.Gold;
            }
        }

        private void lblCity2_MouseEnter(object sender, EventArgs e)
        {
            if (playerCities.Contains(picCity2))
            {
                lblCity2.BackColor = Color.Gold;
            }
        }

        private void lblCity3_MouseEnter(object sender, EventArgs e)
        {
            if (playerCities.Contains(picCity3))
            {
                lblCity3.BackColor = Color.Gold;
            }
        }

        private void lblCity4_MouseEnter(object sender, EventArgs e)
        {
            if (playerCities.Contains(picCity4))
            {
                lblCity4.BackColor = Color.Gold;
            }
        }

        private void lblCity5_MouseEnter(object sender, EventArgs e)
        {
            if (playerCities.Contains(picCity5))
            {
                lblCity5.BackColor = Color.Gold;
            }
        }

        private void lblCity6_MouseEnter(object sender, EventArgs e)
        {
            if (playerCities.Contains(picCity6))
            {
                lblCity6.BackColor = Color.Gold;
            }
        }

        private void lblCity7_MouseEnter(object sender, EventArgs e)
        {
            if (playerCities.Contains(picCity7))
            {
                lblCity7.BackColor = Color.Gold;
            }
        }
        private void lblCity1_MouseLeave(object sender, EventArgs e)
        {
            lblCity1.BackColor = Color.Brown;
        }

        private void lblCity2_MouseLeave(object sender, EventArgs e)
        {
            lblCity2.BackColor = Color.Brown;
        }

        private void lblCity3_MouseLeave(object sender, EventArgs e)
        {
            lblCity3.BackColor = Color.Brown;
        }

        private void lblCity4_MouseLeave(object sender, EventArgs e)
        {
            lblCity4.BackColor = Color.Brown;
        }

        private void lblCity5_MouseLeave(object sender, EventArgs e)
        {
            lblCity5.BackColor = Color.Brown;
        }

        private void lblCity6_MouseLeave(object sender, EventArgs e)
        {
            lblCity6.BackColor = Color.Brown;
        }

        private void lblCity7_MouseLeave(object sender, EventArgs e)
        {
            lblCity7.BackColor = Color.Brown;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you sure you want to exit the game? All progress will be lost.", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            frmMainMenu main = new frmMainMenu();
            main.Show();
            this.Close();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            pnlCreateUnit.Visible = false;
        }

        private void lblCity1_Click(object sender, EventArgs e)
        {
            if (playerCities.Contains(picCity1))
            {
                pnlCreateUnit.Visible = true;
                pnlCreateUnit.BringToFront();
                citySelected = 1;
            }
        }

        private void lblCity2_Click(object sender, EventArgs e)
        {
            if (playerCities.Contains(picCity2))
            {
                pnlCreateUnit.Visible = true;
                pnlCreateUnit.BringToFront();
                citySelected = 2;
            }
        }

        private void lblCity3_Click(object sender, EventArgs e)
        {
            if (playerCities.Contains(picCity3))
            {
                pnlCreateUnit.Visible = true;
                pnlCreateUnit.BringToFront();
                citySelected = 2 + 1;
            }
        }

        private void lblCity4_Click(object sender, EventArgs e)
        {
            if (playerCities.Contains(picCity4))
            {
                pnlCreateUnit.Visible = true;
                pnlCreateUnit.BringToFront();
                citySelected = 4;
            }
        }

        private void lblCity5_Click(object sender, EventArgs e)
        {
            if (playerCities.Contains(picCity5))
            {
                pnlCreateUnit.Visible = true;
                pnlCreateUnit.BringToFront();
                citySelected = 5;
            }
        }

        private void lblCity6_Click(object sender, EventArgs e)
        {
            if (playerCities.Contains(picCity6))
            {
                pnlCreateUnit.Visible = true;
                pnlCreateUnit.BringToFront();
                citySelected = 6;
            }
        }

        private void lblCity7_Click(object sender, EventArgs e)
        {
            if (playerCities.Contains(picCity7))
            {
                pnlCreateUnit.Visible = true;
                pnlCreateUnit.BringToFront();
                citySelected = 7;
            }
        }

        private void btnCreateSol_Click(object sender, EventArgs e)
        {
            if (playerMoney >= 5)
            {
                Unit soldierN = new Unit(1, new Random(), 12, 200, 200, new PictureBox(), true);
                pUnits.Add(soldierN);
                PictureBox icon = new PictureBox();
                Controls.Add(icon);
                soldierN.Icon = icon;
                if (citySelected == 1)
                {
                    soldierN.Icon.Location = new Point(374, 488);
                }
                if (citySelected == 2)
                {
                    soldierN.Icon.Location = new Point(129, 401);
                }
                if (citySelected == 3)
                {
                    soldierN.Icon.Location = new Point(586, 379);
                }
                if (citySelected == 4)
                {
                    soldierN.Icon.Location = new Point(376, 251);
                }
                if (citySelected == 5)
                {
                    soldierN.Icon.Location = new Point(152, 181);
                }
                if (citySelected == 6)
                {
                    soldierN.Icon.Location = new Point(615, 136);
                }
                if (citySelected == 7)
                {
                    soldierN.Icon.Location = new Point(288, 8);
                }

                soldierN.Icon.TabStop = false;
                soldierN.Icon.SizeMode = PictureBoxSizeMode.StretchImage;
                soldierN.Icon.BorderStyle = BorderStyle.None;
                soldierN.Icon.Image = Properties.Resources.friendlysoldier;
                soldierN.Icon.Size = new Size(44, 54);
                soldierN.Icon.Visible = true;
                soldierN.Icon.BringToFront();
                soldierN.Icon.Click += SoldierClicked;
                soldierN.Icon.BackColor = Color.Transparent;
                pnlCreateUnit.BringToFront();
                pnlCreateUnit.Hide();

                playerMoney = playerMoney - 5;
                lblMoney.Text = playerMoney.ToString();
            }
        }

        private void SoldierClicked(object sender, EventArgs e)
        {
            if (btnMoveVisible == false)
            {
                btnMoveVisible = true;
                for (int i = 0; i < movement.Count; i++)
                {
                    PictureBox sol = sender as PictureBox;
                    Unit selUnit = new Unit(1, new Random(), 1, 1, 1, new PictureBox(), false);
                    foreach (Unit unit in pUnits)
                    {
                        if (unit.Icon == sol)
                        {
                            selUnit = unit;
                        }
                    }
                    selectedPicBox = sol;
                    Point btnLoc = movement[i].Location;
                    Point currentLoc = sol.Location;

                    if (Math.Sqrt(((currentLoc.X - btnLoc.X) * (currentLoc.X - btnLoc.X)) + (currentLoc.Y - btnLoc.Y) * (currentLoc.Y - btnLoc.Y)) <= selUnit.AttackRange)
                    {
                        movement[i].Visible = true;

                        for (int k = 0; k < eUnits.Count; k++)
                        {
                            if (btnLoc == new Point(eUnits[k].Icon.Location.X + 12, eUnits[k].Icon.Location.Y + 21))
                            {
                                movement[i].BringToFront();
                                movement[i].BackColor = Color.Yellow;
                                enemiesInRange.Add(eUnits[k].Icon);
                            }
                        }
                    }
                }
            }
            else
            {
                foreach (Button btn in movement)
                {
                    btn.Visible = false;
                }
                btnMoveVisible = false;
            }            

            if (pnlStats.Visible == false)
            {
                pnlStats.Visible = true;
                pnlStats.BringToFront();

                PictureBox pic = sender as PictureBox;
                selectedPicBox = pic;
                foreach (Unit unit in pUnits)
                {
                    if (pic == unit.Icon)
                    {
                        lblStatTitle.Text = "Soldier";
                        lblAttackStats.Text = "Attack: 2 - 10";
                        lblHealthStats.Text = "Health: " + unit.Health.ToString();
                        lblMoveStats.Text = "Movement: 2/Turn";
                        lblRangeStats.Text = "Range: 1";
                        picStat.Size = new Size(44, 54);
                        picStat.Image = Properties.Resources.friendlysoldier;
                    }                   
                }
            }
            else
            {
                pnlStats.Visible = false;
            }
        }
        
        private void ArtilleryClicked(object sender, EventArgs e)
        {
            if (btnMoveVisible == false)
            {
                for (int i = 0; i < movement.Count; i++)
                {
                    PictureBox sol = sender as PictureBox;
                    Unit selUnit = new Unit(1, new Random(), 1, 1, 1, new PictureBox(), false);
                    foreach (Unit unit in pUnits)
                    {
                        if (unit.Icon == sol)
                        {
                            selUnit = unit;
                        }
                    }
                    Point btnLoc = movement[i].Location;
                    Point currentLoc = sol.Location;

                    if (Math.Sqrt(((currentLoc.X - btnLoc.X) * (currentLoc.X - btnLoc.X)) + (currentLoc.Y - btnLoc.Y) * (currentLoc.Y - btnLoc.Y)) <= selUnit.MoveRange)
                    {
                        movement[i].Visible = true;
                    }

                    if (Math.Sqrt(((currentLoc.X - btnLoc.X) * (currentLoc.X - btnLoc.X)) + (currentLoc.Y - btnLoc.Y) * (currentLoc.Y - btnLoc.Y)) <= selUnit.AttackRange)
                    {
                        for (int k = 0; k < eUnits.Count; k++)
                        {                            
                            if (btnLoc == new Point(eUnits[k].Icon.Location.X + 12, eUnits[k].Icon.Location.Y + 21))
                            {
                                movement[i].BringToFront();
                                movement[i].BackColor = Color.Yellow;
                                enemiesInRange.Add(eUnits[k].Icon);
                                movement[i].Visible = true;
                            }
                        }
                    }
                }
            }
            else
            {
                foreach (Button btn in movement)
                {
                    btn.Visible = false;
                }
                btnMoveVisible = false;
            }

            if (pnlStats.Visible == false)
            {
                pnlStats.Visible = true;
                pnlStats.BringToFront();

                PictureBox pic = sender as PictureBox;
                selectedPicBox = pic;
                foreach(Unit unit in pUnits)
                {
                    if(unit.Icon == pic)
                    {
                        lblStatTitle.Text = "Artillery";
                        lblAttackStats.Text = "Attack: 2 - 12";
                        lblHealthStats.Text = "Health: " + unit.Health.ToString();
                        lblMoveStats.Text = "Movement: 1/Turn";
                        lblRangeStats.Text = "Range: 3";
                        picStat.Size = new Size(44, 54);
                        picStat.Image = Properties.Resources.friendlyartillery;
                    }
                }
            }
            else
            {
                pnlStats.Visible = false;
            }
        }

        private void TankClicked(object sender, EventArgs e)
        {
            if (btnMoveVisible == false)
            {
                for (int i = 0; i < movement.Count; i++)
                {
                    PictureBox sol = sender as PictureBox;
                    selectedPicBox = sol;
                    Point btnLoc = movement[i].Location;
                    Point currentLoc = sol.Location;

                    if (Math.Sqrt(((currentLoc.X - btnLoc.X) * (currentLoc.X - btnLoc.X)) + (currentLoc.Y - btnLoc.Y) * (currentLoc.Y - btnLoc.Y)) <= 275)
                    {
                        movement[i].Visible = true;
                    }

                    if (Math.Sqrt(((currentLoc.X - btnLoc.X) * (currentLoc.X - btnLoc.X)) + (currentLoc.Y - btnLoc.Y) * (currentLoc.Y - btnLoc.Y)) <= 275)
                    {
                        for (int k = 0; k < eUnits.Count; k++)
                        {
                            if (btnLoc == new Point(eUnits[k].Icon.Location.X + 12, eUnits[k].Icon.Location.Y + 21))
                            {
                                movement[i].BringToFront();
                                movement[i].BackColor = Color.Yellow;
                                enemiesInRange.Add(eUnits[k].Icon);
                                movement[i].Visible = true;
                            }
                        }
                    }
                }
                btnMoveVisible = true;
            }
            else
            {
                foreach (Button btn in movement)
                {
                    btn.Visible = false;                    
                }
                btnMoveVisible = false;
            }

            if (pnlStats.Visible == false)
            {
                pnlStats.Visible = true;
                pnlStats.BringToFront();
                PictureBox pic = new PictureBox();
                selectedPicBox = pic;

                foreach (Unit unit in pUnits)
                {
                    if (pic == unit.Icon)
                    {
                        lblStatTitle.Text = "Tank";
                        lblAttackStats.Text = "Attack: 2 - 15";
                        lblHealthStats.Text = "Health: " + unit.Health.ToString();
                        lblMoveStats.Text = "Movement: 2/Turn";
                        lblRangeStats.Text = "Range: 1";
                        picStat.Image = Properties.Resources.friendlytank;
                        picStat.Size = new Size(44, 54);
                    }
                }                    
            }
            else
            {
                pnlStats.Visible = false;
            }
        }

        private void btnCreateArt_Click(object sender, EventArgs e)
        {
            if (playerMoney >= 10)
            {
                Unit artilleryN = new Unit(2, new Random(), 10, 200, 300, new PictureBox(), true);
                pUnits.Add(artilleryN);
                PictureBox icon = new PictureBox();
                Controls.Add(icon);
                artilleryN.Icon = icon;
                if (citySelected == 1)
                {
                    artilleryN.Icon.Location = new Point(374, 488);
                }
                if (citySelected == 2)
                {
                    artilleryN.Icon.Location = new Point(129, 401);
                }
                if (citySelected == 3)
                {
                    artilleryN.Icon.Location = new Point(586, 379);
                }
                if (citySelected == 4)
                {
                    artilleryN.Icon.Location = new Point(376, 251);
                }
                if (citySelected == 5)
                {
                    artilleryN.Icon.Location = new Point(152, 181);
                }
                if (citySelected == 6)
                {
                    artilleryN.Icon.Location = new Point(615, 136);
                }
                if (citySelected == 7)
                {
                    artilleryN.Icon.Location = new Point(288, 8);
                }

                artilleryN.Icon.TabStop = false;
                artilleryN.Icon.SizeMode = PictureBoxSizeMode.StretchImage;
                artilleryN.Icon.BorderStyle = BorderStyle.None;
                artilleryN.Icon.Image = Properties.Resources.friendlyartillery;
                artilleryN.Icon.Size = new Size(44, 54);
                artilleryN.Icon.Visible = true;
                artilleryN.Icon.BringToFront();
                artilleryN.Icon.Click += ArtilleryClicked;
                artilleryN.Icon.BackColor = Color.Transparent;
                pnlCreateUnit.BringToFront();
                pnlCreateUnit.Hide();

                playerMoney = playerMoney - 10;
                lblMoney.Text = playerMoney.ToString();
            }
        }

        private void btnCreateTank_Click(object sender, EventArgs e)
        {
            if (playerMoney >= 20)
            {
                Unit tankN = new Unit(3, new Random(), 15, 275, 275, new PictureBox(), true);
                pUnits.Add(tankN);
                PictureBox icon = new PictureBox();
                Controls.Add(icon);
                tankN.Icon = icon;
                if (citySelected == 1)
                {
                    tankN.Icon.Location = new Point(374, 488);
                }
                if (citySelected == 2)
                {
                    tankN.Icon.Location = new Point(129, 401);
                }
                if (citySelected == 3)
                {
                    tankN.Icon.Location = new Point(586, 379);
                }
                if (citySelected == 4)
                {
                    tankN.Icon.Location = new Point(376, 251);
                }
                if (citySelected == 5)
                {
                    tankN.Icon.Location = new Point(152, 181);
                }
                if (citySelected == 6)
                {
                    tankN.Icon.Location = new Point(615, 136);
                }
                if (citySelected == 7)
                {
                    tankN.Icon.Location = new Point(288, 8);
                }

                tankN.Icon.TabStop = false;
                tankN.Icon.SizeMode = PictureBoxSizeMode.StretchImage;
                tankN.Icon.BorderStyle = BorderStyle.None;
                tankN.Icon.Image = Properties.Resources.friendlytank;
                tankN.Icon.Size = new Size(44, 54);
                tankN.Icon.Visible = true;
                tankN.Icon.BringToFront();
                tankN.Icon.Click += TankClicked;
                tankN.Icon.BackColor = Color.Transparent;
                pnlCreateUnit.BringToFront();
                pnlCreateUnit.Hide();

                playerMoney = playerMoney - 20;
                lblMoney.Text = playerMoney.ToString();
            }
        }

        private void btnProvince1_Click(object sender, EventArgs e)
        {
            if (btnProvince1.BackColor == Color.Lime)
            {
                foreach(Unit unit in pUnits)
                {
                    if((unit.Icon == selectedPicBox) && (unit.Moved == false))
                    {
                        selectedPicBox.Location = new Point(btnProvince1.Location.X - 9, btnProvince1.Location.Y - 19);
                        if (pnlStats.Visible == true)
                        {
                            pnlStats.Visible = false;
                        }
                        for (int i = 0; i < movement.Count; i++)
                        {
                            movement[i].Visible = false;
                        }
                        btnMoveVisible = false;
                        unit.Moved = true;
                    }
                }               
            }
            else
            {
                foreach(Unit unit in pUnits)
                {
                    if((unit.Icon == selectedPicBox) && (unit.Moved == false))
                    {
                        aUnit = unit;

                        foreach (EnemyUnit eUnit in eUnits)
                        {
                            if (eUnit.Icon.Location == new Point(btnProvince1.Location.X - 12, btnProvince1.Location.Y - 21))
                            {
                                tUnit = eUnit;
                            }
                        }
                        Attack(aUnit, tUnit);

                        if(tUnit.Health <= 0)
                        {                            
                            tUnit.Icon.Dispose();
                            eUnits.Remove(tUnit);
                            aUnit.Icon.Location = new Point(btnProvince1.Location.X - 9, btnProvince1.Location.Y - 19);
                            MessageBox.Show("Enemy unit defeated", "Success", MessageBoxButtons.OK);
                        }
                    }   
                }                           
            }
        }
        private void btnProvince2_Click(object sender, EventArgs e)
        {
            if (btnProvince2.BackColor == Color.Lime)
            {
                foreach (Unit unit in pUnits)
                {
                    if ((unit.Icon == selectedPicBox) && (unit.Moved == false))
                    {
                        selectedPicBox.Location = new Point(btnProvince2.Location.X - 9, btnProvince2.Location.Y - 19);
                        if (pnlStats.Visible == true)
                        {
                            pnlStats.Visible = false;
                        }
                        for (int i = 0; i < movement.Count; i++)
                        {
                            movement[i].Visible = false;
                        }
                        btnMoveVisible = false;
                        unit.Moved = true;
                    }
                }
            }
            else
            {
                foreach (Unit unit in pUnits)
                {
                    if ((unit.Icon == selectedPicBox) && (unit.Moved == false))
                    {
                        aUnit = unit;

                        foreach (EnemyUnit eUnit in eUnits)
                        {
                            if (eUnit.Icon.Location == new Point(btnProvince2.Location.X - 12, btnProvince2.Location.Y - 21))
                            {
                                tUnit = eUnit;
                            }
                        }
                        Attack(aUnit, tUnit);

                        if (tUnit.Health <= 0)
                        {
                            tUnit.Icon.Dispose();
                            eUnits.Remove(tUnit);
                            aUnit.Icon.Location = new Point(btnProvince2.Location.X - 9, btnProvince2.Location.Y - 19);
                            MessageBox.Show("Enemy unit defeated", "Success", MessageBoxButtons.OK);
                        }
                    }
                }
            }
        }

        private void btnProvince3_Click(object sender, EventArgs e)
        {
            if (btnProvince3.BackColor == Color.Lime)
            {
                foreach (Unit unit in pUnits)
                {
                    if ((unit.Icon == selectedPicBox) && (unit.Moved == false))
                    {
                        selectedPicBox.Location = new Point(btnProvince3.Location.X - 9, btnProvince3.Location.Y - 19);
                        if (pnlStats.Visible == true)
                        {
                            pnlStats.Visible = false;
                        }
                        for (int i = 0; i < movement.Count; i++)
                        {
                            movement[i].Visible = false;
                        }
                        btnMoveVisible = false;
                        unit.Moved = true;
                    }
                }
            }
            else
            {
                foreach (Unit unit in pUnits)
                {
                    if ((unit.Icon == selectedPicBox) && (unit.Moved == false))
                    {
                        aUnit = unit;

                        foreach (EnemyUnit eUnit in eUnits)
                        {
                            if (eUnit.Icon.Location == new Point(btnProvince3.Location.X - 12, btnProvince3.Location.Y - 21))
                            {
                                tUnit = eUnit;
                            }
                        }
                        Attack(aUnit, tUnit);

                        if (tUnit.Health <= 0)
                        {
                            tUnit.Icon.Dispose();
                            eUnits.Remove(tUnit);
                            aUnit.Icon.Location = new Point(btnProvince3.Location.X - 9, btnProvince3.Location.Y - 19);
                            MessageBox.Show("Enemy unit defeated", "Success", MessageBoxButtons.OK);
                        }
                    }
                }
            }
        }

        private void btnProvince4_Click(object sender, EventArgs e)
        {
            if (btnProvince4.BackColor == Color.Lime)
            {
                foreach (Unit unit in pUnits)
                {
                    if ((unit.Icon == selectedPicBox) && (unit.Moved == false))
                    {
                        selectedPicBox.Location = new Point(btnProvince4.Location.X - 9, btnProvince4.Location.Y - 19);
                        if (pnlStats.Visible == true)
                        {
                            pnlStats.Visible = false;
                        }
                        for (int i = 0; i < movement.Count; i++)
                        {
                            movement[i].Visible = false;
                        }
                        btnMoveVisible = false;
                        unit.Moved = true;
                    }
                }
            }
            else
            {
                foreach (Unit unit in pUnits)
                {
                    if ((unit.Icon == selectedPicBox) && (unit.Moved == false))
                    {
                        aUnit = unit;

                        foreach (EnemyUnit eUnit in eUnits)
                        {
                            if (eUnit.Icon.Location == new Point(btnProvince4.Location.X - 12, btnProvince4.Location.Y - 21))
                            {
                                tUnit = eUnit;
                            }
                        }
                        Attack(aUnit, tUnit);

                        if (tUnit.Health <= 0)
                        {
                            tUnit.Icon.Dispose();
                            eUnits.Remove(tUnit);
                            aUnit.Icon.Location = new Point(btnProvince4.Location.X - 9, btnProvince4.Location.Y - 19);
                            MessageBox.Show("Enemy unit defeated", "Success", MessageBoxButtons.OK);
                        }
                    }
                }
            }
        }

        private void btnProvince5_Click(object sender, EventArgs e)
        {
            if (btnProvince5.BackColor == Color.Lime)
            {
                foreach (Unit unit in pUnits)
                {
                    if ((unit.Icon == selectedPicBox) && (unit.Moved == false))
                    {
                        selectedPicBox.Location = new Point(btnProvince5.Location.X - 9, btnProvince5.Location.Y - 19);
                        if (pnlStats.Visible == true)
                        {
                            pnlStats.Visible = false;
                        }
                        for (int i = 0; i < movement.Count; i++)
                        {
                            movement[i].Visible = false;
                        }
                        btnMoveVisible = false;
                        unit.Moved = true;
                    }
                }
            }
            else
            {
                foreach (Unit unit in pUnits)
                {
                    if ((unit.Icon == selectedPicBox) && (unit.Moved == false))
                    {
                        aUnit = unit;

                        foreach (EnemyUnit eUnit in eUnits)
                        {
                            if (eUnit.Icon.Location == new Point(btnProvince5.Location.X - 12, btnProvince5.Location.Y - 21))
                            {
                                tUnit = eUnit;
                            }
                        }
                        Attack(aUnit, tUnit);

                        if (tUnit.Health <= 0)
                        {
                            tUnit.Icon.Dispose();
                            eUnits.Remove(tUnit);
                            aUnit.Icon.Location = new Point(btnProvince5.Location.X - 9, btnProvince5.Location.Y - 19);
                            MessageBox.Show("Enemy unit defeated", "Success", MessageBoxButtons.OK);
                        }
                    }
                }
            }
        }

        private void btnProvince6_Click(object sender, EventArgs e)
        {
            if (btnProvince6.BackColor == Color.Lime)
            {
                foreach (Unit unit in pUnits)
                {
                    if ((unit.Icon == selectedPicBox) && (unit.Moved == false))
                    {
                        selectedPicBox.Location = new Point(btnProvince6.Location.X - 9, btnProvince6.Location.Y - 19);
                        if (pnlStats.Visible == true)
                        {
                            pnlStats.Visible = false;
                        }
                        for (int i = 0; i < movement.Count; i++)
                        {
                            movement[i].Visible = false;
                        }
                        btnMoveVisible = false;
                        unit.Moved = true;
                    }
                }
            }
            else
            {
                foreach (Unit unit in pUnits)
                {
                    if ((unit.Icon == selectedPicBox) && (unit.Moved == false))
                    {
                        aUnit = unit;

                        foreach (EnemyUnit eUnit in eUnits)
                        {
                            if (eUnit.Icon.Location == new Point(btnProvince6.Location.X - 12, btnProvince6.Location.Y - 21))
                            {
                                tUnit = eUnit;
                            }
                        }
                        Attack(aUnit, tUnit);

                        if (tUnit.Health <= 0)
                        {
                            tUnit.Icon.Dispose();
                            eUnits.Remove(tUnit);
                            aUnit.Icon.Location = new Point(btnProvince6.Location.X - 9, btnProvince6.Location.Y - 19);
                            MessageBox.Show("Enemy unit defeated", "Success", MessageBoxButtons.OK);
                        }
                    }
                }
            }
        }

        private void btnProvince7_Click(object sender, EventArgs e)
        {
            if (btnProvince7.BackColor == Color.Lime)
            {
                foreach (Unit unit in pUnits)
                {
                    if ((unit.Icon == selectedPicBox) && (unit.Moved == false))
                    {
                        selectedPicBox.Location = new Point(btnProvince7.Location.X - 9, btnProvince7.Location.Y - 19);
                        if (pnlStats.Visible == true)
                        {
                            pnlStats.Visible = false;
                        }
                        for (int i = 0; i < movement.Count; i++)
                        {
                            movement[i].Visible = false;
                        }
                        btnMoveVisible = false;
                        unit.Moved = true;
                    }
                }
            }
            else
            {
                foreach (Unit unit in pUnits)
                {
                    if ((unit.Icon == selectedPicBox) && (unit.Moved == false))
                    {
                        aUnit = unit;

                        foreach (EnemyUnit eUnit in eUnits)
                        {
                            if (eUnit.Icon.Location == new Point(btnProvince7.Location.X - 12, btnProvince7.Location.Y - 21))
                            {
                                tUnit = eUnit;
                            }
                        }
                        Attack(aUnit, tUnit);

                        if (tUnit.Health <= 0)
                        {
                            tUnit.Icon.Dispose();
                            eUnits.Remove(tUnit);
                            aUnit.Icon.Location = new Point(btnProvince7.Location.X - 9, btnProvince7.Location.Y - 19);
                            MessageBox.Show("Enemy unit defeated", "Success", MessageBoxButtons.OK);
                        }
                    }
                }
            }
        }

        private void btnProvince8_Click(object sender, EventArgs e)
        {
            if (btnProvince8.BackColor == Color.Lime)
            {
                foreach (Unit unit in pUnits)
                {
                    if ((unit.Icon == selectedPicBox) && (unit.Moved == false))
                    {
                        selectedPicBox.Location = new Point(btnProvince8.Location.X - 9, btnProvince8.Location.Y - 19);
                        if (pnlStats.Visible == true)
                        {
                            pnlStats.Visible = false;
                        }
                        for (int i = 0; i < movement.Count; i++)
                        {
                            movement[i].Visible = false;
                        }
                        btnMoveVisible = false;
                        unit.Moved = true;
                    }
                }
            }
            else
            {
                foreach (Unit unit in pUnits)
                {
                    if ((unit.Icon == selectedPicBox) && (unit.Moved == false))
                    {
                        aUnit = unit;

                        foreach (EnemyUnit eUnit in eUnits)
                        {
                            if (eUnit.Icon.Location == new Point(btnProvince8.Location.X - 12, btnProvince8.Location.Y - 21))
                            {
                                tUnit = eUnit;
                            }
                        }
                        Attack(aUnit, tUnit);

                        if (tUnit.Health <= 0)
                        {
                            tUnit.Icon.Dispose();
                            eUnits.Remove(tUnit);
                            aUnit.Icon.Location = new Point(btnProvince8.Location.X - 9, btnProvince8.Location.Y - 19);
                            MessageBox.Show("Enemy unit defeated", "Success", MessageBoxButtons.OK);
                        }
                    }
                }
            }
        }

        private void btnProvince9_Click(object sender, EventArgs e)
        {
            if (btnProvince9.BackColor == Color.Lime)
            {
                foreach (Unit unit in pUnits)
                {
                    if ((unit.Icon == selectedPicBox) && (unit.Moved == false))
                    {
                        selectedPicBox.Location = new Point(btnProvince9.Location.X - 9, btnProvince9.Location.Y - 19);
                        if (pnlStats.Visible == true)
                        {
                            pnlStats.Visible = false;
                        }
                        for (int i = 0; i < movement.Count; i++)
                        {
                            movement[i].Visible = false;
                        }
                        btnMoveVisible = false;
                        unit.Moved = true;
                    }
                }
            }
            else
            {
                foreach (Unit unit in pUnits)
                {
                    if ((unit.Icon == selectedPicBox) && (unit.Moved == false))
                    {
                        aUnit = unit;

                        foreach (EnemyUnit eUnit in eUnits)
                        {
                            if (eUnit.Icon.Location == new Point(btnProvince9.Location.X - 12, btnProvince9.Location.Y - 21))
                            {
                                tUnit = eUnit;
                            }
                        }
                        Attack(aUnit, tUnit);

                        if (tUnit.Health <= 0)
                        {
                            tUnit.Icon.Dispose();
                            eUnits.Remove(tUnit);
                            aUnit.Icon.Location = new Point(btnProvince9.Location.X - 9, btnProvince9.Location.Y - 19);
                            MessageBox.Show("Enemy unit defeated", "Success", MessageBoxButtons.OK);
                        }
                    }
                }
            }
        }

        private void btnProvince10_Click(object sender, EventArgs e)
        {
            if (btnProvince10.BackColor == Color.Lime)
            {
                foreach (Unit unit in pUnits)
                {
                    if ((unit.Icon == selectedPicBox) && (unit.Moved == false))
                    {
                        selectedPicBox.Location = new Point(btnProvince10.Location.X - 9, btnProvince10.Location.Y - 19);
                        if (pnlStats.Visible == true)
                        {
                            pnlStats.Visible = false;
                        }
                        for (int i = 0; i < movement.Count; i++)
                        {
                            movement[i].Visible = false;
                        }
                        btnMoveVisible = false;
                        unit.Moved = true;
                    }
                }
            }
            else
            {
                foreach (Unit unit in pUnits)
                {
                    if ((unit.Icon == selectedPicBox) && (unit.Moved == false))
                    {
                        aUnit = unit;

                        foreach (EnemyUnit eUnit in eUnits)
                        {
                            if (eUnit.Icon.Location == new Point(btnProvince10.Location.X - 12, btnProvince10.Location.Y - 21))
                            {
                                tUnit = eUnit;
                            }
                        }
                        Attack(aUnit, tUnit);

                        if (tUnit.Health <= 0)
                        {
                            tUnit.Icon.Dispose();
                            eUnits.Remove(tUnit);
                            aUnit.Icon.Location = new Point(btnProvince10.Location.X - 9, btnProvince10.Location.Y - 19);
                            MessageBox.Show("Enemy unit defeated", "Success", MessageBoxButtons.OK);
                        }
                    }
                }
            }
        }

        private void btnProvince11_Click(object sender, EventArgs e)
        {
            if (btnProvince11.BackColor == Color.Lime)
            {
                foreach (Unit unit in pUnits)
                {
                    if ((unit.Icon == selectedPicBox) && (unit.Moved == false))
                    {
                        selectedPicBox.Location = new Point(btnProvince11.Location.X - 9, btnProvince11.Location.Y - 19);
                        if (pnlStats.Visible == true)
                        {
                            pnlStats.Visible = false;
                        }
                        for (int i = 0; i < movement.Count; i++)
                        {
                            movement[i].Visible = false;
                        }
                        btnMoveVisible = false;
                        unit.Moved = true;
                    }
                }
            }
            else
            {
                foreach (Unit unit in pUnits)
                {
                    if ((unit.Icon == selectedPicBox) && (unit.Moved == false))
                    {
                        aUnit = unit;

                        foreach (EnemyUnit eUnit in eUnits)
                        {
                            if (eUnit.Icon.Location == new Point(btnProvince11.Location.X - 12, btnProvince11.Location.Y - 21))
                            {
                                tUnit = eUnit;
                            }
                        }
                        Attack(aUnit, tUnit);

                        if (tUnit.Health <= 0)
                        {
                            tUnit.Icon.Dispose();
                            eUnits.Remove(tUnit);
                            aUnit.Icon.Location = new Point(btnProvince11.Location.X - 9, btnProvince11.Location.Y - 19);
                            MessageBox.Show("Enemy unit defeated", "Success", MessageBoxButtons.OK);
                        }
                    }
                }
            }
        }

        private void btnProvince12_Click(object sender, EventArgs e)
        {
            if (btnProvince12.BackColor == Color.Lime)
            {
                foreach (Unit unit in pUnits)
                {
                    if ((unit.Icon == selectedPicBox) && (unit.Moved == false))
                    {
                        selectedPicBox.Location = new Point(btnProvince12.Location.X - 9, btnProvince12.Location.Y - 19);
                        if (pnlStats.Visible == true)
                        {
                            pnlStats.Visible = false;
                        }
                        for (int i = 0; i < movement.Count; i++)
                        {
                            movement[i].Visible = false;
                        }
                        btnMoveVisible = false;
                        unit.Moved = true;
                    }
                }
            }
            else
            {
                foreach (Unit unit in pUnits)
                {
                    if ((unit.Icon == selectedPicBox) && (unit.Moved == false))
                    {
                        aUnit = unit;

                        foreach (EnemyUnit eUnit in eUnits)
                        {
                            if (eUnit.Icon.Location == new Point(btnProvince12.Location.X - 12, btnProvince12.Location.Y - 21))
                            {
                                tUnit = eUnit;
                            }
                        }
                        Attack(aUnit, tUnit);

                        if (tUnit.Health <= 0)
                        {
                            tUnit.Icon.Dispose();
                            eUnits.Remove(tUnit);
                            aUnit.Icon.Location = new Point(btnProvince12.Location.X - 9, btnProvince12.Location.Y - 19);
                            MessageBox.Show("Enemy unit defeated", "Success", MessageBoxButtons.OK);
                        }
                    }
                }
            }
        }

        private void btnProvince13_Click(object sender, EventArgs e)
        {
            if (btnProvince13.BackColor == Color.Lime)
            {
                foreach (Unit unit in pUnits)
                {
                    if ((unit.Icon == selectedPicBox) && (unit.Moved == false))
                    {
                        selectedPicBox.Location = new Point(btnProvince13.Location.X - 9, btnProvince13.Location.Y - 19);
                        if (pnlStats.Visible == true)
                        {
                            pnlStats.Visible = false;
                        }
                        for (int i = 0; i < movement.Count; i++)
                        {
                            movement[i].Visible = false;
                        }
                        btnMoveVisible = false;
                        unit.Moved = true;
                    }
                }
            }
            else
            {
                foreach (Unit unit in pUnits)
                {
                    if ((unit.Icon == selectedPicBox) && (unit.Moved == false))
                    {
                        aUnit = unit;

                        foreach (EnemyUnit eUnit in eUnits)
                        {
                            if (eUnit.Icon.Location == new Point(btnProvince13.Location.X - 12, btnProvince13.Location.Y - 21))
                            {
                                tUnit = eUnit;
                            }
                        }
                        Attack(aUnit, tUnit);

                        if (tUnit.Health <= 0)
                        {
                            tUnit.Icon.Dispose();
                            eUnits.Remove(tUnit);
                            aUnit.Icon.Location = new Point(btnProvince13.Location.X - 9, btnProvince13.Location.Y - 19);
                            MessageBox.Show("Enemy unit defeated", "Success", MessageBoxButtons.OK);
                        }
                    }
                }
            }
        }

        private void btnProvince14_Click(object sender, EventArgs e)
        {
            if (btnProvince14.BackColor == Color.Lime)
            {
                foreach (Unit unit in pUnits)
                {
                    if ((unit.Icon == selectedPicBox) && (unit.Moved == false))
                    {
                        selectedPicBox.Location = new Point(btnProvince14.Location.X - 9, btnProvince14.Location.Y - 19);
                        if (pnlStats.Visible == true)
                        {
                            pnlStats.Visible = false;
                        }
                        for (int i = 0; i < movement.Count; i++)
                        {
                            movement[i].Visible = false;
                        }
                        btnMoveVisible = false;
                        unit.Moved = true;
                    }
                }
            }
            else
            {
                foreach (Unit unit in pUnits)
                {
                    if ((unit.Icon == selectedPicBox) && (unit.Moved == false))
                    {
                        aUnit = unit;

                        foreach (EnemyUnit eUnit in eUnits)
                        {
                            if (eUnit.Icon.Location == new Point(btnProvince14.Location.X - 12, btnProvince14.Location.Y - 21))
                            {
                                tUnit = eUnit;
                            }
                        }
                        Attack(aUnit, tUnit);

                        if (tUnit.Health <= 0)
                        {
                            tUnit.Icon.Dispose();
                            eUnits.Remove(tUnit);
                            aUnit.Icon.Location = new Point(btnProvince14.Location.X - 9, btnProvince14.Location.Y - 19);
                            MessageBox.Show("Enemy unit defeated", "Success", MessageBoxButtons.OK);
                        }
                    }
                }
            }
        }

        private void btnProvince15_Click(object sender, EventArgs e)
        {
            if (btnProvince15.BackColor == Color.Lime)
            {
                foreach (Unit unit in pUnits)
                {
                    if ((unit.Icon == selectedPicBox) && (unit.Moved == false))
                    {
                        selectedPicBox.Location = new Point(btnProvince15.Location.X - 9, btnProvince15.Location.Y - 19);
                        if (pnlStats.Visible == true)
                        {
                            pnlStats.Visible = false;
                        }
                        for (int i = 0; i < movement.Count; i++)
                        {
                            movement[i].Visible = false;
                        }
                        btnMoveVisible = false;
                        unit.Moved = true;
                    }
                }
            }
            else
            {
                foreach (Unit unit in pUnits)
                {
                    if ((unit.Icon == selectedPicBox) && (unit.Moved == false))
                    {
                        aUnit = unit;

                        foreach (EnemyUnit eUnit in eUnits)
                        {
                            if (eUnit.Icon.Location == new Point(btnProvince15.Location.X - 12, btnProvince15.Location.Y - 21))
                            {
                                tUnit = eUnit;
                            }
                        }
                        Attack(aUnit, tUnit);

                        if (tUnit.Health <= 0)
                        {
                            tUnit.Icon.Dispose();
                            eUnits.Remove(tUnit);
                            aUnit.Icon.Location = new Point(btnProvince15.Location.X - 9, btnProvince15.Location.Y - 19);
                            MessageBox.Show("Enemy unit defeated", "Success", MessageBoxButtons.OK);
                        }
                    }
                }
            }
        }

        private void btnProvince16_Click(object sender, EventArgs e)
        {
            if (btnProvince16.BackColor == Color.Lime)
            {
                foreach (Unit unit in pUnits)
                {
                    if ((unit.Icon == selectedPicBox) && (unit.Moved == false))
                    {
                        selectedPicBox.Location = new Point(btnProvince16.Location.X - 9, btnProvince16.Location.Y - 19);
                        if (pnlStats.Visible == true)
                        {
                            pnlStats.Visible = false;
                        }
                        for (int i = 0; i < movement.Count; i++)
                        {
                            movement[i].Visible = false;
                        }
                        btnMoveVisible = false;
                        unit.Moved = true;
                    }
                }
            }
            else
            {
                foreach (Unit unit in pUnits)
                {
                    if ((unit.Icon == selectedPicBox) && (unit.Moved == false))
                    {
                        aUnit = unit;

                        foreach (EnemyUnit eUnit in eUnits)
                        {
                            if (eUnit.Icon.Location == new Point(btnProvince16.Location.X - 12, btnProvince16.Location.Y - 21))
                            {
                                tUnit = eUnit;
                            }
                        }
                        Attack(aUnit, tUnit);

                        if (tUnit.Health <= 0)
                        {
                            tUnit.Icon.Dispose();
                            eUnits.Remove(tUnit);
                            aUnit.Icon.Location = new Point(btnProvince16.Location.X - 9, btnProvince16.Location.Y - 19);
                            MessageBox.Show("Enemy unit defeated", "Success", MessageBoxButtons.OK);
                        }
                    }
                }
            }
        }

        private void btnProvince17_Click(object sender, EventArgs e)
        {
            if (btnProvince17.BackColor == Color.Lime)
            {
                foreach (Unit unit in pUnits)
                {
                    if ((unit.Icon == selectedPicBox) && (unit.Moved == false))
                    {
                        selectedPicBox.Location = new Point(btnProvince17.Location.X - 9, btnProvince17.Location.Y - 19);
                        if (pnlStats.Visible == true)
                        {
                            pnlStats.Visible = false;
                        }
                        for (int i = 0; i < movement.Count; i++)
                        {
                            movement[i].Visible = false;
                        }
                        btnMoveVisible = false;
                        unit.Moved = true;
                    }
                }
            }
            else
            {
                foreach (Unit unit in pUnits)
                {
                    if ((unit.Icon == selectedPicBox) && (unit.Moved == false))
                    {
                        aUnit = unit;

                        foreach (EnemyUnit eUnit in eUnits)
                        {
                            if (eUnit.Icon.Location == new Point(btnProvince17.Location.X - 12, btnProvince17.Location.Y - 21))
                            {
                                tUnit = eUnit;
                            }
                        }
                        Attack(aUnit, tUnit);

                        if (tUnit.Health <= 0)
                        {
                            tUnit.Icon.Dispose();
                            eUnits.Remove(tUnit);
                            aUnit.Icon.Location = new Point(btnProvince17.Location.X - 9, btnProvince17.Location.Y - 19);
                            MessageBox.Show("Enemy unit defeated", "Success", MessageBoxButtons.OK);
                        }
                    }
                }
            }
        }

        private void btnProvince18_Click(object sender, EventArgs e)
        {
            if (btnProvince18.BackColor == Color.Lime)
            {
                foreach (Unit unit in pUnits)
                {
                    if ((unit.Icon == selectedPicBox) && (unit.Moved == false))
                    {
                        selectedPicBox.Location = new Point(btnProvince18.Location.X - 9, btnProvince18.Location.Y - 19);
                        if (pnlStats.Visible == true)
                        {
                            pnlStats.Visible = false;
                        }
                        for (int i = 0; i < movement.Count; i++)
                        {
                            movement[i].Visible = false;
                        }
                        btnMoveVisible = false;
                        unit.Moved = true;
                    }
                }
            }
            else
            {
                foreach (Unit unit in pUnits)
                {
                    if ((unit.Icon == selectedPicBox) && (unit.Moved == false))
                    {
                        aUnit = unit;

                        foreach (EnemyUnit eUnit in eUnits)
                        {
                            if (eUnit.Icon.Location == new Point(btnProvince18.Location.X - 12, btnProvince18.Location.Y - 21))
                            {
                                tUnit = eUnit;
                            }
                        }
                        Attack(aUnit, tUnit);

                        if (tUnit.Health <= 0)
                        {
                            tUnit.Icon.Dispose();
                            eUnits.Remove(tUnit);
                            aUnit.Icon.Location = new Point(btnProvince18.Location.X - 9, btnProvince18.Location.Y - 19);
                            MessageBox.Show("Enemy unit defeated", "Success", MessageBoxButtons.OK);
                        }
                    }
                }
            }
        }

        private void btnProvince19_Click(object sender, EventArgs e)
        {
            if (btnProvince19.BackColor == Color.Lime)
            {
                foreach (Unit unit in pUnits)
                {
                    if ((unit.Icon == selectedPicBox) && (unit.Moved == false))
                    {
                        selectedPicBox.Location = new Point(btnProvince19.Location.X - 9, btnProvince19.Location.Y - 19);
                        if (pnlStats.Visible == true)
                        {
                            pnlStats.Visible = false;
                        }
                        for (int i = 0; i < movement.Count; i++)
                        {
                            movement[i].Visible = false;
                        }
                        btnMoveVisible = false;
                        unit.Moved = true;
                    }
                }
            }
            else
            {
                foreach (Unit unit in pUnits)
                {
                    if ((unit.Icon == selectedPicBox) && (unit.Moved == false))
                    {
                        aUnit = unit;

                        foreach (EnemyUnit eUnit in eUnits)
                        {
                            if (eUnit.Icon.Location == new Point(btnProvince19.Location.X - 12, btnProvince19.Location.Y - 21))
                            {
                                tUnit = eUnit;
                            }
                        }
                        Attack(aUnit, tUnit);
                    }
                }
            }
        }

        private void SaveAndQuit(string username, int newScore)
        {
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Username could not be found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            List<Player> players = new List<Player>();

            if (File.Exists(GlobalVariables.binaryFilePath))
            {
                try
                {
                    using (FileStream stream = new FileStream(GlobalVariables.binaryFilePath, FileMode.Open))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        players = (List<Player>) formatter.Deserialize(stream);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("An error occured loading player data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Player data not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Player playerToUpdate = players.Find(player => player.GetUsername() == GlobalVariables.usernameLoggedIn);

            playerToUpdate.SetLastScore(newScore);

            if (newScore > playerToUpdate.GetHighScore())
            {
                playerToUpdate.SetHighScore(newScore);
            }

            try
            {
                using (FileStream stream = new FileStream(GlobalVariables.binaryFilePath, FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, players);
                }
                MessageBox.Show("Score updated!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("An error occured while saving your score", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCloseStats_Click(object sender, EventArgs e)
        {
            pnlStats.Visible = false;
        }

        private void EnemyClicked(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            int unitType = 0;
            if (pnlStats.Visible == false)
            {
                pnlStats.Visible = true;
                foreach (EnemyUnit eUnit in eUnits)
                {
                    if (eUnit.Icon == pic)
                    {
                        unitType = eUnit.Type;
                        enemyHP = eUnit.Health;
                    }
                }

                switch (unitType)
                {
                    case 1:
                        picStat.Image = Properties.Resources.enemysoldier;
                        picStat.Size = new Size(50, 50);
                        lblStatTitle.Text = "Soldier";
                        lblAttackStats.Text = "Attack: 2 - 10";
                        lblHealthStats.Text = "Health: " + enemyHP.ToString();
                        lblMoveStats.Text = "Movement: 2/Turn";
                        lblRangeStats.Text = "Range: 1";
                        break;
                    case 2:
                        lblStatTitle.Text = "Atillery";
                        lblAttackStats.Text = "Attack: 2 - 12";
                        lblHealthStats.Text = "Health: " + enemyHP.ToString();
                        lblMoveStats.Text = "Movement: 1/Turn";
                        lblRangeStats.Text = "Range: 3";
                        picStat.Size = new Size(50, 50);
                        picStat.Image = Properties.Resources.enemyartillery;
                        break;
                    case 3:
                        lblStatTitle.Text = "Tank";
                        lblAttackStats.Text = "Attack: 2 - 15";
                        lblHealthStats.Text = "Health: " + enemyHP.ToString();
                        lblMoveStats.Text = "Movement: 2/Turn";
                        lblRangeStats.Text = "Range: 1";
                        picStat.Image = Properties.Resources.enemytank;
                        picStat.Size = new Size(50, 50);
                        break;
                }
            }
            else
            {
                pnlStats.Visible = false;
            }
        }

        private void Attack(Unit attackingUnit, Unit targettedUnit)
        {
            switch (attackingUnit.Type)
            {
                case 1:
                    damageDealt = attackingUnit.Attack.Next(2, 11);
                    targettedUnit.Health = targettedUnit.Health - damageDealt;

                    switch (targettedUnit.Type)
                    {
                        case 1:
                            damageTaken = def.Next(1, 6);
                            if (damageTaken >= damageDealt)
                            {
                                for (int i = damageTaken; i >= damageDealt; i--)
                                {
                                    damageTaken = i;
                                }
                            }
                            attackingUnit.Health = attackingUnit.Health - damageTaken;

                            if (attackingUnit.Health <= 0)
                            {
                                attackingUnit.Icon.Dispose();
                                aUnit = null;
                                MessageBox.Show("A unit has been deafeated!", "Battle result", MessageBoxButtons.OK);
                            }
                            else if (targettedUnit.Health <= 0)
                            {
                                targettedUnit.Icon.Dispose();
                                tUnit = null;
                                attackingUnit.Icon.Location = new Point(btnProvince19.Location.X - 9, btnProvince19.Location.Y - 19);
                                MessageBox.Show("A unit has been deafeated!", "Battle result", MessageBoxButtons.OK);
                            }
                            break;

                        case 2:
                            damageTaken = def.Next(1, 7);
                            if (damageTaken >= damageDealt)
                            {
                                for (int i = damageTaken; i >= damageDealt; i--)
                                {
                                    damageTaken = i;
                                }
                            }
                            attackingUnit.Health = attackingUnit.Health - damageTaken;

                            if (attackingUnit.Health <= 0)
                            {
                                attackingUnit.Icon.Dispose();
                                aUnit = null;
                                MessageBox.Show("A unit has been deafeated!", "Battle result", MessageBoxButtons.OK);
                            }
                            else if (targettedUnit.Health <= 0)
                            {
                                targettedUnit.Icon.Dispose();
                                tUnit = null;
                                attackingUnit.Icon.Location = new Point(btnProvince19.Location.X - 9, btnProvince19.Location.Y - 19);
                                MessageBox.Show("A unit has been deafeated!", "Battle result", MessageBoxButtons.OK);
                            }
                            break;

                        case 3:
                            damageTaken = def.Next(1, 9);
                            if (damageTaken >= damageDealt)
                            {
                                for (int i = damageTaken; i >= damageDealt; i--)
                                {
                                    damageTaken = i;
                                }
                            }
                            attackingUnit.Health = attackingUnit.Health - damageTaken;

                            if (attackingUnit.Health <= 0)
                            {
                                attackingUnit.Icon.Dispose();
                                aUnit = null;
                                MessageBox.Show("A unit has been deafeated!", "Battle result", MessageBoxButtons.OK);
                            }
                            else if (targettedUnit.Health <= 0)
                            {
                                targettedUnit.Icon.Dispose();
                                tUnit = null;
                                attackingUnit.Icon.Location = new Point(btnProvince19.Location.X - 9, btnProvince19.Location.Y - 19);
                                MessageBox.Show("A unit has been deafeated!", "Battle result", MessageBoxButtons.OK);
                            }
                            break;
                    }
                    break;

                case 2:
                    targettedUnit.Health = targettedUnit.Health - attackingUnit.Attack.Next(2, 13);

                    if (attackingUnit.Health <= 0)
                    {
                        attackingUnit.Icon.Dispose();
                        aUnit = null;
                        MessageBox.Show("A unit has been deafeated!", "Battle result", MessageBoxButtons.OK);
                    }
                    else if (targettedUnit.Health <= 0)
                    {
                        targettedUnit.Icon.Dispose();
                        tUnit = null;
                        attackingUnit.Icon.Location = new Point(btnProvince19.Location.X - 9, btnProvince19.Location.Y - 19);
                        MessageBox.Show("A unit has been deafeated!", "Battle result", MessageBoxButtons.OK);
                    }
                    break;
                case 3:

                    targettedUnit.Health = targettedUnit.Health - attackingUnit.Attack.Next(2, 16);
                    switch (targettedUnit.Type)
                    {
                        case 1:
                            damageTaken = def.Next(1, 6);
                            if (damageTaken >= damageDealt)
                            {
                                for (int i = damageTaken; i >= damageDealt; i--)
                                {
                                    damageTaken = i;
                                }
                            }
                            attackingUnit.Health = attackingUnit.Health - damageTaken;

                            if (attackingUnit.Health <= 0)
                            {
                                attackingUnit.Icon.Dispose();
                                aUnit = null;
                                MessageBox.Show("A unit has been deafeated!", "Battle result", MessageBoxButtons.OK);
                            }
                            else if (targettedUnit.Health <= 0)
                            {
                                targettedUnit.Icon.Dispose();
                                tUnit = null;
                                attackingUnit.Icon.Location = new Point(btnProvince19.Location.X - 9, btnProvince19.Location.Y - 19);
                                MessageBox.Show("A unit has been deafeated!", "Battle result", MessageBoxButtons.OK);
                            }
                            break;

                        case 2:
                            damageTaken = def.Next(1, 7);
                            if (damageTaken >= damageDealt)
                            {
                                for (int i = damageTaken; i >= damageDealt; i--)
                                {
                                    damageTaken = i;
                                }
                            }
                            attackingUnit.Health = attackingUnit.Health - damageTaken;

                            if (attackingUnit.Health <= 0)
                            {
                                attackingUnit.Icon.Dispose();
                                aUnit = null;
                                MessageBox.Show("A unit has been deafeated!", "Battle result", MessageBoxButtons.OK);
                            }
                            else if (targettedUnit.Health <= 0)
                            {
                                targettedUnit.Icon.Dispose();
                                tUnit = null;
                                attackingUnit.Icon.Location = new Point(btnProvince19.Location.X - 9, btnProvince19.Location.Y - 19);
                                MessageBox.Show("A unit has been deafeated!", "Battle result", MessageBoxButtons.OK);
                            }
                            break;

                        case 3:
                            damageTaken = def.Next(1, 9);
                            if (damageTaken >= damageDealt)
                            {
                                for (int i = damageTaken; i >= damageDealt; i--)
                                {
                                    damageTaken = i;
                                }
                            }
                            attackingUnit.Health = attackingUnit.Health - damageTaken;

                            if (attackingUnit.Health <= 0)
                            {
                                attackingUnit.Icon.Dispose();
                                aUnit = null;
                                MessageBox.Show("A unit has been deafeated!", "Battle result", MessageBoxButtons.OK);
                            }
                            else if (targettedUnit.Health <= 0)
                            {
                                targettedUnit.Icon.Dispose();
                                tUnit = null;
                                attackingUnit.Icon.Location = new Point(btnProvince19.Location.X - 9, btnProvince19.Location.Y - 19);
                                MessageBox.Show("A unit has been deafeated!", "Battle result", MessageBoxButtons.OK);
                            }
                            break;
                    }
                    break;
            }

            foreach(Button btn in movement)
            {
                btn.BackColor = Color.Lime;
                btn.Visible = false;
            }
        }

        private void FindTarget(EnemyUnit eUnit)
        {
            cpuRan = cpuPathRan.Next(1, pUnits.Count + cities.Count + 1);
            if(cpuRan <= 7)
            {
                switch (cpuRan)
                {
                    case 1:
                        eUnit.Target = new Point(btnProvince2.Location.X - 12, btnProvince2.Location.Y - 21);
                        eUnit.TargetType = 'C';
                        break;
                    case 2:
                        eUnit.Target = new Point(btnProvince4.Location.X - 12, btnProvince4.Location.Y - 21);
                        eUnit.TargetType = 'C';
                        break;
                    case 3:
                        eUnit.Target = new Point(btnProvince7.Location.X - 12, btnProvince7.Location.Y - 21);
                        eUnit.TargetType = 'C';
                        break;
                    case 4:
                        eUnit.Target = new Point(btnProvince10.Location.X - 12, btnProvince10.Location.Y - 21);
                        eUnit.TargetType = 'C';
                        break;
                    case 5:
                        eUnit.Target = new Point(btnProvince12.Location.X - 12, btnProvince12.Location.Y - 21);
                        eUnit.TargetType = 'C';
                        break;
                    case 6:
                        eUnit.Target = new Point(btnProvince16.Location.X - 12, btnProvince16.Location.Y - 21);
                        eUnit.TargetType = 'C';
                        break;
                    case 7:
                        eUnit.Target = new Point(btnProvince17.Location.X - 12, btnProvince17.Location.Y - 21);
                        eUnit.TargetType = 'C';
                        break;
                }
            }                
        }

        private Point FindPath(Point currentLoc, Point targetLoc, EnemyUnit eUnit)
        {
            Point closestLoc = new Point(5000, 5000);
            possibleEnemyMovement.Clear();
            for (int i = 0; i < movement.Count; i++)
            {
                Point btns = movement[i].Location;

                if (Math.Sqrt(((currentLoc.X - btns.X) * (currentLoc.X - btns.X)) + (currentLoc.Y - btns.Y) * (currentLoc.Y - btns.Y)) <= eUnit.MoveRange)
                {
                    possibleEnemyMovement.Add(new Point(btns.X - 12, btns.Y - 21));
                }
            }

            foreach(Point loc in possibleEnemyMovement)
            {
                if (Math.Sqrt((loc.X - targetLoc.X)*(loc.X - targetLoc.X) + (loc.Y - targetLoc.Y)*(loc.Y - targetLoc.Y)) < (Math.Sqrt(closestLoc.X - targetLoc.X)*(closestLoc.X - targetLoc.X) + (closestLoc.Y - targetLoc.Y)*(closestLoc.Y - targetLoc.Y)))
                {
                    closestLoc = loc;
                }                
            }

            return closestLoc;
        }

        public void CPUSpawn()
        {
            Random typeRan = new Random();
            Random cityRan = new Random();
            Random spawnRan = new Random();
            Point loc = new Point();

            int type = 0;
            int city = cityRan.Next(1, enemyCities.Count + 1);
            int chance = spawnRan.Next(1, 101);
            
            if (chance <= 60)
            {
                if ((cpuMoney >= 5) && (cpuMoney < 10))
                {
                    type = 1;
                }
                else if ((cpuMoney >= 10) && (cpuMoney < 20))
                {
                    type = typeRan.Next(1, 3);
                }
                else if (cpuMoney >= 20)
                {
                    type = typeRan.Next(1, 4);
                }
                else
                {
                    type = 0;
                }

                switch (enemyCities[city - 1].Name)
                {
                    case "picCity1":
                        loc = new Point(btnProvince2.Location.X - 12, btnProvince2.Location.Y - 21);
                        break;

                    case "picCity2":
                        loc = new Point(btnProvince4.Location.X - 12, btnProvince4.Location.Y - 21);
                        break;

                    case "picCity3":
                        loc = new Point(btnProvince7.Location.X - 12, btnProvince7.Location.Y - 21);
                        break;

                    case "picCity4":
                        loc = new Point(btnProvince10.Location.X - 12, btnProvince10.Location.Y - 21);
                        break;

                    case "picCity5":
                        loc = new Point(btnProvince12.Location.X - 12, btnProvince12.Location.Y - 21);
                        break;

                    case "picCity6":
                        loc = new Point(btnProvince16.Location.X - 12, btnProvince16.Location.Y - 21);
                        break;

                    case "picCity7":
                        loc = new Point(btnProvince17.Location.X - 12, btnProvince17.Location.Y - 21);
                        break;
                }

                switch (type)
                {
                    case 1:
                        EnemyUnit eSoldierN = new EnemyUnit(1, new Random(), 12, 200, 200, new PictureBox(), true, new Point(3000, 3000), 'A', 1000);
                        eUnits.Add(eSoldierN);
                        PictureBox icon1 = new PictureBox();
                        Controls.Add(icon1);
                        eSoldierN.Icon = icon1;
                        eSoldierN.Icon.Location = loc;
                        eSoldierN.Icon.TabStop = false;
                        eSoldierN.Icon.SizeMode = PictureBoxSizeMode.StretchImage;
                        eSoldierN.Icon.BorderStyle = BorderStyle.None;
                        eSoldierN.Icon.Image = Properties.Resources.enemysoldier;
                        eSoldierN.Icon.Size = new Size(50, 50);
                        eSoldierN.Icon.Visible = true;
                        eSoldierN.Icon.BringToFront();
                        eSoldierN.Icon.BackColor = Color.Transparent;
                        eSoldierN.Icon.Click += EnemyClicked;

                        cpuMoney = cpuMoney - 5;
                        break;

                    case 2:
                        EnemyUnit eSoldierI = new EnemyUnit(2, new Random(), 12, 200, 300, new PictureBox(), true, new Point(3000, 3000), 'A', 1000);
                        eUnits.Add(eSoldierI);
                        PictureBox icon2 = new PictureBox();
                        Controls.Add(icon2);
                        eSoldierI.Icon = icon2;
                        eSoldierI.Icon.Location = loc;
                        eSoldierI.Icon.TabStop = false;
                        eSoldierI.Icon.SizeMode = PictureBoxSizeMode.StretchImage;
                        eSoldierI.Icon.BorderStyle = BorderStyle.None;
                        eSoldierI.Icon.Image = Properties.Resources.enemyartillery;
                        eSoldierI.Icon.Size = new Size(50, 50);
                        eSoldierI.Icon.Visible = true;
                        eSoldierI.Icon.BringToFront();
                        eSoldierI.Icon.BackColor = Color.Transparent;
                        eSoldierI.Icon.Click += EnemyClicked;

                        cpuMoney = cpuMoney - 10;
                        break;

                    case 3:
                        EnemyUnit eSoldierJ = new EnemyUnit(3, new Random(), 15, 300, 200, new PictureBox(), true, new Point(3000, 3000), 'A', 1000);
                        eUnits.Add(eSoldierJ);
                        PictureBox icon3 = new PictureBox();
                        Controls.Add(icon3);
                        eSoldierJ.Icon = icon3;
                        eSoldierJ.Icon.Location = loc;
                        eSoldierJ.Icon.TabStop = false;
                        eSoldierJ.Icon.SizeMode = PictureBoxSizeMode.StretchImage;
                        eSoldierJ.Icon.BorderStyle = BorderStyle.None;
                        eSoldierJ.Icon.Image = Properties.Resources.enemytank;
                        eSoldierJ.Icon.Size = new Size(50, 50);
                        eSoldierJ.Icon.Visible = true;
                        eSoldierJ.Icon.BringToFront();
                        eSoldierJ.Icon.BackColor = Color.Transparent;
                        eSoldierJ.Icon.Click += EnemyClicked;

                        cpuMoney = cpuMoney - 20;
                        break;
                }
            }
            else
            {

            }
        }
    }
}