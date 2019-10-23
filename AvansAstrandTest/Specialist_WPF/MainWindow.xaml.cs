using ServerProgram.Data;
using ServerProgram.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Specialist_WPF.Communication;

namespace Specialist_WPF
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window, PatientReceivedCallback
	{
        private SpecialistClient Client;
        private Dictionary<string, Patient> PatientNamesWithData;
		public MainWindow(SpecialistClient client)
		{
			InitializeComponent();
            this.PatientNamesWithData = new Dictionary<string, Patient>();
            this.Client = client;
        }

       

        public List<string> GetPatientNames()
        {
            List<string> patientNames = new List<string>();

            foreach (Patient patientData in Client.Patients)
            {
                if (!patientNames.Contains(patientData.Name))
                {
                    patientNames.Add(patientData.Name);
                }
                this.PatientNamesWithData.Add(patientData.Name, patientData);
            }

            return patientNames;
        }

        private void NameComboBox_DropDown(object sender, EventArgs e)
        {
            UpdateNamesInNameBox();
        }

        public void UpdateNamesInNameBox()
        {
            Dispatcher.Invoke( () =>  this.NameComboBox.Items.Clear());
            foreach (String name in GetPatientNames())
            {
                Dispatcher.Invoke(()=> this.NameComboBox.Items.Add(name));
            }
            
        }

        private void NameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dispatcher.Invoke(() => this.SessionComboBox.Items.Clear());
            string SelectedName = this.NameComboBox.SelectedItem.ToString();

            foreach (Patient patient in PatientNamesWithData.Values)
            {
                if (patient.Name == SelectedName)
                {
                    Dispatcher.Invoke(() =>this.SessionComboBox.Items.Add(patient));
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
            SessionWindow session1 = new SessionWindow(this.SessionComboBox.SelectedItem as Patient);
            session1.ShowDialog();
            
        }
    }
}
