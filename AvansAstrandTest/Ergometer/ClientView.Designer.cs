namespace Ergometer
{
    partial class ClientView
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
            this.StartButton = new System.Windows.Forms.Button();
            this.WeightBox = new System.Windows.Forms.TextBox();
            this.GenderComboBox = new System.Windows.Forms.ComboBox();
            this.AgeBox = new System.Windows.Forms.TextBox();
            this.WeightLabel = new System.Windows.Forms.Label();
            this.GenderLabel = new System.Windows.Forms.Label();
            this.AgeLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(152, 115);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(307, 23);
            this.StartButton.TabIndex = 17;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // WeightBox
            // 
            this.WeightBox.Location = new System.Drawing.Point(211, 79);
            this.WeightBox.Name = "WeightBox";
            this.WeightBox.Size = new System.Drawing.Size(121, 20);
            this.WeightBox.TabIndex = 16;
            // 
            // GenderComboBox
            // 
            this.GenderComboBox.FormattingEnabled = true;
            this.GenderComboBox.Items.AddRange(new object[] {
            "Man",
            "Vrouw"});
            this.GenderComboBox.Location = new System.Drawing.Point(406, 79);
            this.GenderComboBox.Name = "GenderComboBox";
            this.GenderComboBox.Size = new System.Drawing.Size(121, 21);
            this.GenderComboBox.TabIndex = 15;
            // 
            // AgeBox
            // 
            this.AgeBox.Location = new System.Drawing.Point(104, 79);
            this.AgeBox.Name = "AgeBox";
            this.AgeBox.Size = new System.Drawing.Size(42, 20);
            this.AgeBox.TabIndex = 14;
            // 
            // WeightLabel
            // 
            this.WeightLabel.AutoSize = true;
            this.WeightLabel.Location = new System.Drawing.Point(156, 82);
            this.WeightLabel.Name = "WeightLabel";
            this.WeightLabel.Size = new System.Drawing.Size(49, 13);
            this.WeightLabel.TabIndex = 13;
            this.WeightLabel.Text = "Gewicht:";
            // 
            // GenderLabel
            // 
            this.GenderLabel.AutoSize = true;
            this.GenderLabel.Location = new System.Drawing.Point(348, 82);
            this.GenderLabel.Name = "GenderLabel";
            this.GenderLabel.Size = new System.Drawing.Size(52, 13);
            this.GenderLabel.TabIndex = 12;
            this.GenderLabel.Text = "Geslacht:";
            // 
            // AgeLabel
            // 
            this.AgeLabel.AutoSize = true;
            this.AgeLabel.Location = new System.Drawing.Point(54, 82);
            this.AgeLabel.Name = "AgeLabel";
            this.AgeLabel.Size = new System.Drawing.Size(44, 13);
            this.AgeLabel.TabIndex = 11;
            this.AgeLabel.Text = "Leeftijd:";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(74, 50);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(72, 13);
            this.NameLabel.TabIndex = 10;
            this.NameLabel.Text = "Patient naam:";
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(152, 47);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(307, 20);
            this.NameBox.TabIndex = 9;
            // 
            // ClientView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 206);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.WeightBox);
            this.Controls.Add(this.GenderComboBox);
            this.Controls.Add(this.AgeBox);
            this.Controls.Add(this.WeightLabel);
            this.Controls.Add(this.GenderLabel);
            this.Controls.Add(this.AgeLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.NameBox);
            this.Name = "ClientView";
            this.Text = "ClientView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.TextBox WeightBox;
        private System.Windows.Forms.ComboBox GenderComboBox;
        private System.Windows.Forms.TextBox AgeBox;
        private System.Windows.Forms.Label WeightLabel;
        private System.Windows.Forms.Label GenderLabel;
        private System.Windows.Forms.Label AgeLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.TextBox NameBox;
    }
}