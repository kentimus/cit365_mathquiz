using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathQuiz
{
    public partial class Form1 : Form
    {
        // creating a Random object to generate random numbers
        Random randomizer = new Random();

        // for the addition problem
        int addend1, addend2;

        // for the subtraction problem
        int minuend, subtrahend;

        // for multiplation and division
        int multiplicand, multiplier, dividend, divisor;

        // keeps track of time left on the timer
        int timeLeft;

        /// <summary>
        /// Start the quiz by filling in all of the problems and start the timer
        /// </summary>
        public void StartTheQuiz()
        {
            // Get two random numbers for the the addition problem
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            // convert random numbers to strings and add to form labels
            plusLeftLabel.Text  = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            // start 'sum' value at zero
            sum.Value = 0;

            // fill in the subtraction problem
            minuend              = randomizer.Next(1, 101);
            subtrahend           = randomizer.Next(1, minuend);
            minusLeftLabel.Text  = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value     = 0;

            // fill in the multiplaction problem
            multiplicand         = randomizer.Next(2, 11);
            multiplier           = randomizer.Next(2, 11);
            timesLeftLabel.Text  = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value        = 0;

            // fill in division problem
            divisor                = randomizer.Next(2, 11);
            int temporaryQuotient  = randomizer.Next(2, 11);
            dividend               = divisor * temporaryQuotient;
            dividedLeftLabel.Text  = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;

            // start the timer
            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();
            timeLabel.ForeColor = Color.White;
        }

        

        private void StartButton_Click_1(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string todaysDate = DateTime.Now.ToString("dd MMMM yyyy");
            datePlaceholderLabel.Text = todaysDate;
        }

        private void DatePlaceholderLabel_Click(object sender, EventArgs e)
        {

        }

        public Form1()
        {
            InitializeComponent();
        }

        

        private void Timer1_Tick(object sender, EventArgs e)
        {
            

            if (CheckTheAnswer())
            {
                // stop timer if all answers are correct and show a MessageBox
                timer1.Stop();
                MessageBox.Show("You got all the answers right!", "Congratulations!");
                startButton.Enabled = true;
            }
            else if(timeLeft > 0)
            {
                // update the timer label
                timeLeft -= 1;
                timeLabel.Text = timeLeft + " seconds";

                if (timeLeft <= 5)
                {
                    timeLabel.ForeColor = Color.Red;
                }
            }
            else
            {
                // user ran out of time, so stop timer, show a MessageBox, and fill in answers
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
            }
        }

        /// <summary>
        /// Check the answer to see if the user got everything right
        /// </summary>
        /// <returns>True is answer is correct, false if answer is wrong</returns>
        private bool CheckTheAnswer()
        {
            bool everythingCorrect = true;

            if (addend1 + addend2 == sum.Value)
            {
                sum.BackColor = Color.Yellow;
            }
            else
            {
                sum.BackColor = Color.White;
                everythingCorrect = false;
            }

            if (minuend - subtrahend == difference.Value)
            {
                difference.BackColor = Color.Yellow;
            }
            else
            {
                difference.BackColor = Color.White;
                everythingCorrect = false;
            }

            if(multiplicand * multiplier == product.Value)
            {
                product.BackColor = Color.Yellow;
            }
            else
            {
                product.BackColor = Color.White;
                everythingCorrect = false;
            }

            if(dividend / divisor == quotient.Value)
            {
                quotient.BackColor = Color.Yellow;
            }
            else
            {
                quotient.BackColor = Color.White;
                everythingCorrect = false;
            }


            return everythingCorrect;
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            // select the whole answer in the NumericUpDown control
            NumericUpDown answerBox = sender as NumericUpDown;

            if(answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
    }
}
