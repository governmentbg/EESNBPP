using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBPPRegixClient.Log
{
    public class SMainLog
    {
#pragma warning disable 0618
        private StreamWriter w;
        public void close()
        {
            try
            {
                if (w != null) w.Close();
                w = null;
            }
            catch { }
        }
        public SMainLog(string _name)
        {
            try
            {
                string path = System.Web.Hosting.HostingEnvironment.MapPath(@"~/Logs");

                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                string name = path + @"\" + _name;
                if (File.Exists(name))
                {
                    try
                    {
                        FileInfo fi = new FileInfo(name);
                        if (fi.Length > 500000)
                        {
                            File.Delete(name + ".9");
                            for (int i = 9; i > 0; i--)
                            {
                                int j = i - 1;
                                if (File.Exists(name + "." + j.ToString()))
                                {
                                    try { File.Move(name + "." + j.ToString(), name + "." + i.ToString()); }
                                    catch { }
                                }
                            }
                            File.Move(name, name + ".0");
                        }
                    }
                    catch { }

                }
                w = File.AppendText(name);
            }
            catch { w = null; }
        }
        public void Log(string text)
        {
            if (w != null)
                try
                {
                    w.WriteLine("\r\n{0} {1} : {2}",
                        DateTime.Now.ToString("dd.MM.yyyy"),
                        DateTime.Now.ToString("HH:mm:ss"),
                        text);
                    w.Flush();
                }
                catch { }
        }
        public void Log(string text, string trace)
        {
            if (w != null)
                try
                {
                    w.WriteLine("\r\n{0} {1} : {2}",
                        DateTime.Now.ToString("dd.MM.yyyy"),
                        DateTime.Now.ToString("HH:mm:ss"),
                        text);
                    w.WriteLine("Trace: {0}", trace);
                    w.Flush();
                }
                catch { }
        }
    }
}
