using KaosesCommon.Objects;
using KaosesCommon.Utils;
using KaosesWages.Objects;
using KaosesWages.Settings;
using KaosesWagesCore;
using KaosesWagesCore.Objects;
using KaosesWagesCore.Settings;
using CoreConfig = KaosesWagesCore.Settings.KaosesWagesCoreConfig;
using CoreFactory = KaosesWagesCore.Objects.KaosesWagesCoreFactory;

namespace KaosesWages
{
    /// <summary>
    /// Internal class to initialize the mod settings class from MCM and to set the IM and Logger variables 
    /// </summary>
    internal class Init
    {
        public Init()
        {
            /// Load the Settings Object
            Config settings = Factory.Settings;

            //ConfigOther settings2 = Factory.Settings2;
            //TempCoreConfig settings2 = Factory.SettingsCore;
            //TempCoreConfig settings2 = TempCoreFactory.Settings;
            //Factory.DConfig();


            ///
            /// Set IM variable values
            ///
            InfoMgr im = new InfoMgr(settings.Debug, settings.LogToFile, SubModule.ModuleId, SubModule.modulePath);
            im.PrePrend = SubModule.ModuleId;
            im.ModVersion = settings.versionTextObj.ToString();
            //im.LogFilePath = "c:\\BannerLord\\KaosesCommon\\logfile.text";
            //im.AddDateTimeToLog = true;
            Factory.IM = im;
        }
    }
}
