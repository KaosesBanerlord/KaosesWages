using Bannerlord.BUTR.Shared.Helpers;
using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Dropdown;
using MCM.Abstractions.Settings.Base;
using MCM.Abstractions.Settings.Base.Global;
using System;
//using MCM.Abstractions.Settings.Base.PerSave;
using System.Collections.Generic;
using TaleWorlds.Localization;

namespace KaosesWages.Settings
{
    //public class MCMSettings : AttributePerSaveSettings<MCMSettings>, ISettingsProviderInterface
    //public class MCMSettings : AttributeGlobalSettings<MCMSettings>, ISettingsProviderInterface 
    public class MCMSettings : AttributeGlobalSettings<MCMSettings>, ISettingsProviderInterface
    {
        #region ModSettingsStandard
        public override string Id => Statics.InstanceID;

        // Build mod display name with name and version form the project properties version
#pragma warning disable CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
        string modName = Statics.DisplayName;
        public override string DisplayName => TextObjectHelper.Create("{=KWDisplayName}" + modName + " {VERSION}", new Dictionary<string, TextObject>()
        {
            { "VERSION", TextObjectHelper.Create(typeof(MCMSettings).Assembly.GetName().Version?.ToString(3) ?? "")! }
        })!.ToString();
#pragma warning restore CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.

        public override string FolderName => Statics.ModuleFolder;
        public override string FormatType => Statics.FormatType;

        public bool LoadMCMConfigFile { get; set; } = false;
        public string ModDisplayName { get { return DisplayName; } }
        #endregion

        //[SettingPropertyBool("{=debug}Debug", RequireRestart = false, HintText = "{=}{=debug_desc}Displays mod developer debug information and logs them to the file")]
        //[SettingPropertyGroup("Debug", GroupOrder = 100)]
        public bool Debug { get; set; } = Statics.Debug;

        //[SettingPropertyBool("{=debuglog}Log to file", RequireRestart = false, HintText = "{=}{=debuglog_desc}Log information messages to the log file as well as errors and debug")]
        //[SettingPropertyGroup("Debug", GroupOrder = 100)]
        public bool LogToFile { get; set; } = Statics.LogToFile;


        ///~ Mod Specific settings 

        #region Debug

        #endregion Debug


        ///~ Mod Specific settings 

        //~ BaseRecruitCost
        #region BaseRecruitCost
        [SettingPropertyBool("{=KWM_BRCE}Base Recruit Cost Enabled", IsToggle = true, Order = 0, RequireRestart = false,
            HintText = "{=KWM_BRCEH}Enables modifying native Base recruit cost per tier")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=KWM_General}General" + "/" + "{=KWM_BaseRecruit}Base Recruit")]
        public bool UseMCMRecruitBase { get; set; } = false;

        [SettingPropertyInteger("{=KWM_T0}Tier 0", 1, 2000, "0 Denars", Order = 1, RequireRestart = false,
            HintText = "{=KWM_BCR1}Base cost for recruiting [Native 10].")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=KWM_General}General" + "/" + "{=KWM_BaseRecruit}Base Recruit")]
        public int tier0RecruitCostBase { get; set; } = 10;

        [SettingPropertyInteger("{=KWM_T1}Tier 1", 1, 2000, "0 Denars", Order = 1, RequireRestart = false,
            HintText = "{=KWM_BCR2}Base cost for recruiting [Native 20].")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=KWM_General}General" + "/" + "{=KWM_BaseRecruit}Base Recruit")]
        public int tier1RecruitCostBase { get; set; } = 20;

        [SettingPropertyInteger("{=KWM_T2}Tier 2", 1, 2000, "0 Denars", Order = 1, RequireRestart = false,
            HintText = "{=KWM_BCR3}Base cost for recruiting [Native 50].")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=KWM_General}General" + "/" + "{=KWM_BaseRecruit}Base Recruit")]
        public int tier2RecruitCostBase { get; set; } = 50;

        [SettingPropertyInteger("{=KWM_T3}Tier 3", 1, 2000, "0 Denars", Order = 1, RequireRestart = false,
            HintText = "{=KWM_BCR4}Base cost for recruiting [Native 100].")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=KWM_General}General" + "/" + "{=KWM_BaseRecruit}Base Recruit")]
        public int tier3RecruitCostBase { get; set; } = 100;

        [SettingPropertyInteger("{=KWM_T4}Tier 4", 1, 2000, "0 Denars", Order = 1, RequireRestart = false,
            HintText = "{=KWM_BCR5}Base cost for recruiting [Native 200].")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=KWM_General}General" + "/" + "{=KWM_BaseRecruit}Base Recruit")]
        public int tier4RecruitCostBase { get; set; } = 200;

        [SettingPropertyInteger("{=KWM_T5}Tier 5", 1, 2000, "0 Denars", Order = 1, RequireRestart = false,
            HintText = "{=KWM_BCR6}Base cost for recruiting [Native 400].")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=KWM_General}General" + "/" + "{=KWM_BaseRecruit}Base Recruit")]
        public int tier5RecruitCostBase { get; set; } = 400;

        [SettingPropertyInteger("{=KWM_T6}Tier 6", 1, 2000, "0 Denars", Order = 1, RequireRestart = false,
            HintText = "{=KWM_BCR7}Base cost for recruiting [Native 600].")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=KWM_General}General" + "/" + "{=KWM_BaseRecruit}Base Recruit")]
        public int tier6RecruitCostBase { get; set; } = 600;

        [SettingPropertyInteger("{=KWM_T7}Tier 7", 1, 3000, "0 Denars", Order = 1, RequireRestart = false,
            HintText = "{=KWM_BCR8}Base cost for recruiting [Native 1000].")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=KWM_General}General" + "/" + "{=KWM_BaseRecruit}Base Recruit")]
        public int tier7RecruitCostBase { get; set; } = 1000;

        [SettingPropertyInteger("{=KWM_TO}Tier Other", 1, 3000, "0 Denars", Order = 1, RequireRestart = false,
            HintText = "{=KWM_BCR9}Base cost for recruiting [Native 1500].")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=KWM_General}General" + "/" + "{=KWM_BaseRecruit}Base Recruit")]
        public int tierOtherRecruitCostBase { get; set; } = 1500;
        #endregion //~ BaseRecruitCost

        //~ BaseWageCost
        #region BaseWageCost
        [SettingPropertyBool("{=KWM_BWCE}Base wage cost Enabled", IsToggle = true, Order = 0, RequireRestart = false,
            HintText = "{=KWM_BWCEH}Enables modifying native Base wage cost per tier.")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=KWM_General}General" + "/" + "{=KWM_BaseWages}Base Wages")]
        public bool UseMCMWageBase { get; set; } = false;

