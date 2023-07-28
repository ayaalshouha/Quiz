using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quiz
{
    public partial class QuestionsForms : Form
    {
        private int remainingTime = 0;
        private const int totalTime = 300;
        private int score = 0;
        private int QuestionIndex = 0;

        public QuestionsForms()
        {
            InitializeComponent();

            pictureBoxCompleted.Hide();
            lblQuizFinished.Hide();
            lblFinalScore.Hide();
            btnClose.Hide();
            
            remainingTime = totalTime;
            lblTimer.Text = $"{GetFormattedTime(remainingTime)}";
            timer1.Enabled = true;
            timer1.Tick += timer1_Tick;
            DisplayQuestion();
        }

        void ShowResult()
        {
            timer1.Enabled = false;
            lblTimer.Hide();
            lblQuestion.Hide();
            lblQuestionText.Hide();
            button1.Hide();
            button2.Hide();
            button3.Hide();
            button4.Hide();
            button5.Hide();
            pictureBoxCompleted.Show();
            lblQuizFinished.Show();
            lblFinalScore.Text += score + "/5.";
            lblFinalScore.Show();
            btnClose.Show();

            

        }

        private string[] Questions =
        {
            "What is the result of 25 + 17 ?",
            "Solve for x: 3x + 7 = 22 ?",
            "Calculate the area of a rectangle with " +
                "length 8 units and width 5 units.",
            "Evaluate the expression: (12 ÷ 3) × (5 + 2) ?",
            "Find the square root of 144"
        };

        private string[] Answers =
        {
            "42",
            "x = 5",
            "40 square units",
            "28",
            "12"
        };

        private void SetOptions()
        {
            button2.BackColor = Color.Khaki;
            button3.BackColor = Color.Khaki;
            button5.BackColor = Color.Khaki;
            button4.BackColor = Color.Khaki;

            switch (QuestionIndex)
            {
                case 0:
                    button2.Text = "40";
                    button3.Text = "45";
                    button4.Text = "42";
                    button5.Text = "56";
                    break;
                case 1:
                    button2.Text = "x = 5";
                    button3.Text = "x = 4";
                    button4.Text = "x = 10";
                    button5.Text = "x = 15";
                    break;
                case 2:
                    button2.Text = "55 square units";
                    button3.Text = "35 square units";
                    button4.Text = "40 square units";
                    button5.Text = "120 square units";
                    break;
                case 3:
                    button2.Text = "55";
                    button3.Text = "28";
                    button4.Text = "48";
                    button5.Text = "200";
                    break;
                case 4:
                    button2.Text = "55";
                    button3.Text = "12";
                    button5.Text = "10";
                    button4.Text = "14";
                    break;
            }
        }

        private void CheckAnswer()
        {
            if (button2.Text == Answers[QuestionIndex]
                && button2.BackColor == Color.Yellow)
            {
                score++;
            }
            else if (button3.Text == Answers[QuestionIndex]
                && button3.BackColor == Color.Yellow)
            {
                score++;
            }
            else if (button4.Text == Answers[QuestionIndex]
                && button4.BackColor == Color.Yellow)
            {
                score++;
            }
            else if (button5.Text == Answers[QuestionIndex]
                && button5.BackColor == Color.Yellow)
            {
                score++;
            }
            else
                return; 
        }

        private void DisplayQuestion()
        {
            lblQuestion.Text = "Question(" + (QuestionIndex + 1).ToString() + "/5)."; 
            lblQuestionText.Text = Questions[QuestionIndex];
            SetOptions();
        }


        private string GetFormattedTime(int Secs)
        {
            TimeSpan time = TimeSpan.FromSeconds(Secs);

            return time.ToString("mm':'ss"); 
        }

        private void FinishQuiz()
        {
            ShowResult(); 
        }

       

        private void QuestionsForms_Load(object sender, EventArgs e)
        {
               

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Submit Answer?", "Confirm",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) == DialogResult.OK)
            {
                CheckAnswer();
                QuestionIndex++;

                if (QuestionIndex < 5)
                {
                    DisplayQuestion();
                }
                else
                {
                    FinishQuiz();

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(button3.BackColor == Color.Yellow)
            {
                return; 
            }

            if(button2.BackColor == Color.Yellow 
                || button4.BackColor == Color.Yellow 
                || button5.BackColor == Color.Yellow)
            {
                button2.BackColor = Color.Khaki;
                button4.BackColor = Color.Khaki;
                button5.BackColor = Color.Khaki;
            }

            button3.BackColor = Color.Yellow;
             
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.BackColor == Color.Yellow)
            {
                return;
            }

            if (button2.BackColor == Color.Yellow
                || button4.BackColor == Color.Yellow
                || button3.BackColor == Color.Yellow)
            {
                button2.BackColor = Color.Khaki;
                button4.BackColor = Color.Khaki;
                button3.BackColor = Color.Khaki;
            }

            button5.BackColor = Color.Yellow;
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.BackColor == Color.Yellow)
            {
                return;
            }

            if (button3.BackColor == Color.Yellow
                || button4.BackColor == Color.Yellow
                || button5.BackColor == Color.Yellow)
            {
                button5.BackColor = Color.Khaki;
                button4.BackColor = Color.Khaki;
                button3.BackColor = Color.Khaki;
            }

            button2.BackColor = Color.Yellow;
          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.BackColor == Color.Yellow)
            {
                return;
            }

            if ( button2.BackColor == Color.Yellow
                || button5.BackColor == Color.Yellow
                || button3.BackColor == Color.Yellow)
            {
                button2.BackColor = Color.Khaki;
                button5.BackColor = Color.Khaki;
                button3.BackColor = Color.Khaki;
            }

            button4.BackColor = Color.Yellow;
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            remainingTime--;
            lblTimer.Text = $"{GetFormattedTime(remainingTime)}";

            if (remainingTime <= 60)
            {
                lblTimer.ForeColor = Color.Red; 
            }
            if (remainingTime <= 0)
            {
                timer1.Enabled = false;
                if (MessageBox.Show("Time's Up!", "Out of Session",
                     MessageBoxButtons.OK, MessageBoxIcon.Stop) == DialogResult.OK)
                {
                    FinishQuiz();
                } 
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
