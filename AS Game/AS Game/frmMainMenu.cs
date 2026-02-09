using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AS_Game
{
    public partial class frmMainMenu : Form
    {
        public frmMainMenu()
        {
            InitializeComponent();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            frmLogin log = new frmLogin();
            log.Show();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            frmPreGame pre = new frmPreGame();
            pre.Show();
            this.Close();
        }

        private void btnLead_Click(object sender, EventArgs e)
        {
            frmLeaderboard lead = new frmLeaderboard();
            lead.Show();
            this.Close();
        }

        private void howToPlayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlHelp.Visible = true;
            pnlHelp.Location = new Point(171, 32);
            try
            {
                using (StreamReader reader = new StreamReader(GlobalVariables.helpFilePath))
                {
                    string text = reader.ReadToEnd();
                    txtHelp.Text = text;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred when attempting to read from the text file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            pnlHelp.Visible = false;
        }
    }
}
