using System;
using TaleWorlds.MountAndBlade;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using KaosesWages.Models;
using HarmonyLib;
using System.Reflection;
using KaosesWages.Settings;
using KaosesCommon.Utils;
using KaosesCommon;

namespace KaosesWages
{
    public class SubModule : MBSubModuleBase
    {
        public static MCMSettings? _settings;
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
                        try
                        {
                            if (_harmony == null)
                            {
                                _harmony = new Harmony(Statics.HarmonyId);
                                _harmony.PatchAll(Assembly.GetExecutingAssembly());
                            }

                        }
                        catch (Exception ex)
                        {
                            IM.ShowError("Error with harmony patch", "Kaoses Parties error", ex);
                        }

                    }
                    else { IM.DisplayModHarmonyErrorMessage(); }
                }
                else { IM.DisplayModLoadedMessage(); }
            }
            catch (Exception ex)
            {
                IM.ShowError("Error loading", "initial Mod Data", ex);
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
        }
        protected override void OnSubModuleUnloaded()
        {
            base.OnSubModuleUnloaded();
        }
        public override void OnGameEnd(Game game)
        {
        }
    }
}