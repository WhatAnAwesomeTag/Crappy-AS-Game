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
    public partial class frmLeaderboard : Form
    {
        public frmLeaderboard()
        {
            InitializeComponent();
        }

        public void PopulateLeaderboard(ListView listViewLeaderboard)
        {
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
                catch (Exception)
                {
                    MessageBox.Show("An error occured loading player data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            players.Sort(new PlayerScoreCompare());
            listViewLeaderboard.Items.Clear();

            foreach (Player player in players)
            {
                ListViewItem item = new ListViewItem(player.GetAbbrev());
                item.SubItems.Add(player.GetHighScore().ToString());
                listViewLeaderboard.Items.Add(item);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmMainMenu main = new frmMainMenu();
            main.Show();
            this.Hide();
        }

        private void frmLeaderboard_Load(object sender, EventArgs e)
        {
            PopulateLeaderboard(listViewLeaderboard);
        }
    }

    public class PlayerScoreCompare : IComparer<Player>
    {
        public int Compare(Player x, Player y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            return y.GetHighScore().CompareTo(x.GetHighScore());
        }
    }
}
