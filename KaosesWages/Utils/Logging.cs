using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace KaosesWages.Utils
{
    class Logging
    {
        private string _logPath;

        public Logging(string logPath)
        {
            this._logPath = logPath;
        }

        public void logString(string message)
        {
            using (StreamWriter sw = File.AppendText(this._logPath))
            {
                sw.WriteLine(message);
            }
        }

        public static void lm(string message)
        {
            using (StreamWriter sw = File.AppendText(KaosesWagesSubModule.logPath))
            {
                sw.WriteLine(message);
            }
        }
    }
}
