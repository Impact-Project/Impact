using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Impact
{
    internal class Functions
    {
        public static string exploitdll = "Impact.vmp.dll";//this is the name of your dll

        public static void Inject()
        {
            if (NamedPipes.NamedPipeExist(NamedPipes.scriptpipe))//check if the pipe exist
            {
                return;
            }
            else if (!NamedPipes.NamedPipeExist(NamedPipes.scriptpipe))//check if the pipe don't exist
            {
                switch (Injector.DllInjector.GetInstance.Inject("RobloxPlayerBeta", AppDomain.CurrentDomain.BaseDirectory + exploitdll))//Process name and dll directory
                {
                }
                Thread.Sleep(2000);//pause the ui for 2 seconds
                if (NamedPipes.NamedPipeExist(NamedPipes.scriptpipe))//check if the pipe exist
                {
                    MessageBox.Show("Impact Successfully injected");
                }
                else
                {
                    MessageBox.Show("Something went wrong");
                }
            }
        }

        public static string[] TextToBox =
        {
           //Commands [0]
            "\n" +
            "\n" +
            "[SYSTEM]  =============\n" +
            "[SYSTEM]  All Commands:\n" +
            "[SYSTEM]  =============\n" +
            "\n" +
            "[SYSTEM]  ff [p]\n" +
            "[SYSTEM]  heaven [p]\n" +
            "[SYSTEM]  ghost [p]\n" +
            "[SYSTEM]  statchange [p] [stat] [#]\n" +
            "[SYSTEM]  keemstar [p]\n" +
            "[SYSTEM]  illuminati [p]\n" +
            "[SYSTEM]  duck [p]\n" +
            "[SYSTEM]  mlg [p]\n" +
            "[SYSTEM]  pussy [p]\n" +
            "[SYSTEM]  fog [#]\n" +
            "[SYSTEM]  rfog\n" +
            "[SYSTEM]  rhat [p]\n" +
            "[SYSTEM]  ws [p] [#]\n" +
            "[SYSTEM]  sit [p]\n" +
            "[SYSTEM]  hipheight [p] [#]\n" +
            "[SYSTEM]  jp [p] [#]\n" +
            "[SYSTEM]  kill [p]\n" +
            "[SYSTEM]  drivebloxmoney [p]\n" +
            "[SYSTEM]  gravity [#]\n" +
            "[SYSTEM]  btools [p]\n" +
            "[SYSTEM]  god [p]\n" +
            "[SYSTEM]  bigfire [p]\n" +
            "[SYSTEM]  time [#]\n" +
            "[SYSTEM]  select [p]\n" +
            "[SYSTEM]  fencingr\n" +
            "[SYSTEM]  forcechat [p] [blue/red/green]\n" +
            "[SYSTEM]  charapp [p] [#]\n" +
            "[SYSTEM]  noob [p]\n" +
            "[SYSTEM]  fire [p]\n" +
            "[SYSTEM]  smoke [p]\n" +
            "[SYSTEM]  sethealth [p] [#]\n" +
            "[SYSTEM]  addhealth [p] [#]\n" +
            "[SYSTEM]  sparkles [p]\n" +
            "\n" +
            "[SYSTEM]  ==================\n" +
            "[SYSTEM]  JailBreak Commands\n" +
            "[SYSTEM]  ==================\n" +
            "\n" +
            "[SYSTEM]  criminal\n" +
            "[SYSTEM]  garage\n" +
            "[SYSTEM]  bank\n" +
            "[SYSTEM]  prison\n" +
            "[SYSTEM]  nodoors\n" +
            "[SYSTEM]  banklazers\n" +
            "[SYSTEM]  jewelrycameras\n" +
            "[SYSTEM]  jewelrylazers\n" +
            "[SYSTEM]  jewelryflazers\n" +
            "[SYSTEM]  jewelry\n" +
            "\n" +
            "[SYSTEM]  ==============\n" +
            "[SYSTEM]  Other Commands\n" +
            "[SYSTEM]  ==============\n" +
            "\n" +
            "[SYSTEM]  jump [p]\n" +
            "[SYSTEM]  freeze [p]\n" +
            "[SYSTEM]  ragdoll [p]\n" +
            "[SYSTEM]  unragdoll [p]\n" +
            "[SYSTEM]  fov [p] [#]\n" +
            "[SYSTEM]  health [p] [#]\n" +
            "[SYSTEM]  cameralock [p] [#]\n" +
            "[SYSTEM]  showname [p]\n" +
            "[SYSTEM]  hidename [p]\n" +
            "[SYSTEM]  rickroll\n" +
            "[SYSTEM]  ppap\n" +
            "[SYSTEM]  billnye\n" +
            "[SYSTEM]  illuminati\n" +
            "[SYSTEM]  rage\n" +
            "[SYSTEM]  cringe\n" +
            "[SYSTEM]  clearws\n" +
            "[SYSTEM]  unanchorall\n" +
            "[SYSTEM]  fecheck\n" +
            "[SYSTEM]  play [#]\n" +
            "[SYSTEM]  stopmusic\n" +
            "[SYSTEM]  no baseplate\n" +
            "[SYSTEM]  keycard\n" +
            "[SYSTEM]  shutup\n" +
            "\n" +
            "[SYSTEM]  ==============\n" +
            "[SYSTEM]  New Commands\n" +
            "[SYSTEM]  ==============\n" +
            "\n" +
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
            "[SYSTEM] New commands can be broken or unstable",
            "\n" +
            //Credits [1]
            "\n" +
            "[SYSTEM]  Credits;\n" +
            "[SYSTEM]  Terroriser\n" +
            "[SYSTEM]  Gagi12\n" +
            "[SYSTEM]  Official_killer12\n" +
            "[SYSTEM]  The Community\n" +
            "[SYSTEM]  And Chosey"
        };

        public static OpenFileDialog openfiledialog = new OpenFileDialog
        {
            Filter = "LuaC/Lua Script Txt (*.txt)|*.txt|All files (*.*)|*.*",//add txt and all files filter
            FilterIndex = 1,//choose what filter will be the default
            RestoreDirectory = true//restore the last used directory
        };//Initialize OpenFileDialog

        public static void PopulateListBox(ListBox LuaCScriptList, string Folder, string FileType)
        {
            DirectoryInfo dinfo = new DirectoryInfo(Folder);
            FileInfo[] Files = dinfo.GetFiles(FileType);
            foreach (FileInfo file in Files)
            {
                LuaCScriptList.Items.Add(file.Name);
            }
        }

        public static bool UpdateUI = false;
        public static bool UpdateDLL = false;

        internal static void PopulateListBox(ListView luaCScriptList2, string v1, string v2)
        {
            throw new NotImplementedException();
        }

        public static void PopulatelistBox1(ListBox LuaCScriptList, string Folder, string FileType)
        {
            DirectoryInfo dinfo = new DirectoryInfo(Folder);
            FileInfo[] Files = dinfo.GetFiles(FileType);
            foreach (FileInfo file in Files)
            {
                LuaCScriptList.Items.Add(file.Name);
            }
        }

        public static void PopulateListBox2(ListBox LuaCScriptList, string Folder, string FileType)
        {
            DirectoryInfo dinfo = new DirectoryInfo(Folder);
            FileInfo[] Files = dinfo.GetFiles(FileType);
            foreach (FileInfo file in Files)
            {
                LuaCScriptList.Items.Add(file.Name);
            }
        }

        internal static void PopulateListBox3(ListView luaCScriptList2, string v1, string v2)
        {
            throw new NotImplementedException();
        }
    }
}