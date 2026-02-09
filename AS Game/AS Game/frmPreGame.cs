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
    public partial class frmPreGame : Form
    {
        public frmPreGame()
        {
            InitializeComponent();
        }

        private void btnCont_Click(object sender, EventArgs e)
        {
            frmQuizQuestions quiz = new frmQuizQuestions();
            quiz.Show();
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmMainMenu main = new frmMainMenu();
            main.Show();
            this.Close();
        }

        private void frmPreGame_Load(object sender, EventArgs e)
        {
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
    }
}
