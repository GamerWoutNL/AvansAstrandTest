using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Specialist.Communication;
using ServerProgram.Data;
using System.Windows.Threading;

namespace Specialist
{
    public partial class DokterView : Form, PatientReceivedCallback
    {

        private SpecialistClient Client;
        private Dictionary<string, Patient> PatientNamesWithData;

        public DokterView(SpecialistClient client)
        {
            InitializeComponent();
            this.Client = client;
            this.PatientNamesWithData = new Dictionary<string, Patient>();
        }

        public List<string> GetPatientNames()
        {
            List<string> patientNames = new List<string>();

            foreach(Patient patientData in Client.Patients)
            {
                if (!patientNames.Contains(patientData.Name))
                {
                    patientNames.Add(patientData.Name);
                }
                if (!this.PatientNamesWithData.Keys.Contains(patientData.Name))
				{
					this.PatientNamesWithData.Add(patientData.Name, patientData);
				}
            }

            return patientNames;
        }

        private void NameComboBox_DropDown(object sender, EventArgs e)
        {
            UpdateNamesInNameBox();
        }

        public void UpdateNamesInNameBox()
        {
			this.Invoke((MethodInvoker)delegate
			{
				this.NameComboBox.Items.Clear();
			});
            foreach (String name in GetPatientNames())
            {
				this.Invoke((MethodInvoker)delegate
				{
					this.NameComboBox.Items.Add(name);
				});
            }
        }

        private void NameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SessionComboBox.Items.Clear();
            string SelectedName = this.NameComboBox.SelectedItem.ToString();

            foreach(Patient patient in PatientNamesWithData.Values)
            {
                if(patient.Name == SelectedName)
                {
                    this.SessionComboBox.Items.Add(patient);
                }
            }
        }

        private void GetSessionsButton_Click(object sender, EventArgs e)
        {
            this.Client.RefreshPatients();
            
        }

        public void PatientsReceived()
        {
            UpdateNamesInNameBox();
        }

        private void LoadSessionButton_Click(object sender, EventArgs e)
        {
			this.Invoke((MethodInvoker)delegate
			{
				SessionViewForm SessionView1 = new SessionViewForm(this.SessionComboBox.SelectedItem as Patient);
				SessionView1.ShowDialog();
			});
        }
    }
}
