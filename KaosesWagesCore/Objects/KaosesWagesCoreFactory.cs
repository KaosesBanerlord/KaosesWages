using KaosesCommon;
using KaosesCommon.Objects;
using KaosesCommon.Utils;
using KaosesWagesCore.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KaosesWagesCore.Objects
{
    /// <summary>
    /// KaosesWagesCoreFactory Factory Object
    /// </summary>
    public static class KaosesWagesCoreFactory
    {
        /// <summary>
        /// Variable to hold the MCM settings object
        /// </summary>
        private static KaosesWagesCoreConfig _settings = null;

        private static InfoMgr? _im = null;

        public static InfoMgr IM
        {
            get
            {
                return _im;
            }
            set
            {
                _im = value;
            }
        }

        /// <summary>
        /// MCM Settings Object Instance
        /// </summary>
        public static KaosesWagesCoreConfig Settings
        {
            get
            {
                if (_settings == null)
                {
                    _settings = KaosesWagesCoreConfig.Instance;
                    if (_settings is null)
                    {
                        //IM.ShowMessageBox("KaosesWagesCoreConfig Failed to load KaosesWagesCoreConfig provider", "KaosesWagesCoreConfig Error");
                    }
                }
                return _settings;
            }
            set
            {
                _settings = value;
            }
        }

        /// <summary>
        /// Mod version
        /// </summary>
        public static string ModVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();

    }
}
