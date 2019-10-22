using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ergometer
{
    public partial class ActiveWorkoutView : Form
    {
        public ActiveWorkoutView()
        {
            InitializeComponent();
            WarmingUpView warmingUpView = this.warmingUpView1;
            TestView testView = this.testView1;


            warmingUpView.AttachStateCallback(testView);


        }
    }
}
