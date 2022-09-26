using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Project1
{
    public partial class Form1 : Form
    {
        bool goLeft, goRight, goUp, goDown, gameOver;
        string facing = "up";   //player faces up by default 
        int playerHealth = 100;
        int speed = 10;
        int ammo = 8;
        public static int score;
        int enemySpeed = 2;
        Loading form = new Loading();
        Random randomNum = new Random();
        ScoreRepository scoreRepository;


        List<PictureBox> enemiesList = new List<PictureBox>(); //group together their pics in picture box
        List<PictureBox> items = new List<PictureBox>();


        public Form1()
        {
            InitializeComponent();
            RestartGame();
            DoubleBuffered = true;
            
        }

        #region MainTimerEvent
        private void MainTimerEvent(object sender, EventArgs e)
        {

            if (playerHealth >= 0)
            {
                lblPlayerHealth.Text = ($"{playerHealth} / 100");
                if(playerHealth > 100)
                {
                    healthBar.Value = 100;
                }
                else
                {
                    healthBar.Value = playerHealth;
                }
                

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
                scoreRepository = new ScoreRepository();
                var newScore = new Score();
                newScore.Player = Int32.Parse((scoreRepository.GetMaxId() + 1).ToString());
                newScore.Score1 = score;
                scoreRepository.AddScore(newScore);
            }
            txtAmmo.Text = "Ammo " + ammo;
            lblScore.Text = "Kills: " + score;

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
            if (inactiveboss.Bounds.IntersectsWith(player.Bounds))
            {
                Boss bosslevel = new Boss();
                this.Hide();
                GameTimer.Stop();
                bosslevel.Show();
            }


            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "ammo")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        this.Controls.Remove(x);
                        ((PictureBox)x).Dispose();
                        ammo += 10;  //ammo refill 
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

                if (x is PictureBox && (string)x.Tag == "enemy")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        playerHealth -= 1;

                    }

                    if (x.Left > player.Left)   //enemy will move left of the player
                    {
                        x.Left -= enemySpeed;
                        ((PictureBox)x).Image = Properties.Resources.Enemy_Left;
                    }
                    if (x.Left < player.Left)
                    {
                        x.Left += enemySpeed;
                        ((PictureBox)x).Image = Properties.Resources.Enemy_Right;
                    }
                    if (x.Top > player.Top)
                    {
                        x.Top -= enemySpeed;
                        ((PictureBox)x).Image = Properties.Resources.Enemy_Up;
                    }
                    if (x.Top < player.Left)
                    {
                        x.Top += enemySpeed;
                        ((PictureBox)x).Image = Properties.Resources.Enemy_Down;
                    }
                }

                foreach (Control j in this.Controls)
                {
                    if (x is PictureBox && (string)j.Tag == "bullet" && x is PictureBox && (string)x.Tag == "enemy")
                    {
                        if (x.Bounds.IntersectsWith(j.Bounds))
                        {
                            score++;
                            this.Controls.Remove(j); //remove bullet
                            ((PictureBox)j).Dispose();
                            this.Controls.Remove(x); //remove enemy
                            ((PictureBox)x).Dispose();

                            enemiesList.Remove(((PictureBox)x)); //remove enemy from enemy list //watch the paranthese

                            Enemies();  //call the enemies function to create enemies so they will spawn during game
                        }
                    }
                }

            }
        } 
        #endregion

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
                player.Image = Properties.Resources.Player_Left; //add pic

            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
                facing = "right";
                player.Image = Properties.Resources.Player_Right; //add pic
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = true;
                facing = "up";
                player.Image = Properties.Resources.Player_Up; //add pic
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = true;
                facing = "down";
                player.Image = Properties.Resources.Player_Down; //add pic
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

                if (ammo < 1 )
                {
                    DropAmmo();
                   
                }
                
                

            }

            if (e.KeyCode == Keys.Enter && gameOver == true)
            {
                RestartGame();
            }
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        private void Shoot(string direction)
        {
            Bullet shootBullet = new Bullet();  //Bullet Class
            shootBullet.direction = direction;
            shootBullet.bulletLeft = player.Left + (player.Width /2); //where bullet will originate 
            shootBullet.bulletTop = player.Top + (player.Height /2);
            shootBullet.MakeBullet(this); //accessing bullet class
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Loading loading = new Loading();
            loading.Show();
            GameTimer.Stop();
            if(loading != null)
            {
                GameTimer.Start();
            }
        }

        private void Enemies()
        {
            PictureBox enemy = new PictureBox();
            enemy.Tag = "enemy";
            enemy.Image = Properties.Resources.Enemy_Down;
            enemy.BackColor = Color.Transparent;
            enemy.Left = randomNum.Next(0, 900);    //spawning at different locations
            enemy.Top = randomNum.Next(0, 800);
            enemy.SizeMode = PictureBoxSizeMode.Zoom;
            enemiesList.Add(enemy); //List Collection
            this.Controls.Add(enemy);   //enemy will be added to the form
            player.BringToFront();  //player will be on top of the enemy picture box

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
            playerHealth.SizeMode = PictureBoxSizeMode.AutoSize;
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
            
            for(int i = 0; i < 3; i++)  //3 is max number of zombies that will appear
            {
                Enemies();
                
            }
            items.Clear();
            
            
            goUp = false;
            goDown = false;
            goLeft = false;
            goRight = false;
            gameOver = false;

            playerHealth = 100;
            score = 0;
            ammo = 10;
            GameTimer.Start();
            
        }
        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
