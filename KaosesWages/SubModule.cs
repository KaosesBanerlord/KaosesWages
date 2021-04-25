using System;
using TaleWorlds.MountAndBlade;
using KaosesWages.Utils;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using StoryMode;
using KaosesWages.Models;
using HarmonyLib;
using System.Reflection;
using TaleWorlds.Library;
using KaosesWages.Settings;
using TaleWorlds.CampaignSystem.ViewModelCollection.GameMenu;

namespace KaosesWages
{
    public class SubModule : MBSubModuleBase
    {
        protected override void OnBeforeInitialModuleScreenSetAsRoot()
        {
            base.OnBeforeInitialModuleScreenSetAsRoot();
            ConfigLoader.LoadConfig();
            Ux.MessageInfo("Loaded: " + Statics._settings.ModDisplayName);
        }

        protected override void OnSubModuleLoad()
        {
            base.OnSubModuleLoad();
            try
            {
                var harmony = new Harmony("kaoses.wages.patch");
                harmony.PatchAll(Assembly.GetExecutingAssembly());
            }
            catch (Exception ex)
            {
                //Handle exceptions
                Logging.Lm("Error with harmony patch");
                Logging.Lm(ex.ToString());
            }
            
        }

        protected override void OnGameStart(Game game, IGameStarter gameStarter)
        {
            base.OnGameStart(game, gameStarter);
            if (game.GameType is Campaign)
            {
                CampaignGameStarter campaignGameStarter = (CampaignGameStarter)gameStarter;

                //if (Settings.Instance.bUseTierWagesModifiers)
                //{
                campaignGameStarter.AddModel(new KaosesWageModel());
                campaignGameStarter.AddModel(new KaosesTroopUpgrade());
                campaignGameStarter.AddModel(new CompanionRecruitment());
                //}
            }
        }

        protected override void OnSubModuleUnloaded()
        {
            base.OnSubModuleUnloaded();
        }
    }
}