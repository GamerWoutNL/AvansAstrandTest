namespace Specialist
{
    partial class SessionView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.VO2Label = new System.Windows.Forms.Label();
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.NameLabel = new System.Windows.Forms.Label();
            this.AgeLabel = new System.Windows.Forms.Label();
            this.WeightLabel = new System.Windows.Forms.Label();
            this.GenderLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // VO2Label
            // 
            this.VO2Label.AutoSize = true;
            this.VO2Label.Font = new System.Drawing.Font("Microsoft Tai Le", 19.69811F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VO2Label.Location = new System.Drawing.Point(345, 445);
            this.VO2Label.Name = "VO2Label";
            this.VO2Label.Size = new System.Drawing.Size(282, 37);
            this.VO2Label.TabIndex = 8;
            this.VO2Label.Text = "VO2 Max: ml/kg/min";
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.Location = new System.Drawing.Point(3, 79);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(968, 363);
            this.cartesianChart1.TabIndex = 7;
            this.cartesianChart1.Text = "cartesianChart1";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("Microsoft Tai Le", 14.26415F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameLabel.Location = new System.Drawing.Point(3, 9);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(290, 26);
            this.NameLabel.TabIndex = 9;
            this.NameLabel.Text = "Patient naam: Japie Klaasseen";
            // 
            // AgeLabel
            // 
            this.AgeLabel.AutoSize = true;
            this.AgeLabel.Font = new System.Drawing.Font("Microsoft Tai Le", 14.26415F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AgeLabel.Location = new System.Drawing.Point(3, 50);
            this.AgeLabel.Name = "AgeLabel";
            this.AgeLabel.Size = new System.Drawing.Size(179, 26);
            this.AgeLabel.TabIndex = 10;
            this.AgeLabel.Text = "Patient leeftijd: 78";
            // 
            // WeightLabel
            // 
            this.WeightLabel.AutoSize = true;
            this.WeightLabel.Font = new System.Drawing.Font("Microsoft Tai Le", 14.26415F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WeightLabel.Location = new System.Drawing.Point(277, 50);
            this.WeightLabel.Name = "WeightLabel";
            this.WeightLabel.Size = new System.Drawing.Size(216, 26);
            this.WeightLabel.TabIndex = 11;
            this.WeightLabel.Text = "Patient gewicht: 90 kg";
            // 
            // GenderLabel
            // 
            this.GenderLabel.AutoSize = true;
            this.GenderLabel.Font = new System.Drawing.Font("Microsoft Tai Le", 14.26415F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenderLabel.Location = new System.Drawing.Point(587, 50);
            this.GenderLabel.Name = "GenderLabel";
            this.GenderLabel.Size = new System.Drawing.Size(211, 26);
            this.GenderLabel.TabIndex = 12;
            this.GenderLabel.Text = "Patient geslacht: M/V";
            // 
            // SessionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GenderLabel);
            this.Controls.Add(this.WeightLabel);
            this.Controls.Add(this.AgeLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.VO2Label);
            this.Controls.Add(this.cartesianChart1);
            this.Name = "SessionView";
            this.Size = new System.Drawing.Size(987, 486);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label VO2Label;
        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label AgeLabel;
        private System.Windows.Forms.Label WeightLabel;
        private System.Windows.Forms.Label GenderLabel;
    }
}
