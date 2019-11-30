using System;
using System.IO;
using System.IO.Pipes;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Impact
{
    internal class NamedPipes
    {
        public static string click5 = "AWPIFIIOANWOFNAOWNFOINAOWNFAWIFPAWFMAPWMCNWANFN";//name of click pipe
        public static string click3 = "APJFPAWIJFIJAWJF)AWJF)";//name of click pipe
        public static string click2 = "APIJAWJFOIJQJ@)@)J@)J!WDOIFNAOWNAF";//name of click pipe
        public static string click = "AJFAWFOIJAOWJFOANWNVOAINWNOAN";//name of command pipe
        public static string cmdpipe = "AWOOAUWFOAWHFAOWFN";//name of command pipe
        public static string scriptpipe = "AAWNFOAIWNFONAO";// name of lua c pipe
        public static string luapipe = "AWPAWFPNNAWPIN";//name of lua pipe
        public static string fepipe = "fecheckerfd45sd4f5sd4f5ds4f5ds4";//name of lua pipe

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool WaitNamedPipe(string name, int timeout);

        //function to check if the pipe exist
        public static bool NamedPipeExist(string pipeName)
        {
            bool result;
            try
            {
                int timeout = 0;
                if (!WaitNamedPipe(Path.GetFullPath(string.Format("\\\\\\\\.\\\\pipe\\\\{0}", pipeName)), timeout))
                {
                    int lastWin32Error = Marshal.GetLastWin32Error();
                    if (lastWin32Error == 0)
                    {
                        result = false;
                        return result;
                    }
                    if (lastWin32Error == 2)
                    {
                        result = false;
                        return result;
                    }
                }
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        //command pipe function
        public static void CommandPipe(string command)
        {
            if (NamedPipeExist(cmdpipe))
            {
                new Thread(() =>//lets run this in another thread so if roblox crash the ui/gui don't freeze or something
                {
                    try
                    {
                        using (NamedPipeClientStream namedPipeClientStream = new NamedPipeClientStream(".", cmdpipe, PipeDirection.Out))
                        {
                            namedPipeClientStream.Connect();
                            using (StreamWriter streamWriter = new StreamWriter(namedPipeClientStream))
                            {
                                streamWriter.Write(command);
                                streamWriter.Dispose();
                            }
                            namedPipeClientStream.Dispose();
                        }
                    }
                    catch (IOException)
                    {
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }).Start();
            }
            else
            {
                return;
            }
        }

        public static void fechek()
        {
            if (NamedPipeExist(fepipe))
            {
                new Thread(() =>//lets run this in another thread so if roblox crash the ui/gui don't freeze or something
                {
                    try
                    {
                        using (NamedPipeClientStream namedPipeClientStream = new NamedPipeClientStream(".", fepipe, PipeDirection.Out))
                        {
                        }
                    }
                    catch (IOException)
                    {
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }).Start();
            }
            else
            {
                return;
            }
        }

        //command pipe function
        public static void clickCmd5(string command)
        {
            if (NamedPipeExist(click))
            {
                new Thread(() =>//lets run this in another thread so if roblox crash the ui/gui don't freeze or something
                {
                    try
                    {
                        using (NamedPipeClientStream namedPipeClientStream = new NamedPipeClientStream(".", click, PipeDirection.Out))
                        {
                            namedPipeClientStream.Connect();
                            using (StreamWriter streamWriter = new StreamWriter(namedPipeClientStream))
                            {
                                streamWriter.Write(command);
                                streamWriter.Dispose();
                            }
                            namedPipeClientStream.Dispose();
                        }
                    }
                    catch (IOException)
                    {
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }).Start();
            }
            else
            {
                return;
            }
        }

        //command pipe function
        public static void clickCmd3(string command)
        {
            if (NamedPipeExist(click))
            {
                new Thread(() =>//lets run this in another thread so if roblox crash the ui/gui don't freeze or something
                {
                    try
                    {
                        using (NamedPipeClientStream namedPipeClientStream = new NamedPipeClientStream(".", click, PipeDirection.Out))
                        {
                            namedPipeClientStream.Connect();
                            using (StreamWriter streamWriter = new StreamWriter(namedPipeClientStream))
                            {
                                streamWriter.Write(command);
                                streamWriter.Dispose();
                            }
                            namedPipeClientStream.Dispose();
                        }
                    }
                    catch (IOException)
                    {
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }).Start();
            }
            else
            {
                return;
            }
        }

        //command pipe function
        public static void clickCmd2(string command)
        {
            if (NamedPipeExist(click))
            {
                new Thread(() =>//lets run this in another thread so if roblox crash the ui/gui don't freeze or something
                {
                    try
                    {
                        using (NamedPipeClientStream namedPipeClientStream = new NamedPipeClientStream(".", click, PipeDirection.Out))
                        {
                            namedPipeClientStream.Connect();
                            using (StreamWriter streamWriter = new StreamWriter(namedPipeClientStream))
                            {
                                streamWriter.Write(command);
                                streamWriter.Dispose();
                            }
                            namedPipeClientStream.Dispose();
                        }
                    }
                    catch (IOException)
                    {
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }).Start();
            }
            else
            {
                return;
            }
        }

        //click pipe function
        public static void clickCmd(string clicknew)
        {
            if (NamedPipeExist(click))
            {
                new Thread(() =>//lets run this in another thread so if roblox crash the ui/gui don't freeze or something
                {
                    try
                    {
                        using (NamedPipeClientStream namedPipeClientStream = new NamedPipeClientStream(".", click, PipeDirection.Out))
                        {
                            namedPipeClientStream.Connect();
                            using (StreamWriter streamWriter = new StreamWriter(namedPipeClientStream))
                            {
                                streamWriter.Write(clicknew);
                                streamWriter.Dispose();
                            }
                            namedPipeClientStream.Dispose();
                        }
                    }
                    catch (IOException)
                    {
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }).Start();
            }
            else
            {
                return;
            }
        }

        //lua c pipe function
        public static void LuaCPipe(string script)
        {
            if (NamedPipeExist(scriptpipe))
            {
                try
                {
                    using (NamedPipeClientStream namedPipeClientStream = new NamedPipeClientStream(".", scriptpipe, PipeDirection.Out))
                    {
                        namedPipeClientStream.Connect();
                        using (StreamWriter streamWriter = new StreamWriter(namedPipeClientStream))
                        {
                            streamWriter.Write(script);
                            streamWriter.Dispose();
                        }
                        namedPipeClientStream.Dispose();
                    }
                }
                catch (IOException)
                {
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            else
            {
                return;
            }
        }

        //lua pipe function
        public static void MemeLua(string script)
        {
            if (NamedPipeExist(luapipe))
            {
                try
                {
                    using (NamedPipeClientStream namedPipeClientStream = new NamedPipeClientStream(".", luapipe, PipeDirection.Out))
                    {
                        namedPipeClientStream.Connect();
                        using (StreamWriter streamWriter = new StreamWriter(namedPipeClientStream))
                        {
                            streamWriter.Write(script);
                            streamWriter.Dispose();
                        }
                        namedPipeClientStream.Dispose();
                    }
                }
                catch (IOException)
                {
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            else
            {
                return;
            }
        }
    }
}