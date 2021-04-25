
namespace KaosesWages.Settings
{
    public interface ISettingsProviderInterface
    {
        #region ModDebug
        bool Debug { get; set; }
        bool LoadMCMConfigFile { get; set; }
        bool LogToFile { get; set; }
        string ModDisplayName { get; }
        #endregion

        ///~ Mod Specific settings 

        #region BaseRecruitCost
        public int tier0RecruitCostBase { get; set; }
        public int tier1RecruitCostBase { get; set; }
        public int tier2RecruitCostBase { get; set; }
        public int tier3RecruitCostBase { get; set; }
        public int tier4RecruitCostBase { get; set; }
        public int tier5RecruitCostBase { get; set; }
        public int tier6RecruitCostBase { get; set; }
        public int tier7RecruitCostBase { get; set; }
        public int tierOtherRecruitCostBase { get; set; }
        #endregion BaseRecruitCost

        #region BaseWageCost
        public int tier0WagesBase { get; set; }
        public int tier1WagesBase { get; set; }
        public int tier2WagesBase { get; set; }
        public int tier3WagesBase { get; set; }
        public int tier4WagesBase { get; set; }
        public int tier5WagesBase { get; set; }
        public int tier6WagesBase { get; set; }
        public int tier7WagesBase { get; set; }
        public int tierOtherWagesBase { get; set; }
        #endregion BaseWageCost


        // Player Tiered Wages
        #region PlayerModifiers

        #region PlayerWagesTroopTiers
        public bool bUsePlayerTierWagesModifiers { get; set; }
        public bool bUsePlayerCompanionWagesCostModifiers { get; set; }
        public float tierPlayerCompanionWagesMultiplier { get; set; }
        public float tier0PlayerWagesMultiplier { get; set; }
        public float tier1PlayerWagesMultiplier { get; set; }
        public float tier2PlayerWagesMultiplier { get; set; }
        public float tier3PlayerWagesMultiplier { get; set; }
        public float tier4PlayerWagesMultiplier { get; set; }
        public float tier5PlayerWagesMultiplier { get; set; }
        public float tier6PlayerWagesMultiplier { get; set; }
        public float tier7PlayerWagesMultiplier { get; set; }
        #endregion

        #region PlayerWagesCaravans
        public bool bUsePlayerCaravanWagesModifiers { get; set; }
        public float wagesPlayerCaravanMultiplier { get; set; }
        #endregion

        #region PlayerWagesGarrison
        public bool bUsePlayerGarrisonWagesModifiers { get; set; }
        public float wagesPlayerGarrisonMultiplier { get; set; }
        #endregion

        #region PlayerWagesMercenary
        public bool bUsePlayerMercenaryWagesModifiers { get; set; }
        public float tierPlayerMercenaryWagesMultiplier { get; set; }
        #endregion

        #region PlayerWagesBandit
        public bool bUsePlayerBanditWagesModifiers { get; set; }
        public float playerBanditWagesMultiplier { get; set; }
        #endregion


        #region PlayerWagesHorseTroops
        public bool bUsePlayerWithHorsesWages { get; set; }
        public int tierPlayerHorseWages { get; set; }
        #endregion


        #region PlayerWagesRecruitmentCost
        public bool bUsePlayerRecruitCostModifiers { get; set; }
        public bool bUsePlayerCompanionRecruitCostModifiers { get; set; }
        public float tier0PlayerRecruitCostMultiplier { get; set; }
        public float tier1PlayerRecruitCostMultiplier { get; set; }
        public float tier2PlayerRecruitCostMultiplier { get; set; }
        public float tier3PlayerRecruitCostMultiplier { get; set; }
        public float tier4PlayerRecruitCostMultiplier { get; set; }
        public float tier5PlayerRecruitCostMultiplier { get; set; }
        public float tier6PlayerRecruitCostMultiplier { get; set; }
        public float tier7PlayerRecruitCostMultiplier { get; set; }
        public float tierMercenaryPlayerRecruitCostMultiplier { get; set; }
        public float tierBanditPlayerRecruitCostMultiplier { get; set; }
        public float tierCompanionRecruitCostMultiplier { get; set; }
        public int tierMountedPlayerRecruitCost { get; set; }
        public int tierMountedPlayerRecruitHighCost { get; set; }
        #endregion

        #region PlayerWagesUpgradeCost
        public bool bUsePlayerUpgradeCostMultiplier { get; set; }
        public float playerUpgradeCostMultiplier { get; set; }
        public bool bUsePlayerUpgradeCostForClanMembers { get; set; }
        #endregion

        #endregion PlayerModifiers


        #region AIModifiers

        #region AIWages
        public bool bUseAITierWagesModifiers { get; set; }

        #region AIWagesTroopWages
        public float tierAIHeroWagesMultiplier { get; set; }
        public float tier0AIWagesMultiplier { get; set; }
        public float tier1AIWagesMultiplier { get; set; }
        public float tier2AIWagesMultiplier { get; set; }
        public float tier3AIWagesMultiplier { get; set; }
        public float tier4AIWagesMultiplier { get; set; }
        public float tier5AIWagesMultiplier { get; set; }
        public float tier6AIWagesMultiplier { get; set; }
        public float tier7AIWagesMultiplier { get; set; }
        #endregion


        #region AIWagesCaravan
        public bool bUseAICaravanWagesModifiers { get; set; }
        public float wagesAICaravanMultiplier { get; set; }
        #endregion

        #region AIWagesGarrison
        public bool bUseAIGarrisonWagesModifiers { get; set; }
        public float wagesAIGarrisonMultiplier { get; set; }
        #endregion


        #region AIWagesHorseTroops
        public bool bUseAIWithHorsesWagesModifiers { get; set; }
        public int tierAIHorseWages { get; set; }
        #endregion

        #region AIWagesMercenary
        public bool bUseAIMercenaryWagesModifiers { get; set; }
        public float tierAIMercenaryWagesMultiplier { get; set; }
        #endregion

        #region AIWagesBandit
        public bool bUseAIBanditWagesModifiers { get; set; }
        public float tierAIBanditWagesMultiplier { get; set; }
        #endregion

        #endregion AIWages


        #region AIWagesUpgradeCost
        public bool bUseAIRecruitCostModifiers { get; set; }
        public float tier0AIRecruitCostMultiplier { get; set; }
        public float tier1AIRecruitCostMultiplier { get; set; }
        public float tier2AIRecruitCostMultiplier { get; set; }
        public float tier3AIRecruitCostMultiplier { get; set; }
        public float tier4AIRecruitCostMultiplier { get; set; }
        public float tier5AIRecruitCostMultiplier { get; set; }
        public float tier6AIRecruitCostMultiplier { get; set; }
        public float tier7AIRecruitCostMultiplier { get; set; }
        public float tierMercenaryAIRecruitCostMultiplier { get; set; }
        public float tierBanditAIRecruitCostMultiplier { get; set; }
        public int tierMountedAIRecruitCost { get; set; }
        public int tierMountedAIRecruitHighCost { get; set; }
        #endregion

        #region AIWagesUpgradeCost
        public bool bUseAIUpgradeCostMultiplier { get; set; }
        public float AIUpgradeCostMultiplier { get; set; }
        #endregion


        #endregion AIModifiers
    }
}
