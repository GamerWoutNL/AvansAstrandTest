using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using ServerProgram.Data;
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
using System.Windows.Shapes;

namespace Specialist_WPF
{
    /// <summary>
    /// Interaction logic for SessionWindow.xaml
    /// </summary>
    public partial class SessionWindow : Window
    {
        private Patient patient;

        public SessionWindow(Patient patient)
        {
            InitializeComponent();
            this.patient = patient;

            this.NameLabel.Content = $"Patient naam: {patient.Name}";
            this.AgeLabel.Content = $"Patient leeftijd: {patient.Age}";
            this.GenderLabel.Content = $"Patient geslacht: {patient.Gender.ToString()}";
            this.WeightLabel.Content = $"Patient gewicht: {patient.Weight} kg";
            this.VO2Label.Content = $"VO2 Max: {patient.Session.VO2Max} ml/kg/min";

            patient.Session.HeartrateDataPoints.Sort((x, y) => x.Time.CompareTo(y.Time));
            patient.Session.InstantaniousCadenceDataPoints.Sort((x, y) => x.Time.CompareTo(y.Time));
            patient.Session.InstantaniousPowerDataPoints.Sort((x, y) => x.Time.CompareTo(y.Time));

            DateTime firstRecorderTime = this.patient.Session.HeartrateDataPoints.First().Time;
            ChartValues<ObservablePoint> HeartratePoints = new ChartValues<ObservablePoint>();
            foreach (DataPoint dataPoint in patient.Session.HeartrateDataPoints)
            {
                if ((dataPoint.Time - firstRecorderTime).TotalSeconds % 5 == 0) HeartratePoints.Add(new ObservablePoint((dataPoint.Time - firstRecorderTime).TotalSeconds, dataPoint.Data));
            }

            ChartValues<ObservablePoint> CadencePoints = new ChartValues<ObservablePoint>();
            foreach (DataPoint dataPoint in patient.Session.InstantaniousCadenceDataPoints)
            {
                if ((dataPoint.Time - firstRecorderTime).TotalSeconds % 5 == 0) CadencePoints.Add(new ObservablePoint((dataPoint.Time - firstRecorderTime).TotalSeconds, dataPoint.Data));
            }

            ChartValues<ObservablePoint> PowerPoints = new ChartValues<ObservablePoint>();
            foreach (DataPoint dataPoint in patient.Session.InstantaniousPowerDataPoints)
            {
                if((dataPoint.Time - firstRecorderTime).TotalSeconds % 5 == 0) PowerPoints.Add(new ObservablePoint((dataPoint.Time - firstRecorderTime).TotalSeconds, dataPoint.Data));
            }
            this.Chart.Series = new LiveCharts.SeriesCollection
            {
                new LineSeries
                {
                    Title = "Heartrate",
                    Values = HeartratePoints
                },
                new LineSeries
                {
                    Title = "Cadence",
                    Values = CadencePoints
                },
                new LineSeries
                {
                    Title = "Instant Power",
                    Values = PowerPoints
                }
            };
        }
    }
}
