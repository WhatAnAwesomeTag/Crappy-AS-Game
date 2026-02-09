using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS_Game
{
    [Serializable]
    public class Player
    {
        private string username;
        private string password;
        private string abbrev;
        private int lastScore;
        private int highScore;

        public string GetUsername()
        {
            return username;
        }

        public void SetUsername(string username)
        {
            this.username = username;
        }

        public string GetPassword()
        {
            return password;
        }

        public void SetPassword(string password)
        {
            this.password = password;
        }

        public string GetAbbrev()
        {
            return abbrev;
        }

        public void SetAbbrev(string abbrev)
        {
            this.abbrev = abbrev;
        }

        public int GetLastScore()
        {
            return lastScore;
        }

        public void SetLastScore(int lastScore)
        {
            this.lastScore = lastScore;
        }

        public int GetHighScore()
        {
            return highScore;
        }

        public void SetHighScore(int highScore)
        {
            this.highScore = highScore;
        }

        public Player(string username, string password, string abbrev, int lastScore, int highScore)
        {
            this.username = username;
            this.password = password;
            this.abbrev = abbrev;
            this.lastScore = lastScore;
            this.lastScore = highScore;
        }

        public Player(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }
}
