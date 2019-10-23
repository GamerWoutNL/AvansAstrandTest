using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErgoConnect
{
    public partial class ActiveWorkoutView : Form, MessageCallback
    {
        public ActiveWorkoutView()
        {
            InitializeComponent();

            this.WarmingUpTestState.Initialize("Warming Up", 2, this.InTestStateView);
            this.InTestStateView.Initialize("In Test", 4, this.CoolingDownTestState);
            this.CoolingDownTestState.Initialize("Cooling Down", 1, null);
        }

        public void MessageReceived(string message)
        {
            if (this.FeedbackLabel.InvokeRequired)
            {
                this.FeedbackLabel.Invoke(new MethodInvoker(delegate { MessageReceived(message); }));
            }
            this.FeedbackLabel.Text = message;
        }

        public void CadenceReceived(string message)
        {
            if (this.CadenceLabel.InvokeRequired)
            {
                this.CadenceLabel.Invoke(new MethodInvoker(delegate { CadenceReceived(message); }));
            }
            this.CadenceLabel.Text = $"Cadans: {message} Omwentelingen per minuut";
        }

        public void ResistanceReceived(string message)
        {
            if (this.ResistanceLabel.InvokeRequired)
            {
                this.ResistanceLabel.Invoke(new MethodInvoker(delegate { ResistanceReceived(message); }));
            }
            this.ResistanceLabel.Text = $"Weerstand: {message}%";
        }

        public void PowerReceived(string message)
        {
            if (this.WattLabel.InvokeRequired)
            {
                this.WattLabel.Invoke(new MethodInvoker(delegate { PowerReceived(message); }));
            }
            this.WattLabel.Text = $"Wattage: {message} watt";
        }

        public void HeartrateReceived(string message)
        {
            if (this.HeartrateLabel.InvokeRequired)
            {
                this.HeartrateLabel.Invoke(new MethodInvoker(delegate { HeartrateReceived(message); }));
            }
            this.HeartrateLabel.Text = $"Hartslag: {message} slagen per minuut";
        }

		public void StartTimers()
		{
			this.WarmingUpTestState.StartState();
		}
	}
}
