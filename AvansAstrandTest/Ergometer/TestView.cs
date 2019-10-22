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
    public partial class TestView : UserControl, StateCallback
    {
        private StateCallback stateCallback;
        public TestView()
        {
            InitializeComponent();
        }

        public void AttachStateCallback(StateCallback stateCallback)
        {
            this.stateCallback = stateCallback;
        }

        public void EndState()
        {
            this.backgroundWorker1.RunWorkerAsync();
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 240; i++)
            {
                Thread.Sleep(1000);
                int percentage = (i + 1) * 100 / 240;
                backgroundWorker1.ReportProgress(percentage);
            }
        }

        private void BackgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            InTestProgressBar.Value = e.ProgressPercentage;
        }
    }
}
