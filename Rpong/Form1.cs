using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rpong
{
    public partial class R6pong : Form
    {
        //Location Variables
        int cpuDirection = 10;
        int ballXCoordinate = 8;
        int ballYCoordinate = 8;
        //Score Variables
        int playerScore = 0;
        int cpuScore = 0;
        //Size Variables
        int bottomBoundary;
        int centerPoint;
        int xMidPoint;
        int yMidPoint;
        //Detection Variables
        bool playerIsUp;
        bool playerIsDown;
        bool player2IsUp;
        bool player2IsDown;
        bool cpuControlsEnabled = true;
        bool hasCollided;
        //Spécial Keys
        int spaceBarClicked = 0;


        public R6pong()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            bottomBoundary = ClientSize.Height - player1.Height;
            xMidPoint = ClientSize.Width / 2;
            yMidPoint = ClientSize.Height / 2;
        }

        private void R6pong_Load(object sender, EventArgs e)
        {

        }

        private void pongTimer_Tick(object sender, EventArgs e)
        {
            Random newBallSpot = new Random();
            int newSpot = newBallSpot.Next(100, ClientSize.Height - 100);

            //Adjust where the ball is
            pongBall.Top -= ballYCoordinate;
            pongBall.Left -= ballXCoordinate;

            //Make CPU move
            if (cpuControlsEnabled)
            {
                cpuPlayer.Top -= cpuDirection;
            }
            else
            {
                //CPU controlled manualy
                if (player2IsUp == true && cpuPlayer.Top > 0) { cpuPlayer.Top -= 10; }
                if (player2IsDown == true && cpuPlayer.Top < bottomBoundary) { cpuPlayer.Top += 10; }
            }

            //CPU move better
            if (playerScore > 8)
            {
                int newTop = pongBall.Top - (cpuPlayer.Height / 2);

                //Make sure that the paddle does not go out from the top
                newTop = Math.Max(newTop, 0);

                //Make sure that the paddle does not go out from the bottom 
                newTop = Math.Min(newTop, this.ClientSize.Height - cpuPlayer.Height);

                cpuPlayer.Top = newTop;
            }

            //Check if cpu has reached top or bottom
            if (cpuPlayer.Top < 0 || cpuPlayer.Top > bottomBoundary ) { cpuDirection = -cpuDirection; }
            
            //Check if CPU scored
            if (pongBall.Left < 0)
            {
                pongBall.Left = xMidPoint;
                pongBall.Top = newSpot;
                ballXCoordinate = -ballXCoordinate;
                if (playerScore < 5) { ballXCoordinate -= 1; }
                cpuScore++;
                cpuScoreLabel.Text = cpuScore.ToString();
            }
            
            //Check if Player scored
            if (pongBall.Left + pongBall.Width > ClientSize.Width)
            {
                pongBall.Left = xMidPoint;
                pongBall.Top = newSpot;
                ballXCoordinate = -ballXCoordinate;
                if (playerScore < 5) { ballXCoordinate += 1; }
                playerScore++;
                playerScoreLabel.Text = playerScore.ToString();
            }

            //Make sure the ball stay in the screen
            if (pongBall.Top < 0 || pongBall.Top + pongBall.Height > ClientSize.Height) { ballYCoordinate = -ballYCoordinate; }

            //Check if the ball hits one of the paddles
            if (pongBall.Bounds.IntersectsWith(player1.Bounds) || pongBall.Bounds.IntersectsWith(cpuPlayer.Bounds))
            {
                if (!hasCollided)
                {
                    //Send the ball in opposite direction
                    ballXCoordinate = -ballXCoordinate;

                    //Mark the ball as "has collided"
                    hasCollided = true;
                }
            }
            else
            {
                //If the ball is not in collision, reset the collision mark
                hasCollided = false;
            }

            //Move player Up
            if (playerIsUp == true && player1.Top > 0) { player1.Top -= 10;}
            //Move player Down
            if (playerIsDown == true && player1.Top < bottomBoundary) { player1.Top += 10;}

            //Check for winner
            if (playerScore >= 10 || cpuScore >= 10)
            {
                pongTimer.Stop();
            }
        }

        private void R6pong_KeyUp(object sender, KeyEventArgs e)
        {
            //If up arrow is pressed, move paddle upwards
            if (e.KeyCode == Keys.Z) { playerIsUp = false; }
            //If down arrow is pressed, move paddle downwards
            if (e.KeyCode == Keys.S) { playerIsDown = false; }

            if (e.KeyCode == Keys.Up) { player2IsUp = false; }
            if (e.KeyCode == Keys.Down) { player2IsDown = false; }
        }

        private void R6pong_KeyDown(object sender, KeyEventArgs e)
        {
            //If up arrow is pressed, move paddle upwards
            if (e.KeyCode == Keys.Z) { playerIsUp = true; }
            //If down arrow is pressed, move paddle downwards
            if (e.KeyCode == Keys.S) { playerIsDown = true; }

            if (e.KeyCode == Keys.Up && !cpuControlsEnabled) { player2IsUp = true; }
            if (e.KeyCode == Keys.Down && !cpuControlsEnabled) { player2IsDown = true; }

            //Switch between solo or multiplayer
            if (e.KeyCode == Keys.M)
            {
                cpuControlsEnabled = !cpuControlsEnabled;
            }

            //If player press C key, open the Change Style window
            if (e.KeyCode == Keys.C)
            {
                Form change = new ChangeStyle();
                change.Owner = this;
                pongTimer.Stop();
                change.Show();
            }

            //If space bar is pressed, pause the game
            if (e.KeyCode == Keys.Space)
            {
                if (spaceBarClicked % 2 == 0)
                {
                    pongTimer.Stop();
                }
                else
                {
                    pongTimer.Start();
                }
            }
            spaceBarClicked++;

            //If player press R key, restart the game from 0
            if (e.KeyCode == Keys.R)
            {
                //Reinitialize the game and stop the timer
                playerScore = 0;
                cpuScore = 0;
                playerScoreLabel.Text = "0";
                cpuScoreLabel.Text = "0";
                pongTimer.Stop();

                //Set the ball and the paddles to default position
                pongBall.Left = xMidPoint;
                pongBall.Top = yMidPoint;
                player1.Top = yMidPoint - player1.Height / 2;
                cpuPlayer.Top = yMidPoint - cpuPlayer.Height / 2;

                //Restart the timer
                pongTimer.Start();
            }

            // Si le score atteint 10 et la touche "Entrée" est enfoncée
            if (playerScore >= 10 || cpuScore >= 10)
            {
                pongTimer.Stop();
                if (e.KeyCode == Keys.Enter)
                {
                    // Réinitialisez les scores et l'arrêtez le timer
                    playerScore = 0;
                    cpuScore = 0;
                    playerScoreLabel.Text = "0";
                    cpuScoreLabel.Text = "0";

                    // Remettez la balle et les paddles à leurs positions initiales
                    pongBall.Left = xMidPoint;
                    pongBall.Top = yMidPoint;
                    player1.Top = yMidPoint - player1.Height / 2;
                    cpuPlayer.Top = yMidPoint - cpuPlayer.Height / 2;

                    // Redémarrez le timer
                    pongTimer.Start();
                }
            }

            //If Escape key is pressed
            if (e.KeyCode == Keys.Escape)
            {
                //Close the Game
                this.Close();
            }
        }
    }
}
