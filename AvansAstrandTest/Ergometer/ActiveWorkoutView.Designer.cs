namespace Ergometer
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
            this.warmingUpView1 = new Ergometer.WarmingUpView();
            this.testView1 = new Ergometer.TestView();
            this.SuspendLayout();
            // 
            // warmingUpView1
            // 
            this.warmingUpView1.Location = new System.Drawing.Point(40, 47);
            this.warmingUpView1.Name = "warmingUpView1";
            this.warmingUpView1.Size = new System.Drawing.Size(412, 189);
            this.warmingUpView1.TabIndex = 0;
            // 
            // testView1
            // 
            this.testView1.Location = new System.Drawing.Point(426, 47);
            this.testView1.Name = "testView1";
            this.testView1.Size = new System.Drawing.Size(410, 203);
            this.testView1.TabIndex = 1;
            // 
            // ActiveWorkoutView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 789);
            this.Controls.Add(this.testView1);
            this.Controls.Add(this.warmingUpView1);
            this.Name = "ActiveWorkoutView";
            this.Text = "ActiveWorkoutView";
            this.ResumeLayout(false);

        }

        #endregion

        private WarmingUpView warmingUpView1;
        private TestView testView1;
    }
}