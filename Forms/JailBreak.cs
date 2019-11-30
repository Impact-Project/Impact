using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Impact
{
    public partial class JailBreak : Form
    {
        public JailBreak()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                NamedPipes.CommandPipe("bank");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NamedPipes.CommandPipe("prison");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Visible = false;
            Quick_Game_Tab Quick_Game_Tab = new Quick_Game_Tab();
            Quick_Game_Tab.ShowDialog();
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            NamedPipes.CommandPipe("helispawn");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NamedPipes.CommandPipe("jewelry");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            NamedPipes.CommandPipe("garage");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            NamedPipes.CommandPipe("criminal");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            NamedPipes.CommandPipe("gravity 50");
        }

        private void JailBreak_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void JailBreak_FormClosed(object sender, FormClosedEventArgs e)
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