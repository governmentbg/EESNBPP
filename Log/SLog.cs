using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBPPRegixClient.Log
{
    public class SLog
    {
#pragma warning disable 0618
        private static SMainLog _inst;
        static readonly object lockObject = new object();

        public delegate void OnWriteHandler(string msg1, string msg2);
        public static event OnWriteHandler OnWrite;


        [ThreadStatic]
        public static string fileName = "slog.log";

        private static string GetFileName()
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return "slog.log";
            }
            return fileName;
        }

        public static void log(string text)
        {
            lock (lockObject)
            {
                if (_inst == null)
                    _inst = new SMainLog(GetFileName());

                _inst.Log(text);
                _inst.close();
                _inst = null;
            }
        }

        public static void log(string text, string trace)
        {
            lock (lockObject)
            {
                if (_inst == null)
                    _inst = new SMainLog(GetFileName());
                _inst.Log(text, trace);
                _inst.close();
                _inst = null;
            }
        }

        public static void log(Exception ex)
        {
            lock (lockObject)
            {
                if (_inst == null)
                    _inst = new SMainLog(GetFileName());

                _inst.Log("Error: " + ex.Message, ex.StackTrace);
                if (ex.InnerException != null)
                {
                    _inst.Log("InnerException: " + ex.InnerException.Message, ex.InnerException.StackTrace);
                }
                _inst.close();
                _inst = null;
            }
            if (OnWrite != null) { OnWrite(ex.Message, ex.StackTrace); }
        }

        public static void log(Exception ex, string text)
        {
            lock (lockObject)
            {
                if (_inst == null)
                    _inst = new SMainLog(GetFileName());

                _inst.Log("[" + text + "] Error: " + ex.Message, ex.StackTrace);
                _inst.close();
                _inst = null;
            }
            if (OnWrite != null) { OnWrite(ex.Message, text); }
        }

        public static void DetLog(string text)
        {
            lock (lockObject)
            {
                if (_inst == null)
                    _inst = new SMainLog(GetFileName());
                _inst.Log(text);
                _inst.close();
                _inst = null;
            }
        }
    }
}