using System.IO;

namespace KaosesWages.Utils
{
    class Logging
    {
        public static string PrePrend = "";

        public static void Lm(string message)
        {
            try
            {
                using StreamWriter sw = File.AppendText(Statics.logPath);
                sw.WriteLine(PrePrend + " : " + message + "\r\n");
            }
            catch
            {

            }
        }

    }
}
