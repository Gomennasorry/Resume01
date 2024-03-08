using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BASE.Utils
{
    public enum LogType
    {
        System,
        Interface,
        Application,
        WMS,
        SCGEX,
        SCGL,
        Adapter
    }
    public static class Logger
    {
        public static void WriteLog(LogType Module, string LogGroup, string LogText)
        {
            if (!Directory.Exists("Logs"))
                Directory.CreateDirectory("Logs");

            string fileName = $"{Module.ToString()}_{DateTime.Now.ToString("yyyyMMdd")}.txt";

            fileName = Path.Combine("Logs", fileName);
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileName, true))
            {
                file.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " : [" + LogGroup + "]" + LogText);
            }
        }

    }
}
