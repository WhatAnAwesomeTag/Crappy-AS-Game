using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AS_Game
{
    public partial class frmSplashScreen : Form
    {
        public frmSplashScreen()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random ran = new Random();
            int num = ran.Next(1, 15);
            pnlLoading.Width += num;
            if (pnlLoading.Width >= 753)
            {                
                frmLogin login = new frmLogin();
                timer1.Stop();
                login.Show();
                this.Hide();
            }
        }
    }

}
