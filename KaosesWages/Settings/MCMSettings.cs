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
        public override string Id => Statics.InstanceID;

        // Build mod display name with name and version form the project properties version
#pragma warning disable CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
        string modName = Statics.DisplayName;
        public override string DisplayName => TextObjectHelper.Create("{=testModDisplayName}" + modName + " {VERSION}", new Dictionary<string, TextObject>()
        {
            { "VERSION", TextObjectHelper.Create(typeof(MCMSettings).Assembly.GetName().Version?.ToString(3) ?? "")! }
        })!.ToString();
#pragma warning restore CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.

        public override string FolderName => Statics.ModuleFolder;
        public override string FormatType => Statics.FormatType;

        #region ModDebug
        [SettingPropertyBool("{=debug}Debug", RequireRestart = false, 
            HintText = "{=debug_desc}Displays mod developer debug information and logs them to the file")]
        [SettingPropertyGroup("Debug")]
        public bool Debug { get; set; } = false;

        [SettingPropertyBool("{=debuglog}Log to file", RequireRestart = false, 
            HintText = "{=debuglog_desc}Log information messages to the log file as well as errors and debug")]
        [SettingPropertyGroup("Debug")]
        public bool LogToFile { get; set; } = false;

        public bool LoadMCMConfigFile { get; set; } = false;
        public string ModDisplayName { get { return DisplayName; } }
        #endregion


        ///~ Mod Specific settings 


        #region BaseRecruitCost
        [SettingPropertyBool("Base Recruit Cost Enabled", IsToggle = true, Order = 0, RequireRestart = false,
            HintText = "Enables modifying native Base recruit cost per tier")]
        [SettingPropertyGroup("Wages/General/Base Recruit")]
        public bool UseMCMRecruitBase { get; set; } = false;

        [SettingPropertyInteger("Tier 0 Base", 1, 3000, "0 Denars", Order = 1, RequireRestart = false,
            HintText = "Base cost for recruiting [Native 10].")]
        [SettingPropertyGroup("Wages/General/Base Recruit")]
        public int tier0RecruitCostBase { get; set; } = 10;

        [SettingPropertyInteger("Tier 1 Base", 1, 3000, "0 Denars", Order = 1, RequireRestart = false,
            HintText = "Base cost for recruiting [Native 20].")]
        [SettingPropertyGroup("Wages/General/Base Recruit")]
        public int tier1RecruitCostBase { get; set; } = 20;

        [SettingPropertyInteger("Tier 2 Base", 1, 3000, "0 Denars", Order = 1, RequireRestart = false,
            HintText = "Base cost for recruiting [Native 50].")]
        [SettingPropertyGroup("Wages/General/Base Recruit")]
        public int tier2RecruitCostBase { get; set; } = 50;

        [SettingPropertyInteger("Tier 3 Base", 1, 3000, "0 Denars", Order = 1, RequireRestart = false,
            HintText = "Base cost for recruiting [Native 100].")]
        [SettingPropertyGroup("Wages/General/Base Recruit")]
        public int tier3RecruitCostBase { get; set; } = 100;

        [SettingPropertyInteger("Tier 4 Base", 1, 3000, "0 Denars", Order = 1, RequireRestart = false,
            HintText = "Base cost for recruiting [Native 200].")]
        [SettingPropertyGroup("Wages/General/Base Recruit")]
        public int tier4RecruitCostBase { get; set; } = 200;

        [SettingPropertyInteger("Tier 5 Base", 1, 3000, "0 Denars", Order = 1, RequireRestart = false,
            HintText = "Base cost for recruiting [Native 400].")]
        [SettingPropertyGroup("Wages/General/Base Recruit")]
        public int tier5RecruitCostBase { get; set; } = 400;

        [SettingPropertyInteger("Tier 6 Base", 1, 3000, "0 Denars", Order = 1, RequireRestart = false,
            HintText = "Base cost for recruiting [Native 600].")]
        [SettingPropertyGroup("Wages/General/Base Recruit")]
        public int tier6RecruitCostBase { get; set; } = 600;

        [SettingPropertyInteger("Tier 7 Base", 1, 3000, "0 Denars", Order = 1, RequireRestart = false,
            HintText = "Base cost for recruiting [Native 1000].")]
        [SettingPropertyGroup("Wages/General/Base Recruit")]
        public int tier7RecruitCostBase { get; set; } = 1000;

        [SettingPropertyInteger("Tier Other Base", 1, 3000, "0 Denars", Order = 1, RequireRestart = false,
            HintText = "Base cost for recruiting [Native 1500].")]
        [SettingPropertyGroup("Wages/General/Base Recruit")]
        public int tierOtherRecruitCostBase { get; set; } = 1500;
        #endregion BaseRecruitCost

        #region BaseWageCost
        [SettingPropertyBool("Base wage cost Enabled", IsToggle = true, Order = 0, RequireRestart = false,
            HintText = "Enables modifying native Base wage cost per tier.")]
        [SettingPropertyGroup("Wages/General/Base Wages")]
        public bool UseMCMWageBase { get; set; } = false;

        [SettingPropertyInteger("Tier 0 Base", 1, 3000, "0 Denars", Order = 1, RequireRestart = false,
            HintText = "Base wage cost [Native 1].")]
        [SettingPropertyGroup("Wages/General/Base Wages")]
        public int tier0WagesBase { get; set; } = 1;

        [SettingPropertyInteger("Tier 1 Base", 1, 3000, "0 Denars", Order = 1, RequireRestart = false,
            HintText = "Base wage cost [Native 2].")]
        [SettingPropertyGroup("Wages/General/Base Wages")]
        public int tier1WagesBase { get; set; } = 2;

        [SettingPropertyInteger("Tier 2 Base", 1, 3000, "0 Denars", Order = 1, RequireRestart = false,
            HintText = "Base wage cost [Native 3].")]
        [SettingPropertyGroup("Wages/General/Base Wages")]
        public int tier2WagesBase { get; set; } = 3;

        [SettingPropertyInteger("Tier 3 Base", 1, 3000, "0 Denars", Order = 1, RequireRestart = false,
            HintText = "Base wage cost [Native 5].")]
        [SettingPropertyGroup("Wages/General/Base Wages")]
        public int tier3WagesBase { get; set; } = 5;

        [SettingPropertyInteger("Tier 4 Base", 1, 3000, "0 Denars", Order = 1, RequireRestart = false,
            HintText = "Base wage cost [Native 8].")]
        [SettingPropertyGroup("Wages/General/Base Wages")]
        public int tier4WagesBase { get; set; } = 8;

        [SettingPropertyInteger("Tier 5 Base", 1, 3000, "0 Denars", Order = 1, RequireRestart = false,
            HintText = "Base wage cost [Native 12].")]
        [SettingPropertyGroup("Wages/General/Base Wages")]
        public int tier5WagesBase { get; set; } = 12;

        [SettingPropertyInteger("Tier 6 Base", 1, 3000, "0 Denars", Order = 1, RequireRestart = false,
            HintText = "Base wage cost [Native 17].")]
        [SettingPropertyGroup("Wages/General/Base Wages")]
        public int tier6WagesBase { get; set; } = 17;

        [SettingPropertyInteger("Tier 7 Base", 1, 3000, "0 Denars", Order = 1, RequireRestart = false,
            HintText = "Base wage cost [Native 23].")]
        [SettingPropertyGroup("Wages/General/Base Wages")]
        public int tier7WagesBase { get; set; } = 23;

        [SettingPropertyInteger("Tier Other Base", 1, 3000, "0 Denars", Order = 1, RequireRestart = false,
            HintText = "Base wage cost [Native 33].")]
        [SettingPropertyGroup("Wages/General/Base Wages")]
        public int tierOtherWagesBase { get; set; } = 33;
        #endregion BaseWageCost



        // Player Tiered Wages
        #region PlayerWages

        [SettingPropertyBool("Player wages Enabled", IsToggle = true, Order = 0, RequireRestart = false, 
            HintText = "Enables modifying Player wage values.")]
        [SettingPropertyGroup("Wages/Player")]
        public bool bMenuPlayerModifiers { get; set; } = false;

        #region PlayerWagesTroopTiers
        [SettingPropertyBool("Tier troops wages Enabled", IsToggle = true, Order = 0, RequireRestart = false, 
            HintText = "Enables modifying Player troops wages by Tier.")]
        [SettingPropertyGroup("Wages/Player/Wages By Tier")]
        public bool bUsePlayerTierWagesModifiers { get; set; } = false;


        [SettingPropertyBool("Companion Wages as Player Enabled", Order = 0, RequireRestart = false, 
            HintText = "Enables Companion Troops wages to use same values as player ,else uses AI values.")]
        [SettingPropertyGroup("Wages/Player")]
        public bool bUsePlayerCompanionWagesCostModifiers { get; set; } = false;


        [SettingPropertyFloatingInteger("Companion Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "Multiply Companion wages by the multiplier supplied.")]
        [SettingPropertyGroup("Wages/Player/Wages By Tier")]
        public float tierPlayerCompanionWagesMultiplier { get; set; } = 1.0f;

        [SettingPropertyFloatingInteger("Tier 0 Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "Multiply Troop Tier 0 wages by the multiplier supplied.")]
        [SettingPropertyGroup("Wages/Player/Wages By Tier")]
        public float tier0PlayerWagesMultiplier { get; set; } = 1.0f;


        [SettingPropertyFloatingInteger("Tier 1 Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "Multiply Troop Tier 1 wages by the multiplier supplied.")]
        [SettingPropertyGroup("Wages/Player/Wages By Tier")]
        public float tier1PlayerWagesMultiplier { get; set; } = 1.0f;


        [SettingPropertyFloatingInteger("Tier 2 Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "Multiply Troop Tier 2 wages by the multiplier supplied.")]
        [SettingPropertyGroup("Wages/Player/Wages By Tier")]
        public float tier2PlayerWagesMultiplier { get; set; } = 1.0f;


        [SettingPropertyFloatingInteger("Tier 3 Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "Multiply Troop Tier 3 wages by the multiplier supplied.")]
        [SettingPropertyGroup("Wages/Player/Wages By Tier")]
        public float tier3PlayerWagesMultiplier { get; set; } = 1.0f;


        [SettingPropertyFloatingInteger("Tier 4 Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "Multiply Troop Tier 4 wages by the multiplier supplied.")]
        [SettingPropertyGroup("Wages/Player/Wages By Tier")]
        public float tier4PlayerWagesMultiplier { get; set; } = 1.0f;


        [SettingPropertyFloatingInteger("Tier 5 Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "Multiply Troop Tier 5 wages by the multiplier supplied.")]
        [SettingPropertyGroup("Wages/Player/Wages By Tier")]
        public float tier5PlayerWagesMultiplier { get; set; } = 1.0f;


        [SettingPropertyFloatingInteger("Tier 6 Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "Multiply Troop Tier 6 wages by the multiplier supplied.")]
        [SettingPropertyGroup("Wages/Player/Wages By Tier")]
        public float tier6PlayerWagesMultiplier { get; set; } = 1.0f;

        [SettingPropertyFloatingInteger("Tier 7+ Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false,
           HintText = "Multiply Troop Tier 7+ wages by the multiplier supplied.")]
        [SettingPropertyGroup("Wages/Player/Wages By Tier")]
        public float tier7PlayerWagesMultiplier { get; set; } = 1.0f;
        #endregion


        //Player Caravan Wages
        #region PlayerWagesCaravans
        [SettingPropertyBool("Caravan wages Enabled", IsToggle = true, Order = 0, RequireRestart = false, 
            HintText = "Enables modifying Player Caravan troops wages.")]
        [SettingPropertyGroup("Wages/Player/Caravan Wages")]
        public bool bUsePlayerCaravanWagesModifiers { get; set; } = false;


        [SettingPropertyFloatingInteger("Caravan Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "Multiply Caravan Troop wages cost by the multiplier supplied.")]
        [SettingPropertyGroup("Wages/Player/Caravan Wages")]
        public float wagesPlayerCaravanMultiplier { get; set; } = 1.0f;
        #endregion
        //Player Garrison Wages

        #region PlayerWagesGarrison
        [SettingPropertyBool("Garrison wages Enabled", IsToggle = true, Order = 0, RequireRestart = false, 
            HintText = "Enables modifying Player Garrison troops wages Requires.")]
        [SettingPropertyGroup("Wages/Player/Garrison Wages")]
        public bool bUsePlayerGarrisonWagesModifiers { get; set; } = false;


        [SettingPropertyFloatingInteger("Garrison Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "Multiply Garrison Troop wages cost by the multiplier supplied.")]
        [SettingPropertyGroup("Wages/Player/Garrison Wages")]
        public float wagesPlayerGarrisonMultiplier { get; set; } = 1.0f;
        #endregion
        //Player Mercenary Wages

        #region PlayerWagesMercenary
        [SettingPropertyBool("Mercenary wages Enabled", IsToggle = true, Order = 0, RequireRestart = false, 
            HintText = "Enables modifying Player mercenary wages.")]
        [SettingPropertyGroup("Wages/Player/Mercenary Wages")]
        public bool bUsePlayerMercenaryWagesModifiers { get; set; } = false;


        [SettingPropertyFloatingInteger("Mercenary Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "Multiply Troop Mercenary wages cost by the multiplier [Native:2.0].")]
        [SettingPropertyGroup("Wages/Player/Mercenary Wages")]
        public float tierPlayerMercenaryWagesMultiplier { get; set; } = 2.0f;
        #endregion
        

        #region PlayerWagesBandit
        [SettingPropertyBool("Bandit wages Enabled", IsToggle = true, Order = 0, RequireRestart = false, 
            HintText = "Enables modifying Player Bandit wages.")]
        [SettingPropertyGroup("Wages/Player/Bandit Wages")]
        public bool bUsePlayerBanditWagesModifiers { get; set; } = false;


        [SettingPropertyFloatingInteger("Bandit Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "Multiply Troop Bandit wages cost by the multiplier [Native: N/A].")]
        [SettingPropertyGroup("Wages/Player/Bandit Wages")]
        public float playerBanditWagesMultiplier { get; set; } = 1.5f;
        #endregion

        #region PlayerWagesHorseTroops
        [SettingPropertyBool("Mounted Additional Enabled", IsToggle = true, Order = 0, RequireRestart = false, 
            HintText = "Enables Player troops with horses additional wage costs.")]
        [SettingPropertyGroup("Wages/Player/Mounted Wages Cost")]
        public bool bUsePlayerWithHorsesWages { get; set; } = false;

        [SettingPropertyInteger("Mounted daily cost", 0, 1000, "0 Denars", Order = 1, RequireRestart = false, 
            HintText = "Additional mounted troops daily wage cost  [Native 0].")]
        [SettingPropertyGroup("Wages/Player/Mounted Wages Cost")]
        public int tierPlayerHorseWages { get; set; } = 0;
        #endregion


        //Player Recruit Costs
        #region PlayerWagesRecruitmentCost
        [SettingPropertyBool("Recruit Multipliers Enabled", IsToggle = true, Order = 0, RequireRestart = false, 
            HintText = "Enables Player Recruit Troops cost Multipliers.")]
        [SettingPropertyGroup("Wages/Player/Recruit Cost")]
        public bool bUsePlayerRecruitCostModifiers { get; set; } = false;

        //@todo Does this get used
        [SettingPropertyBool("Companion cost Multipliers Enabled", Order = 0, RequireRestart = false, 
            HintText = "Enables Companion Recruit Troops cost to be same as player values else uses AI values.")]
        [SettingPropertyGroup("Wages/Player/Recruit Cost")]
        public bool bUsePlayerCompanionRecruitCostModifiers { get; set; } = false;


        [SettingPropertyFloatingInteger("Tier 0 Recruit Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "Multiply Troop Tier 0 Recruit cost by this value.")]
        [SettingPropertyGroup("Wages/Player/Recruit Cost")]
        public float tier0PlayerRecruitCostMultiplier { get; set; } = 1.0f;


        [SettingPropertyFloatingInteger("Tier 1 Recruit Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false,
            HintText = "Multiply Troop Tier 1 Recruit cost by this value.")]
        [SettingPropertyGroup("Wages/Player/Recruit Cost")]
        public float tier1PlayerRecruitCostMultiplier { get; set; } = 1.0f;


        [SettingPropertyFloatingInteger("Tier 2 Recruit Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "Multiply Troop Tier 2 Recruit cost by this value.")]
        [SettingPropertyGroup("Wages/Player/Recruit Cost")]
        public float tier2PlayerRecruitCostMultiplier { get; set; } = 1.0f;


        [SettingPropertyFloatingInteger("Tier 3 Recruit Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "Multiply Troop Tier 3 Recruit cost by this value.")]
        [SettingPropertyGroup("Wages/Player/Recruit Cost")]
        public float tier3PlayerRecruitCostMultiplier { get; set; } = 1.0f;


        [SettingPropertyFloatingInteger("Tier 4 Recruit Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "Multiply Troop Tier 4 Recruit cost by this value.")]
        [SettingPropertyGroup("Wages/Player/Recruit Cost")]
        public float tier4PlayerRecruitCostMultiplier { get; set; } = 1.0f;


        [SettingPropertyFloatingInteger("Tier 5 Recruit Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "Multiply Troop Tier 5 Recruit cost by this value.")]
        [SettingPropertyGroup("Wages/Player/Recruit Cost")]
        public float tier5PlayerRecruitCostMultiplier { get; set; } = 1.0f;


        [SettingPropertyFloatingInteger("Tier 6 Recruit Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "Multiply Troop Tier 6 Recruit cost by this value.")]
        [SettingPropertyGroup("Wages/Player/Recruit Cost")]
        public float tier6PlayerRecruitCostMultiplier { get; set; } = 1.0f;


        [SettingPropertyFloatingInteger("Tier 7+ Recruit Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "Multiply Troop Tier 7+ Recruit cost by this value.")]
        [SettingPropertyGroup("Wages/Player/Recruit Cost")]
        public float tier7PlayerRecruitCostMultiplier { get; set; } = 1.0f;


        [SettingPropertyFloatingInteger("Mercenary Recruit Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "Multiply Troop Mercenary Recruit cost by this value [Native:2.0].")]
        [SettingPropertyGroup("Wages/Player/Recruit Cost")]
        public float tierMercenaryPlayerRecruitCostMultiplier { get; set; } = 2.0f;

        [SettingPropertyFloatingInteger("Bandit Recruit Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "Multiply Troop Bandit Recruit cost by this value [Native: N/A].")]
        [SettingPropertyGroup("Wages/Player/Recruit Cost")]
        public float tierBanditPlayerRecruitCostMultiplier { get; set; } = 0.7f;

        [SettingPropertyInteger("Mounted Recruit Tier < 4", 0, 1000, "0 Denars", Order = 1, RequireRestart = false, 
            HintText = "Mounted additional Recruit cost for troops Tier < 4 [Native:150] .")]
        [SettingPropertyGroup("Wages/Player/Recruit Cost")]
        public int tierMountedPlayerRecruitCost { get; set; } = 150;

        [SettingPropertyInteger("Mounted Recruit Tier >= 4", 0, 1000, "0 Denars", Order = 1, RequireRestart = false, 
            HintText = "Mounted additional Recruit cost for troops Tier >= 4 [Native:500].")]
        [SettingPropertyGroup("Wages/Player/Recruit Cost")]
        public int tierMountedPlayerRecruitHighCost { get; set; } = 500;

        [SettingPropertyFloatingInteger("Companion Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false,
            HintText = "Multiply Companion recruitment cost value for being hired by the player [Native:0].")]
        [SettingPropertyGroup("Wages/Player/Recruit Cost")]
        public float tierCompanionRecruitCostMultiplier { get; set; } = 1.0f;
        #endregion

        #region PlayerWagesUpgradeCost
        [SettingPropertyBool("Upgrade cost Multiplier Enable", IsToggle = true, Order = 0, RequireRestart = false,
            HintText = "Enables Player Troop upgrade cost Multipliers.")]
        [SettingPropertyGroup("Wages/Player/Upgrade Cost")]
        public bool bUsePlayerUpgradeCostMultiplier { get; set; } = false;


        [SettingPropertyFloatingInteger("Upgrade Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false,
            HintText = "Multiply the cost of upgrading troops for the player and optionally players clan.")]//
        [SettingPropertyGroup("Wages/Player/Upgrade Cost")]
        public float playerUpgradeCostMultiplier { get; set; } = 1.0f;

        //@todo is this used
        [SettingPropertyBool("Clan Uses Player Upgrade cost Enabled", Order = 0, RequireRestart = false,
            HintText = "Enables Clan member Troop upgrade cost to use player Multipliers.")]
        [SettingPropertyGroup("Wages/Player/Upgrade Cost")]
        public bool bUsePlayerUpgradeCostForClanMembers { get; set; } = true;
        #endregion

        #endregion


        #region AIWages

        [SettingPropertyBool("Modifying AI Enabled", IsToggle = true, Order = 0, RequireRestart = false, 
            HintText = "Enables modifying AI values.")]
        [SettingPropertyGroup("Wages/AI")]
        public bool bMenuAIModifiers { get; set; } = false;

        [SettingPropertyBool("Modifying AI wages Enabled", IsToggle = true, Order = 0, RequireRestart = false, 
            HintText = "Enables modifying AI troops wages by Tier.")]
        [SettingPropertyGroup("Wages/AI/Wages By Tier")]
        public bool bUseAITierWagesModifiers { get; set; } = false;


        #region AIWagesTroopWages
        [SettingPropertyFloatingInteger("Companion Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "Multiply AI Troop Companion wages by the multiplier supplied.")]//
        [SettingPropertyGroup("Wages/AI/Wages By Tier")]
        public float tierAIHeroWagesMultiplier { get; set; } = 1.0f;


        [SettingPropertyFloatingInteger("Tier 0 Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "Multiply AI Troop Tier 0 wages by the multiplier supplied.")]//
        [SettingPropertyGroup("Wages/AI/Wages By Tier")]
        public float tier0AIWagesMultiplier { get; set; } = 1.0f;


        [SettingPropertyFloatingInteger("Tier 1 Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "Multiply AI Troop Tier 1 wages by the multiplier supplied.")]//
        [SettingPropertyGroup("Wages/AI/Wages By Tier")]
        public float tier1AIWagesMultiplier { get; set; } = 1.0f;


        [SettingPropertyFloatingInteger("Tier 2 Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "Multiply AI Troop Tier 2 wages by the multiplier supplied.")]//
        [SettingPropertyGroup("Wages/AI/Wages By Tier")]
        public float tier2AIWagesMultiplier { get; set; } = 1.0f;


        [SettingPropertyFloatingInteger("Tier 3 Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "Multiply AI Troop Tier 3 wages by the multiplier supplied.")]//
        [SettingPropertyGroup("Wages/AI/Wages By Tier")]
        public float tier3AIWagesMultiplier { get; set; } = 1.0f;


        [SettingPropertyFloatingInteger("Tier 4 Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "Multiply AI Troop Tier 4 wages by the multiplier supplied.")]//
        [SettingPropertyGroup("Wages/AI/Wages By Tier")]
        public float tier4AIWagesMultiplier { get; set; } = 1.0f;


        [SettingPropertyFloatingInteger("Tier 5 Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "Multiply Troop Tier 5 wages by the multiplier supplied.")]//
        [SettingPropertyGroup("Wages/AI/Wages By Tier")]
        public float tier5AIWagesMultiplier { get; set; } = 1.0f;


        [SettingPropertyFloatingInteger("Tier 6 Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "Multiply Troop Tier 6 wages by the multiplier supplied.")]//
        [SettingPropertyGroup("Wages/AI/Wages By Tier")]
        public float tier6AIWagesMultiplier { get; set; } = 1.0f;


        [SettingPropertyFloatingInteger("Tier 7+ Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "Multiply Troop Tier 7+ wages by the multiplier supplied.")]//
        [SettingPropertyGroup("Wages/AI/Wages By Tier")]
        public float tier7AIWagesMultiplier { get; set; } = 1.0f;
        #endregion

        #region AIWagesCaravan
        [SettingPropertyBool("Caravan wages Enabled", IsToggle = true, Order = 0, RequireRestart = false, 
            HintText = "Enables modifying AI Caravan troops wages.")]
        [SettingPropertyGroup("Wages/AI/Caravan Wages")]
        public bool bUseAICaravanWagesModifiers { get; set; } = false;


        [SettingPropertyFloatingInteger("Caravan Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "Multiply AI Caravan Troop wages cost by the multiplier supplied.")]//
        [SettingPropertyGroup("Wages/AI/Caravan Wages")]
        public float wagesAICaravanMultiplier { get; set; } = 1.0f;
        #endregion

        #region AIWagesGarrison
        [SettingPropertyBool("Garrison wages Enabled", IsToggle = true, Order = 0, RequireRestart = false, 
            HintText = "Enables modifying AI Garrison troops wages")]
        [SettingPropertyGroup("Wages/AI/Garrison Wages")]
        public bool bUseAIGarrisonWagesModifiers { get; set; } = false;


        [SettingPropertyFloatingInteger("Garrison Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "Multiply AI Garrison Troop wage cost by the multiplier supplied.")]//
        [SettingPropertyGroup("Wages/AI/Garrison Wages")]
        public float wagesAIGarrisonMultiplier { get; set; } = 1.0f;
        #endregion

        #region AIWagesHorseTroops
        [SettingPropertyBool("Mounted wages Enabled", IsToggle = true, Order = 0, RequireRestart = false, 
            HintText = "Enables modifying AI troops with horses wages.")]
        [SettingPropertyGroup("Wages/AI/Mounted Wages")]
        public bool bUseAIWithHorsesWagesModifiers { get; set; } = false;

        [SettingPropertyInteger("Mounted cost", 0, 100, "0 Denars", Order = 1, RequireRestart = false, 
            HintText = "Additional AI mounted daily wage cost [Native 0].")]
        [SettingPropertyGroup("Wages/AI/Mounted Wages")]
        public int tierAIHorseWages { get; set; } = 0;
        #endregion

        #region AIWagesMercenary
        [SettingPropertyBool("Mercenary wages Enabled", IsToggle = true, Order = 0, RequireRestart = false, 
            HintText = "Enables modifying AI mercenary wages.")]
        [SettingPropertyGroup("Wages/AI/Mercenary Wages")]
        public bool bUseAIMercenaryWagesModifiers { get; set; } = false;


        [SettingPropertyFloatingInteger("Mercenary Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "Multiply AI Mercenary wage cost by the multiplier supplied  [Native 2.0].")]//
        [SettingPropertyGroup("Wages/AI/Mercenary Wages")]
        public float tierAIMercenaryWagesMultiplier { get; set; } = 2.0f;
        #endregion

        #region AIWagesBandit
        [SettingPropertyBool("Bandit wages Enabled", IsToggle = true, Order = 0, RequireRestart = false, 
            HintText = "Enables modifying AI Bandit wages.")]
        [SettingPropertyGroup("Wages/AI/Bandit Wages")]
        public bool bUseAIBanditWagesModifiers { get; set; } = false;


        [SettingPropertyFloatingInteger("Bandit Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "Multiply AI Bandit wage cost by the multiplier supplied  [Native 0].")]//
        [SettingPropertyGroup("Wages/AI/Bandit Wages")]
        public float tierAIBanditWagesMultiplier { get; set; } = 1.5f;
        #endregion

        #endregion

        #region AIWagesAIWagesRecruitCostCost
        [SettingPropertyBool("AI Recruit cost Multipliers Enabled", IsToggle = true, Order = 0, RequireRestart = false, 
            HintText = "Enables AI Recruit Troops cost Multipliers.")]
        [SettingPropertyGroup("Wages/AI/Recruit Cost")]
        public bool bUseAIRecruitCostModifiers { get; set; } = false;


        [SettingPropertyFloatingInteger("Tier 0 Recruit Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "Multiply AI Troop Tier 0 Recruit cost by this value.")]//
        [SettingPropertyGroup("Wages/AI/Recruit Cost")]
        public float tier0AIRecruitCostMultiplier { get; set; } = 1.0f;


        [SettingPropertyFloatingInteger("Tier 1 Recruit Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "Multiply AI Troop Tier 1 Recruit cost by this value.")]//
        [SettingPropertyGroup("Wages/AI/Recruit Cost")]
        public float tier1AIRecruitCostMultiplier { get; set; } = 1.0f;


        [SettingPropertyFloatingInteger("Tier 2 Recruit Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "Multiply AI Troop Tier 2 Recruit cost by this value.")]//
        [SettingPropertyGroup("Wages/AI/Recruit Cost")]
        public float tier2AIRecruitCostMultiplier { get; set; } = 1.0f;


        [SettingPropertyFloatingInteger("Tier 3 Recruit Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "Multiply AI Troop Tier 3 Recruit cost by this value.")]//
        [SettingPropertyGroup("Wages/AI/Recruit Cost")]
        public float tier3AIRecruitCostMultiplier { get; set; } = 1.0f;


        [SettingPropertyFloatingInteger("Tier 4 Recruit Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "Multiply AI Troop Tier 4 Recruit cost by this value.")]//
        [SettingPropertyGroup("Wages/AI/Recruit Cost")]
        public float tier4AIRecruitCostMultiplier { get; set; } = 1.0f;


        [SettingPropertyFloatingInteger("Tier 5 Recruit Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "Multiply AI Troop Tier 5 Recruit cost by this value.")]//
        [SettingPropertyGroup("Wages/AI/Recruit Cost")]
        public float tier5AIRecruitCostMultiplier { get; set; } = 1.0f;


        [SettingPropertyFloatingInteger("Tier 6 Recruit Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "Multiply AI Troop Tier 6 Recruit cost by this value.")]//
        [SettingPropertyGroup("Wages/AI/Recruit Cost")]
        public float tier6AIRecruitCostMultiplier { get; set; } = 1.0f;


        [SettingPropertyFloatingInteger("Tier 7+ Recruit Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "Multiply AI Troop Tier 7+ Recruit cost by this value.")]//
        [SettingPropertyGroup("Wages/AI/Recruit Cost")]
        public float tier7AIRecruitCostMultiplier { get; set; } = 1.0f;



        [SettingPropertyFloatingInteger("Mercenary Recruit Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "Multiply AI Troop Mercenary Recruit cost by this value  [Native 1.5].")]//
        [SettingPropertyGroup("Wages/AI/Recruit Cost")]
        public float tierMercenaryAIRecruitCostMultiplier { get; set; } = 2.0f;

        [SettingPropertyFloatingInteger("Bandit Recruit Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "Multiply AI Troop Bandit Recruit cost by this value  [Native 1.5].")]//
        [SettingPropertyGroup("Wages/AI/Recruit Cost")]
        public float tierBanditAIRecruitCostMultiplier { get; set; } = 0.7f;


        [SettingPropertyInteger("Mounted Recruit Tier < 4 ", 0, 1000, "0 Denars", Order = 1, RequireRestart = false, 
            HintText = "AI Troop With Mounts Recruit cost by this value for troops Tier < 4 [Native 150].")]
        [SettingPropertyGroup("Wages/AI/Recruit Cost")]
        public int tierMountedAIRecruitCost { get; set; } = 150;


        [SettingPropertyInteger("Mounted Recruit cost Tier >= 4", 0, 1000, "0 Denars", Order = 1, RequireRestart = false, 
            HintText = "AI Troop With Mounts Recruit cost by this value for troops Tier >= 4 [Native 500].")]
        [SettingPropertyGroup("Wages/AI/Recruit Cost")]
        public int tierMountedAIRecruitHighCost { get; set; } = 500;
        #endregion


        #region AIWagesUpgradeCost
        [SettingPropertyBool("Enable AI Upgrade cost Multiplier", IsToggle = true, Order = 0, RequireRestart = false, 
            HintText = "Enables AI Troop upgrade cost Multipliers.")]
        [SettingPropertyGroup("Wages/AI/Upgrade Cost")]
        public bool bUseAIUpgradeCostMultiplier { get; set; } = true;


        [SettingPropertyFloatingInteger("Troop Upgrade Multiplier", 0.1f, 10.0f, "#0%", Order = 2, RequireRestart = false, 
            HintText = "Multiply the cost of upgrading troops for the AI.")]//
        [SettingPropertyGroup("Wages/AI/Upgrade Cost")]
        public float AIUpgradeCostMultiplier { get; set; } = 1.0f;

        #endregion


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
