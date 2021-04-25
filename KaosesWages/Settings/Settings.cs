using Bannerlord.BUTR.Shared.Helpers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace KaosesWages.Settings
{
    public class Settings : ISettingsProviderInterface
    {
        //private readonly ISettingsProviderInterface _provider;
        public static Settings? Instance;

        public string Id => Statics.InstanceID;
        string modName = Statics.DisplayName;
        public string DisplayName => TextObjectHelper.Create("{=testModDisplayName}" + modName + " {VERSION}", new Dictionary<string, TextObject>()
        {
            { "VERSION", TextObjectHelper.Create(typeof(MCMSettings).Assembly.GetName().Version?.ToString(3) ?? "")! }
        })!.ToString();

        #region ModDebug
        public bool Debug { get; set; } = false;
        public bool LoadMCMConfigFile { get; set; } = false;
        public bool LogToFile { get; set; } = false;
        public string ModDisplayName { get { return DisplayName; } }
        #endregion


        ///~ Mod Specific settings 

        #region BaseRecruitCost
        public int tier0RecruitCostBase { get; set; } = 10;
        public int tier1RecruitCostBase { get; set; } = 20;
        public int tier2RecruitCostBase { get; set; } = 50;
        public int tier3RecruitCostBase { get; set; } = 100;
        public int tier4RecruitCostBase { get; set; } = 200;
        public int tier5RecruitCostBase { get; set; } = 400;
        public int tier6RecruitCostBase { get; set; } = 600;
        public int tier7RecruitCostBase { get; set; } = 1000;
        public int tierOtherRecruitCostBase { get; set; } = 1500;
        #endregion BaseRecruitCost

        #region BaseWageCost
        public int tier0WagesBase { get; set; } = 1;
        public int tier1WagesBase { get; set; } = 2;
        public int tier2WagesBase { get; set; } = 3;
        public int tier3WagesBase { get; set; } = 5;
        public int tier4WagesBase { get; set; } = 8;
        public int tier5WagesBase { get; set; } = 12;
        public int tier6WagesBase { get; set; } = 17;
        public int tier7WagesBase { get; set; } = 23;
        public int tierOtherWagesBase { get; set; } = 33;
        #endregion BaseWageCost



        #region PlayerModifiers

        #region PlayerWagesTroopTiers
        public bool bUsePlayerTierWagesModifiers { get; set; } = false;
        public bool bUsePlayerCompanionWagesCostModifiers { get; set; } = false;
        public float tierPlayerCompanionWagesMultiplier { get; set; } = 1.0f;
        public float tier0PlayerWagesMultiplier { get; set; } = 1.0f;
        public float tier1PlayerWagesMultiplier { get; set; } = 1.0f;
        public float tier2PlayerWagesMultiplier { get; set; } = 1.0f;
        public float tier3PlayerWagesMultiplier { get; set; } = 1.0f;
        public float tier4PlayerWagesMultiplier { get; set; } = 1.0f;
        public float tier5PlayerWagesMultiplier { get; set; } = 1.0f;
        public float tier6PlayerWagesMultiplier { get; set; } = 1.0f;
        public float tier7PlayerWagesMultiplier { get; set; } = 1.0f;
        #endregion

        #region PlayerWagesCaravans
        public bool bUsePlayerCaravanWagesModifiers { get; set; } = false;

        public float wagesPlayerCaravanMultiplier { get; set; } = 1.0f;
        #endregion

        #region PlayerWagesGarrison
        public bool bUsePlayerGarrisonWagesModifiers { get; set; } = false;

        public float wagesPlayerGarrisonMultiplier { get; set; } = 1.0f;
        #endregion

        #region PlayerWagesMercenary
        public bool bUsePlayerMercenaryWagesModifiers { get; set; } = false;

        public float tierPlayerMercenaryWagesMultiplier { get; set; } = 2.0f;
        #endregion

        #region PlayerWagesBandit
        public bool bUsePlayerBanditWagesModifiers { get; set; } = false;

        public float playerBanditWagesMultiplier { get; set; } = 1.5f;
        #endregion


        #region PlayerWagesHorseTroops
        public bool bUsePlayerWithHorsesWages { get; set; } = false;

        public int tierPlayerHorseWages { get; set; } = 0;
        #endregion


        #region PlayerWagesRecruitmentCost
        public bool bUsePlayerRecruitCostModifiers { get; set; } = false;
        public bool bUsePlayerCompanionRecruitCostModifiers { get; set; } = false;

        public float tier0PlayerRecruitCostMultiplier { get; set; } = 1.0f;

        public float tier1PlayerRecruitCostMultiplier { get; set; } = 1.0f;

        public float tier2PlayerRecruitCostMultiplier { get; set; } = 1.0f;

        public float tier3PlayerRecruitCostMultiplier { get; set; } = 1.0f;

        public float tier4PlayerRecruitCostMultiplier { get; set; } = 1.0f;

        public float tier5PlayerRecruitCostMultiplier { get; set; } = 1.0f;

        public float tier6PlayerRecruitCostMultiplier { get; set; } = 1.0f;

        public float tier7PlayerRecruitCostMultiplier { get; set; } = 1.0f;

        public float tierMercenaryPlayerRecruitCostMultiplier { get; set; } = 2.0f;

        public float tierBanditPlayerRecruitCostMultiplier { get; set; } = 0.7f;

        public float tierCompanionRecruitCostMultiplier { get; set; } = 1.0f;

        public int tierMountedPlayerRecruitCost { get; set; } = 150;

        public int tierMountedPlayerRecruitHighCost { get; set; } = 500;
        #endregion


        #region PlayerWagesUpgradeCost
        public bool bUsePlayerUpgradeCostMultiplier { get; set; } = true;

        public float playerUpgradeCostMultiplier { get; set; } = 1.0f;

        public bool bUsePlayerUpgradeCostForClanMembers { get; set; } = true;
        #endregion


        #endregion PlayerModifiers


        #region AIModifiers

        #region AIWages
        public bool bUseAITierWagesModifiers { get; set; } = false;


        #region AIWagesTroopWages
        public float tierAIHeroWagesMultiplier { get; set; } = 1.0f;

        public float tier0AIWagesMultiplier { get; set; } = 1.0f;

        public float tier1AIWagesMultiplier { get; set; } = 1.0f;

        public float tier2AIWagesMultiplier { get; set; } = 1.0f;

        public float tier3AIWagesMultiplier { get; set; } = 1.0f;

        public float tier4AIWagesMultiplier { get; set; } = 1.0f;

        public float tier5AIWagesMultiplier { get; set; } = 1.0f;

        public float tier6AIWagesMultiplier { get; set; } = 1.0f;

        public float tier7AIWagesMultiplier { get; set; } = 1.0f;
        #endregion

        #region AIWagesCaravan
        public bool bUseAICaravanWagesModifiers { get; set; } = false;

        public float wagesAICaravanMultiplier { get; set; } = 1.0f;
        #endregion

        #region AIWagesGarrison
        public bool bUseAIGarrisonWagesModifiers { get; set; } = false;


        public float wagesAIGarrisonMultiplier { get; set; } = 1.0f;
        #endregion

        #region AIWagesHorseTroops
        public bool bUseAIWithHorsesWagesModifiers { get; set; } = false;

        public int tierAIHorseWages { get; set; } = 0;
        #endregion


        #region AIWagesMercenary
        public bool bUseAIMercenaryWagesModifiers { get; set; } = false;

        public float tierAIMercenaryWagesMultiplier { get; set; } = 2.0f;
        #endregion


        #region AIWagesBandit
        public bool bUseAIBanditWagesModifiers { get; set; } = false;
        public float tierAIBanditWagesMultiplier { get; set; } = 1.5f;
        #endregion

        #endregion AIWages


        #region AIWagesRecruitCost
        public bool bUseAIRecruitCostModifiers { get; set; } = false;

        public float tier0AIRecruitCostMultiplier { get; set; } = 1.0f;

        public float tier1AIRecruitCostMultiplier { get; set; } = 1.0f;

        public float tier2AIRecruitCostMultiplier { get; set; } = 1.0f;

        public float tier3AIRecruitCostMultiplier { get; set; } = 1.0f;

        public float tier4AIRecruitCostMultiplier { get; set; } = 1.0f;

        public float tier5AIRecruitCostMultiplier { get; set; } = 1.0f;

        public float tier6AIRecruitCostMultiplier { get; set; } = 1.0f;

        public float tier7AIRecruitCostMultiplier { get; set; } = 1.0f;

        public float tierMercenaryAIRecruitCostMultiplier { get; set; } = 2.0f;

        public float tierBanditAIRecruitCostMultiplier { get; set; } = 0.7f;

        public int tierMountedAIRecruitCost { get; set; } = 150;

        public int tierMountedAIRecruitHighCost { get; set; } = 500;
        #endregion

        #region AIWagesUpgradeCost
        public bool bUseAIUpgradeCostMultiplier { get; set; } = true;

        public float AIUpgradeCostMultiplier { get; set; } = 1.0f;
        #endregion


        #endregion AIModifiers
    }
}
