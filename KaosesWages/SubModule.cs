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
using KaosesWages.Common;

namespace KaosesWages
{
    public class SubModule : MBSubModuleBase
    {
        public static ISettingsProviderInterface? _settings;
        private Harmony _harmony;

        protected override void OnBeforeInitialModuleScreenSetAsRoot()
        {
            base.OnBeforeInitialModuleScreenSetAsRoot();
            try
            {
                ConfigLoader.LoadConfig();
                bool modUsesHarmoney = Statics.UsesHarmony;
                if (modUsesHarmoney)
                {
                    if (Kaoses.IsHarmonyLoaded())
                    {
                        IM.DisplayModLoadedMessage();
                    }
                    else { IM.DisplayModHarmonyErrorMessage(); }
                }
                else { IM.DisplayModLoadedMessage(); }
            }
            catch (Exception ex)
            {
                //Handle exceptions
                IM.MessageError("Error loading initial config: " + ex.ToStringFull());
            }

        }

        protected override void OnSubModuleLoad()
        {
            base.OnSubModuleLoad();            
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

        public override void OnGameInitializationFinished(Game game)
        {
            // Called 4th after choosing (Resume Game, Campaign, Custom Battle) from the main menu.
            base.OnGameInitializationFinished(game);
            if (!(game.GameType is Campaign))
            {
                return;
            }

            try
            {
                var harmony = new Harmony(Statics.HarmonyId);
                harmony.PatchAll(Assembly.GetExecutingAssembly());
            }
            catch (Exception ex)
            {
                //Handle exceptions
                IM.MessageError("Error with harmony patch: " + ex.ToStringFull());
            }
        }
        protected override void OnSubModuleUnloaded()
        {
            base.OnSubModuleUnloaded();
        }
        public override void OnGameEnd(Game game)
        {
            try
            {
                _harmony?.UnpatchAll(Statics.HarmonyId);
            }
            catch (Exception ex)
            {
                //Handle exceptions
                IM.MessageError("Error OnGameEnd harmony un-patch: " + ex.ToStringFull());
            }
        }
    }
}