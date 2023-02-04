using KaosesCommon.Utils;
using KaosesCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using KaosesWagesCore.Settings;
using TaleWorlds.Localization;

namespace KaosesWagesCore.Objects
{
    /// <summary>
    /// KaosesWages Factory Object
    /// </summary>
    public static class WagesCoreFactory
    {
        /// <summary>
        /// Variable to hold the MCM settings object
        /// </summary>
        private static WagesCoreConfig _settings = null;

        /// <summary>
        /// Bool indicates if MCM is a loaded mod
        /// </summary>
        public static bool MCMModuleLoaded { get; set; } = false;

        /// <summary>
        /// MCM Settings Object Instance
        /// </summary>
        public static WagesCoreConfig Settings
        {
            get
            {
                if (_settings == null)
                {
                    _settings = WagesCoreConfig.Instance;
                    if (_settings is null)
                    {
                        IM.ShowMessageBox("Kaoses Wages Failed to load MCM WagesCoreConfig provider", "Kaoses Wages MCM Error");
                    }
                }
                return _settings;
            }
            set
            {
                _settings = value;
            }
        }

        public static string ModuleId = "KaosesWages";
        public static string ModuleName = "Kaoses Wages";

        public static string DisplayName;

        /// <summary>
        /// Mod version
        /// </summary>
        public static string ModVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();

        /// <summary>
        /// Unused mod WagesCoreConfig file path
        /// </summary>
        private static string WagesCoreConfigFilePath
        {

            get
            {
                return @"..\\..\\Modules\\" + SubModule.ModuleId + "\\WagesCoreConfig.json";
            }
            //set {  = value; }

        }
    }
}
