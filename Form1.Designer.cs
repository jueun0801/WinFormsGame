namespace Project1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.player = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblPlayerHealth = new System.Windows.Forms.Label();
            this.healthBar = new System.Windows.Forms.ProgressBar();
            this.lblHealth = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.txtAmmo = new System.Windows.Forms.Label();
            this.inactiveboss = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inactiveboss)).BeginInit();
            this.SuspendLayout();
            // 
            // GameTimer
            // 
            this.GameTimer.Enabled = true;
            this.GameTimer.Interval = 20;
            this.GameTimer.Tick += new System.EventHandler(this.MainTimerEvent);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Project1.Properties.Resources._return;
            this.pictureBox1.Location = new System.Drawing.Point(873, 823);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(43, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // player
            // 
            this.player.BackColor = System.Drawing.Color.Transparent;
            this.player.Image = global::Project1.Properties.Resources.Player_Up;
            this.player.Location = new System.Drawing.Point(417, 759);
            this.player.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(82, 104);
            this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.player.TabIndex = 4;
            this.player.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblPlayerHealth);
            this.panel1.Controls.Add(this.healthBar);
            this.panel1.Controls.Add(this.lblHealth);
            this.panel1.Controls.Add(this.lblScore);
            this.panel1.Controls.Add(this.txtAmmo);
            this.panel1.Location = new System.Drawing.Point(0, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(925, 54);
            this.panel1.TabIndex = 7;
            // 
            // lblPlayerHealth
            // 
            this.lblPlayerHealth.AutoSize = true;
            this.lblPlayerHealth.BackColor = System.Drawing.Color.Transparent;
            this.lblPlayerHealth.ForeColor = System.Drawing.Color.DarkRed;
            this.lblPlayerHealth.Location = new System.Drawing.Point(826, 32);
            this.lblPlayerHealth.Name = "lblPlayerHealth";
            this.lblPlayerHealth.Size = new System.Drawing.Size(0, 17);
            this.lblPlayerHealth.TabIndex = 10;
            // 
            // healthBar
            // 
            this.healthBar.Cursor = System.Windows.Forms.Cursors.Default;
            this.healthBar.Location = new System.Drawing.Point(661, 8);
            this.healthBar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.healthBar.Name = "healthBar";
            this.healthBar.Size = new System.Drawing.Size(218, 23);
            this.healthBar.TabIndex = 9;
            this.healthBar.Value = 100;
            // 
            // lblHealth
            // 
            this.lblHealth.AutoSize = true;
            this.lblHealth.BackColor = System.Drawing.Color.Transparent;
            this.lblHealth.Font = new System.Drawing.Font("Haettenschweiler", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHealth.ForeColor = System.Drawing.Color.DarkRed;
            this.lblHealth.Location = new System.Drawing.Point(602, 9);
            this.lblHealth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHealth.Name = "lblHealth";
            this.lblHealth.Size = new System.Drawing.Size(55, 23);
            this.lblHealth.TabIndex = 8;
            this.lblHealth.Text = "Health:";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.BackColor = System.Drawing.Color.Transparent;
            this.lblScore.Font = new System.Drawing.Font("Haettenschweiler", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.ForeColor = System.Drawing.Color.DarkRed;
            this.lblScore.Location = new System.Drawing.Point(355, 9);
            this.lblScore.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(50, 23);
            this.lblScore.TabIndex = 7;
            this.lblScore.Text = "Kills: 0";
            // 
            // txtAmmo
            // 
            this.txtAmmo.AutoSize = true;
            this.txtAmmo.BackColor = System.Drawing.Color.Transparent;
            this.txtAmmo.Font = new System.Drawing.Font("Haettenschweiler", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmmo.ForeColor = System.Drawing.Color.DarkRed;
            this.txtAmmo.Location = new System.Drawing.Point(31, 9);
            this.txtAmmo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtAmmo.Name = "txtAmmo";
            this.txtAmmo.Size = new System.Drawing.Size(63, 23);
            this.txtAmmo.TabIndex = 6;
            this.txtAmmo.Text = "Ammo: 0";
            // 
            // inactiveboss
            // 
            this.inactiveboss.BackColor = System.Drawing.Color.Transparent;
            this.inactiveboss.Image = global::Project1.Properties.Resources.inactive;
            this.inactiveboss.Location = new System.Drawing.Point(336, 51);
            this.inactiveboss.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.inactiveboss.Name = "inactiveboss";
            this.inactiveboss.Size = new System.Drawing.Size(234, 189);
            this.inactiveboss.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.inactiveboss.TabIndex = 8;
            this.inactiveboss.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.BackgroundImage = global::Project1.Properties.Resources.background1;
            this.ClientSize = new System.Drawing.Size(924, 865);
            this.Controls.Add(this.inactiveboss);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.player);
            this.Font = new System.Drawing.Font("Haettenschweiler", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnFormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inactiveboss)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblPlayerHealth;
        private System.Windows.Forms.ProgressBar healthBar;
        private System.Windows.Forms.Label lblHealth;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label txtAmmo;
        private System.Windows.Forms.PictureBox inactiveboss;
    }
}

