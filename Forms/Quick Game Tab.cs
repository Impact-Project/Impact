using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Impact
{
    public partial class Quick_Game_Tab : Form
    {
        public Quick_Game_Tab()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Visible = false;
            JailBreak JailBreak = new JailBreak();
            JailBreak.ShowDialog();
            Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Visible = false;
            Main main = new Main();
            main.ShowDialog();
            Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Visible = false;
            Destruction_Sim Destruction_Sim = new Destruction_Sim();
            Destruction_Sim.ShowDialog();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Visible = false;
            JailBreak JailBreak = new JailBreak();
            JailBreak.ShowDialog();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Visible = false;
            Destruction_Sim Destruction_Sim = new Destruction_Sim();
            Destruction_Sim.ShowDialog();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Visible = false;
            Main Main = new Main();
            Main.ShowDialog();
            Close();
        }

        private void Quick_Game_Tab_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void Quick_Game_Tab_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
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