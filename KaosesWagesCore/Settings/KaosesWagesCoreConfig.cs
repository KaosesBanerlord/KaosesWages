using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.Localization;

namespace KaosesWagesCore.Settings
{
    public class KaosesWagesCoreConfig
    {
        private static KaosesWagesCoreConfig _instance = null;

        private KaosesWagesCoreConfig()
        {

        }

        public static KaosesWagesCoreConfig Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new KaosesWagesCoreConfig();
                return _instance;
            }
        }



        #region Debug
        public bool Debug { get; set; } = true;
        public bool LogToFile { get; set; } = true;


        #endregion //~Debug


        ///~ Mod Specific settings 
        #region Mod Specific settings


        //~ BaseRecruitCost
        #region BaseRecruitCost

        public bool UseMCMRecruitBase { get; set; } = false;
        public int tier0RecruitCostBase { get; set; } = 10;
        public int tier1RecruitCostBase { get; set; } = 20;
        public int tier2RecruitCostBase { get; set; } = 50;
        public int tier3RecruitCostBase { get; set; } = 100;
        public int tier4RecruitCostBase { get; set; } = 200;
        public int tier5RecruitCostBase { get; set; } = 400;
        public int tier6RecruitCostBase { get; set; } = 600;
        public int tier7RecruitCostBase { get; set; } = 1000;
        public int tierOtherRecruitCostBase { get; set; } = 1500;
        #endregion //~ BaseRecruitCost

        //~ BaseWageCost
        #region BaseWageCost
        public bool UseMCMWageBase { get; set; } = false;
        public int tier0WagesBase { get; set; } = 1;
        public int tier1WagesBase { get; set; } = 2;
        public int tier2WagesBase { get; set; } = 3;
        public int tier3WagesBase { get; set; } = 5;
        public int tier4WagesBase { get; set; } = 8;
        public int tier5WagesBase { get; set; } = 12;
        public int tier6WagesBase { get; set; } = 17;
        public int tier7WagesBase { get; set; } = 23;
        public int tierOtherWagesBase { get; set; } = 33;
        #endregion //~ BaseWageCost

        //~ PlayerWages
        #region PlayerWages
        public bool bMenuPlayerModifiers { get; set; } = false;
        public bool PlayerClanWagesSameAsPlayer { get; set; } = false;

        //~ PlayerWagesTroopTiers
        #region PlayerWagesTroopTiers
        public bool bUsePlayerTierWagesModifiers { get; set; } = false;
        public float tierPlayerCompanionWagesMultiplier { get; set; } = 1.0f;
        public float tier0PlayerWagesMultiplier { get; set; } = 1.0f;
        public float tier1PlayerWagesMultiplier { get; set; } = 1.0f;
        public float tier2PlayerWagesMultiplier { get; set; } = 1.0f;
        public float tier3PlayerWagesMultiplier { get; set; } = 1.0f;
        public float tier4PlayerWagesMultiplier { get; set; } = 1.0f;
        public float tier5PlayerWagesMultiplier { get; set; } = 1.0f;
        public float tier6PlayerWagesMultiplier { get; set; } = 1.0f;
        public float tier7PlayerWagesMultiplier { get; set; } = 1.0f;
        #endregion //~ PlayerWagesTroopTiers

        //~ PlayerWagesCaravans
        #region PlayerWagesCaravans
        public bool bUsePlayerCaravanWagesModifiers { get; set; } = false;
        public float wagesPlayerCaravanMultiplier { get; set; } = 1.0f;
        #endregion //~ PlayerWagesCaravans

        //~ PlayerWagesGarrison
        #region PlayerWagesGarrison
        public bool bUsePlayerGarrisonWagesModifiers { get; set; } = false;
        public float wagesPlayerGarrisonMultiplier { get; set; } = 1.0f;
        #endregion //~ PlayerWagesGarrison

        //~ PlayerWagesMercenary
        #region PlayerWagesMercenary
        public bool bUsePlayerMercenaryWagesModifiers { get; set; } = false;
        public float tierPlayerMercenaryWagesMultiplier { get; set; } = 2.0f;
        #endregion //~ PlayerWagesMercenary

        //~ PlayerWagesBandit
        #region PlayerWagesBandit
        public bool bUsePlayerBanditWagesModifiers { get; set; } = false;
        public float playerBanditWagesMultiplier { get; set; } = 1.5f;
        #endregion //~ PlayerWagesBandit

        //~ PlayerWagesHorseTroops
        #region PlayerWagesHorseTroops
        public bool bUsePlayerWithHorsesWages { get; set; } = false;
        public int tierPlayerHorseWages { get; set; } = 0;
        #endregion //~ PlayerWagesHorseTroops

        //~ PlayerWagesRecruitmentCost
        #region PlayerWagesRecruitmentCost
        public bool bUsePlayerRecruitCostModifiers { get; set; } = false;
        //@todo Does this get used
        public bool ClanUsesPLayerRecruitCostModifiers { get; set; } = false;
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
        public int tierMountedPlayerRecruitCost { get; set; } = 150;
        public int tierMountedPlayerRecruitHighCost { get; set; } = 500;
        public float tierCompanionRecruitCostMultiplier { get; set; } = 1.0f;
        #endregion //~ PlayerWagesRecruitmentCost

        //~ PlayerWagesUpgradeCost
        #region PlayerWagesUpgradeCost
        public bool bUsePlayerUpgradeCostMultiplier { get; set; } = false;
        public float playerUpgradeCostMultiplier { get; set; } = 1.0f;
        //@todo is this used
        public bool bUsePlayerUpgradeCostForClanMembers { get; set; } = true;
        #endregion //~ PlayerWagesUpgradeCost

        #endregion //~ PlayerWages

        //~ AIWages
        #region AIWages
        public bool bMenuAIModifiers { get; set; } = false;
        public bool bUseAITierWagesModifiers { get; set; } = false;

        //~ AIWagesTroopWages
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
        #endregion //~ AIWagesTroopWages

        //~ AIWagesCaravan
        #region AIWagesCaravan
        public bool bUseAICaravanWagesModifiers { get; set; } = false;
        public float wagesAICaravanMultiplier { get; set; } = 1.0f;
        #endregion //~ AIWagesCaravan

        //~ AIWagesGarrison
        #region AIWagesGarrison
        public bool bUseAIGarrisonWagesModifiers { get; set; } = false;
        public float wagesAIGarrisonMultiplier { get; set; } = 1.0f;
        #endregion //~ AIWagesGarrison

        //~ AIWagesHorseTroops
        #region AIWagesHorseTroops
        public bool bUseAIWithHorsesWagesModifiers { get; set; } = false;
        public int tierAIHorseWages { get; set; } = 0;
        #endregion //~ AIWagesHorseTroops

        //~ AIWagesMercenary
        #region AIWagesMercenary
        public bool bUseAIMercenaryWagesModifiers { get; set; } = false;
        public float tierAIMercenaryWagesMultiplier { get; set; } = 2.0f;
        #endregion //~ AIWagesMercenary

        //~ AIWagesBandit
        #region AIWagesBandit
        public bool bUseAIBanditWagesModifiers { get; set; } = false;
        public float tierAIBanditWagesMultiplier { get; set; } = 1.5f;
        #endregion //~ AIWagesBandit

        //~ AIWagesAIWagesRecruitCostCost
        #region AIWagesAIWagesRecruitCostCost
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
        #endregion //~ AIWagesAIWagesRecruitCostCost

        //~ AIWagesUpgradeCost
        #region AIWagesUpgradeCost
        public bool bUseAIUpgradeCostMultiplier { get; set; } = true;
        public float AIUpgradeCostMultiplier { get; set; } = 1.0f;
        #endregion //~ AIWagesUpgradeCost


        #endregion //~ AIWages

        #endregion


    }
}
