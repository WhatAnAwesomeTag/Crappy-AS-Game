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
    public partial class frmQuizQuestions : Form
    {
        public bool answerCorrect { get; private set; }
        public string[,] questionAndAnswer;

        public int numOfQuestionsInTxt;

        Random ran = new Random();
        HashSet<int> numbers = new HashSet<int>();

        string correctAns;
        string givenAns;

        int qNumToAsk;

        int questionsAsked;

        int questionsCorrect;
        public frmQuizQuestions()
        {
            try
            {
                int linecount = File.ReadAllLines(GlobalVariables.QuestionsAndAnswersFilePath).Length;
                numOfQuestionsInTxt = linecount / 2;
                questionAndAnswer = new string[numOfQuestionsInTxt, 2];
            }
            catch (Exception)
            {
                MessageBox.Show("Error reading number of lines in QuizQuestions.txt", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            InitializeComponent();
            ReadInQuestionsAndAnswers();
            GetQuestion();
        }

        public void ReadInQuestionsAndAnswers()
        {
            try
            {
                using (StreamReader reader = new StreamReader(GlobalVariables.QuestionsAndAnswersFilePath))
                {
                    int count = 0;
                    while (!reader.EndOfStream)
                    {
                        string question = reader.ReadLine();
                        string answer = reader.ReadLine();

                        questionAndAnswer[count, 0] = question;
                        questionAndAnswer[count, 1] = answer;

                        count++;
                    }
                    reader.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error reading number of lines in QuizQuestions.txt", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public int FindRandomNumber()
        {
            int ranNumGen;
            ranNumGen = ran.Next(0, numOfQuestionsInTxt);

            while (numbers.Contains(ranNumGen))
            {
                ranNumGen = ran.Next(0, numOfQuestionsInTxt);
            }
            numbers.Add(ranNumGen);
            return ranNumGen;
        }

        public void GetQuestion()
        {
            qNumToAsk = FindRandomNumber();
            txtQuestion.Text = questionAndAnswer[qNumToAsk, 0];
            correctAns = questionAndAnswer[qNumToAsk, 1];
            questionsAsked++;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            givenAns = txtAnswer.Text;
            txtAnswer.Clear();

            if (givenAns == correctAns)
            {
                MessageBox.Show("Correct answer", "Well done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                answerCorrect = true;
                questionsCorrect++; ;
            }
            else if (givenAns.Length == 0)
            {
                MessageBox.Show("No answer entered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Incorrect answer", "Sorry!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            if (questionsAsked < 3)
            {
                GetQuestion();
            }
            else
            {
                this.Close();
                frmGame game = new frmGame();
                game.Show();
            }                     
        }

        private void frmQuizQuestions_FormClosing(object sender, FormClosingEventArgs e)
        {
            GlobalVariables.moneyFromQuiz = questionsCorrect * 3;
        }
    }
}
