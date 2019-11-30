using Impact.Properties;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Windows.Forms;

namespace Impact
{
    public partial class NewStartUp : Form
    {
        public NewStartUp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = ("Preparing Impact...");
            Refresh();
            Text = ("Preparing Impact...");
            System.Threading.Thread.Sleep(2000);
            Text = ("Finishing...");
            timer2.Stop();
            button1.Text = ("Finishing...");
            Refresh();

            if (System.IO.File.Exists(Directory.GetCurrentDirectory() + "/discord-rpc.dll"))//2
            {
            }
            else
            {
                button1.Text = ("Update Found...");
                Refresh();
                Text = ("Update Found...");
                System.Threading.Thread.Sleep(1000);
                new WebClient().DownloadFile(new Uri("https://github.com/Terroriser1/ImpactUpdate/releases/download/1.0/discord-rpc.dll"), Directory.GetCurrentDirectory() + "/discord-rpc.dll");
            }

            if (System.IO.File.Exists(Directory.GetCurrentDirectory() + "/Figgle.dll"))//3
            {
            }
            else
            {
                button1.Text = ("Update Found...");
                Refresh();
                Text = ("Update Found...");
                System.Threading.Thread.Sleep(1000);
                new WebClient().DownloadFile(new Uri("https://github.com/Terroriser1/ImpactUpdate/releases/download/1.0/Figgle.dll"), Directory.GetCurrentDirectory() + "/Figgle.dll");
            }

            if (System.IO.File.Exists(Directory.GetCurrentDirectory() + "/Impact RCP Loader.exe"))//3
            {
            }
            else
            {
                button1.Text = ("Update Found...");
                Refresh();
                Text = ("Update Found...");
                System.Threading.Thread.Sleep(1000);
                new WebClient().DownloadFile(new Uri("https://github.com/Terroriser1/ImpactUpdate/releases/download/1.0/Impact.RCP.Loader.exe"), Directory.GetCurrentDirectory() + "/Impact RCP Loader.exe");
            }

