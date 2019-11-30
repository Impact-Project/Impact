using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Impact
{
    public partial class Terms : Form
    {
        public Terms()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Visible = false;
            NewStartUp NewStartUp = new NewStartUp();
            NewStartUp.ShowDialog();
            Close();
        }

        private void Terms_FormClosed(object sender, FormClosedEventArgs e)
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