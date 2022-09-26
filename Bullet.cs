using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;  //back color
using System.Windows.Forms;

namespace Project1
{
    class Bullet
    {
        public string direction;
        public int bulletLeft;
        public int bulletTop;

        private int speed = 30;
        private PictureBox bullet = new PictureBox();
        private Timer bulletTimer = new Timer();
        public void MakeBullet(Form form)   
        {

            bullet.Image = Properties.Resources.smallexplosion;
            bullet.BackColor = Color.Transparent;
            bullet.Tag = "bullet";
            bullet.Left = bulletLeft;
            bullet.Top = bulletTop;
            bullet.BringToFront();

            form.Controls.Add(bullet);  //calling this function to add bullet to the form

            bulletTimer.Interval = speed; //20 seconds
            bulletTimer.Tick += new EventHandler(BulletTimerEvent);  //creating event handler
            bulletTimer.Start();
        }
        private void BulletTimerEvent(object sender, EventArgs e)   //custom event handler for bulletTimer.Tick
        {
            if (direction == "left")
            {
                bullet.Left -= speed;
            }

            if (direction == "right")
            {
                bullet.Left += speed;
            }
            if(direction == "up")
            {
                bullet.Top -= speed;
            }
            if (direction == "down")
            {
                bullet.Top += speed;
            }


            if (bullet.Left < 10 || bullet.Left > 900 || bullet.Top < 10 || bullet.Top > 800) //bounds of bulllet
            {
                bulletTimer.Stop();
                bulletTimer.Dispose(); //memory management so game does not slow down while shooting
                bullet.Dispose();
                bulletTimer = null;
                bullet = null;
            }
        }
    }
}
