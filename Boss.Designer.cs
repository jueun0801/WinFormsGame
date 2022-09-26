namespace Project1
{
    partial class Boss
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblPlayerHealth = new System.Windows.Forms.Label();
            this.healthBar = new System.Windows.Forms.ProgressBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblHealth = new System.Windows.Forms.Label();
            this.txtAmmo = new System.Windows.Forms.Label();
            this.player = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            this.SuspendLayout();
            // 
            // GameTimer
            // 
            this.GameTimer.Enabled = true;
            this.GameTimer.Interval = 20;
            this.GameTimer.Tick += new System.EventHandler(this.MainTimerEvent);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.lblPlayerHealth);
            this.panel1.Controls.Add(this.healthBar);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lblHealth);
            this.panel1.Controls.Add(this.txtAmmo);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1488, 54);
            this.panel1.TabIndex = 10;
            // 
            // lblPlayerHealth
            // 
            this.lblPlayerHealth.AutoSize = true;
            this.lblPlayerHealth.BackColor = System.Drawing.Color.Transparent;
            this.lblPlayerHealth.Font = new System.Drawing.Font("Haettenschweiler", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Project1.Properties.Resources._return;
            this.pictureBox1.Location = new System.Drawing.Point(1440, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(43, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
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
            // txtAmmo
            // 
            this.txtAmmo.AutoSize = true;
            this.txtAmmo.BackColor = System.Drawing.Color.Transparent;
            this.txtAmmo.Font = new System.Drawing.Font("Haettenschweiler", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmmo.ForeColor = System.Drawing.Color.DarkRed;
            this.txtAmmo.Location = new System.Drawing.Point(24, 12);
            this.txtAmmo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtAmmo.Name = "txtAmmo";
            this.txtAmmo.Size = new System.Drawing.Size(63, 23);
            this.txtAmmo.TabIndex = 6;
            this.txtAmmo.Text = "Ammo: 0";
            // 
            // player
            // 
            this.player.BackColor = System.Drawing.Color.Transparent;
            this.player.Image = global::Project1.Properties.Resources.Player_Up;
            this.player.Location = new System.Drawing.Point(60, 792);
            this.player.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(82, 104);
            this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.player.TabIndex = 8;
            this.player.TabStop = false;
            // 
            // Boss
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Project1.Properties.Resources.background2;
            this.ClientSize = new System.Drawing.Size(1486, 898);
            this.Controls.Add(this.player);
            this.Controls.Add(this.panel1);
            this.Name = "Boss";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Boss";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnFormClosed);
            this.Load += new System.EventHandler(this.Boss_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblPlayerHealth;
        private System.Windows.Forms.ProgressBar healthBar;
        private System.Windows.Forms.Label lblHealth;
        private System.Windows.Forms.Label txtAmmo;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}