using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Impact
{
    public partial class Setting_impact : Form
    {
        public Setting_impact()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();
            Application.Restart();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                Process[] processesByName = Process.GetProcessesByName("ImpactTMP");
                for (int i = 0; i < processesByName.Length; i++)
                {
                    Process process = processesByName[i];
                    process.Kill();
                }
            }
            catch
            {
            }
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Process[] processesByName = Process.GetProcessesByName("RobloxPlayerBeta");
                for (int i = 0; i < processesByName.Length; i++)
                {
                    Process process = processesByName[i];
                    process.Kill();
                }
            }
            catch
            {
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Refresh();
            this.Hide();
            this.Close();
            Application.Restart();
            Application.Exit();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Only configuration.xml, discord-rpc.dll, Figgle.dll, Impact.exe, Impact.Launcher.exe, Impact.RCP.Loader.exe, Impact.vmp.dll, ScintillaNET.dll are needed!");
            System.Diagnostics.Process.Start("https://github.com/Terroriser1/ImpactUpdate/releases/");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Visible = false;
            NewStartUp NewStartUp = new NewStartUp();
            NewStartUp.ShowDialog();
            Close();
        }

        private void Setting_impact_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Process[] processesByName = Process.GetProcessesByName("Impact RCP Loader");
                for (int i = 0; i < processesByName.Length; i++)
                {
                    Process process = processesByName[i];
                    process.Kill();
                }
            }
            catch
            {
            }
        }
    }
}
