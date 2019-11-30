using Impact.Properties;
using ScintillaNET;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Impact
{
    public partial class Main : Form
    {
        [DllImport("winmm.dll")]
        private static extern int mciSendString(string command, string buffer, long bufferSize, long hwndCallback);

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        private static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

        [DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
        private static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out UIntPtr lpNumberOfBytesWritten);

        [DllImport("kernel32.dll")]
        private static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        public Main()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (NamedPipes.NamedPipeExist(NamedPipes.scriptpipe))//check if the pipe exist
            {
                new Thread(() =>//lets run this in another thread so if roblox crash the ui/gui don't freeze
                {
                    string[] array = richTextBox1.Text.Split("\r\n".ToCharArray());//array to store all and split the script
                    for (int i = 0; i < array.Length; i++)//for loop to send all the lines
                    {
                        string script = array[i];
                        try
                        {
                            NamedPipes.LuaCPipe(script);//lua c pipe function to send the array
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString());//if there any error a messagebox will pop up with the error
                        }
                    }
                }).Start();
            }
            else
            {
                MessageBox.Show("Inject " + Functions.exploitdll + " before Using this!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//if the pipe can't be found a messagebox will appear
                return;
            }
        }

        private void LuaExe_Click(object sender, EventArgs e)
        {
            if (NamedPipes.NamedPipeExist(NamedPipes.scriptpipe))//check if the pipe exist
            {
                new Thread(() =>//lets run this in another thread so if roblox crash the ui/gui don't freeze
                {
                    string[] array = Lua.Text.Split("\r\n".ToCharArray());//array to store all and split the script
                    for (int i = 0; i < array.Length; i++)//for loop to send all the lines
                    {
                        string script = array[i];
                        try
                        {
                            NamedPipes.MemeLua(script);//lua c pipe function to send the array
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString());//if there any error a messagebox will pop up with the error
                        }
                    }
                }).Start();
            }
            else
            {
                MessageBox.Show("Inject " + Functions.exploitdll + " before Using this!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//if the pipe can't be found a messagebox will appear
                return;
            }
        }

        private void Send_Click(object sender, EventArgs e)
        {
            if (CmdTextBox.Text.ToLower() == "cmdsawdawdawsawd")//check if the user send cmds so we can display the commands
            {
                CmdBox.AppendText(Functions.TextToBox[0]);//Append text to the command richtextbox
                CmdTextBox.Clear();//clear the command textbox

                CmdBox.AppendText(Functions.TextToBox[0]);//Append text to the command richtextbox
                CmdTextBox2.Clear();//clear the command textbox
            }
            else if (CmdTextBox.Text.ToLower() == "creditsadasawdawsaw")
            {
                ;//check if the user send credits so we can display the credits
            }
            else if (CmdTextBox2.Text.ToLower() == "creditssawdawsaws")//check if the user send credits so we can display the credits
            {
                CmdBox.AppendText(Functions.TextToBox[1]);//Append text to the command richtextbox
                CmdTextBox.Clear();//clear the command textbox

                CmdBox.AppendText(Functions.TextToBox[1]);//Append text to the command richtextbox
                CmdTextBox2.Clear();//clear the command textbox
            }
            else if (CmdTextBox2.Text.ToLower() == "cleaasawwsar")
            {
                ;//check if the user send clear so we can clear the CmdBox
            }
            else if (CmdTextBox.Text.ToLower() == "cleawdasawdar")//check if the user send clear so we can clear the CmdBox
            {
                CmdBox.Clear();//clear the CmdBox
                CmdTextBox.Clear();//Clear the command textbox

                CmdBox.Clear();//clear the CmdBox
                CmdTextBox2.Clear();//Clear the command textbox
            }
            else
            {
                NamedPipes.CommandPipe(CmdTextBox.Text);//command pipe function to send the text in the command textbox
                CmdBox.AppendText("\n>" + CmdTextBox.Text);//add the used command to CmdBox
                CmdTextBox.Clear();//clear the command textbox

                NamedPipes.CommandPipe(CmdTextBox2.Text);//command pipe function to send the text in the command textbox
                CmdTextBox2.Clear();//clear the command textbox
            }
        }

        private void CmdBox_TextChanged(object sender, EventArgs e)
        {
            CmdBox.SelectionStart = CmdBox.Text.Length;//this get all the text
            CmdBox.ScrollToCaret();//so with this we can scroll to the bottom
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (NamedPipes.NamedPipeExist(NamedPipes.scriptpipe))//check if the pipe exist
            {
                string[] array = textBox12.Text.Split("\r\n".ToCharArray());//array to store all and split the script
                for (int i = 0; i < array.Length; i++)//for loop to send all the lines
                {
                    string script = array[i];
                    try
                    {
                        NamedPipes.LuaCPipe(script);//lua c pipe function to send the array
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());//if there any error a messagebox will pop up with the error
                    }
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (NamedPipes.NamedPipeExist(NamedPipes.scriptpipe))//check if the pipe exist
            {
                string[] array = textBox7.Text.Split("\r\n".ToCharArray());//array to store all and split the script
                for (int i = 0; i < array.Length; i++)//for loop to send all the lines
                {
                    string script = array[i];
                    try
                    {
                        NamedPipes.LuaCPipe(script);//lua c pipe function to send the array
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());//if there any error a messagebox will pop up with the error
                    }
                }
            }
            else
            {
                MessageBox.Show("Inject " + Functions.exploitdll + " before Using this!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//if the pipe can't be found a messagebox will appear
                return;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (NamedPipes.NamedPipeExist(NamedPipes.scriptpipe))//check if the pipe exist
            {
                string[] array = textBox22.Text.Split("\r\n".ToCharArray());//array to store all and split the script
                for (int i = 0; i < array.Length; i++)//for loop to send all the lines
                {
                    string script = array[i];
                    try
                    {
                        NamedPipes.LuaCPipe(script);//lua c pipe function to send the array
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());//if there any error a messagebox will pop up with the error
                    }
                }
            }
            else
            {
                MessageBox.Show("Inject " + Functions.exploitdll + " before Using this!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//if the pipe can't be found a messagebox will appear
                return;
            }
        }

        private void button42_Click(object sender, EventArgs e)
        {
            NamedPipes.CommandPipe("play 1238023022");
        }

        private void button19_Click(object sender, EventArgs e)
        {
            NamedPipes.CommandPipe("play 284057221");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (NamedPipes.NamedPipeExist(NamedPipes.scriptpipe))//check if the pipe exist
            {
                string[] array = textBox59.Text.Split("\r\n".ToCharArray());//array to store all and split the script
                for (int i = 0; i < array.Length; i++)//for loop to send all the lines
                {
                    string script = array[i];
                    try
                    {
                        NamedPipes.LuaCPipe(script);//lua c pipe function to send the array
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());//if there any error a messagebox will pop up with the error
                    }
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            NamedPipes.CommandPipe("rfog"); //you can see again :D
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (NamedPipes.NamedPipeExist(NamedPipes.scriptpipe))//check if the pipe exist
            {
                string[] array = textBox19.Text.Split("\r\n".ToCharArray());//array to store all and split the script
                for (int i = 0; i < array.Length; i++)//for loop to send all the lines
                {
                    string script = array[i];
                    try
                    {
                        NamedPipes.LuaCPipe(script);//lua c pipe function to send the array
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());//if there any error a messagebox will pop up with the error
                    }
                }
            }
            else
            {
                MessageBox.Show("Inject " + Functions.exploitdll + " before Using this!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//if the pipe can't be found a messagebox will appear
                return;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (NamedPipes.NamedPipeExist(NamedPipes.scriptpipe))//check if the pipe exist
            {
                string[] array = textBox14.Text.Split("\r\n".ToCharArray());//array to store all and split the script
                for (int i = 0; i < array.Length; i++)//for loop to send all the lines
                {
                    string script = array[i];
                    try
                    {
                        NamedPipes.LuaCPipe(script);//lua c pipe function to send the array
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());//if there any error a messagebox will pop up with the error
                    }
                }
            }
            else
            {
                MessageBox.Show("Inject " + Functions.exploitdll + " before Using this!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//if the pipe can't be found a messagebox will appear
                return;
            }
        }

        private void button40_Click(object sender, EventArgs e)
        {
            if (NamedPipes.NamedPipeExist(NamedPipes.scriptpipe))//check if the pipe exist
            {
                string[] array = textBox15.Text.Split("\r\n".ToCharArray());//array to store all and split the script
                for (int i = 0; i < array.Length; i++)//for loop to send all the lines
                {
                    string script = array[i];
                    try
                    {
                        NamedPipes.LuaCPipe(script);//lua c pipe function to send the array
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());//if there any error a messagebox will pop up with the error
                    }
                }
            }
            else
            {
                MessageBox.Show("Inject " + Functions.exploitdll + " before Using this!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//if the pipe can't be found a messagebox will appear
                return;
            }
        }

        private void button43_Click(object sender, EventArgs e)
        {
            NamedPipes.CommandPipe("bigfire me");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            NamedPipes.CommandPipe("play 743478138");
        }

        private void button24_Click(object sender, EventArgs e)
        {
            NamedPipes.CommandPipe("ws me 16");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            NamedPipes.CommandPipe("jp me 50");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (NamedPipes.NamedPipeExist(NamedPipes.scriptpipe))//check if the pipe exist
            {
                string[] array = textBox8.Text.Split("\r\n".ToCharArray());//array to store all and split the script
                for (int i = 0; i < array.Length; i++)//for loop to send all the lines
                {
                    string script = array[i];
                    try
                    {
                        NamedPipes.LuaCPipe(script);//lua c pipe function to send the array
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());//if there any error a messagebox will pop up with the error
                    }
                }
            }
            else
            {
                MessageBox.Show("Inject " + Functions.exploitdll + " before Using this!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//if the pipe can't be found a messagebox will appear
                return;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (NamedPipes.NamedPipeExist(NamedPipes.scriptpipe))//check if the pipe exist
            {
                string[] array = textBox20.Text.Split("\r\n".ToCharArray());//array to store all and split the script
                for (int i = 0; i < array.Length; i++)//for loop to send all the lines
                {
                    string script = array[i];
                    try
                    {
                        NamedPipes.LuaCPipe(script);//lua c pipe function to send the array
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());//if there any error a messagebox will pop up with the error
                    }
                }
            }
        }

        private void button41_Click(object sender, EventArgs e)
        {
            if (NamedPipes.NamedPipeExist(NamedPipes.scriptpipe))//check if the pipe exist
            {
                string[] array = textBox16.Text.Split("\r\n".ToCharArray());//array to store all and split the script
                for (int i = 0; i < array.Length; i++)//for loop to send all the lines
                {
                    string script = array[i];
                    try
                    {
                        NamedPipes.LuaCPipe(script);//lua c pipe function to send the array
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());//if there any error a messagebox will pop up with the error
                    }
                }
            }
            else
            {
                MessageBox.Show("Inject " + Functions.exploitdll + " before Using this!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//if the pipe can't be found a messagebox will appear
                return;
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (NamedPipes.NamedPipeExist(NamedPipes.scriptpipe))//check if the pipe exist
            {
                string[] array = textBox1.Text.Split("\r\n".ToCharArray());//array to store all and split the script
                for (int i = 0; i < array.Length; i++)//for loop to send all the lines
                {
                    string script = array[i];
                    try
                    {
                        NamedPipes.LuaCPipe(script);//lua c pipe function to send the array
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());//if there any error a messagebox will pop up with the error
                    }
                }
            }
            else
            {
                MessageBox.Show("Inject " + Functions.exploitdll + " before Using this!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//if the pipe can't be found a messagebox will appear
                return;
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            NamedPipes.CommandPipe("play 568877159");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            NamedPipes.CommandPipe("ws me 200");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            NamedPipes.CommandPipe("jp me 200");
        }

        private void button21_Click(object sender, EventArgs e)
        {
            NamedPipes.CommandPipe("smoke me");
        }

        private void button29_Click(object sender, EventArgs e)
        {
            NamedPipes.CommandPipe("fire me");
        }

        private void button28_Click(object sender, EventArgs e)
        {
            NamedPipes.CommandPipe("baseplate delete");
        }

        private void button27_Click(object sender, EventArgs e)
        {
            if (NamedPipes.NamedPipeExist(NamedPipes.scriptpipe))//check if the pipe exist
            {
                string[] array = textBox2.Text.Split("\r\n".ToCharArray());//array to store all and split the script
                for (int i = 0; i < array.Length; i++)//for loop to send all the lines
                {
                    string script = array[i];
                    try
                    {
                        NamedPipes.LuaCPipe(script);//lua c pipe function to send the array
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());//if there any error a messagebox will pop up with the error
                    }
                }
            }
        }

        private void button34_Click(object sender, EventArgs e)
        {
            if (NamedPipes.NamedPipeExist(NamedPipes.scriptpipe))//check if the pipe exist
            {
                string[] array = textBox3.Text.Split("\r\n".ToCharArray());//array to store all and split the script
                for (int i = 0; i < array.Length; i++)//for loop to send all the lines
                {
                    string script = array[i];
                    try
                    {
                        NamedPipes.LuaCPipe(script);//lua c pipe function to send the array
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());//if there any error a messagebox will pop up with the error
                    }
                }
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            NamedPipes.CommandPipe("heaven me");
        }

        private void button22_Click(object sender, EventArgs e)
        {
            NamedPipes.CommandPipe("gravity 0");
        }

        private void button23_Click(object sender, EventArgs e)
        {
            NamedPipes.CommandPipe("gravity 100");
        }

        private int Inject(string dllName)
        {
            {
            }
            try
            {
                Process process = Process.GetProcessesByName("RobloxPlayerBeta")[0];
                if (process != null)
                {
                    if (process.MainWindowHandle.ToInt32() != 0)
                    {
                        IntPtr hProcess = Main.OpenProcess(1082, false, process.Id);
                        IntPtr procAddress = Main.GetProcAddress(Main.GetModuleHandle("kernel32.dll"), "LoadLibraryA");
                        IntPtr intPtr = Main.VirtualAllocEx(hProcess, IntPtr.Zero, (uint)((dllName.Length + 1) * Marshal.SizeOf(typeof(char))), 12288u, 4u);
                        Main.WriteProcessMemory(hProcess, intPtr, Encoding.Default.GetBytes(dllName), (uint)((dllName.Length + 1) * Marshal.SizeOf(typeof(char))), out UIntPtr uintPtr);
                        Main.CreateRemoteThread(hProcess, IntPtr.Zero, 0u, procAddress, intPtr, 0u, IntPtr.Zero);
                        Text = "Impact [Hooked]";
                    }
                }
            }
            catch (Exception)
            {
                Text = "Impact";
            }
            return 0;
        }

        protected void textBox18_SetText()
        {
            CmdTextBox2.Text = "Commands...";
            CmdTextBox2.ForeColor = Color.Gray;
        }

        private void textBox18_Enter(object sender, EventArgs e)
        {
            if (textBox2.ForeColor == Color.Black)
            {
                return;
            }

            CmdTextBox2.Text = "";
            CmdTextBox2.ForeColor = Color.White;
        }

        private void textBox18_Leave(object sender, EventArgs e)
        {
            if (CmdTextBox2.Text.Trim() == "")
            {
                textBox18_SetText();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                using (WebClient client = new WebClient())
                using (client.OpenRead("https://impacthacks.tk"))
                {
                }
            }
            catch (Exception)
            {
                MessageBox.Show("You have chosen to try to continue we warn you, you can run in some issues!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            Hide();
            WebClient wc = new WebClient();
            string UI = wc.DownloadString("https://impacthacks.tk/version");
            if (UI.Contains("1.5.4"))//here update!
            {
            }
            else
            {
                Injector.Dispose();
                MessageBox.Show("Impact Needs to install update impact will now restart.");
                Hide();
                {
                    Process.Start(Directory.GetCurrentDirectory() + "/Impact");
                }
                Application.Exit();
            }
            CmdTextBox2.Enter += new EventHandler(textBox18_Enter);
            CmdTextBox2.Leave += new EventHandler(textBox18_Leave);
            textBox18_SetText();
            Lua.Styles[32].Font = "Consolas";
            Lua.Styles[32].Size = 10;
            Lua.SetSelectionBackColor(true, Color.FromArgb(1133980));
            Lua.Margins[1].Width = 0;
            Lua.StyleResetDefault();
            Lua.Styles[32].BackColor = Color.FromArgb(0, 20, 20, 20);
            Lua.Styles[32].ForeColor = Color.FromArgb(16777215);
            Lua.StyleClearAll();
            Lua.Styles[11].ForeColor = Color.FromArgb(13687522);
            Lua.Styles[1].ForeColor = Color.FromArgb(12416395);
            Lua.Styles[2].ForeColor = Color.FromArgb(4243287);
            Lua.Styles[3].ForeColor = Color.FromArgb(3124789);
            Lua.Styles[4].ForeColor = Color.FromArgb(16776960);
            Lua.Styles[6].ForeColor = Color.FromArgb(16776960);
            Lua.Styles[7].ForeColor = Color.FromArgb(15291476);
            Lua.Styles[9].ForeColor = Color.FromArgb(9089006);
            Lua.Styles[10].ForeColor = Color.FromArgb(14737632);
            Lua.Styles[5].ForeColor = Color.FromArgb(4761838);
            Lua.Styles[13].ForeColor = Color.FromArgb(4761838);
            Lua.Styles[13].Bold = true;
            Lua.Styles[14].ForeColor = Color.FromArgb(16353542);
            Lua.Styles[14].Bold = true;
            Lua.Lexer = Lexer.Lua;
            Lua.SetProperty("fold", "1");
            Lua.SetProperty("fold.compact", "1");
            Lua.Margins[0].Width = 15;
            Lua.Margins[0].Type = MarginType.Number;
            Lua.Margins[1].Type = MarginType.Symbol;
            Lua.Margins[1].Mask = 4261412864u;
            Lua.Margins[1].Sensitive = true;
            Lua.Margins[1].Width = 10;
            for (int i = 25; i <= 31; i++)
            {
                Lua.Markers[i].SetForeColor(SystemColors.ControlLightLight);
                Lua.Markers[i].SetBackColor(SystemColors.ControlDark);
            }
            Lua.Markers[30].Symbol = MarkerSymbol.BoxPlus;
            Lua.Markers[31].Symbol = MarkerSymbol.BoxMinus;
            Lua.Markers[25].Symbol = MarkerSymbol.BoxPlusConnected;
            Lua.Markers[27].Symbol = MarkerSymbol.TCorner;
            Lua.Markers[26].Symbol = MarkerSymbol.BoxMinusConnected;
            Lua.Markers[29].Symbol = MarkerSymbol.VLine;
            Lua.Markers[28].Symbol = MarkerSymbol.LCorner;
            Lua.Styles[33].BackColor = Color.FromArgb(2368548);
            Lua.AutomaticFold = (AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change);
            Lua.SetFoldMarginColor(true, Color.FromArgb(2500134));
            Lua.SetFoldMarginHighlightColor(true, Color.FromArgb(2500134));
            Lua.SetKeywords(0, "and break do else elseif end false for function if in local nil not or repeat return then true until while");
            Lua.SetKeywords(1, "warn CFrame CFrame.fromEulerAnglesXYZ CFrame.Angles CFrame.fromAxisAngle CFrame.new gcinfo os os.difftime os.time tick UDim UDim.new Instance Instance.Lock Instance.Unlock Instance.new pairs NumberSequence NumberSequence.new assert tonumber getmetatable Color3 Color3.fromHSV Color3.toHSV Color3.fromRGB Color3.new load Stats _G UserSettings Ray Ray.new coroutine coroutine.resume coroutine.yield coroutine.status coroutine.wrap coroutine.create coroutine.running NumberRange NumberRange.new PhysicalProperties PhysicalProperties.new printidentity PluginManager loadstring NumberSequenceKeypoint NumberSequenceKeypoint.new Version Vector2 Vector2.new wait Game delay spawn string string.sub string.upper string.len string.gfind string.rep string.find string.match string.char string.dump string.gmatch string.reverse string.byte string.format string.gsub string.lower CellId CellId.new Delay version stats typeof UDim2 UDim2.new table table.setn table.insert table.getn table.foreachi table.maxn table.foreach table.concat table.sort table.remove settings LoadLibrary require Vector3 Vector3.FromNormalId Vector3.FromAxis Vector3.new Vector3int16 Vector3int16.new setmetatable next ypcall ipairs Wait rawequal Region3int16 Region3int16.new collectgarbage game newproxy Spawn elapsedTime Region3 Region3.new time xpcall shared rawset tostring print Workspace Vector2int16 Vector2int16.new workspace unpack math math.log math.noise math.acos math.huge math.ldexp math.pi math.cos math.tanh math.pow math.deg math.tan math.cosh math.sinh math.random math.randomseed math.frexp math.ceil math.floor math.rad math.abs math.sqrt math.modf math.asin math.min math.max math.fmod math.log10 math.atan2 math.exp math.sin math.atan ColorSequenceKeypoint ColorSequenceKeypoint.new pcall getfenv ColorSequence ColorSequence.new type ElapsedTime select Faces Faces.new rawget debug debug.traceback debug.profileend debug.profilebegin Rect Rect.new BrickColor BrickColor.Blue BrickColor.White BrickColor.Yellow BrickColor.Red BrickColor.Gray BrickColor.palette BrickColor.New BrickColor.Black BrickColor.Green BrickColor.Random BrickColor.DarkGray BrickColor.random BrickColor.new setfenv dofile Axes Axes.new error loadfile ");
            Lua.SetKeywords(2, "getfield getgenv endscript changereadonly setscriptobj getupvalue proto get_nil_instances getrawmetatable get_thread_context getscriptfunc test getregistry getrenv _G setlp getlocal special console_print lproto readfile bctolua getobjects is_protosmasher_closure create_ebc getupvalues getlocals checkreadonly decompile is_protosmasher_func loadstring load_ebc dumpfunc shared copystr writefile bcloadstring loadfile ");
            Lua.ScrollWidth = 1;
            Lua.ScrollWidthTracking = true;
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////
            richTextBox1.Styles[32].Font = "Consolas";
            richTextBox1.Styles[32].Size = 10;
            richTextBox1.SetSelectionBackColor(true, Color.FromArgb(1133980));
            richTextBox1.Margins[1].Width = 0;
            richTextBox1.StyleResetDefault();
            richTextBox1.Styles[32].BackColor = Color.FromArgb(0, 20, 20, 20);
            richTextBox1.Styles[32].ForeColor = Color.FromArgb(16777215);
            richTextBox1.StyleClearAll();
            richTextBox1.Styles[11].ForeColor = Color.FromArgb(13687522);
            richTextBox1.Styles[1].ForeColor = Color.FromArgb(12416395);
            richTextBox1.Styles[2].ForeColor = Color.FromArgb(4243287);
            richTextBox1.Styles[3].ForeColor = Color.FromArgb(3124789);
            richTextBox1.Styles[4].ForeColor = Color.FromArgb(16776960);
            richTextBox1.Styles[6].ForeColor = Color.FromArgb(16776960);
            richTextBox1.Styles[7].ForeColor = Color.FromArgb(15291476);
            richTextBox1.Styles[9].ForeColor = Color.FromArgb(9089006);
            richTextBox1.Styles[10].ForeColor = Color.FromArgb(14737632);
            richTextBox1.Styles[5].ForeColor = Color.FromArgb(4761838);
            richTextBox1.Styles[13].ForeColor = Color.FromArgb(4761838);
            richTextBox1.Styles[13].Bold = true;
            richTextBox1.Styles[14].ForeColor = Color.FromArgb(16353542);
            richTextBox1.Styles[14].Bold = true;
            richTextBox1.Lexer = Lexer.Lua;
            richTextBox1.SetProperty("fold", "1");
            richTextBox1.SetProperty("fold.compact", "1");
            richTextBox1.Margins[0].Width = 15;
            richTextBox1.Margins[0].Type = MarginType.Number;
            richTextBox1.Margins[1].Type = MarginType.Symbol;
            richTextBox1.Margins[1].Mask = 4261412864u;
            richTextBox1.Margins[1].Sensitive = true;
            richTextBox1.Margins[1].Width = 10;
            for (int i = 25; i <= 31; i++)
            {
                richTextBox1.Markers[i].SetForeColor(SystemColors.ControlLightLight);
                richTextBox1.Markers[i].SetBackColor(SystemColors.ControlDark);
            }
            richTextBox1.Markers[30].Symbol = MarkerSymbol.BoxPlus;
            richTextBox1.Markers[31].Symbol = MarkerSymbol.BoxMinus;
            richTextBox1.Markers[25].Symbol = MarkerSymbol.BoxPlusConnected;
            richTextBox1.Markers[27].Symbol = MarkerSymbol.TCorner;
            richTextBox1.Markers[26].Symbol = MarkerSymbol.BoxMinusConnected;
            richTextBox1.Markers[29].Symbol = MarkerSymbol.VLine;
            richTextBox1.Markers[28].Symbol = MarkerSymbol.LCorner;
            richTextBox1.Styles[33].BackColor = Color.FromArgb(2368548);
            richTextBox1.AutomaticFold = (AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change);
            richTextBox1.SetFoldMarginColor(true, Color.FromArgb(2500134));
            richTextBox1.SetFoldMarginHighlightColor(true, Color.FromArgb(2500134));
            richTextBox1.SetKeywords(0, "and break do else elseif end false for function if in local nil not or repeat return then true until while");
            richTextBox1.SetKeywords(1, "warn CFrame CFrame.fromEulerAnglesXYZ CFrame.Angles CFrame.fromAxisAngle CFrame.new gcinfo os os.difftime os.time tick UDim UDim.new Instance Instance.Lock Instance.Unlock Instance.new pairs NumberSequence NumberSequence.new assert tonumber getmetatable Color3 Color3.fromHSV Color3.toHSV Color3.fromRGB Color3.new load Stats _G UserSettings Ray Ray.new coroutine coroutine.resume coroutine.yield coroutine.status coroutine.wrap coroutine.create coroutine.running NumberRange NumberRange.new PhysicalProperties PhysicalProperties.new printidentity PluginManager loadstring NumberSequenceKeypoint NumberSequenceKeypoint.new Version Vector2 Vector2.new wait Game delay spawn string string.sub string.upper string.len string.gfind string.rep string.find string.match string.char string.dump string.gmatch string.reverse string.byte string.format string.gsub string.lower CellId CellId.new Delay version stats typeof UDim2 UDim2.new table table.setn table.insert table.getn table.foreachi table.maxn table.foreach table.concat table.sort table.remove settings LoadLibrary require Vector3 Vector3.FromNormalId Vector3.FromAxis Vector3.new Vector3int16 Vector3int16.new setmetatable next ypcall ipairs Wait rawequal Region3int16 Region3int16.new collectgarbage game newproxy Spawn elapsedTime Region3 Region3.new time xpcall shared rawset tostring print Workspace Vector2int16 Vector2int16.new workspace unpack math math.log math.noise math.acos math.huge math.ldexp math.pi math.cos math.tanh math.pow math.deg math.tan math.cosh math.sinh math.random math.randomseed math.frexp math.ceil math.floor math.rad math.abs math.sqrt math.modf math.asin math.min math.max math.fmod math.log10 math.atan2 math.exp math.sin math.atan ColorSequenceKeypoint ColorSequenceKeypoint.new pcall getfenv ColorSequence ColorSequence.new type ElapsedTime select Faces Faces.new rawget debug debug.traceback debug.profileend debug.profilebegin Rect Rect.new BrickColor BrickColor.Blue BrickColor.White BrickColor.Yellow BrickColor.Red BrickColor.Gray BrickColor.palette BrickColor.New BrickColor.Black BrickColor.Green BrickColor.Random BrickColor.DarkGray BrickColor.random BrickColor.new setfenv dofile Axes Axes.new error loadfile ");
            richTextBox1.SetKeywords(2, "getfield getgenv endscript changereadonly setscriptobj getupvalue proto get_nil_instances getrawmetatable get_thread_context getscriptfunc test getregistry getrenv _G setlp getlocal special console_print lproto readfile bctolua getobjects is_protosmasher_closure create_ebc getupvalues getlocals checkreadonly decompile is_protosmasher_func loadstring load_ebc dumpfunc shared copystr writefile bcloadstring loadfile ");
            richTextBox1.ScrollWidth = 1;
            richTextBox1.ScrollWidthTracking = true;
            Show();
            //////////////////////////////////////////////////////////
            try
            {
            }
            catch
            { }
            Injector.Start();
            listBox2.Items.Clear();
            listBox4.Items.Clear();
            try
            {
                Functions.PopulateListBox(listBox2, "./LuaCScripts", "*.txt");//Populate weak Lua C shit
                Functions.PopulateListBox(listBox4, "./LuaScripts", "*.txt");
            }
            catch (Exception)
            {
            }
            if (Settings.Default.Discord)
            {
                Settings.Default.Discord = false;
                Settings.Default.Save();
                System.Diagnostics.Process.Start("discord:///invite/rQUA74S");
            }
            // rest of code if needed
        }

        private bool InjectOk = true;
        private int startindex;
        private int startIndex;

        private void Injector_Tick(object sender, EventArgs e)
        {
            bool injectOk = InjectOk;
            if (injectOk)
            {
                try
                {
                    Inject(AppDomain.CurrentDomain.BaseDirectory + "/Impact.vmp.dll");
                    Task.Delay(700);
                }
                catch
                {
                }
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            if (NamedPipes.NamedPipeExist(NamedPipes.scriptpipe))//check if the pipe exist
            {
                string[] array = textBox5.Text.Split("\r\n".ToCharArray());//array to store all and split the script
                for (int i = 0; i < array.Length; i++)//for loop to send all the lines
                {
                    string script = array[i];
                    try
                    {
                        NamedPipes.LuaCPipe(script);//lua c pipe function to send the array
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());//if there any error a messagebox will pop up with the error
                    }
                }
            }
        }

        private void button33_Click(object sender, EventArgs e)
        {
            if (NamedPipes.NamedPipeExist(NamedPipes.scriptpipe))//check if the pipe exist
            {
                string[] array = textBox6.Text.Split("\r\n".ToCharArray());//array to store all and split the script
                for (int i = 0; i < array.Length; i++)//for loop to send all the lines
                {
                    string script = array[i];
                    try
                    {
                        NamedPipes.LuaCPipe(script);//lua c pipe function to send the array
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());//if there any error a messagebox will pop up with the error
                    }
                }
            }
        }

        private void button32_Click(object sender, EventArgs e)
        {
            if (NamedPipes.NamedPipeExist(NamedPipes.scriptpipe))//check if the pipe exist
            {
                string[] array = textBox9.Text.Split("\r\n".ToCharArray());//array to store all and split the script
                for (int i = 0; i < array.Length; i++)//for loop to send all the lines
                {
                    string script = array[i];
                    try
                    {
                        NamedPipes.LuaCPipe(script);//lua c pipe function to send the array
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());//if there any error a messagebox will pop up with the error
                    }
                }
            }
        }

        private void button36_Click(object sender, EventArgs e)
        {
            if (NamedPipes.NamedPipeExist(NamedPipes.scriptpipe))//check if the pipe exist
            {
                string[] array = textBox10.Text.Split("\r\n".ToCharArray());//array to store all and split the script
                for (int i = 0; i < array.Length; i++)//for loop to send all the lines
                {
                    string script = array[i];
                    try
                    {
                        NamedPipes.LuaCPipe(script);//lua c pipe function to send the array
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());//if there any error a messagebox will pop up with the error
                    }
                }
            }
        }

        private void button35_Click(object sender, EventArgs e)
        {
            if (NamedPipes.NamedPipeExist(NamedPipes.scriptpipe))//check if the pipe exist
            {
                string[] array = textBox11.Text.Split("\r\n".ToCharArray());//array to store all and split the script
                for (int i = 0; i < array.Length; i++)//for loop to send all the lines
                {
                    string script = array[i];
                    try
                    {
                        NamedPipes.LuaCPipe(script);//lua c pipe function to send the array
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());//if there any error a messagebox will pop up with the error
                    }
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                tabControl1.SelectedTab = tabPage3;
                button2.Visible = false;
                LuaExe.Visible = true;
            }
            else
            {
                tabControl1.SelectedTab = tabPage1;
                button2.Visible = true;
                LuaExe.Visible = false;
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Functions.Inject();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                TopMost = true;
            }
            else
            {
                TopMost = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            checkBox3.Checked = true;
            checkBox4.Checked = false;
            checkBox2.Checked = false;
        }

        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                Injector.Dispose();
                Injector.Stop();
                Text = "Impact";
            }
        }

        private void button44_Click_2(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            Functions.PopulateListBox(listBox2, "./LuaCScripts", "*.txt");//Populate weak Lua C shit
            listBox2.Items.Clear();
            Functions.PopulateListBox(listBox2, "./LuaCScripts", "*.txt");//Populate weak Lua C shit
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox1.Text = File.ReadAllText($"./LuaCScripts/{listBox2.SelectedItem}");//same shit here
        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            Lua.Text = File.ReadAllText($"./LuaScripts/{listBox4.SelectedItem}");
        }

        private void button46_Click(object sender, EventArgs e)
        {
            listBox4.Items.Clear();
            Functions.PopulateListBox(listBox4, "./LuaScripts", "*.txt");
        }

        private void button48_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void button47_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void button37_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void button44_Click(object sender, EventArgs e)
        {
            CmdBox.Clear();
            tabControl1.SelectedTab = tabPage1;
            CmdBox.Clear();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            if (NamedPipes.NamedPipeExist(NamedPipes.scriptpipe))//check if the pipe exist
            {
                string[] array = textBox13.Text.Split("\r\n".ToCharArray());//array to store all and split the script
                for (int i = 0; i < array.Length; i++)//for loop to send all the lines
                {
                    string script = array[i];
                    try
                    {
                        NamedPipes.LuaCPipe(script);//lua c pipe function to send the array
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());//if there any error a messagebox will pop up with the error
                    }
                }
            }
            else
            {
                MessageBox.Show("Inject " + Functions.exploitdll + " before Using this!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//if the pipe can't be found a messagebox will appear
                return;
            }
        }

        private void CmdTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//if user pressed Key Enter
            {
                Send_Click(sender, e);//execute Send_click function
            }
        }

        private void CmdTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//if user pressed Key Enter
            {
                Send_Click(sender, e);//execute Send_click function
            }
        }

        private void forceFieldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamedPipes.CommandPipe("ff me");
        }

        private void sparkelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamedPipes.CommandPipe("sp me");
        }

        private void btoolsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NamedPipes.CommandPipe("btools me");
        }

        private void suicideToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NamedPipes.CommandPipe("kill me");
        }

        private void fireToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NamedPipes.CommandPipe("fire me");
        }

        private void ghostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamedPipes.CommandPipe("ghost me");
        }

        private void forceFieldToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NamedPipes.CommandPipe("ff me");
        }

        private void sparkelsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NamedPipes.CommandPipe("sparkles me");
        }

        private void btoolsToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            NamedPipes.CommandPipe("btools me");
        }

        private void suicideToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            NamedPipes.CommandPipe("kill me");
        }

        private void fireToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            NamedPipes.CommandPipe("fire me");
        }

        private void ghostToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NamedPipes.CommandPipe("ghost me");
        }

        private void clickDelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hold Ctrl + Click to Delete");
            NamedPipes.clickCmd2("clickdellon");
        }

        private void clickTeleportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hold Ctrl + Click to Teleport");
            NamedPipes.clickCmd("clicktpon");
        }

        private void clickExplodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hold Ctrl + Click to Click Explode");
            NamedPipes.clickCmd3("clickex");
        }

        private void clickPrintLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hold Ctrl + Click to Click Explode");
            NamedPipes.clickCmd5("clickxyz");
        }

        private void clickUnanchorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hold Ctrl + Click to Click Explode");
            NamedPipes.clickCmd3("clickunanchor");
        }

        private void clickDeleteJailBreakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hold Ctrl + Click to Click Explode");
            NamedPipes.clickCmd3("clickjl");
        }

        private void forceFieldToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            NamedPipes.CommandPipe("ff me");
        }

        private void sparklesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamedPipes.CommandPipe("sparkles me");
        }

        private void btoolsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            NamedPipes.CommandPipe("btools me");
        }

        private void suicideToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            NamedPipes.CommandPipe("kill me");
        }

        private void fireToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            NamedPipes.CommandPipe("fire me");
        }

        private void ghostToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            NamedPipes.CommandPipe("ghost me");
        }

        private void clickDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hold Ctrl + Click to Delete");
            NamedPipes.clickCmd2("clickdellon");
        }

        private void clickTeleportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hold Ctrl + Click to Teleport");
            NamedPipes.clickCmd("clicktpon");
        }

        private void clickExplodeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hold Ctrl + Click to Click Explode");
            NamedPipes.clickCmd3("clickex");
        }

        private void clickPrintLocationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hold Ctrl + Click to Click Explode");
            NamedPipes.clickCmd5("clickxyz");
        }

        private void adminLoginToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }

        private void outputToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }

        private void killGameToolStripMenuItem1_Click(object sender, EventArgs e)
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

        private void commandConsoleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage4;
            CmdBox.Text +=

            "[SYSTEM] Welcome to Impact!\n" +
            "[SYSTEM] Impact is in open Beta please report any bugs you see\n" +
            "[SYSTEM] Open Roblox to auto inject Impact\n" +
            "\n" +
            "[SYSTEM] =============\n" +
            "[SYSTEM] All Commands:\n" +
            "[SYSTEM] =============\n" +
            "\n" +
            "[SYSTEM] ff [p]\n" +
            "[SYSTEM] heaven [p]\n" +
            "[SYSTEM] ghost [p]\n" +
            "[SYSTEM] statchange [p] [stat] [#]\n" +
            "[SYSTEM] keemstar [p]\n" +
            "[SYSTEM] illuminati [p]\n" +
            "[SYSTEM] duck [p]\n" +
            "[SYSTEM] mlg [p]\n" +
            "[SYSTEM] pussy [p]\n" +
            "[SYSTEM] fog [#]\n" +
            "[SYSTEM] rfog\n" +
            "[SYSTEM] rhat [p]\n" +
            "[SYSTEM] ws [p] [#]\n" +
            "[SYSTEM] sit [p]\n" +
            "[SYSTEM] hipheight [p] [#]\n" +
            "[SYSTEM] jp [p] [#]\n" +
            "[SYSTEM] kill [p]\n" +
            "[SYSTEM] drivebloxmoney [p]\n" +
            "[SYSTEM] gravity [#]\n" +
            "[SYSTEM] btools [p]\n" +
            "[SYSTEM] god [p]\n" +
            "[SYSTEM] bigfire [p]\n" +
            "[SYSTEM] time [#]\n" +
            "[SYSTEM] select [p]\n" +
            "[SYSTEM] fencingr\n" +
            "[SYSTEM] forcechat [p] [blue/red/green]\n" +
            "[SYSTEM] charapp [p] [#]\n" +
            "[SYSTEM] noob [p]\n" +
            "[SYSTEM] fire [p]\n" +
            "[SYSTEM] smoke [p]\n" +
            "[SYSTEM] sethealth [p] [#]\n" +
            "[SYSTEM] addhealth [p] [#]\n" +
            "[SYSTEM] sparkles [p]\n" +
            "\n" +
            "[SYSTEM] ==================\n" +
            "[SYSTEM] JailBreak Commands\n" +
            "[SYSTEM] ==================\n" +
            "\n" +
            "[SYSTEM] criminal\n" +
            "[SYSTEM] garage\n" +
            "[SYSTEM] bank\n" +
            "[SYSTEM] prison\n" +
            "[SYSTEM] nodoors\n" +
            "[SYSTEM] banklazers\n" +
            "[SYSTEM] jewelrycameras\n" +
            "[SYSTEM] jewelrylazers\n" +
            "[SYSTEM] jewelryflazers\n" +
            "[SYSTEM] jewelry\n" +
            "[SYSTEM] helispawn\n" +
            "\n" +
            "[SYSTEM] ========================\n" +
            "[SYSTEM] Lumber Tycoon 2 Commands\n" +
            "[SYSTEM] ========================\n" +
            "\n" +
            "[SYSTEM] bobs [p]\n" +
            "[SYSTEM] boxcars [p]\n" +
            "[SYSTEM] bridge [p]\n" +
            "[SYSTEM] endtimes [p]\n" +
            "[SYSTEM] furnish [p]\n" +
            "[SYSTEM] art [p]\n" +
            "[SYSTEM] cave [p]\n" +
            "[SYSTEM] dock [p]\n" +
            "[SYSTEM] lava [p]\n" +
            "[SYSTEM] logic [p]\n" +
            "[SYSTEM] shrine [p]\n" +
            "[SYSTEM] den [p]\n" +
            "\n" +
            "[SYSTEM] ==============\n" +
            "[SYSTEM] Other Commands\n" +
            "[SYSTEM] ==============\n" +
            "\n" +
            "[SYSTEM] jump [p]\n" +
            "[SYSTEM] freeze [p]\n" +
            "[SYSTEM] ragdoll [p]\n" +
            "[SYSTEM] unragdoll [p]\n" +
            "[SYSTEM] fov [p] [#]\n" +
            "[SYSTEM] health [p] [#]\n" +
            "[SYSTEM] cameralock [p] [#]\n" +
            "[SYSTEM] showname [p]\n" +
            "[SYSTEM] hidename [p]\n" +
            "[SYSTEM] rickroll\n" +
            "[SYSTEM] ppap\n" +
            "[SYSTEM] billnye\n" +
            "[SYSTEM] illuminati\n" +
            "[SYSTEM] rage\n" +
            "[SYSTEM] cringe\n" +
            "[SYSTEM] clearws\n" +
            "[SYSTEM] unanchorall\n" +
            "[SYSTEM] fecheck\n" +
            "[SYSTEM] play [#]\n" +
            "[SYSTEM] stopmusic\n" +
            "[SYSTEM] no baseplate\n" +
            "[SYSTEM] keycard\n" +
            "[SYSTEM] shutup\n" +
            "[SYSTEM] clone [p]\n" +
            "[SYSTEM] explode [p]\n" +
            "[SYSTEM] giant [p]\n" +
            "[SYSTEM] smallhead [p]\n" +
            "[SYSTEM] bighead [p]\n" +
            "[SYSTEM] respawn [p]\n" +
            "[SYSTEM] blockhead [p]\n" +
            "[SYSTEM] fling [p]\n" +
            "[SYSTEM] bodyfire [p]\n" +
            "[SYSTEM] naked [p]\n" +
            "[SYSTEM] walkspeedbypass [p]\n" +
            "[SYSTEM] bluehead [p]\n" +
            "[SYSTEM] disconnect [p]\n" +
            "[SYSTEM] rtools [p]\n" +
            "[SYSTEM] stun [p]\n" +
            "[SYSTEM] newtool [p]\n" +
            "[SYSTEM] newspawn \n" +
            "[SYSTEM] fogcolor [#]\n" +
            "[SYSTEM] freecam [p]\n" +
            "[SYSTEM] cubehead [p]\n" +
            "[SYSTEM] clear fogcolor\n" +
            "[SYSTEM] c00lkid\n" +
            "[SYSTEM] ambient [#]\n" +
            "[SYSTEM] watercolor [#]\n" +
            "[SYSTEM] trump\n" +
            "[SYSTEM] dialog [p]\n" +
            "\n" +
            "[SYSTEM] ==============\n" +
            "[SYSTEM] New Commands\n" +
            "[SYSTEM] ==============\n" +
            "\n" +
            "[SYSTEM] trumptorso [P]\n" +
            "[SYSTEM] roundtorso [P]\n" +
            "[SYSTEM] spin [P]\n" +
            "[SYSTEM] particle [P] [#]\n" +
            "[SYSTEM] skybox [#]\n" +
            "[SYSTEM] rhumanoid [P]\n" +
            "[SYSTEM] kick [P]\n" +
            "[SYSTEM] New commands can be broken or unstable";

            if (CmdBox.Text.Contains("SYSTEM"))
            {
                int index = -1;
                int selectStart = CmdBox.SelectionStart;
                while ((index = CmdBox.Text.IndexOf("SYSTEM", (index + 1))) != -1)
                {
                    CmdBox.Select((index + startIndex), "SYSTEM".Length);
                    CmdBox.SelectionColor = Color.Peru;
                    CmdBox.Select(selectStart, 0);
                    CmdBox.SelectionColor = Color.Peru;
                }
            }
        }

        private void quickExecutionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage5;
        }

        private void undoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void redoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void selectAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void cutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void clearToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                bool flag2 = saveFileDialog1.ShowDialog() != DialogResult.Cancel;
                if (flag2)
                {
                    try
                    {
                        File.Create(saveFileDialog1.FileName).Close();
                        File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
                    }
                    catch
                    {
                    }
                }
                else
                {
                    try
                    {
                    }
                    catch
                    {
                    }
                }
            }
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            {
                richTextBox1.Text = "";
            }
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to save your changes?", "Confirmation", MessageBoxButtons.YesNoCancel);
                bool flag2 = dialogResult == DialogResult.Yes;
                if (flag2)
                {
                    try
                    {
                    }
                    catch
                    {
                    }
                    richTextBox1.Text = "";
                }
                else
                {
                    bool flag3 = dialogResult == DialogResult.No;
                    if (flag3)
                    {
                        richTextBox1.Text = "";
                    }
                }
            }
        }

        private void saveAsToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            bool flag = saveFileDialog1.ShowDialog() != DialogResult.Cancel;
            if (flag)
            {
                try
                {
                    File.Create(saveFileDialog1.FileName).Close();
                    File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
                }
                catch
                {
                }
            }
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            {
                bool flag2 = openFileDialog1.ShowDialog() != DialogResult.Cancel;
                if (flag2)
                {
                    try
                    {
                        richTextBox1.Text = File.ReadAllText(openFileDialog1.FileName);
                    }
                    catch
                    {
                    }
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to save your changes?", "Confirmation", MessageBoxButtons.YesNoCancel);
                    bool flag3 = dialogResult == DialogResult.Yes;
                    if (flag3)
                    {
                        try
                        {
                        }
                        catch
                        {
                        }
                        bool flag4 = openFileDialog1.ShowDialog() != DialogResult.Cancel;
                        if (flag4)
                        {
                            try
                            {
                                richTextBox1.Text = File.ReadAllText(openFileDialog1.FileName);
                            }
                            catch
                            {
                            }
                        }
                    }
                    else
                    {
                        bool flag5 = dialogResult == DialogResult.No;
                        if (flag5)
                        {
                            bool flag6 = openFileDialog1.ShowDialog() != DialogResult.Cancel;
                            if (flag6)
                            {
                                try
                                {
                                    richTextBox1.Text = File.ReadAllText(openFileDialog1.FileName);
                                }
                                catch
                                {
                                }
                            }
                        }
                        else
                        {
                        }
                    }
                }
            }
        }

        private void closeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void settingsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage6;
        }

        private void reportAProblemToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Terroriser1/ImpactUpdate/issues/new");
        }

        private void checkBox4_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                MessageBox.Show("Turned on Safe Mode");
                Application.Restart();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Opacity = 1;
            for (double cont = 1; cont >= 0; cont -= 0.05)
            {
                Opacity = cont;
                Refresh();
            }
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
            Process.GetCurrentProcess().Kill();
        }

        private void richTextBox1_Click(object sender, EventArgs e)
        {
        }

        private void Main_Deactivate(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
            }
            else
            {
                Opacity = 0.95;
            }
        }

        private void Main_Activated(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
            }
            else
            {
                Opacity = 1;
            }
        }

        private void Main_MouseHover(object sender, EventArgs e)
        {
            Opacity = 1;
        }

        private void Main_MouseEnter(object sender, EventArgs e)
        {
            Opacity = 1;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (NamedPipes.NamedPipeExist(NamedPipes.scriptpipe))//check if the pipe exist
            {
                new Thread(() =>//lets run this in another thread so if roblox crash the ui/gui don't freeze
                {
                    string[] array = richTextBox1.Text.Split("\r\n".ToCharArray());//array to store all and split the script
                    for (int i = 0; i < array.Length; i++)//for loop to send all the lines
                    {
                        string script = array[i];
                        try
                        {
                            NamedPipes.LuaCPipe(script);//lua c pipe function to send the array
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString());//if there any error a messagebox will pop up with the error
                        }
                    }
                }).Start();
            }
            else
            {
                MessageBox.Show("Inject " + Functions.exploitdll + " before Using this!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//if the pipe can't be found a messagebox will appear
                return;
            }
        }

        private void clickSpawnBrickToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hold Ctrl + Click to Click Spawn Bricks");
            NamedPipes.CommandPipe("play 992331171");
            NamedPipes.clickCmd3("clicknewpart");
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Opacity = 0;
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
            Process.GetCurrentProcess().Kill();
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

        private void textBox18_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//if user pressed Key Enter
            {
                Send_Click(sender, e);//execute Send_click function
            }
        }

        private void button31_Click(object sender, EventArgs e)
        {
            if (CmdTextBox2.Text.ToLower() == "cmds")//check if the user send cmds so we can display the commands
            {
                CmdBox.AppendText(Functions.TextToBox[0]);//Append text to the command richtextbox
                CmdTextBox2.Clear();//clear the command textbox
            }
            else if (CmdTextBox2.Text.ToLower() == "credits")//check if the user send credits so we can display the credits
            {
                CmdBox.AppendText(Functions.TextToBox[1]);//Append text to the command richtextbox
                CmdTextBox2.Clear();//clear the command textbox
            }
            else if (CmdTextBox2.Text.ToLower() == "clear")//check if the user send clear so we can clear the CmdBox
            {
                CmdBox.Clear();//clear the CmdBox
                CmdTextBox2.Clear();//Clear the command textbox
            }
            else
            {
                NamedPipes.CommandPipe(CmdTextBox2.Text);//command pipe function to send the text in the command textbox
                CmdBox.AppendText("\n>" + CmdTextBox2.Text);//add the used command to CmdBox
                CmdTextBox2.Clear();//clear the command textbox
            }
        }

        private void listBox4_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Lua.Text = File.ReadAllText($"./LuaScripts/{listBox4.SelectedItem}");
        }

        private void clickTeleportToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hold Ctrl + Click to Teleport");
            NamedPipes.clickCmd("clicktpon");
        }

        private void clickExplodeToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hold Ctrl + Click to Click Explode");
            NamedPipes.clickCmd3("clickex");
        }

        private void clickPrintLocationToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hold Ctrl + Click to Click Explode");
            NamedPipes.clickCmd5("clickxyz");
        }

        private void clickDeleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hold Ctrl + Click to Delete");
            NamedPipes.clickCmd2("clickdellon");
        }

        private void clickSpawnBrickToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hold Ctrl + Click to Click Spawn Bricks");
            NamedPipes.CommandPipe("play 992331171");
            NamedPipes.clickCmd3("clicknewpart");
        }

        private void fixCrashToolStripMenuItem_Click(object sender, EventArgs e)
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
            Hide();
            Process.Start(Application.StartupPath + @"\ImpactTMP.exe");
            Application.Exit();
        }

        private void button49_Click(object sender, EventArgs e)
        {
            NamedPipes.CommandPipe("bighead me");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            NamedPipes.CommandPipe("fling me");
        }

        private void button38_Click(object sender, EventArgs e)
        {
            NamedPipes.CommandPipe("kill all");
        }

        private void button39_Click(object sender, EventArgs e)
        {
            NamedPipes.CommandPipe("sp all");
        }

        private void button45_Click_1(object sender, EventArgs e)
        {
            NamedPipes.CommandPipe("ff all");
        }

        private void button46_Click_1(object sender, EventArgs e)
        {
            NamedPipes.CommandPipe("fire all");
        }

        private void openToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Visible = false;
            Quick_Game_Tab Quick_Game_Tab = new Quick_Game_Tab();
            Quick_Game_Tab.ShowDialog();
            Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}