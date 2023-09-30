using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rpong
{
    public partial class ChangeStyle : Form
    {
        public ChangeStyle()
        {
            InitializeComponent();
        }

        private void blueBall_Click(object sender, EventArgs e)
        {
            string appDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string imagePath = Path.Combine(appDirectory, "assets", "blue_reticul.jpg");
            (this.Owner as R6pong).pongBall.Image = Image.FromFile(imagePath);
            (this.Owner as R6pong).pongBall.SizeMode = PictureBoxSizeMode.StretchImage;
            (this.Owner as R6pong).pongTimer.Start();
            this.Hide();
        }


        private void yellowBall_Click(object sender, EventArgs e)
        {
            string appDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string imagePath = Path.Combine(appDirectory, "assets", "yellow_reticul.jpg");
            (this.Owner as R6pong).pongBall.Image = Image.FromFile(imagePath);
            (this.Owner as R6pong).pongBall.SizeMode = PictureBoxSizeMode.StretchImage;
            (this.Owner as R6pong).pongTimer.Start();
            this.Hide();
        }

        private void greenBall_Click(object sender, EventArgs e)
        {
            string appDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string imagePath = Path.Combine(appDirectory, "assets", "green_reticul.jpg");
            (this.Owner as R6pong).pongBall.Image = Image.FromFile(imagePath);
            (this.Owner as R6pong).pongBall.SizeMode = PictureBoxSizeMode.StretchImage;
            (this.Owner as R6pong).pongTimer.Start();
            this.Hide();
        }

        private void whiteBall_Click(object sender, EventArgs e)
        {
            string appDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string imagePath = Path.Combine(appDirectory, "assets", "white_reticul.jpg");
            (this.Owner as R6pong).pongBall.Image = Image.FromFile(imagePath);
            (this.Owner as R6pong).pongBall.SizeMode = PictureBoxSizeMode.StretchImage;
            (this.Owner as R6pong).pongTimer.Start();
            this.Hide();
        }

        private void purpleBall_Click(object sender, EventArgs e)
        {
            string appDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string imagePath = Path.Combine(appDirectory, "assets", "purple_reticul.jpg");
            (this.Owner as R6pong).pongBall.Image = Image.FromFile(imagePath);
            (this.Owner as R6pong).pongBall.SizeMode = PictureBoxSizeMode.StretchImage;
            (this.Owner as R6pong).pongTimer.Start();
            this.Hide();
        }

        private void solisChar_Click(object sender, EventArgs e)
        {
            string appDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string imagePath = Path.Combine(appDirectory, "assets", "solis_pong.png");
            (this.Owner as R6pong).player1.Image = Image.FromFile(imagePath);
            (this.Owner as R6pong).player1.SizeMode = PictureBoxSizeMode.StretchImage;
            (this.Owner as R6pong).pongTimer.Start();
            this.Hide();
        }

        private void grimChar_Click(object sender, EventArgs e)
        {
            string appDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string imagePath = Path.Combine(appDirectory, "assets", "grim_pong.png");
            (this.Owner as R6pong).player1.Image = Image.FromFile(imagePath);
            (this.Owner as R6pong).player1.SizeMode = PictureBoxSizeMode.StretchImage;
            (this.Owner as R6pong).pongTimer.Start();
            this.Hide();
        }

        private void floresChar_Click(object sender, EventArgs e)
        {
            string appDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string imagePath = Path.Combine(appDirectory, "assets", "flores_pong.png");
            (this.Owner as R6pong).player1.Image = Image.FromFile(imagePath);
            (this.Owner as R6pong).player1.SizeMode = PictureBoxSizeMode.StretchImage;
            (this.Owner as R6pong).pongTimer.Start();
            this.Hide();
        }

        private void docChar_Click(object sender, EventArgs e)
        {
            string appDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string imagePath = Path.Combine(appDirectory, "assets", "doc_pong.png");
            (this.Owner as R6pong).player1.Image = Image.FromFile(imagePath);
            (this.Owner as R6pong).player1.SizeMode = PictureBoxSizeMode.StretchImage;
            (this.Owner as R6pong).pongTimer.Start();
            this.Hide();
        }
    }
}