            if (System.IO.File.Exists(Directory.GetCurrentDirectory() + "/ScintillaNET.dll"))//last
            {
            }
            else
            {
                button1.Text = ("Update Found...");
                Refresh();
                Text = ("Update Found...");
                System.Threading.Thread.Sleep(1000);
                new WebClient().DownloadFile(new Uri("https://github.com/Terroriser1/ImpactUpdate/releases/download/1.0/ScintillaNET.dll"), Directory.GetCurrentDirectory() + "/ScintillaNET.dll");
            }
            WebClient wc = new WebClient();
            try
            {
                string UI = wc.DownloadString("https://impacthacks.tk/version");
                if (UI.Contains("1.5.4"))//here update!
                {
                    //  var messageBox = new MyCustomMessageBox();
                    //  messageBox.ShowDialog();
                    Visible = false;
                    Main main = new Main();
                    main.ShowDialog();
                    Close();
                }
                else
                {
                    button1.Text = ("Downloading Update...");
                    Refresh();
                    Text = ("Downloading Update...");
                    System.Threading.Thread.Sleep(1000);
                    new WebClient().DownloadFile(new Uri("https://github.com/Terroriser1/ImpactUpdate/releases/download/1.0/Impact.Launcher.exe"), Directory.GetCurrentDirectory() + "/Impact Launcher.exe");//done
                    {
                        notifyIcon1.ShowBalloonTip(2000, "Impact Update", "Impact Has a update and will now restart!", ToolTipIcon.None);
                        System.Threading.Thread.Sleep(2000);
                        {
                            Process.Start(Directory.GetCurrentDirectory() + "/Impact Launcher.exe");
                        }
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
                        Application.Exit();
                    }
                    try
                    {
                    }
                    catch
                    { }
                }
            }
            catch (Exception)
            {
                DialogResult dialogResult = MessageBox.Show("Impact Detected A error: Something went wrong Reasons: No Internet Connection, Impact server couldn't connect to your Internet, you don't have Discord, Or your firewall blocks impact: Do you want to try to continue?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
                if (dialogResult == DialogResult.Yes)
                {
                    Visible = false;
                    Main main = new Main();
                    main.ShowDialog();
                    Close();
                }
                else if (dialogResult == DialogResult.No)
                {
                    Text = "Error";
                    button1.Text = ("Error Restarting Impact...");
                    Refresh();
                    System.Threading.Thread.Sleep(2000);
                    Hide();
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
                    Process.Start(Application.StartupPath + @"\ImpactTMP.exe");
                    Application.Exit();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/channel/UCqpxXyiO2MSWD-rqEOfq8Gg");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://impacthacks.tk");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("REDACTED");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("REDACTED");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Visible = false;
            Setting_impact Setting_impact = new Setting_impact();
            Setting_impact.ShowDialog();
            Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("REDACTED");
        }

        private void GrantAccess(string fullPath)
        {
            DirectoryInfo dInfo = new DirectoryInfo(fullPath);
            DirectorySecurity dSecurity = dInfo.GetAccessControl();
            dSecurity.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.FullControl, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
            dInfo.SetAccessControl(dSecurity);
        }

        private void NewStartUp_FormClosing(object sender, FormClosingEventArgs e)
        {
            Opacity = 1;
            for (double cont = 1; cont >= 0; cont -= 0.1)
            {
                Opacity = cont;
                Refresh();
                System.Threading.Thread.Sleep(15);
            }
        }

        public class MyCustomMessageBox : Form
        {
            public string Text { get; set; }

            public MyCustomMessageBox()
            {
                MinimizeBox = false;
                MaximizeBox = false;
                Height = 100;
                TopMost = true;
                ShowIcon = false;
                FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
                SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
                StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

                Label label = new Label
                {
                    Location = new System.Drawing.Point(317, 119 + 26),
                    Name = "label",
                    Text = "",
                    Size = new System.Drawing.Size(77, 21)
                };
            }
        }

        private void NewStartUp_Load(object sender, EventArgs e)
        {
            if (Settings.Default.ShowsesDialog)
            {
                Settings.Default.ShowsesDialog = false;
                Settings.Default.Save();
                Visible = false;
                Terms Terms = new Terms();
                Terms.ShowDialog();
                Close();
            }
            // rest of code if needed
            try
            {
                new WebClient().DownloadFile(new Uri("https://github.com/Terroriser1/ImpactUpdate/releases/download/1.0/configuration.xml"), Directory.GetCurrentDirectory() + "/configuration.xml");
                //  new WebClient().DownloadFile(new Uri("https://github.com/Terroriser1/ImpactUpdate/releases/download/1.0/Impact.RCP.Loader.exe"), Directory.GetCurrentDirectory() + "/Impact RCP Loader.exe");
                Process.Start(Directory.GetCurrentDirectory() + "/Impact RCP Loader.exe");
            }
            catch (Exception)
            {
                //do nothing
            }

            try
            {
                using (WebClient client = new WebClient())
                using (client.OpenRead("https://impacthacks.tk"))
                {
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No or bad wifi connection detected you may continue but you can run into errors!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

            Refresh();

            if (System.IO.File.Exists(Directory.GetCurrentDirectory() + "/ScintillaNET.dll"))
            {
            }
            else
            {
                new WebClient().DownloadFile(new Uri("https://github.com/Terroriser1/ImpactUpdate/releases/download/1.0/ScintillaNET.dll"), Directory.GetCurrentDirectory() + "/ScintillaNET.dll");
            }
        }

        private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            {
                try
                {
                    webBrowser1.Refresh();
                }
                catch
                {
                }
            }
        }

        private void NewStartUp_FormClosed(object sender, FormClosedEventArgs e)
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

        private void button3_Click_1(object sender, EventArgs e)
        {
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
        }
    }
}