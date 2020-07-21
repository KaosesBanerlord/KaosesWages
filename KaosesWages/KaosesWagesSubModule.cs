using System;
using System.Collections.Generic;
using TaleWorlds.MountAndBlade;
using System.Linq;
using System.Text;
using KaosesWages.Config;
using KaosesWages.Utils;
using TaleWorlds.ObjectSystem;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using StoryMode;
using KaosesWages.Models;
using System.IO;
using Newtonsoft.Json;
using HarmonyLib;
using System.Reflection;

namespace KaosesWages
{
    public class KaosesWagesSubModule : MBSubModuleBase
    {
        public const string InstanceID = "Kaoses Wages";
        public const string ModuleFolder = "KaosesWages";
        public const string Version = "0.0.8";
        public const string logPath = @"..\\..\\Modules\\" + ModuleFolder + "\\KaosLog.txt";
        public const string ConfigFilePath = @"..\\..\\Modules\\" + ModuleFolder + "\\config.json";
        public const string ConfigFileBasePath = @"..\\..\\Modules\\" + ModuleFolder + "\\Config.base.json";

        protected override void OnBeforeInitialModuleScreenSetAsRoot()
        {
            Ux.ShowMessageInfo(InstanceID + " " + Version + " is now enabled.");
        }

        protected override void OnSubModuleLoad()
        {
            // Called 1st during initial loading before intro movie.
            base.OnSubModuleLoad();

            try
            {
                Loader.LoadConfig();
            }
            catch (Exception ex)
            {
                //Handle exceptions
                Logging.lm(ex.ToString());
            }

            
            try
            {
                var harmony = new Harmony("kaoses.wages.patch");
                harmony.PatchAll(Assembly.GetExecutingAssembly());
            }
            catch (Exception ex)
            {
                //Handle exceptions
                Logging.lm("Error with harmony patch");
                Logging.lm(ex.ToString());
            }
            
        }

        protected override void OnGameStart(Game game, IGameStarter gameStarterObject)
        {
            // Called 1st after choosing (Resume Game, Campaign, Custom Battle) from the main menu.
            base.OnGameStart(game, gameStarterObject);
            if (!(game.GameType is Campaign))
            {
                return;
            }

            if (game.GameType is CampaignStoryMode campaignStoryMode && gameStarterObject is CampaignGameStarter campaignGameStarter)
            {
                //if (Settings.Instance.bUseTierWagesModifiers)
                //{
                    campaignGameStarter.AddModel(new KaosesWageModel());
                //}
            }


        }






    }
}
