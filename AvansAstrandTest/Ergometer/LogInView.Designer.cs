namespace ErgoConnect
{
    partial class LogInView
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
            this.label1 = new System.Windows.Forms.Label();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.AgeBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.GenderBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Weightbox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ergoIdBox = new System.Windows.Forms.TextBox();
            this.StartSessionButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(94, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Patient naam:";
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(183, 66);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(331, 20);
            this.NameBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(127, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Leeftijd:";
            // 
            // AgeBox
            // 
            this.AgeBox.Location = new System.Drawing.Point(184, 94);
            this.AgeBox.Name = "AgeBox";
            this.AgeBox.Size = new System.Drawing.Size(100, 20);
            this.AgeBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(119, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Geslacht:";
            // 
            // GenderBox
            // 
            this.GenderBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GenderBox.FormattingEnabled = true;
            this.GenderBox.Items.AddRange(new object[] {
            "Man",
            "Vrouw"});
            this.GenderBox.Location = new System.Drawing.Point(183, 121);
            this.GenderBox.Name = "GenderBox";
            this.GenderBox.Size = new System.Drawing.Size(121, 21);
            this.GenderBox.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(123, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Gewicht:";
            // 
            // Weightbox
            // 
            this.Weightbox.Location = new System.Drawing.Point(184, 150);
            this.Weightbox.Name = "Weightbox";
            this.Weightbox.Size = new System.Drawing.Size(100, 20);
            this.Weightbox.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(126, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Ergo ID:";
            // 
            // ergoIdBox
            // 
            this.ergoIdBox.Location = new System.Drawing.Point(184, 177);
            this.ergoIdBox.Name = "ergoIdBox";
            this.ergoIdBox.Size = new System.Drawing.Size(100, 20);
            this.ergoIdBox.TabIndex = 9;
            // 
            // StartSessionButton
            // 
            this.StartSessionButton.Location = new System.Drawing.Point(97, 203);
            this.StartSessionButton.Name = "StartSessionButton";
            this.StartSessionButton.Size = new System.Drawing.Size(417, 23);
            this.StartSessionButton.TabIndex = 10;
            this.StartSessionButton.Text = "Start Test";
            this.StartSessionButton.UseVisualStyleBackColor = true;
            this.StartSessionButton.Click += new System.EventHandler(this.StartSessionButton_Click);
            // 
            // LogInView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 274);
            this.Controls.Add(this.StartSessionButton);
            this.Controls.Add(this.ergoIdBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Weightbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.GenderBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.AgeBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.label1);
            this.Name = "LogInView";
            this.Text = "LogInView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox AgeBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox GenderBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Weightbox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ergoIdBox;
        private System.Windows.Forms.Button StartSessionButton;
    }
}