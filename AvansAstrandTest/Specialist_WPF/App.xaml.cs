using Specialist_WPF.Communication;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Specialist_WPF
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
        public App()
        {
            SpecialistClient client = new SpecialistClient();
            client.Connect("localhost", 5678);

            MainWindow mainWindow = new MainWindow(client);
            
            client.AttachPatientReceivedCallback(mainWindow);
            mainWindow.ShowDialog();
        }
	}
}
