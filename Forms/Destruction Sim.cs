using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Impact
{
    public partial class Destruction_Sim : Form
    {
        public Destruction_Sim()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Visible = false;
            Quick_Game_Tab Quick_Game_Tab = new Quick_Game_Tab();
            Quick_Game_Tab.ShowDialog();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NamedPipes.CommandPipe("shop");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NamedPipes.CommandPipe("highway");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            NamedPipes.CommandPipe("home");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NamedPipes.CommandPipe("site");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            NamedPipes.CommandPipe("ship");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            NamedPipes.CommandPipe("space");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            NamedPipes.CommandPipe("camp");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            NamedPipes.CommandPipe("pillar");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            NamedPipes.CommandPipe("castle");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            NamedPipes.CommandPipe("empire");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            NamedPipes.CommandPipe("farm");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            NamedPipes.CommandPipe("sell");
        }

        private void Destruction_Sim_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void Destruction_Sim_FormClosed(object sender, FormClosedEventArgs e)
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