using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Ergometer
{
    public partial class WarmingUpView : UserControl
    {
        private StateCallback stateCallback;
        public WarmingUpView()
        {
            InitializeComponent();
            backgroundWorker1.RunWorkerAsync();
        }

        public void AttachStateCallback(StateCallback stateCallback)
        {
            this.stateCallback = stateCallback;
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for(int i = 0; i < 120; i++)
            {
                Thread.Sleep(1000);
                int percentage = (i + 1) * 100 / 120;
                backgroundWorker1.ReportProgress(percentage);
            }
        }

        private void BackgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            WarmupProgressBar.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.stateCallback.EndState();
        }
    }
}