        [SettingPropertyInteger("{=KWM_T0}Tier 0", 1, 1000, "0 Denars", Order = 1, RequireRestart = false,
            HintText = "{=KWM_BWC1}Base wage cost [Native 1].")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=KWM_General}General" + "/" + "{=KWM_BaseWages}Base Wages")]
        public int tier0WagesBase { get; set; } = 1;

        [SettingPropertyInteger("{=KWM_T1}Tier 1", 1, 1000, "0 Denars", Order = 1, RequireRestart = false,
            HintText = "{=KWM_BWC2}Base wage cost [Native 2].")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=KWM_General}General" + "/" + "{=KWM_BaseWages}Base Wages")]
        public int tier1WagesBase { get; set; } = 2;

        [SettingPropertyInteger("{=KWM_T2}Tier 2", 1, 1000, "0 Denars", Order = 1, RequireRestart = false,
            HintText = "{=KWM_BWC3}Base wage cost [Native 3].")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=KWM_General}General" + "/" + "{=KWM_BaseWages}Base Wages")]
        public int tier2WagesBase { get; set; } = 3;

        [SettingPropertyInteger("{=KWM_T3}Tier 3", 1, 1000, "0 Denars", Order = 1, RequireRestart = false,
            HintText = "{=KWM_BWC4}Base wage cost [Native 5].")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=KWM_General}General" + "/" + "{=KWM_BaseWages}Base Wages")]
        public int tier3WagesBase { get; set; } = 5;

        [SettingPropertyInteger("{=KWM_T4}Tier 4", 1, 1000, "0 Denars", Order = 1, RequireRestart = false,
            HintText = "{=KWM_BWC5}Base wage cost [Native 8].")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=KWM_General}General" + "/" + "{=KWM_BaseWages}Base Wages")]
        public int tier4WagesBase { get; set; } = 8;

        [SettingPropertyInteger("{=KWM_T5}Tier 5", 1, 1000, "0 Denars", Order = 1, RequireRestart = false,
            HintText = "{=KWM_BWC6}Base wage cost [Native 12].")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=KWM_General}General" + "/" + "{=KWM_BaseWages}Base Wages")]
        public int tier5WagesBase { get; set; } = 12;

        [SettingPropertyInteger("{=KWM_T6}Tier 6", 1, 1000, "0 Denars", Order = 1, RequireRestart = false,
            HintText = "{=KWM_BWC7}Base wage cost [Native 17].")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=KWM_General}General" + "/" + "{=KWM_BaseWages}Base Wages")]
        public int tier6WagesBase { get; set; } = 17;

        [SettingPropertyInteger("{=KWM_T7}Tier 7", 1, 1000, "0 Denars", Order = 1, RequireRestart = false,
            HintText = "{=KWM_BWC8}Base wage cost [Native 23].")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=KWM_General}General" + "/" + "{=KWM_BaseWages}Base Wages")]
        public int tier7WagesBase { get; set; } = 23;

        [SettingPropertyInteger("{=KWM_TO}Tier Other", 1, 1000, "0 Denars", Order = 1, RequireRestart = false,
            HintText = "{=KWM_BWC9}Base wage cost [Native 33].")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=KWM_General}General" + "/" + "{=KWM_BaseWages}Base Wages")]
        public int tierOtherWagesBase { get; set; } = 33;
        #endregion //~ BaseWageCost

        //~ PlayerWages
        #region PlayerWages
        [SettingPropertyBool("{=KWM_PWE}Player wages Enabled", IsToggle = true, Order = 0, RequireRestart = false, 
            HintText = "{KWM_PWEH}Enables modifying Player wage values.")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=Player}Player")]
        public bool bMenuPlayerModifiers { get; set; } = false;

        [SettingPropertyBool("{=KWM_CWAPE}Clan Wages as Player Enabled", Order = 0, RequireRestart = false, 
            HintText = "{=KWM_CWAPEH}Enables Clan Troops wages to use same values as player ,else uses AI values.")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=Player}Player")]
        public bool bUsePlayerCompanionWagesCostModifiers { get; set; } = false;

        //~ PlayerWagesTroopTiers
        #region PlayerWagesTroopTiers
        [SettingPropertyBool("{=KWM_TTWE}Tier troops wages Enabled", IsToggle = true, Order = 0, RequireRestart = false, 
            HintText = "{KWM_TTWEH}Enables modifying Player troops wages by Tier.")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=Player}Player" + "/" + "{=KWM_WagesByTier}Wages By Tier")]
        public bool bUsePlayerTierWagesModifiers { get; set; } = false;

        [SettingPropertyFloatingInteger("Companion Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "{=KWM_MTWBM}Multiply Troop wages by the multiplier supplied.")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=Player}Player" + "/" + "{=KWM_WagesByTier}Wages By Tier")]
        public float tierPlayerCompanionWagesMultiplier { get; set; } = 1.0f;

        [SettingPropertyFloatingInteger("{=KWM_T0}Tier 0", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "{=KWM_MTWBM}Multiply Troop wages by the multiplier supplied.")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=Player}Player" + "/" + "{=KWM_WagesByTier}Wages By Tier")]
        public float tier0PlayerWagesMultiplier { get; set; } = 1.0f;

        [SettingPropertyFloatingInteger("{=KWM_T1}Tier 1", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "{=KWM_MTWBM}Multiply Troop wages by the multiplier supplied.")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=Player}Player" + "/" + "{=KWM_WagesByTier}Wages By Tier")]
        public float tier1PlayerWagesMultiplier { get; set; } = 1.0f;

        [SettingPropertyFloatingInteger("{=KWM_T2}Tier 2", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "{=KWM_MTWBM}Multiply Troop wages by the multiplier supplied.")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=Player}Player" + "/" + "{=KWM_WagesByTier}Wages By Tier")]
        public float tier2PlayerWagesMultiplier { get; set; } = 1.0f;

        [SettingPropertyFloatingInteger("{=KWM_T3}Tier 3", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "{=KWM_MTWBM}Multiply Troop wages by the multiplier supplied.")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=Player}Player" + "/" + "{=KWM_WagesByTier}Wages By Tier")]
        public float tier3PlayerWagesMultiplier { get; set; } = 1.0f;

