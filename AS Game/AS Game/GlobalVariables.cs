using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS_Game
{
    class GlobalVariables
    {
        public static List<Player> PlayerList = new List<Player>();

        public static string QuestionsAndAnswersFilePath = @"../../Questions.txt";
        public static string binaryFilePath = @"../../UserInfo.bin";
        public static string helpFilePath = @"../../Help.txt";
        public static int moneyFromQuiz;

        public static string usernameLoggedIn;
    }
}
