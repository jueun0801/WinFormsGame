using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Project1
{
    public partial class Loading : Form
    {

        SoundPlayer player = new SoundPlayer();
        ScoreRepository scoreRepository;
        public static int score;

        public Loading()
        {
            InitializeComponent();
            SoundPlayer player = new SoundPlayer();
            this.player.SoundLocation = "C:\\MSSA\\20483\\Assignments\\PROJECT\\Project1\\bin\\Debug\\Music.wav";
        
            this.player.PlayLooping();

        }

        private void Loading_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'scoreboardDataSet.Scores' table. You can move, or remove it, as needed.
            this.scoresTableAdapter.Fill(this.scoreboardDataSet.Scores);
            // TODO: This line of code loads data into the 'scoreboardDataSet.Scores' table. You can move, or remove it, as needed.
            //this.scoresTableAdapter.Fill(this.scoreboardDataSet.Scores);
            LoadPrgsBar.Visible = false;
            controlPanel.Visible = false;
            lblPrgs.Visible = false;
            scoreGrid.Visible = false;
            scoreGrid.DataSource = null;

            
            
            
        }
        private Task ProcessData(List<string> list, IProgress<ProgressReport> progress)
        {
            int index = 1;
            int totalProcess = list.Count;
            var progressReport = new ProgressReport();
            return Task.Run(() =>
            {
                for(int i = 0; i < totalProcess; i++)
                {
                    progressReport.PercentComplete = index++ * 100 / totalProcess;
                    progress.Report(progressReport);
                    Thread.Sleep(1); //used to simulate length of operation

                }
            });
        }
        private async void btnStart_Click(object sender, EventArgs e)
        {
            lblPrgs.Visible = true;
            this.timer1.Start();
            List<string> list = new List<string>();
            for(int i=0; i<1000; i++)
                list.Add(i.ToString());
            lblPrgs.Text = "Working...";
            var progress = new Progress<ProgressReport>();
            progress.ProgressChanged+=(o,report) =>
            {
                lblPrgs.Text = string.Format($"Processing...{report.PercentComplete}%");
                LoadPrgsBar.Value =report.PercentComplete;
                LoadPrgsBar.Update();
            };
            await ProcessData(list, progress);
            lblPrgs.TextAlign= ContentAlignment.MiddleCenter;
            lblPrgs.Text = "100% !";


            if (lblPrgs.Text == "100% !")
            {
                Form1 gameform = new Form1();
                gameform.Show();
                this.Hide();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LoadPrgsBar.Visible=true;
            //this.LoadPrgsBar.Increment(10);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            controlPanel.Visible = true;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            controlPanel.Visible = false;
        }

        private void pictureBoxScoreBoard_Click(object sender, EventArgs e)
        {
            scoreGrid.Visible = true;
            scoreRepository = new ScoreRepository();
            scoreGrid.DataSource = scoreRepository.GetAllScores();

        }
    }
}
