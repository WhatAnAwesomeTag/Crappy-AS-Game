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
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace AS_Game
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            frmReg reg = new frmReg();
            reg.Show();
            this.Close();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (txtPass.PasswordChar == '●')
            {
                txtPass.PasswordChar = '\0';
            }
            else
            {
                txtPass.PasswordChar = '●';
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPass.Clear();
            txtUser.Clear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string enteredUser = txtUser.Text;
            string enteredPass = txtPass.Text;

            if (File.Exists(GlobalVariables.binaryFilePath))
            {
                try
                {
                    using (FileStream stream = new FileStream(GlobalVariables.binaryFilePath, FileMode.Open))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        List<Player> players = (List<Player>)formatter.Deserialize(stream);

                        foreach (Player player in players)
                        {
                            if (player.GetUsername() == enteredUser && player.GetPassword() == enteredPass)
                            {
                                MessageBox.Show("Login successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                GlobalVariables.usernameLoggedIn = enteredUser;
                                frmMainMenu menu = new frmMainMenu();
                                menu.Show();
                                this.Close();
                            }
                            else
                            {
                                txtUser.Clear();
                                txtPass.Clear();
                                lblIncorrect.Visible = true;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There has been an error \n " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Could not find UserInfo.bin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
