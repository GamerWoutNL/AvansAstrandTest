namespace ErgoConnect
{
    partial class ActiveWorkoutView
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
            this.CoolingDownTestState = new ErgoConnect.TestStateUserControl();
            this.InTestStateView = new ErgoConnect.TestStateUserControl();
            this.WarmingUpTestState = new ErgoConnect.TestStateUserControl();
            this.TestStateUserControl = new ErgoConnect.TestStateUserControl();
            this.ResistanceLabel = new System.Windows.Forms.Label();
            this.CadenceLabel = new System.Windows.Forms.Label();
            this.WattLabel = new System.Windows.Forms.Label();
            this.HeartrateLabel = new System.Windows.Forms.Label();
            this.FeedbackLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CoolingDownTestState
            // 
            this.CoolingDownTestState.active = false;
            this.CoolingDownTestState.CallBack = null;
            this.CoolingDownTestState.Location = new System.Drawing.Point(653, 36);
            this.CoolingDownTestState.minutes = 0;
            this.CoolingDownTestState.Name = "CoolingDownTestState";
            this.CoolingDownTestState.seconds = 0;
            this.CoolingDownTestState.Size = new System.Drawing.Size(241, 220);
            this.CoolingDownTestState.state = null;
            this.CoolingDownTestState.TabIndex = 2;
            // 
            // InTestStateView
            // 
            this.InTestStateView.active = false;
            this.InTestStateView.CallBack = null;
            this.InTestStateView.Location = new System.Drawing.Point(344, 36);
            this.InTestStateView.minutes = 0;
            this.InTestStateView.Name = "InTestStateView";
            this.InTestStateView.seconds = 0;
            this.InTestStateView.Size = new System.Drawing.Size(241, 220);
            this.InTestStateView.state = null;
            this.InTestStateView.TabIndex = 1;
            // 
            // WarmingUpTestState
            // 
            this.WarmingUpTestState.active = false;
            this.WarmingUpTestState.CallBack = null;
            this.WarmingUpTestState.Location = new System.Drawing.Point(46, 36);
            this.WarmingUpTestState.minutes = 0;
            this.WarmingUpTestState.Name = "WarmingUpTestState";
            this.WarmingUpTestState.seconds = 0;
            this.WarmingUpTestState.Size = new System.Drawing.Size(241, 220);
            this.WarmingUpTestState.state = null;
            this.WarmingUpTestState.TabIndex = 0;
            // 
            // TestStateUserControl
            // 
            this.TestStateUserControl.active = false;
            this.TestStateUserControl.CallBack = null;
            this.TestStateUserControl.Location = new System.Drawing.Point(0, 0);
            this.TestStateUserControl.minutes = 0;
            this.TestStateUserControl.Name = "TestStateUserControl";
            this.TestStateUserControl.seconds = 0;
            this.TestStateUserControl.Size = new System.Drawing.Size(241, 220);
            this.TestStateUserControl.state = null;
            this.TestStateUserControl.TabIndex = 0;
            // 
            // ResistanceLabel
            // 
            this.ResistanceLabel.AutoSize = true;
            this.ResistanceLabel.Font = new System.Drawing.Font("Microsoft Tai Le", 19.69811F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResistanceLabel.Location = new System.Drawing.Point(678, 484);
            this.ResistanceLabel.Name = "ResistanceLabel";
            this.ResistanceLabel.Size = new System.Drawing.Size(224, 37);
            this.ResistanceLabel.TabIndex = 3;
            this.ResistanceLabel.Text = "Weerstand: 00%";
            // 
            // CadenceLabel
            // 
            this.CadenceLabel.AutoSize = true;
            this.CadenceLabel.Font = new System.Drawing.Font("Microsoft Tai Le", 19.69811F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CadenceLabel.Location = new System.Drawing.Point(71, 484);
            this.CadenceLabel.Name = "CadenceLabel";
            this.CadenceLabel.Size = new System.Drawing.Size(514, 37);
            this.CadenceLabel.TabIndex = 4;
            this.CadenceLabel.Text = "Cadans: 00 Omwentelingen per minuut";
            // 
            // WattLabel
            // 
            this.WattLabel.AutoSize = true;
            this.WattLabel.Font = new System.Drawing.Font("Microsoft Tai Le", 19.69811F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WattLabel.Location = new System.Drawing.Point(678, 546);
            this.WattLabel.Name = "WattLabel";
            this.WattLabel.Size = new System.Drawing.Size(252, 37);
            this.WattLabel.TabIndex = 5;
            this.WattLabel.Text = "Wattage: 000 watt";
            // 
            // HeartrateLabel
            // 
            this.HeartrateLabel.AutoSize = true;
            this.HeartrateLabel.Font = new System.Drawing.Font("Microsoft Tai Le", 19.69811F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeartrateLabel.Location = new System.Drawing.Point(71, 546);
            this.HeartrateLabel.Name = "HeartrateLabel";
            this.HeartrateLabel.Size = new System.Drawing.Size(424, 37);
            this.HeartrateLabel.TabIndex = 6;
            this.HeartrateLabel.Text = "Hartslag: 000 slagen per minuut";
            // 
            // FeedbackLabel
            // 
            this.FeedbackLabel.AutoSize = true;
            this.FeedbackLabel.Font = new System.Drawing.Font("Microsoft Tai Le", 19.69811F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FeedbackLabel.Location = new System.Drawing.Point(100, 327);
            this.FeedbackLabel.Name = "FeedbackLabel";
            this.FeedbackLabel.Size = new System.Drawing.Size(213, 37);
            this.FeedbackLabel.TabIndex = 7;
            this.FeedbackLabel.Text = "Feedback Label";
            // 
            // ActiveWorkoutView
            // 
            this.ClientSize = new System.Drawing.Size(1000, 669);
            this.Controls.Add(this.FeedbackLabel);
            this.Controls.Add(this.HeartrateLabel);
            this.Controls.Add(this.WattLabel);
            this.Controls.Add(this.CadenceLabel);
            this.Controls.Add(this.ResistanceLabel);
            this.Controls.Add(this.CoolingDownTestState);
            this.Controls.Add(this.InTestStateView);
            this.Controls.Add(this.WarmingUpTestState);
            this.Name = "ActiveWorkoutView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TestStateUserControl TestStateUserControl;
        private TestStateUserControl WarmingUpTestState;
        private TestStateUserControl InTestStateView;
        private TestStateUserControl CoolingDownTestState;
        private System.Windows.Forms.Label ResistanceLabel;
        private System.Windows.Forms.Label CadenceLabel;
        private System.Windows.Forms.Label WattLabel;
        private System.Windows.Forms.Label HeartrateLabel;
        private System.Windows.Forms.Label FeedbackLabel;
    }
}