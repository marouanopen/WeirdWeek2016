using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocCar
{
    public partial class ScoreCounterForm : Form
    {
        GameManager gm;
        Timer timer;
        int timeLeft;
        public ScoreCounterForm()
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            gm = new GameManager();
            InitializeComponent();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0 )
            {
                timeLeft--;
                updateLabels();
            }
            else
            {
                timer.Enabled = false;
                btnPlay.Enabled = true;
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            timeLeft = 300;
            updateLabels();
            gm.newGame();
            timer.Enabled = true;
            btnPlay.Enabled = false;
        }

        
        private void updateLabels()
        {
            lblTeam1.Text = gm.scoreBlauw.ToString();
            lblTeam2.Text = gm.scoreRood.ToString();
            lblTimer.Text = timeLeft / 60 + ":" + ((timeLeft % 60) >= 10 ? (timeLeft % 60).ToString() : "0" + timeLeft % 60);
        }

        private void lblTeam1_Click(object sender, EventArgs e)
        {
            gm.goal("blauw");
            updateLabels();
        }

        private void lblTeam2_Click(object sender, EventArgs e)
        {
            gm.goal("rood");
            updateLabels();
        }
    }
}
