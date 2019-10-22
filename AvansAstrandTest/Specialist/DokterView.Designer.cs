namespace Specialist
{
    partial class DokterView
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
            this.NameComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SessionComboBox = new System.Windows.Forms.ComboBox();
            this.LoadSessionButton = new System.Windows.Forms.Button();
            this.GetSessionsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NameComboBox
            // 
            this.NameComboBox.Font = new System.Drawing.Font("Microsoft Tai Le", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameComboBox.FormattingEnabled = true;
            this.NameComboBox.Location = new System.Drawing.Point(111, 19);
            this.NameComboBox.Name = "NameComboBox";
            this.NameComboBox.Size = new System.Drawing.Size(205, 29);
            this.NameComboBox.TabIndex = 1;
            this.NameComboBox.DropDown += new System.EventHandler(this.NameComboBox_DropDown);
            this.NameComboBox.SelectedIndexChanged += new System.EventHandler(this.NameComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "Patient:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(345, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "Sessie:";
            // 
            // SessionComboBox
            // 
            this.SessionComboBox.Font = new System.Drawing.Font("Microsoft Tai Le", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SessionComboBox.FormattingEnabled = true;
            this.SessionComboBox.Location = new System.Drawing.Point(416, 21);
            this.SessionComboBox.Name = "SessionComboBox";
            this.SessionComboBox.Size = new System.Drawing.Size(224, 29);
            this.SessionComboBox.TabIndex = 4;
            // 
            // LoadSessionButton
            // 
            this.LoadSessionButton.AutoSize = true;
            this.LoadSessionButton.Font = new System.Drawing.Font("Microsoft Tai Le", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadSessionButton.Location = new System.Drawing.Point(349, 58);
            this.LoadSessionButton.Name = "LoadSessionButton";
            this.LoadSessionButton.Size = new System.Drawing.Size(291, 33);
            this.LoadSessionButton.TabIndex = 5;
            this.LoadSessionButton.Text = "Laad de sessie";
            this.LoadSessionButton.UseVisualStyleBackColor = true;
            this.LoadSessionButton.Click += new System.EventHandler(this.LoadSessionButton_Click);
            // 
            // GetSessionsButton
            // 
            this.GetSessionsButton.AutoSize = true;
            this.GetSessionsButton.Font = new System.Drawing.Font("Microsoft Tai Le", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GetSessionsButton.Location = new System.Drawing.Point(36, 56);
            this.GetSessionsButton.Name = "GetSessionsButton";
            this.GetSessionsButton.Size = new System.Drawing.Size(280, 33);
            this.GetSessionsButton.TabIndex = 7;
            this.GetSessionsButton.Text = "Vernieuw sessie\'s";
            this.GetSessionsButton.UseVisualStyleBackColor = true;
            this.GetSessionsButton.Click += new System.EventHandler(this.GetSessionsButton_Click);
            // 
            // DokterView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 113);
            this.Controls.Add(this.GetSessionsButton);
            this.Controls.Add(this.LoadSessionButton);
            this.Controls.Add(this.SessionComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NameComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "DokterView";
            this.Text = "DokterView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox NameComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox SessionComboBox;
        private System.Windows.Forms.Button LoadSessionButton;
        private System.Windows.Forms.Button GetSessionsButton;
    }
}