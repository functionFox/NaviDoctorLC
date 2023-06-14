using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NaviDoctor
{
    public partial class AboutUs : Form
    {
        public AboutUs()
        {
            InitializeComponent();
            lblVersion.Text = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Version}";
        }

        private void linkLabel_functionFox_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/functionFox");
        }

        private void linkLabel_Dillonzer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Dillonzer");
        }

        private void linkLabel_github_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/functionFox/NaviDoctorLC");
       
        }

        private void linkLabel_Issue_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/functionFox/NaviDoctorLC/issues");

        }
    }
}