        [SettingPropertyFloatingInteger("{=KWM_T4}Tier 4", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "{=KWM_MTWBM}Multiply Troop wages by the multiplier supplied.")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=Player}Player" + "/" + "{=KWM_WagesByTier}Wages By Tier")]
        public float tier4PlayerWagesMultiplier { get; set; } = 1.0f;

        [SettingPropertyFloatingInteger("{=KWM_T5}Tier 5", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "{=KWM_MTWBM}Multiply Troop wages by the multiplier supplied.")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=Player}Player" + "/" + "{=KWM_WagesByTier}Wages By Tier")]
        public float tier5PlayerWagesMultiplier { get; set; } = 1.0f;

        [SettingPropertyFloatingInteger("{=KWM_T6}Tier 6", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "{=KWM_MTWBM}Multiply Troop wages by the multiplier supplied.")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=Player}Player" + "/" + "{=KWM_WagesByTier}Wages By Tier")]
        public float tier6PlayerWagesMultiplier { get; set; } = 1.0f;

        [SettingPropertyFloatingInteger("Tier 7+", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false,
           HintText = "{=KWM_MTWBM}Multiply Troop wages by the multiplier supplied.")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=Player}Player" + "/" + "{=KWM_WagesByTier}Wages By Tier")]
        public float tier7PlayerWagesMultiplier { get; set; } = 1.0f;
        #endregion //~ PlayerWagesTroopTiers

        //~ PlayerWagesCaravans
        #region PlayerWagesCaravans
        [SettingPropertyBool("{=KWM_CWE}Caravan wages Enabled", IsToggle = true, Order = 0, RequireRestart = false, 
            HintText = "{=KWM_CWEH}Enables modifying Caravan troops wages.")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=Player}Player" + "/" + "{=KWM_CaravanWages}Caravan Wages")]
        public bool bUsePlayerCaravanWagesModifiers { get; set; } = false;


        [SettingPropertyFloatingInteger("{=KWM_CM}Caravan Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "{=KWM_CMH}Multiply Caravan Troop wages cost by the multiplier supplied.")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=Player}Player" + "/" + "{=KWM_CaravanWages}Caravan Wages")]
        public float wagesPlayerCaravanMultiplier { get; set; } = 1.0f;
        #endregion //~ PlayerWagesCaravans

        //~ PlayerWagesGarrison
        #region PlayerWagesGarrison
        [SettingPropertyBool("{=KWM_GW}Garrison wages Enabled", IsToggle = true, Order = 0, RequireRestart = false, 
            HintText = "{=KWM_GWH}Enables modifying Garrison troops wages.")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=Player}Player" + "/" + "{=KWM_GarrisonWages}Garrison Wages")]
        public bool bUsePlayerGarrisonWagesModifiers { get; set; } = false;


        [SettingPropertyFloatingInteger("Garrison Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "Multiply Garrison Troop wages cost by the multiplier supplied.")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=Player}Player" + "/" + "{=KWM_GarrisonWages}Garrison Wages")]
        public float wagesPlayerGarrisonMultiplier { get; set; } = 1.0f;
        #endregion //~ PlayerWagesGarrison

        //~ PlayerWagesMercenary
        #region PlayerWagesMercenary
        [SettingPropertyBool("{=KWM_MWE}Mercenary wages Enabled", IsToggle = true, Order = 0, RequireRestart = false, 
            HintText = "{=KWM_MWEH}Enables modifying mercenary wages.")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=Player}Player" + "/" + "{=KWM_MercenaryWages}Mercenary Wages")]
        public bool bUsePlayerMercenaryWagesModifiers { get; set; } = false;


        [SettingPropertyFloatingInteger("{=KWM_MWM}Mercenary Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "{=KWM_MWMH}Multiply Troop Mercenary wages cost by the multiplier [Native:2.0].")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=Player}Player" + "/" + "{=KWM_MercenaryWages}Mercenary Wages")]
        public float tierPlayerMercenaryWagesMultiplier { get; set; } = 2.0f;
        #endregion //~ PlayerWagesMercenary

        //~ PlayerWagesBandit
        #region PlayerWagesBandit
        [SettingPropertyBool("{=KWM_BWE}Bandit wages Enabled", IsToggle = true, Order = 0, RequireRestart = false, 
            HintText = "{=KWM_BWEH}Enables modifying Bandit wages.")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=Player}Player" + "/" + "{=KWM_Bandit}Bandit")]
        public bool bUsePlayerBanditWagesModifiers { get; set; } = false;

        [SettingPropertyFloatingInteger("{=KWM_BWM}Bandit Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "{=KWM_BWMH}Multiply Troop Bandit wages cost by the multiplier [Native: N/A].")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=Player}Player" + "/" + "{=KWM_Bandit}Bandit")]
        public float playerBanditWagesMultiplier { get; set; } = 1.5f;
        #endregion //~ PlayerWagesBandit

        //~ PlayerWagesHorseTroops
        #region PlayerWagesHorseTroops
        [SettingPropertyBool("{=KWM_MAE}Mounted Additional Enabled", IsToggle = true, Order = 0, RequireRestart = false, 
            HintText = "{=KWM_MAEH}Enables troops with horses to have additional daily wage costs.")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=Player}Player" + "/" + "{=KWM_MountedWagesCost}Mounted Wages Cost")]
        public bool bUsePlayerWithHorsesWages { get; set; } = false;

        [SettingPropertyInteger("{=KWM_MDC}Mounted daily cost", 0, 1000, "0 Denars", Order = 1, RequireRestart = false, 
            HintText = "{=KWM_MDCH}Additional mounted troops daily wage cost  [Native 0].")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=Player}Player" + "/" + "{=KWM_MountedWagesCost}Mounted Wages Cost")]
        public int tierPlayerHorseWages { get; set; } = 0;
        #endregion //~ PlayerWagesHorseTroops

        //~ PlayerWagesRecruitmentCost
        #region PlayerWagesRecruitmentCost
        [SettingPropertyBool("{=KWM_RME}Recruit Multipliers Enabled", IsToggle = true, Order = 0, RequireRestart = false, 
            HintText = "{=KWM_RMEH}Enables Recruit Troops cost Multipliers.")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=Player}Player" + "/" + "{=KWM_RecruitCost}Recruit Cost")]
        public bool bUsePlayerRecruitCostModifiers { get; set; } = false;

        //@todo Does this get used
        [SettingPropertyBool("{=KWM_CCSAP}Clan cost same as Player Enabled", Order = 0, RequireRestart = false, 
            HintText = "{=KWM_CCSAPH}Enables Clan Recruit Troops cost to be same as player values else uses AI values.")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=Player}Player" + "/" + "{=KWM_RecruitCost}Recruit Cost")]
        public bool bUsePlayerCompanionRecruitCostModifiers { get; set; } = false;

