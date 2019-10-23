using System;
using System.Windows.Forms;

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
			this.chartContainer = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// GenderLabel
			// 
			this.GenderLabel.AutoSize = true;
			this.GenderLabel.Font = new System.Drawing.Font("Microsoft Tai Le", 14.26415F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.GenderLabel.Location = new System.Drawing.Point(795, 75);
			this.GenderLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.GenderLabel.Name = "GenderLabel";
			this.GenderLabel.Size = new System.Drawing.Size(240, 30);
			this.GenderLabel.TabIndex = 18;
			this.GenderLabel.Text = "Patient geslacht: M/V";
			// 
			// WeightLabel
			// 
			this.WeightLabel.AutoSize = true;
			this.WeightLabel.Font = new System.Drawing.Font("Microsoft Tai Le", 14.26415F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.WeightLabel.Location = new System.Drawing.Point(381, 75);
			this.WeightLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.WeightLabel.Name = "WeightLabel";
			this.WeightLabel.Size = new System.Drawing.Size(248, 30);
			this.WeightLabel.TabIndex = 17;
			this.WeightLabel.Text = "Patient gewicht: 90 kg";
			// 
			// AgeLabel
			// 
			this.AgeLabel.AutoSize = true;
			this.AgeLabel.Font = new System.Drawing.Font("Microsoft Tai Le", 14.26415F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AgeLabel.Location = new System.Drawing.Point(16, 75);
			this.AgeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.AgeLabel.Name = "AgeLabel";
			this.AgeLabel.Size = new System.Drawing.Size(206, 30);
			this.AgeLabel.TabIndex = 16;
			this.AgeLabel.Text = "Patient leeftijd: 78";
			// 
			// NameLabel
			// 
			this.NameLabel.AutoSize = true;
			this.NameLabel.Font = new System.Drawing.Font("Microsoft Tai Le", 14.26415F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.NameLabel.Location = new System.Drawing.Point(16, 25);
			this.NameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.NameLabel.Name = "NameLabel";
			this.NameLabel.Size = new System.Drawing.Size(330, 30);
			this.NameLabel.TabIndex = 15;
			this.NameLabel.Text = "Patient naam: Japie Klaasseen";
			// 
			// VO2Label
			// 
			this.VO2Label.AutoSize = true;
			this.VO2Label.Font = new System.Drawing.Font("Microsoft Tai Le", 19.69811F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.VO2Label.Location = new System.Drawing.Point(472, 561);
			this.VO2Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.VO2Label.Name = "VO2Label";
			this.VO2Label.Size = new System.Drawing.Size(321, 42);
			this.VO2Label.TabIndex = 14;
			this.VO2Label.Text = "VO2 Max: ml/kg/min";
			// 
			// chartContainer
			// 
			this.chartContainer.Location = new System.Drawing.Point(31, 139);
			this.chartContainer.Name = "chartContainer";
			this.chartContainer.Size = new System.Drawing.Size(1288, 396);
			this.chartContainer.TabIndex = 19;
			// 
			// SessionViewForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1331, 610);
			this.Controls.Add(this.chartContainer);
			this.Controls.Add(this.GenderLabel);
			this.Controls.Add(this.WeightLabel);
			this.Controls.Add(this.AgeLabel);
			this.Controls.Add(this.NameLabel);
			this.Controls.Add(this.VO2Label);
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
		private Panel chartContainer;
	}
}