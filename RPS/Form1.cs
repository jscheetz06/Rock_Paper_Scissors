using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPS
{
    public partial class Form1 : Form
    {

        int rounds = 3;
        int timerPerRound = 6;
        bool gameOver = false;

        string[] CPUchoiceList = { "rock", "paper", "scissors", "rock", "paper", "scissors" };

        int randomNumber = 0;

        Random rnd = new Random();

        string CPUChoice;

        string playerChoice;

        int playerScore;
        int CPUScore;



        public Form1()
        {
            InitializeComponent();

            countDownTimer.Enabled = true;

            playerChoice = "none";

            txtCountDown.Text = "5";

        }

        private void btnRock_Click(object sender, EventArgs e)
        {
            picPlayer.Image = Properties.Resources.rock;
            playerChoice = "rock";
        }

        private void btnPaper_Click(object sender, EventArgs e)
        {
            picPlayer.Image = Properties.Resources.paper;
            playerChoice = "paper";
        }

        private void btnScissors_Click(object sender, EventArgs e)
        {
            picPlayer.Image = Properties.Resources.scissors;
            playerChoice = "scissors";
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            playerScore = 0;
            CPUScore = 0;
            rounds = 3;
            txtScore.Text = "Player: " + playerScore + " - CPU: " + CPUScore;

            playerChoice = "none";

            countDownTimer.Enabled = true;

            picPlayer.Image = Properties.Resources.q;
            picCPU.Image = Properties.Resources.q;

            gameOver = false;

        }

        private void countDownTimerEvent(object sender, EventArgs e)
        {
            timerPerRound -= 1;

            txtCountDown.Text = timerPerRound.ToString();

            txtRounds.Text = "Rounds: " + rounds;

            if (timerPerRound < 1)
            {
                countDownTimer.Enabled = false;

                timerPerRound = 6;

                randomNumber = rnd.Next(0, CPUchoiceList.Length);

                CPUChoice = CPUchoiceList[randomNumber];

                switch (CPUChoice)
                {
                    case "rock":
                        picCPU.Image = Properties.Resources.rock;
                        break;

                    case "paper":

                        picCPU.Image = Properties.Resources.paper;
                        break;

                    case "scissors":

                        picCPU.Image = Properties.Resources.scissors;
                        break;

                }

                if (rounds > 0)
                {
                    checkGame();
                }
                else
                {
                    if (playerScore > CPUScore)
                    {
                        MessageBox.Show("Congrats Dude, ya won!!");
                    }
                    else
                    {
                        MessageBox.Show("CPU won.. you are a loser!");
                    }

                    gameOver = true;
                }

            }



        }

        private void checkGame()
        {
            if (playerChoice == "rock" && CPUChoice == "paper")
            {

                CPUScore += 1;

                rounds -= 1;

                MessageBox.Show("Oh Snap CPU just beat yo butt becuase paper covers rock, yo!!");
            }
            else if (playerChoice == "scissors" && CPUChoice == "rock")
            {

                CPUScore += 1;

                rounds -= 1;

                MessageBox.Show("Oh Snap CPU just beat yo butt becuase that rock crushed your scissors, yo!!");
            }

            else if (playerChoice == "paper" && CPUChoice == "scissors")
            {

                CPUScore += 1;

                rounds -= 1;

                MessageBox.Show("Oh Snap CPU just beat yo butt becuase your paper got sliced up by the scissors , yo!!");
            }
            else if (playerChoice == "rock" && CPUChoice == "scissors")
            {

                playerScore += 1;

                rounds -= 1;

                MessageBox.Show("Nice move my dude, you just crushed those scissors up dawg.");
            }

            else if (playerChoice == "scissors" && CPUChoice == "paper")
            {

                playerScore += 1;

                rounds -= 1;

                MessageBox.Show("Nice move my dude, you just torn that paper to shreds.");
            }

            else if (playerChoice == "paper" && CPUChoice == "rock")
            {

                playerScore += 1;

                rounds -= 1;

                MessageBox.Show("Nice move my dude, you just covered that rock like a lil punk.");
            }
            else if (playerChoice == "none")
            {
                MessageBox.Show("Make a choice buddy!");
            }
            else
            {
                MessageBox.Show("Draw!");

            }

            startNextRound();
        }


        private void startNextRound()
        {
            if (gameOver == true)
            {
                return;
            }

            txtScore.Text = "Player: " + playerScore + " - " + "CPU: "  + CPUScore;

            playerChoice = "none";

            countDownTimer.Enabled = true;

            picPlayer.Image = Properties.Resources.q;
            picCPU.Image = Properties.Resources.q;

        }

    }
}