        [SettingPropertyFloatingInteger("{=KWM_T0}Tier 0", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "{=KWM_MTRCM}Multiply Troop Recruit cost by the multiplier.")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=Player}Player" + "/" + "{=KWM_RecruitCost}Recruit Cost")]
        public float tier0PlayerRecruitCostMultiplier { get; set; } = 1.0f;

        [SettingPropertyFloatingInteger("{=KWM_T1}Tier 1", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false,
            HintText = "{=KWM_MTRCM}Multiply Troop Recruit cost by the multiplier.")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=Player}Player" + "/" + "{=KWM_RecruitCost}Recruit Cost")]
        public float tier1PlayerRecruitCostMultiplier { get; set; } = 1.0f;

        [SettingPropertyFloatingInteger("{=KWM_T2}Tier 2", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "{=KWM_MTRCM}Multiply Troop Recruit cost by the multiplier.")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=Player}Player" + "/" + "{=KWM_RecruitCost}Recruit Cost")]
        public float tier2PlayerRecruitCostMultiplier { get; set; } = 1.0f;

        [SettingPropertyFloatingInteger("{=KWM_T3}Tier 3", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "{=KWM_MTRCM}Multiply Troop Recruit cost by the multiplier.")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=Player}Player" + "/" + "{=KWM_RecruitCost}Recruit Cost")]
        public float tier3PlayerRecruitCostMultiplier { get; set; } = 1.0f;

        [SettingPropertyFloatingInteger("{=KWM_T4}Tier 4", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "{=KWM_MTRCM}Multiply Troop Recruit cost by the multiplier.")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=Player}Player" + "/" + "{=KWM_RecruitCost}Recruit Cost")]
        public float tier4PlayerRecruitCostMultiplier { get; set; } = 1.0f;

        [SettingPropertyFloatingInteger("{=KWM_T5}Tier 5", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "{=KWM_MTRCM}Multiply Troop Recruit cost by the multiplier.")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=Player}Player" + "/" + "{=KWM_RecruitCost}Recruit Cost")]
        public float tier5PlayerRecruitCostMultiplier { get; set; } = 1.0f;

        [SettingPropertyFloatingInteger("{=KWM_T6}Tier 6", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "{=KWM_MTRCM}Multiply Troop Recruit cost by the multiplier.")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=Player}Player" + "/" + "{=KWM_RecruitCost}Recruit Cost")]
        public float tier6PlayerRecruitCostMultiplier { get; set; } = 1.0f;

        [SettingPropertyFloatingInteger("{=KWM_T7}Tier 7", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "{=KWM_MTRCM}Multiply Troop Recruit cost by the multiplier.")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=Player}Player" + "/" + "{=KWM_RecruitCost}Recruit Cost")]
        public float tier7PlayerRecruitCostMultiplier { get; set; } = 1.0f;

        [SettingPropertyFloatingInteger("{=KWM_MCR}Mercenary Recruit Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "{=KWM_MTRCMH}Multiply Mercenary Recruit cost by the multiplier [Native:2.0].")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=Player}Player" + "/" + "{=KWM_RecruitCost}Recruit Cost")]
        public float tierMercenaryPlayerRecruitCostMultiplier { get; set; } = 2.0f;

        [SettingPropertyFloatingInteger("{=KWM_BCR}Bandit Recruit Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "{=KWM_MTBRCM}Multiply Bandit Recruit cost by this value [Native: N/A].")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=Player}Player" + "/" + "{=KWM_RecruitCost}Recruit Cost")]
        public float tierBanditPlayerRecruitCostMultiplier { get; set; } = 0.7f;

        [SettingPropertyInteger("{=KWM_MRCTL4}Mounted Recruit Tier less than 4", 0, 1000, "0 Denars", Order = 1, RequireRestart = false, 
            HintText = "{KWM_MTBRCMH}Mounted additional Recruit cost for troops Tier less than 4 [Native:150] .")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=Player}Player" + "/" + "{=KWM_RecruitCost}Recruit Cost")]
        public int tierMountedPlayerRecruitCost { get; set; } = 150;

        [SettingPropertyInteger("{KWM_MRCTG4}Mounted Recruit Tier greater than 4", 0, 1000, "0 Denars", Order = 1, RequireRestart = false, 
            HintText = "{KWM_MARC4}Mounted additional Recruit cost for troops Tier greater than or equal to 4 [Native:500].")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=Player}Player" + "/" + "{=KWM_RecruitCost}Recruit Cost")]
        public int tierMountedPlayerRecruitHighCost { get; set; } = 500;

        [SettingPropertyFloatingInteger("{=KWM_CMPM}Companion Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false,
            HintText = "{=KWM_CRCP}Multiply Companion recruitment cost value for being hired by the player [Native:0].")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=Player}Player" + "/" + "{=KWM_RecruitCost}Recruit Cost")]
        public float tierCompanionRecruitCostMultiplier { get; set; } = 1.0f;
        #endregion //~ PlayerWagesRecruitmentCost

        //~ PlayerWagesUpgradeCost
        #region PlayerWagesUpgradeCost
        [SettingPropertyBool("{=KWM_UCME}Upgrade cost Multiplier Enable", IsToggle = true, Order = 0, RequireRestart = false,
            HintText = "{=KWM_UCMEH}Enables Player Troop upgrade cost Multipliers.")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=Player}Player" + "/" + "{=KWM_UpgradeCost}Upgrade Cost")]
        public bool bUsePlayerUpgradeCostMultiplier { get; set; } = false;

        [SettingPropertyFloatingInteger("{=KWM_UM}Upgrade Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false,
            HintText = "{=KWM_UMH}Multiply the cost of upgrading troops.")]//
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=Player}Player" + "/" + "{=KWM_UpgradeCost}Upgrade Cost")]
        public float playerUpgradeCostMultiplier { get; set; } = 1.0f;

        //@todo is this used
        [SettingPropertyBool("{=KWM_CUPUCE}Clan Uses Player Upgrade cost Enabled", Order = 0, RequireRestart = false,
            HintText = "{=KWM_CUPUCEH}Enables Clan member Troop upgrade cost to use player Multipliers.")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=Player}Player" + "/" + "{=KWM_UpgradeCost}Upgrade Cost")]
        public bool bUsePlayerUpgradeCostForClanMembers { get; set; } = true;
        #endregion //~ PlayerWagesUpgradeCost
        #endregion //~ PlayerWages

