using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Project1
{

    public partial class Boss : Form
    {
        bool goLeft, goRight, goUp, goDown, gameOver;
        string facing = "up";   //player faces up by default 
        int playerHealth = 100;
        int speed = 10;
        int ammo = 8;
        int bossSpeed = 10;
        List<PictureBox> enemiesList = new List<PictureBox>();
        List<PictureBox> items = new List<PictureBox>();
        Random randomNum = new Random();
        SoundPlayer sound = new SoundPlayer();
        public Boss()
        {
            InitializeComponent();
            Bosses();
        }

        private void Boss_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }
        private void MainTimerEvent(object sender, EventArgs e)
        {

            if (playerHealth >= 0)
            {
                healthBar.Value = playerHealth;
                lblPlayerHealth.Text = ($"{playerHealth} / 100");

            }
            if (playerHealth == 25 || playerHealth == 5)
            {
                Health();
            }

            if (playerHealth <= 1)
            {
                gameOver = true;
                player.Image = Properties.Resources.dead;
                GameTimer.Stop();
                
            }
            txtAmmo.Text = "Ammo " + ammo;

            if (goLeft == true && player.Left > 0)
            {
                player.Left -= speed;
            }
            if (goRight == true && player.Left + player.Width < this.ClientSize.Width)
            {
                player.Left += speed;
            }
            if (goUp == true && player.Top > 45)
            {
                player.Top -= speed;
            }
            if (goDown == true && player.Top + player.Height < this.ClientSize.Height)
            {
                player.Top += speed;
            }


            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "ammo")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        this.Controls.Remove(x);
                        ((PictureBox)x).Dispose();
                        ammo += 10;  
                    }
                }
                if (x is PictureBox && (string)x.Tag == "health")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds) && x.Visible == true)
                    {

                        this.Controls.Remove(x);
                        ((PictureBox)x).Dispose();
                        playerHealth += 25;
                    }
                }

                if (x is PictureBox && (string)x.Tag == "boss")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        playerHealth -= 10;
                        
                    }

                    if (x.Left > player.Left)   
                    {
                        x.Left -= bossSpeed;
                        ((PictureBox)x).Image = Properties.Resources.boss_left ;
                    }
                    if (x.Left < player.Left)
                    {
                        x.Left += bossSpeed;
                        ((PictureBox)x).Image = Properties.Resources.boss_right;
                    }
                    if (x.Top > player.Top)
                    {
                        x.Top -= bossSpeed;
                        ((PictureBox)x).Image = Properties.Resources.boss_up;
                    }
                    if (x.Top < player.Left)
                    {
                        x.Top += bossSpeed;
                        ((PictureBox)x).Image = Properties.Resources.boss;
                    }
                }

                foreach (Control j in this.Controls)
                {
                    if (x is PictureBox && (string)j.Tag == "bullet" && x is PictureBox && (string)x.Tag == "boss")
                    {
                        if (x.Bounds.IntersectsWith(j.Bounds))
                        {

                            this.Controls.Remove(j); 
                            ((PictureBox)j).Dispose();
                            this.Controls.Remove(x); 
                            ((PictureBox)x).Dispose();

                            enemiesList.Remove(((PictureBox)x)); 

                            Bosses();  
                        }
                    }
                }

            }
        }
        private void KeyIsDown(object sender, KeyEventArgs e)
        {

            if (gameOver == true)
            {
                return;
            }

            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
                facing = "left";
                player.Image = Properties.Resources.Player_Left;

            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
                facing = "right";
                player.Image = Properties.Resources.Player_Right; 
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = true;
                facing = "up";
                player.Image = Properties.Resources.Player_Up; 
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = true;
                facing = "down";
                player.Image = Properties.Resources.Player_Down; 
            }

        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;

            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }

            if (e.KeyCode == Keys.Space && ammo > 0 && gameOver == false)
            {
                ammo--;
                Shoot(facing);

                if (ammo < 1)
                {
                    DropAmmo();

                }



            }

            if (e.KeyCode == Keys.Enter && gameOver == true)
            {
                RestartGame();
            }

        }
        private void Shoot(string direction)
        {
            Bullet shootBullet = new Bullet();  //Bullet Class
            shootBullet.direction = direction;
            shootBullet.bulletLeft = player.Left + (player.Width / 2);
            shootBullet.bulletTop = player.Top + (player.Height / 2);
            shootBullet.MakeBullet(this);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Loading loading = new Loading();
            loading.Show();
            GameTimer.Stop();
            this.Hide();
        }

        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Bosses()
        {
            PictureBox boss = new PictureBox();
            boss.Tag = "boss";
            boss.Image = Properties.Resources.boss;
            boss.BackColor = Color.Transparent;
            boss.Left = randomNum.Next(900, 900);    //spawning at different locations
            boss.Top = randomNum.Next(500, 900);
            boss.SizeMode = PictureBoxSizeMode.AutoSize;
            enemiesList.Add(boss); //List Collection
            this.Controls.Add(boss);   //enemy will be added to the form
            player.BringToFront();  //player will be on top of the enemy picture box
            this.sound.SoundLocation = @"C:\MSSA\20483\Assignments\PROJECT\Project1\bin\Debug\Jumpscare.wav";
            this.sound.Play();

        }

        private void DropAmmo()
        {
            PictureBox ammo = new PictureBox();
            ammo.Image = Properties.Resources.box;
            ammo.BackColor = Color.Transparent;
            ammo.SizeMode = PictureBoxSizeMode.Zoom;
            ammo.Left = randomNum.Next(10, this.ClientSize.Width - ammo.Width);
            ammo.Top = randomNum.Next(60, this.ClientSize.Height - ammo.Height);
            ammo.Tag = "ammo";
            items.Add(ammo);
            this.Controls.Add(ammo);

            ammo.BringToFront();
            player.BringToFront();

        }
        private void Health()
        {
            PictureBox playerHealth = new PictureBox();
            playerHealth.Image = Properties.Resources.icons8_sodacola_64;
            playerHealth.BackColor = Color.Transparent;
            playerHealth.SizeMode = PictureBoxSizeMode.Zoom;
            playerHealth.Left = randomNum.Next(20, this.ClientSize.Width - playerHealth.Width);
            playerHealth.Top = randomNum.Next(70, this.ClientSize.Height - playerHealth.Height);
            playerHealth.Tag = "health";
            items.Add((playerHealth));
            this.Controls.Add(playerHealth);

            playerHealth.BringToFront();
            player.BringToFront();

        }
        private void RestartGame()
        {

            player.Image = Properties.Resources.Player_Up;

            foreach (PictureBox i in enemiesList)
            {
                this.Controls.Remove(i);

            }
            enemiesList.Clear();

            for (int i = 0; i < 1; i++)  
            {
                Bosses();

            }

            goUp = false;
            goDown = false;
            goLeft = false;
            goRight = false;
            gameOver = false;

            playerHealth = 100;
            //score = 0;
            ammo = 10;
            GameTimer.Start();

        }

    }
}
