using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServerProgram.Data;

namespace ErgoConnect
{
    public partial class LogInView : Form
    {
        public LogInView()
        {
            InitializeComponent();
        }

        private void StartSessionButton_Click(object sender, EventArgs e)
        {
            string patientName = this.NameBox.Text;
            string patientAge = this.AgeBox.Text;
            string patientGender = this.GenderBox.Text == "Man" ? "M" : "F";
            string patientWeight = this.Weightbox.Text;
            string ergoID = this.ergoIdBox.Text;

            //Win forms: Save patient data Button

            Program program = new Program(ergoID, patientName, patientAge, patientGender, patientWeight);
            //Win forms: Start session 
            //program.client.Write($"<{ServerProgram.Data.Tag.MT.ToString()}>patient<{ServerProgram.Data.Tag.AC.ToString()}>sessionstart<{ServerProgram.Data.Tag.EOF.ToString()}>");
            ActiveWorkoutView workoutView = new ActiveWorkoutView();
            program.client.attachMessageCallback(workoutView);
            workoutView.ShowDialog();
            this.Close();
        }
    }
}
