namespace Specialist
{
    partial class SessionViewForm
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
            this.GenderLabel = new System.Windows.Forms.Label();
            this.WeightLabel = new System.Windows.Forms.Label();
            this.AgeLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.VO2Label = new System.Windows.Forms.Label();
            this.Chart = new LiveCharts.WinForms.CartesianChart();
            this.SuspendLayout();
            // 
            // GenderLabel
            // 
            this.GenderLabel.AutoSize = true;
            this.GenderLabel.Font = new System.Drawing.Font("Microsoft Tai Le", 14.26415F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenderLabel.Location = new System.Drawing.Point(596, 61);
            this.GenderLabel.Name = "GenderLabel";
            this.GenderLabel.Size = new System.Drawing.Size(197, 25);
            this.GenderLabel.TabIndex = 18;
            this.GenderLabel.Text = "Patient geslacht: M/V";
            // 
            // WeightLabel
            // 
            this.WeightLabel.AutoSize = true;
            this.WeightLabel.Font = new System.Drawing.Font("Microsoft Tai Le", 14.26415F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WeightLabel.Location = new System.Drawing.Point(286, 61);
            this.WeightLabel.Name = "WeightLabel";
            this.WeightLabel.Size = new System.Drawing.Size(204, 25);
            this.WeightLabel.TabIndex = 17;
            this.WeightLabel.Text = "Patient gewicht: 90 kg";
            // 
            // AgeLabel
            // 
            this.AgeLabel.AutoSize = true;
            this.AgeLabel.Font = new System.Drawing.Font("Microsoft Tai Le", 14.26415F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AgeLabel.Location = new System.Drawing.Point(12, 61);
            this.AgeLabel.Name = "AgeLabel";
            this.AgeLabel.Size = new System.Drawing.Size(169, 25);
            this.AgeLabel.TabIndex = 16;
            this.AgeLabel.Text = "Patient leeftijd: 78";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("Microsoft Tai Le", 14.26415F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameLabel.Location = new System.Drawing.Point(12, 20);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(268, 25);
            this.NameLabel.TabIndex = 15;
            this.NameLabel.Text = "Patient naam: Japie Klaasseen";
            // 
            // VO2Label
            // 
            this.VO2Label.AutoSize = true;
            this.VO2Label.Font = new System.Drawing.Font("Microsoft Tai Le", 19.69811F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VO2Label.Location = new System.Drawing.Point(354, 456);
            this.VO2Label.Name = "VO2Label";
            this.VO2Label.Size = new System.Drawing.Size(263, 34);
            this.VO2Label.TabIndex = 14;
            this.VO2Label.Text = "VO2 Max: ml/kg/min";
            // 
            // Chart
            // 
            this.Chart.Location = new System.Drawing.Point(12, 90);
            this.Chart.Name = "Chart";
            this.Chart.Size = new System.Drawing.Size(968, 363);
            this.Chart.TabIndex = 13;
            this.Chart.Text = "Chart";
            // 
            // SessionViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 496);
            this.Controls.Add(this.GenderLabel);
            this.Controls.Add(this.WeightLabel);
            this.Controls.Add(this.AgeLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.VO2Label);
            this.Controls.Add(this.Chart);
            this.Name = "SessionViewForm";
            this.Text = "SessionViewForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label GenderLabel;
        private System.Windows.Forms.Label WeightLabel;
        private System.Windows.Forms.Label AgeLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label VO2Label;
        private LiveCharts.WinForms.CartesianChart Chart;
    }
}