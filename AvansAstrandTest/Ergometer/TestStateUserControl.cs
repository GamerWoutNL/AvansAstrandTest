using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErgoConnect
{
    public partial class TestStateUserControl : UserControl, StateCallback
    {
        public string state { get; set; }
        public int minutes { get; set; }
        public int seconds { get; set; }
        public bool active { get; set; }
        public Timer timer { get; set; }
        public StateCallback CallBack { get; set; }

        public TestStateUserControl()
        {
            InitializeComponent();
            this.active = false;
            this.timer = new Timer();
        }

        public void Initialize(string state, int minutes, StateCallback callback)
        {
            this.state = state;
            this.minutes = minutes;
            this.seconds = minutes * 60;
            this.CallBack = callback;

            this.StateLabel.Text = this.state;
            this.TimeLabel.Text = $"0{minutes}:00";
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            seconds--;
            int secondCount = seconds % 60;
            string secondString = "";
            if (secondCount < 10)
            {
                secondString = $"0{secondCount}";
            } else
            {
                secondString = $"{secondCount}";
            }
            this.TimeLabel.Text = $"0{seconds / 60}:{secondString}";
            if (seconds == 0)
            {
                StopState();
            }
        }

        public void StartState()
        {
            this.BackColor = Color.LightBlue;
            timer.Start();
        }

        public void StopState()
        {
            this.BackColor = Control.DefaultBackColor;
            this.timer.Stop();
            if(this.CallBack != null)
            {
                CallBack.StartState();
            }
        }
    }
}
