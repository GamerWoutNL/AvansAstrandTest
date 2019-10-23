using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using ServerProgram.Data;

namespace Specialist
{
    public partial class SessionViewForm : Form
    {
        public SessionViewForm(Patient patient)
        {
            InitializeComponent();

            this.NameLabel.Text = $"Patient naam: {patient.Name}";
            this.AgeLabel.Text = $"Patient leeftijd: {patient.Age}";
            this.GenderLabel.Text = $"Patient geslacht: {patient.Gender.ToString()}";
            this.WeightLabel.Text = $"Patient gewicht: {patient.Weight} kg";
            this.VO2Label.Text = $"VO2 Max: {patient.Session.VO2Max} ml/kg/min";

            patient.Session.HeartrateDataPoints.Sort((x, y) => x.Time.CompareTo(y.Time));
            patient.Session.InstantaniousCadenceDataPoints.Sort((x, y) => x.Time.CompareTo(y.Time));
            patient.Session.InstantaniousPowerDataPoints.Sort((x, y) => x.Time.CompareTo(y.Time));

            ChartValues<DateTimePoint> HeartratePoints = new ChartValues<DateTimePoint>();
            foreach (DataPoint dataPoint in patient.Session.HeartrateDataPoints) HeartratePoints.Add(new DateTimePoint(dataPoint.Time, dataPoint.Data));

            ChartValues<DateTimePoint> CadencePoints = new ChartValues<DateTimePoint>();
            foreach (DataPoint dataPoint in patient.Session.InstantaniousCadenceDataPoints) CadencePoints.Add(new DateTimePoint(dataPoint.Time, dataPoint.Data));

            ChartValues<DateTimePoint> PowerPoints = new ChartValues<DateTimePoint>();
            foreach (DataPoint dataPoint in patient.Session.InstantaniousPowerDataPoints) PowerPoints.Add(new DateTimePoint(dataPoint.Time, dataPoint.Data));

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