        //~ AIWages
        #region AIWages
        [SettingPropertyBool("Modifying AI Enabled", IsToggle = true, Order = 0, RequireRestart = false, 
            HintText = "Enables modifying AI values.")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=KWM_AI}AI")]
        public bool bMenuAIModifiers { get; set; } = false;

        [SettingPropertyBool("{=KWM_MAIE}Modifying AI wages Enabled", IsToggle = true, Order = 0, RequireRestart = false, 
            HintText = "{=KWM_MAIEH}Enables modifying AI troops wages by Tier.")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=KWM_AI}AI" + "/" + "{=KWM_WagesByTier}Wages By Tier")]
        public bool bUseAITierWagesModifiers { get; set; } = false;

        //~ AIWagesTroopWages
        #region AIWagesTroopWages
/*
        [SettingPropertyFloatingInteger("Companion Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "Multiply AI Troop Companion wages by the multiplier supplied.")]//
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=KWM_AI}AI" + "/" + "{=KWM_WagesByTier}Wages By Tier")]*/
        public float tierAIHeroWagesMultiplier { get; set; } = 1.0f;

        [SettingPropertyFloatingInteger("{=KWM_T0}Tier 0", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "{=KWM_MTWBM}Multiply Troop wages by the multiplier supplied.")]//
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=KWM_AI}AI" + "/" + "{=KWM_WagesByTier}Wages By Tier")]
        public float tier0AIWagesMultiplier { get; set; } = 1.0f;

        [SettingPropertyFloatingInteger("{=KWM_T10}Tier 1", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "{=KWM_MTWBM}Multiply Troop wages by the multiplier supplied.")]//
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=KWM_AI}AI" + "/" + "{=KWM_WagesByTier}Wages By Tier")]
        public float tier1AIWagesMultiplier { get; set; } = 1.0f;

        [SettingPropertyFloatingInteger("{=KWM_T2}Tier 2", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "{=KWM_MTWBM}Multiply Troop wages by the multiplier supplied.")]//
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=KWM_AI}AI" + "/" + "{=KWM_WagesByTier}Wages By Tier")]
        public float tier2AIWagesMultiplier { get; set; } = 1.0f;

        [SettingPropertyFloatingInteger("{=KWM_T3}Tier 3", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "{=KWM_MTWBM}Multiply Troop wages by the multiplier supplied.")]//
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=KWM_AI}AI" + "/" + "{=KWM_WagesByTier}Wages By Tier")]
        public float tier3AIWagesMultiplier { get; set; } = 1.0f;

        [SettingPropertyFloatingInteger("{=KWM_T4}Tier 4", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "{=KWM_MTWBM}Multiply Troop wages by the multiplier supplied.")]//
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=KWM_AI}AI" + "/" + "{=KWM_WagesByTier}Wages By Tier")]
        public float tier4AIWagesMultiplier { get; set; } = 1.0f;

        [SettingPropertyFloatingInteger("{=KWM_T5}Tier 5", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "{=KWM_MTWBM}Multiply Troop wages by the multiplier supplied.")]//
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=KWM_AI}AI" + "/" + "{=KWM_WagesByTier}Wages By Tier")]
        public float tier5AIWagesMultiplier { get; set; } = 1.0f;

        [SettingPropertyFloatingInteger("{=KWM_T6}Tier 6", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "{=KWM_MTWBM}Multiply Troop wages by the multiplier supplied.")]//
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=KWM_AI}AI" + "/" + "{=KWM_WagesByTier}Wages By Tier")]
        public float tier6AIWagesMultiplier { get; set; } = 1.0f;

        [SettingPropertyFloatingInteger("{=KWM_T7}Tier 7", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "{=KWM_MTWBM}Multiply Troop wages by the multiplier supplied.")]//
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=KWM_AI}AI" + "/" + "{=KWM_WagesByTier}Wages By Tier")]
        public float tier7AIWagesMultiplier { get; set; } = 1.0f;
        #endregion //~ AIWagesTroopWages

        //~ AIWagesCaravan
        #region AIWagesCaravan
        [SettingPropertyBool("{=KWM_CWE}Caravan wages Enabled", IsToggle = true, Order = 0, RequireRestart = false, 
            HintText = "{KWM_CWEH}Enables modifying Caravan troops wages.")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=KWM_AI}AI" + "/" + "{=KWM_CaravanWages}Caravan Wages")]
        public bool bUseAICaravanWagesModifiers { get; set; } = false;

        [SettingPropertyFloatingInteger("{=KWM_CM}Caravan Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "{=KWM_CMH}Multiply Caravan Troop wages cost by the multiplier supplied.")]//
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=KWM_AI}AI" + "/" + "{=KWM_CaravanWages}Caravan Wages")]
        public float wagesAICaravanMultiplier { get; set; } = 1.0f;
        #endregion //~ AIWagesCaravan

        //~ AIWagesGarrison
        #region AIWagesGarrison
        [SettingPropertyBool("{KWM_GW}Garrison wages Enabled", IsToggle = true, Order = 0, RequireRestart = false, 
            HintText = "{=KWM_GWH}Enables modifying Garrison troops wages.")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=KWM_AI}AI" + "/" + "{KWM_GarrisonWages}Garrison Wages")]
        public bool bUseAIGarrisonWagesModifiers { get; set; } = false;

        [SettingPropertyFloatingInteger("{=KWM_GWM}Garrison Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "{=KWM_GWMH}Multiply Garrison Troop wages cost by the multiplier supplied.")]//
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=KWM_AI}AI" + "/" + "{KWM_GarrisonWages}Garrison Wages")]
        public float wagesAIGarrisonMultiplier { get; set; } = 1.0f;
        #endregion //~ AIWagesGarrison

        //~ AIWagesHorseTroops
        #region AIWagesHorseTroops
        [SettingPropertyBool("{=KWM_MAE}Mounted Additional Enabled", IsToggle = true, Order = 0, RequireRestart = false, 
            HintText = "{=KWM_MAEH}Enables troops with horses to have additional daily wage costs.")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=KWM_AI}AI" + "/" + "{=KWM_MountedWagesCost}Mounted Wages Cost")]
        public bool bUseAIWithHorsesWagesModifiers { get; set; } = false;

        [SettingPropertyInteger("{=KWM_MDC}Mounted daily cost", 0, 100, "0 Denars", Order = 1, RequireRestart = false, 
            HintText = "{=KWM_MDCH}Additional mounted troops daily wage cost  [Native 0].")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=KWM_AI}AI" + "/" + "{=KWM_MountedWagesCost}Mounted Wages Cost")]
        public int tierAIHorseWages { get; set; } = 0;
        #endregion //~ AIWagesHorseTroops

        //~ AIWagesMercenary
        #region AIWagesMercenary
        [SettingPropertyBool("{=KWM_MWE}Mercenary wages Enabled", IsToggle = true, Order = 0, RequireRestart = false, 
            HintText = "{=KWM_MWEH}Enables modifying mercenary wages.")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=KWM_AI}AI" + "/" + "{=KWM_MercenaryWages}Mercenary Wages")]
        public bool bUseAIMercenaryWagesModifiers { get; set; } = false;

        [SettingPropertyFloatingInteger("{=KWM_MWM}Mercenary Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "{=KWM_MWMH}Multiply Troop Mercenary wages cost by the multiplier [Native:2.0].")]//
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=KWM_AI}AI" + "/" + "{=KWM_MercenaryWages}Mercenary Wages")]
        public float tierAIMercenaryWagesMultiplier { get; set; } = 2.0f;
        #endregion //~ AIWagesMercenary

        //~ AIWagesBandit
        #region AIWagesBandit
        [SettingPropertyBool("{=KWM_BWE}Bandit wages Enabled", IsToggle = true, Order = 0, RequireRestart = false, 
            HintText = "{=KWM_BWEH}Enables modifying Bandit wages.")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=KWM_AI}AI" + "/" + "{=KWM_Bandit}Bandit")]
        public bool bUseAIBanditWagesModifiers { get; set; } = false;

        [SettingPropertyFloatingInteger("{=KWM_BWM}Bandit Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "{=KWM_BWMH}Multiply Troop Bandit wages cost by the multiplier [Native: N/A].")]//
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=KWM_AI}AI" + "/" + "{=KWM_Bandit}Bandit")]
        public float tierAIBanditWagesMultiplier { get; set; } = 1.5f;
        #endregion //~ AIWagesBandit

        //~ AIWagesAIWagesRecruitCostCost
        #region AIWagesAIWagesRecruitCostCost
        [SettingPropertyBool("{=KWM_RME}Recruit Multipliers Enabled", IsToggle = true, Order = 0, RequireRestart = false, 
            HintText = "{=KWM_RMEH}Enables Recruit Troops cost Multipliers.")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=KWM_AI}AI" + "/" + "{=KWM_RecruitCost}Recruit Cost")]
        public bool bUseAIRecruitCostModifiers { get; set; } = false;

        [SettingPropertyFloatingInteger("{=KWM_T0}Tier 0", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "{=KWM_MTRCM}Multiply Troop Recruit cost by the multiplier.")]//
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=KWM_AI}AI" + "/" + "{=KWM_RecruitCost}Recruit Cost")]
        public float tier0AIRecruitCostMultiplier { get; set; } = 1.0f;

        [SettingPropertyFloatingInteger("{=KWM_T1}Tier 1", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "{=KWM_MTRCM}Multiply Troop Recruit cost by the multiplier.")]//
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=KWM_AI}AI" + "/" + "{=KWM_RecruitCost}Recruit Cost")]
        public float tier1AIRecruitCostMultiplier { get; set; } = 1.0f;

        [SettingPropertyFloatingInteger("{=KWM_T2}Tier 2", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "{=KWM_MTRCM}Multiply Troop Recruit cost by the multiplier.")]//
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=KWM_AI}AI" + "/" + "{=KWM_RecruitCost}Recruit Cost")]
        public float tier2AIRecruitCostMultiplier { get; set; } = 1.0f;

        [SettingPropertyFloatingInteger("{=KWM_T3}Tier 3", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "{=KWM_MTRCM}Multiply Troop Recruit cost by the multiplier.")]//
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=KWM_AI}AI" + "/" + "{=KWM_RecruitCost}Recruit Cost")]
        public float tier3AIRecruitCostMultiplier { get; set; } = 1.0f;

        [SettingPropertyFloatingInteger("{=KWM_T4}Tier 4", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "{=KWM_MTRCM}Multiply Troop Recruit cost by the multiplier.")]//
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=KWM_AI}AI" + "/" + "{=KWM_RecruitCost}Recruit Cost")]
        public float tier4AIRecruitCostMultiplier { get; set; } = 1.0f;

        [SettingPropertyFloatingInteger("{=KWM_T5}Tier 5", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "{=KWM_MTRCM}Multiply Troop Recruit cost by the multiplier.")]//
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=KWM_AI}AI" + "/" + "{=KWM_RecruitCost}Recruit Cost")]
        public float tier5AIRecruitCostMultiplier { get; set; } = 1.0f;

        [SettingPropertyFloatingInteger("{=KWM_T6}Tier 6", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "{=KWM_MTRCM}Multiply Troop Recruit cost by the multiplier.")]//
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=KWM_AI}AI" + "/" + "{=KWM_RecruitCost}Recruit Cost")]
        public float tier6AIRecruitCostMultiplier { get; set; } = 1.0f;

        [SettingPropertyFloatingInteger("{=KWM_T7}Tier 7", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "{=KWM_MTRCM}Multiply Troop Recruit cost by the multiplier.")]//
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=KWM_AI}AI" + "/" + "{=KWM_RecruitCost}Recruit Cost")]
        public float tier7AIRecruitCostMultiplier { get; set; } = 1.0f;

        [SettingPropertyFloatingInteger("{=KWM_MCR}Mercenary Recruit Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "{=KWM_MTRCMH}Multiply Mercenary Recruit cost by the multiplier [Native:2.0].")]//
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=KWM_AI}AI" + "/" + "{=KWM_RecruitCost}Recruit Cost")]
        public float tierMercenaryAIRecruitCostMultiplier { get; set; } = 2.0f;

        [SettingPropertyFloatingInteger("{=KWM_BCR}Bandit Recruit Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "{=KWM_MTBRCM}Multiply Bandit Recruit cost by this value [Native: N/A].")]//
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=KWM_AI}AI" + "/" + "{=KWM_RecruitCost}Recruit Cost")]
        public float tierBanditAIRecruitCostMultiplier { get; set; } = 0.7f;

        [SettingPropertyInteger("{=KWM_MRCTL4}Mounted Recruit Tier less than 4", 0, 1000, "0 Denars", Order = 1, RequireRestart = false, 
            HintText = "{=KWM_MTBRCMH}Mounted additional Recruit cost for troops Tier less than 4 [Native:150] .")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=KWM_AI}AI" + "/" + "{=KWM_RecruitCost}Recruit Cost")]
        public int tierMountedAIRecruitCost { get; set; } = 150;

        [SettingPropertyInteger("{=KWM_MRCTG4}Mounted Recruit Tier greater than 4", 0, 1000, "0 Denars", Order = 1, RequireRestart = false, 
            HintText = "{=KWM_MARC4}Mounted additional Recruit cost for troops Tier greater than or equal to 4 [Native:500].")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=KWM_AI}AI" + "/" + "{=KWM_RecruitCost}Recruit Cost")]
        public int tierMountedAIRecruitHighCost { get; set; } = 500;
        #endregion //~ AIWagesAIWagesRecruitCostCost

        //~ AIWagesUpgradeCost
        #region AIWagesUpgradeCost
        [SettingPropertyBool("{=KWM_UCME}Upgrade cost Multiplier Enable", IsToggle = true, Order = 0, RequireRestart = false, 
            HintText = "{=KWM_UCMEHAI}Enables AI Troop upgrade cost Multipliers.")]
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=KWM_AI}AI" + "/" + "{=KWM_UpgradeCost}Upgrade Cost")]
        public bool bUseAIUpgradeCostMultiplier { get; set; } = true;


        [SettingPropertyFloatingInteger("{=KWM_UM}Upgrade Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "{KWM_UMH}Multiply the cost of upgrading troops.")]//
        [SettingPropertyGroup("{=KWM_Wages}Wages" + "/" + "{=KWM_AI}AI" + "/" + "{=KWM_UpgradeCost}Upgrade Cost")]
        public float AIUpgradeCostMultiplier { get; set; } = 1.0f;
        #endregion //~ AIWagesUpgradeCost
        #endregion //~ AIWages


        public override IDictionary<string, Func<BaseSettings>> GetAvailablePresets()
        {
            var basePresets = base.GetAvailablePresets(); // include the 'Default' preset that MCM provides
            
            basePresets.Add("native", () => new MCMSettings()
            {
                Debug = false,
                LoadMCMConfigFile = false,
                LogToFile = false,
                UseMCMRecruitBase = false,
                UseMCMWageBase = false,
                bMenuPlayerModifiers = false,
                bMenuAIModifiers = false,
                tier0RecruitCostBase = 10,
                tier1RecruitCostBase = 20,
                tier2RecruitCostBase = 50,
                tier3RecruitCostBase = 100,
                tier4RecruitCostBase = 200,
                tier5RecruitCostBase = 400,
                tier6RecruitCostBase = 600,
                tier7RecruitCostBase = 1000,
                tierOtherRecruitCostBase = 1500,
                tier0WagesBase = 1,
                tier1WagesBase = 2,
                tier2WagesBase = 3,
                tier3WagesBase = 5,
                tier4WagesBase = 8,
                tier5WagesBase = 12,
                tier6WagesBase = 17,
                tier7WagesBase = 23,
                tierOtherWagesBase = 33,
                bUsePlayerTierWagesModifiers = false,
                bUsePlayerCompanionWagesCostModifiers = false,
                tierPlayerCompanionWagesMultiplier = 1.0f,
                tier0PlayerWagesMultiplier = 1.0f,
                tier1PlayerWagesMultiplier = 1.0f,
                tier2PlayerWagesMultiplier = 1.0f,
                tier3PlayerWagesMultiplier = 1.0f,
                tier4PlayerWagesMultiplier = 1.0f,
                tier5PlayerWagesMultiplier = 1.0f,
                tier6PlayerWagesMultiplier = 1.0f,
                tier7PlayerWagesMultiplier = 1.0f,
                bUsePlayerCaravanWagesModifiers = false,
                wagesPlayerCaravanMultiplier = 1.0f,
                bUsePlayerGarrisonWagesModifiers = false,
                wagesPlayerGarrisonMultiplier = 1.0f,
                bUsePlayerMercenaryWagesModifiers = false,
                tierPlayerMercenaryWagesMultiplier = 2.0f,
                bUsePlayerBanditWagesModifiers = false,
                playerBanditWagesMultiplier = 1.0f,
                bUsePlayerWithHorsesWages = false,
                tierPlayerHorseWages = 0,
                bUsePlayerRecruitCostModifiers = false,
                bUsePlayerCompanionRecruitCostModifiers = false,
                tier0PlayerRecruitCostMultiplier = 1.0f,
                tier1PlayerRecruitCostMultiplier = 1.0f,
                tier2PlayerRecruitCostMultiplier = 1.0f,
                tier3PlayerRecruitCostMultiplier = 1.0f,
                tier4PlayerRecruitCostMultiplier = 1.0f,
                tier5PlayerRecruitCostMultiplier = 1.0f,
                tier6PlayerRecruitCostMultiplier = 1.0f,
                tier7PlayerRecruitCostMultiplier = 1.0f,
                tierMercenaryPlayerRecruitCostMultiplier = 2.0f,
                tierBanditPlayerRecruitCostMultiplier = 1.0f,
                tierCompanionRecruitCostMultiplier = 1.0f,
                tierMountedPlayerRecruitCost = 150,
                tierMountedPlayerRecruitHighCost = 500,
                bUsePlayerUpgradeCostMultiplier = false,
                playerUpgradeCostMultiplier = 1.0f,
                bUsePlayerUpgradeCostForClanMembers = false,

                bUseAITierWagesModifiers = false,
                tierAIHeroWagesMultiplier = 1.0f,
                tier0AIWagesMultiplier = 1.0f,
                tier1AIWagesMultiplier = 1.0f,
                tier2AIWagesMultiplier = 1.0f,
                tier3AIWagesMultiplier = 1.0f,
                tier4AIWagesMultiplier = 1.0f,
                tier5AIWagesMultiplier = 1.0f,
                tier6AIWagesMultiplier = 1.0f,
                tier7AIWagesMultiplier = 1.0f,
                bUseAICaravanWagesModifiers = false,
                wagesAICaravanMultiplier = 1.0f,
                bUseAIGarrisonWagesModifiers = false,
                wagesAIGarrisonMultiplier = 1.0f,
                bUseAIWithHorsesWagesModifiers = false,
                tierAIHorseWages = 0,
                bUseAIMercenaryWagesModifiers = false,
                tierAIMercenaryWagesMultiplier = 2.0f,
                bUseAIBanditWagesModifiers = false,
                tierAIBanditWagesMultiplier = 1.5f,
                bUseAIRecruitCostModifiers = false,
                tier0AIRecruitCostMultiplier = 1.0f,
                tier1AIRecruitCostMultiplier = 1.0f,
                tier2AIRecruitCostMultiplier = 1.0f,
                tier3AIRecruitCostMultiplier = 1.0f,
                tier4AIRecruitCostMultiplier = 1.0f,
                tier5AIRecruitCostMultiplier = 1.0f,
                tier6AIRecruitCostMultiplier = 1.0f,
                tier7AIRecruitCostMultiplier = 1.0f,
                tierMercenaryAIRecruitCostMultiplier = 2.0f,
                tierBanditAIRecruitCostMultiplier = 1.0f,
                tierMountedAIRecruitCost = 150,
                tierMountedAIRecruitHighCost = 500,
                bUseAIUpgradeCostMultiplier = false,
                AIUpgradeCostMultiplier = 1.0f,


            });

            basePresets.Add("Kaoses", () => new MCMSettings()
            {
                Debug = false,
                LoadMCMConfigFile = false,
                LogToFile = false,
                UseMCMRecruitBase = true,
                UseMCMWageBase = true,
                bMenuPlayerModifiers = true,
                bMenuAIModifiers = true,
                tier0RecruitCostBase = 5,
                tier1RecruitCostBase = 15,
                tier2RecruitCostBase = 56,
                tier3RecruitCostBase = 133,
                tier4RecruitCostBase = 230,
                tier5RecruitCostBase = 480,
                tier6RecruitCostBase = 720,
                tier7RecruitCostBase = 1110,
                tierOtherRecruitCostBase = 1850,
                tier0WagesBase = 1,
                tier1WagesBase = 2,
                tier2WagesBase = 4,
                tier3WagesBase = 8,
                tier4WagesBase = 16,
                tier5WagesBase = 22,
                tier6WagesBase = 32,
                tier7WagesBase = 42,
                tierOtherWagesBase = 56,
                bUsePlayerTierWagesModifiers = false,
                bUsePlayerCompanionWagesCostModifiers = false,
                tierPlayerCompanionWagesMultiplier = 1.0f,
                tier0PlayerWagesMultiplier = 1.0f,
                tier1PlayerWagesMultiplier = 1.0f,
                tier2PlayerWagesMultiplier = 1.0f,
                tier3PlayerWagesMultiplier = 1.0f,
                tier4PlayerWagesMultiplier = 1.1f,
                tier5PlayerWagesMultiplier = 1.2f,
                tier6PlayerWagesMultiplier = 1.3f,
                tier7PlayerWagesMultiplier = 1.4f,
                bUsePlayerCaravanWagesModifiers = true,
                wagesPlayerCaravanMultiplier = 0.8f,
                bUsePlayerGarrisonWagesModifiers = true,
                wagesPlayerGarrisonMultiplier = 0.7f,
                bUsePlayerMercenaryWagesModifiers = true,
                tierPlayerMercenaryWagesMultiplier = 2.5f,
                bUsePlayerBanditWagesModifiers = true,
                playerBanditWagesMultiplier = 1.5f,
                bUsePlayerWithHorsesWages = true,
                tierPlayerHorseWages = 2,
                bUsePlayerRecruitCostModifiers = true,
                bUsePlayerCompanionRecruitCostModifiers = true,
                tier0PlayerRecruitCostMultiplier = 1.0f,
                tier1PlayerRecruitCostMultiplier = 1.0f,
                tier2PlayerRecruitCostMultiplier = 1.0f,
                tier3PlayerRecruitCostMultiplier = 1.0f,
                tier4PlayerRecruitCostMultiplier = 1.0f,
                tier5PlayerRecruitCostMultiplier = 1.0f,
                tier6PlayerRecruitCostMultiplier = 1.0f,
                tier7PlayerRecruitCostMultiplier = 1.0f,
                tierMercenaryPlayerRecruitCostMultiplier = 2.2f,
                tierBanditPlayerRecruitCostMultiplier = 0.7f,
                tierCompanionRecruitCostMultiplier = 1.0f,
                tierMountedPlayerRecruitCost = 250,
                tierMountedPlayerRecruitHighCost = 650,
                bUsePlayerUpgradeCostMultiplier = true,
                playerUpgradeCostMultiplier = 1.3f,
                bUsePlayerUpgradeCostForClanMembers = true,

                bUseAITierWagesModifiers = false,
                tierAIHeroWagesMultiplier = 1.0f,
                tier0AIWagesMultiplier = 1.0f,
                tier1AIWagesMultiplier = 1.0f,
                tier2AIWagesMultiplier = 1.0f,
                tier3AIWagesMultiplier = 1.0f,
                tier4AIWagesMultiplier = 1.0f,
                tier5AIWagesMultiplier = 1.0f,
                tier6AIWagesMultiplier = 1.0f,
                tier7AIWagesMultiplier = 1.0f,
                bUseAICaravanWagesModifiers = true,
                wagesAICaravanMultiplier = 0.8f,
                bUseAIGarrisonWagesModifiers = true,
                wagesAIGarrisonMultiplier = 0.7f,
                bUseAIWithHorsesWagesModifiers = true,
                tierAIHorseWages = 2,
                bUseAIMercenaryWagesModifiers = true,
                tierAIMercenaryWagesMultiplier = 2.5f,
                bUseAIBanditWagesModifiers = true,
                tierAIBanditWagesMultiplier = 1.5f,
                bUseAIRecruitCostModifiers = true,
                tier0AIRecruitCostMultiplier = 1.0f,
                tier1AIRecruitCostMultiplier = 1.0f,
                tier2AIRecruitCostMultiplier = 1.0f,
                tier3AIRecruitCostMultiplier = 1.0f,
                tier4AIRecruitCostMultiplier = 1.0f,
                tier5AIRecruitCostMultiplier = 1.0f,
                tier6AIRecruitCostMultiplier = 1.0f,
                tier7AIRecruitCostMultiplier = 1.0f,
                tierMercenaryAIRecruitCostMultiplier = 2.2f,
                tierBanditAIRecruitCostMultiplier = 0.7f,
                tierMountedAIRecruitCost = 250,
                tierMountedAIRecruitHighCost = 650,
                bUseAIUpgradeCostMultiplier = true,
                AIUpgradeCostMultiplier = 1.3f,
            });
            /*
            basePresets.Add("True", () => new MCMSettings()
            {
                Property1 = true,
                Property2 = true
            });
            */
            return basePresets;
        }



    }
}
