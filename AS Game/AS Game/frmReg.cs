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
    public partial class frmReg : Form
    {
        public frmReg()
        {
            InitializeComponent();
        }

        bool abrCaps;

        private void btnBack_Click(object sender, EventArgs e) // Goes back to login form
        {
            frmLogin log = new frmLogin();
            this.Close();
            log.Show();
        }

        private void btnClear_Click(object sender, EventArgs e) // Clears all textboxes
        {
            txtUser.Clear();
            txtPass.Clear();
            txtAbbrev.Clear();
            txtCon.Clear();
        }

        private void btnShow_Click(object sender, EventArgs e) // Switches passwordchar between "●" and plain text
        {
            if (txtPass.PasswordChar == '●' && txtCon.PasswordChar == '●')
            {
                txtPass.PasswordChar = '\0';
                txtCon.PasswordChar = '\0';
            }
            else
            {
                txtPass.PasswordChar = '●';
                txtCon.PasswordChar = '●';
            }
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            string abr = txtAbbrev.Text;            // Validates all data

            if ((txtUser.Text.Length <= 20) & (txtUser.Text.Length >= 5))
            {
                if (txtPass.Text.Length >= 8)
                {
                    if (txtCon.Text == txtPass.Text)
                    {
                        for (int i = 0; i < abr.Length; i++)
                        {
                            if (!Char.IsUpper(txtAbbrev.Text[i]))
                            {
                                abrCaps = false;
                            }
                            else
                            {
                                abrCaps = true;
                            }
                        }
                        
                        if ((abrCaps == true) & (abr.Length == 3))
                        {
                            try
                            {
                                string newUser = txtUser.Text;
                                string newPass = txtPass.Text;

                                List<Player> players = new List<Player>();
                                if (File.Exists(GlobalVariables.binaryFilePath))
                                {
                                    try
                                    {
                                        using (FileStream stream = new FileStream(GlobalVariables.binaryFilePath, FileMode.Open))
                                        {
                                            BinaryFormatter formatter = new BinaryFormatter();
                                            players = (List<Player>)formatter.Deserialize(stream);
                                        }
                                    }
                                    catch (Exception exception)
                                    {
                                        MessageBox.Show("There has been an error \n" + exception.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }

                                foreach (Player player in players)
                                {
                                    if(player.GetUsername() == newUser)
                                    {
                                        txtUser.Clear();
                                        throw new CustomExceptions.UserAlreadyExistsException(newUser);
                                    }
                                }

                                Player newPlayer = new Player(newUser, newPass, txtAbbrev.Text, 0, 0);
                                players.Add(newPlayer);

                                try
                                {
                                    using (FileStream stream = new FileStream(GlobalVariables.binaryFilePath, FileMode.Create))
                                    {
                                        BinaryFormatter formatter = new BinaryFormatter();
                                        formatter.Serialize(stream, players);
                                    }
                                    MessageBox.Show("Registration successful, good luck " + newUser + "!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    frmLogin login = new frmLogin();
                                    login.Show();
                                }
                                catch (Exception exce)
                                {
                                    MessageBox.Show(exce.Message, "An error occurred while saving player data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            catch (CustomExceptions.UserAlreadyExistsException exc)
                            {
                                MessageBox.Show(exc.Message, "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            catch (Exception exception2)
                            {
                                MessageBox.Show("There has been an error \n " + exception2.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please ensure all characters in your abbreviation are upper case and it is exactly 3 characters long", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtAbbrev.Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please ensure your passwords match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPass.Clear();
                        txtCon.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Please ensure your password is more than 8 characters in length", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPass.Clear();
                    txtCon.Clear();
                }
            }
            else
            {
                MessageBox.Show("Please ensure your username in between 5 and 20 characters in length", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUser.Clear();
            }
        }
    }
}
