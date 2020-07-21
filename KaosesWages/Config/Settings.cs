using KaosesWages.Utils;
using ModLib.Definitions;
using ModLib.Definitions.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace KaosesWages.Config
{
    public class Settings : SettingsBase
    {
        public const string InstanceID = KaosesWagesSubModule.InstanceID;
        public const string ModuleFolder = KaosesWagesSubModule.ModuleFolder;
        public override string ModName => "KaosWages " + KaosesWagesSubModule.Version;
        public override string ModuleFolderName => ModuleFolder;

        [XmlElement]
        public override string ID { get; set; } = InstanceID;

        private static Settings _instance;

        public static Settings Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = (Settings)SettingsDatabase.GetSettings<Settings>();
                }
                return _instance;
            }
        }

        public static void SetSettings(Settings settings)
        {
            _instance = settings;
        }

        public bool bIsDebug { get; set; } = true;

        public bool bLogToFile { get; set; } = false;

        public bool bOverRideModLibSettings { get; set; } = false;

        public string modVersionOfConfig { get; set; } = KaosesWagesSubModule.Version;


        /*[XmlElement]
        [SettingProperty("Use Recruit Costs By Level (Native) Enabled", "Enables Natives old Recruit Costs By Level instead of by Tier this doesnt change the cost of troops just how we determine the orginal cost")]// modifying wages
        [SettingPropertyGroup("Config/General")]
        */
        public bool bUseNativeRecruitCostSystem { get; set; } = false;


        //PLAYER OPTIONS ENABLERS
        [XmlElement]
        [SettingProperty("Companion Recruit Troops cost Multipliers Enabled", "Enables Companion Recruit Troops cost to be same as player values else uses AI values")]// modifying wages
        [SettingPropertyGroup("Wages/Config/Player")]
        public bool bUsePlayerCompanionRecruitCostModifiers { get; set; } = false;


        //PLAYER OPTIONS ENABLERS
        // Player Tiered Wages
        [XmlElement]
        [SettingProperty("Modifying Player troops wages Enabled", "Enables modifying Player troops wages")]
        [SettingPropertyGroup("Wages/Player/Wages By Tier", true)]
        public bool bUsePlayerTierWagesModifiers { get; set; } = false;

        [XmlElement]
        [SettingProperty("Troop Hero wages Multiplier", 0.1f, 10.0f, "Multiply Troop Hero wages by the multiplier supplied")]
        [SettingPropertyGroup("Wages/Player/Wages By Tier")]
        public float tierPlayerHeroWagesMultiplier { get; set; } = 1.0f;

        [XmlElement]
        [SettingProperty("Troop Tier 0 wages Multiplier", 0.1f, 10.0f, "Multiply Troop Tier 0 wages by the multiplier supplied")]
        [SettingPropertyGroup("Wages/Player/Wages By Tier")]
        public float tier0PlayerWagesMultiplier { get; set; } = 1.0f;

        [XmlElement]
        [SettingProperty("Troop Tier 1 wages Multiplier", 0.1f, 10.0f, "Multiply Troop Tier 1 wages by the multiplier supplied")]
        [SettingPropertyGroup("Wages/Player/Wages By Tier")]
        public float tier1PlayerWagesMultiplier { get; set; } = 1.0f;

        [XmlElement]
        [SettingProperty("Troop Tier 2 wages Multiplier", 0.1f, 10.0f, "Multiply Troop Tier 2 wages by the multiplier supplied")]
        [SettingPropertyGroup("Wages/Player/Wages By Tier")]
        public float tier2PlayerWagesMultiplier { get; set; } = 1.0f;

        [XmlElement]
        [SettingProperty("Troop Tier 3 wages Multiplier", 0.1f, 10.0f, "Multiply Troop Tier 3 wages by the multiplier supplied")]
        [SettingPropertyGroup("Wages/Player/Wages By Tier")]
        public float tier3PlayerWagesMultiplier { get; set; } = 1.0f;

        [XmlElement]
        [SettingProperty("Troop Tier 4 wages Multiplier", 0.1f, 10.0f, "Multiply Troop Tier 4 wages by the multiplier supplied")]
        [SettingPropertyGroup("Wages/Player/Wages By Tier")]
        public float tier4PlayerWagesMultiplier { get; set; } = 1.0f;

        [XmlElement]
        [SettingProperty("Troop Tier 5 wages Multiplier", 0.1f, 10.0f, "Multiply Troop Tier 5 wages by the multiplier supplied")]
        [SettingPropertyGroup("Wages/Player/Wages By Tier")]
        public float tier5PlayerWagesMultiplier { get; set; } = 1.0f;

        [XmlElement]
        [SettingProperty("Troop Tier 6 wages Multiplier", 0.1f, 10.0f, "Multiply Troop Tier 6 wages by the multiplier supplied")]
        [SettingPropertyGroup("Wages/Player/Wages By Tier")]
        public float tier6PlayerWagesMultiplier { get; set; } = 1.0f;

        [XmlElement]
        [JsonProperty("tier7PlayerWagesMultiplier")]
        [SettingProperty("Troop Tier 7+ wages Multiplier", 0.1f, 10.0f, "Multiply Troop Tier 7+ wages by the multiplier supplied")]
        [SettingPropertyGroup("Wages/Player/Wages By Tier")]
        public float tier7PlayerWagesMultiplier { get; set; } = 1.0f;



        //Player Caravan Wages
        [XmlElement]
        [SettingProperty("Player Caravan Troops wages Enabled", "Enables modifying Player Caravan troops wages Requires")]// modifying wages
        [SettingPropertyGroup("Wages/Player/Caravan Wages", true)]
        public bool bUsePlayerCaravanWagesModifiers { get; set; } = false;

        [XmlElement]
        [SettingProperty("Caravan Troop cost Multiplier", 0.1f, 10.0f, "Multiply Caravan Troop cost by the multiplier supplied")]
        [SettingPropertyGroup("Wages/Player/Caravan Wages")]
        public float wagesPlayerCaravanMultiplier { get; set; } = 1.0f;

        //Player Garrison Wages
        [XmlElement]
        [SettingProperty("Player Garrison Troops wages Enabled", "Enables modifying Player Garrison troops wages Requires")]// modifying wages
        [SettingPropertyGroup("Wages/Player/Garrison Wages", true)]
        public bool bUsePlayerGarrisonWagesModifiers { get; set; } = false;

        [XmlElement]
        [SettingProperty("Garrison Troop cost Multiplier", 0.1f, 10.0f, "Multiply Garrison Troop cost by the multiplier supplied")]
        [SettingPropertyGroup("Wages/Player/Garrison Wages")]
        public float wagesPlayerGarrisonMultiplier { get; set; } = 1.0f;

        //Player Mercenary Wages
        [XmlElement]
        [SettingProperty("Player Mercenary wages Enabled", "Enables modifying Player mercenary wages")]
        [SettingPropertyGroup("Wages/Player/Mercenary Wages", true)]
        public bool bUsePlayerMercenaryWagesModifiers { get; set; } = false;

        [XmlElement]
        [SettingProperty("Troop Mercenary cost Multiplier", 0.1f, 10.0f, "Multiply Troop Mercenary cost by the multiplier [Native:1.5]")]
        [SettingPropertyGroup("Wages/Player/Mercenary Wages")]
        public float tierPlayerMercenaryWagesMultiplier { get; set; } = 1.5f;

        //Additional Troop With Horses Wages
        /// <summary>
        ///  Version 0.0.5 Modified
        /// </summary>
        [XmlElement]
        [SettingProperty("Player Troops with horses Additional wages Enabled", "Enables Player troops with horses additional wage ")]
        [SettingPropertyGroup("Wages/Player/Mounted Wages Cost", true)]
        public bool bUsePlayerWithHorsesWages { get; set; } = false;

        /// <summary>
        /// version 0.0.5 Additonal cost per day for troops with horses
        /// </summary>
        [XmlElement]
        [SettingProperty("Troop with Horse daily wage cost", 0, 1000, "Additional Troop with Horse daily wage cost  [Native 0]")]
        [SettingPropertyGroup("Wages/Player/Mounted Wages Cost")]
        public int tierPlayerHorseWages { get; set; } = 0;



        //Player Recruit Costs
        [XmlElement]
        [SettingProperty("Player Recruit Troops cost Multipliers Enabled", "Enables Player Recruit Troops cost Multipliers")]// modifying wages
        [SettingPropertyGroup("Wages/Player/Recruit Cost", true)]
        public bool bUsePlayerRecruitCostModifiers { get; set; } = false;

        [XmlElement]
        [SettingProperty("Troop Tier 0 Recruit cost Multiplier", 0.1f, 10.0f, "Multiply Troop Tier 0 Recruit cost by this value")]
        [SettingPropertyGroup("Wages/Player/Recruit Cost")]
        public float tier0PlayerRecruitCostMultiplier { get; set; } = 1.0f;

        [XmlElement]
        [SettingProperty("Player Troop Tier 1 Recruit cost Multiplier", 0.1f, 10.0f, "Multiply Troop Tier 1 Recruit cost by this value")]
        [SettingPropertyGroup("Wages/Player/Recruit Cost")]
        public float tier1PlayerRecruitCostMultiplier { get; set; } = 1.0f;

        [XmlElement]
        [SettingProperty("Troop Tier 2 Recruit cost Multiplier", 0.1f, 10.0f, "Multiply Troop Tier 2 Recruit cost by this value")]
        [SettingPropertyGroup("Wages/Player/Recruit Cost")]
        public float tier2PlayerRecruitCostMultiplier { get; set; } = 1.0f;

        [XmlElement]
        [SettingProperty("Troop Tier 3 Recruit cost Multiplier", 0.1f, 10.0f, "Multiply Troop Tier 3 Recruit cost by this value")]
        [SettingPropertyGroup("Wages/Player/Recruit Cost")]
        public float tier3PlayerRecruitCostMultiplier { get; set; } = 1.0f;

        [XmlElement]
        [SettingProperty("Troop Tier 4 Recruit cost Multiplier", 0.1f, 10.0f, "Multiply Troop Tier 4 Recruit cost by this value")]
        [SettingPropertyGroup("Wages/Player/Recruit Cost")]
        public float tier4PlayerRecruitCostMultiplier { get; set; } = 1.0f;

        [XmlElement]
        [SettingProperty("Troop Tier 5 Recruit cost Multiplier", 0.1f, 10.0f, "Multiply Troop Tier 5 Recruit cost by this value")]
        [SettingPropertyGroup("Wages/Player/Recruit Cost")]
        public float tier5PlayerRecruitCostMultiplier { get; set; } = 1.0f;

        [XmlElement]
        [SettingProperty("Troop Tier 6 Recruit cost Multiplier", 0.1f, 10.0f, "Multiply Troop Tier 6 Recruit cost by this value")]
        [SettingPropertyGroup("Wages/Player/Recruit Cost")]
        public float tier6PlayerRecruitCostMultiplier { get; set; } = 1.0f;

        [XmlElement]
        [SettingProperty("Troop Tier 7+ Recruit cost Multiplier", 0.1f, 10.0f, "Multiply Troop Tier 7+ Recruit cost by this value")]
        [SettingPropertyGroup("Wages/Player/Recruit Cost")]
        public float tier7PlayerRecruitCostMultiplier { get; set; } = 1.0f;

        [XmlElement]
        [SettingProperty("Troop Mercenary Recruit cost Multiplier", 0.1f, 10.0f, "Multiply Troop Mercenary Recruit cost by this value [Native:1.5]")]
        [SettingPropertyGroup("Wages/Player/Recruit Cost")]
        public float tierMercenaryPlayerRecruitCostMultiplier { get; set; } = 1.5f;

        /// <summary>
        /// version 0.0.5 additional cost to recruit troop with horse
        /// </summary>
        [XmlElement]
        [SettingProperty("Troop With Mounts Recruit cost Tier < 4", 0, 1000, "Troop With Mounts additional Recruit cost for troops Tier < 4 [Native:150] ")]
        [SettingPropertyGroup("Wages/Player/Recruit Cost")]
        public int tierMountedPlayerRecruitCost { get; set; } = 150;

        /// <summary>
        /// version 0.0.5 additional cost to recruit troop with horse
        /// </summary>
        [XmlElement]
        [SettingProperty("Troop With Mounts Recruit cost Tier >= 4", 0, 1000, "Troop With Mounts additional Recruit cost for troops Tier >= 4 [Native:150] ")]
        [SettingPropertyGroup("Wages/Player/Recruit Cost")]
        public int tierMountedPlayerRecruitHighCost { get; set; } = 150;



        //AI OPTIONS ENABLERS
        // AI Tier Wages
        [XmlElement]
        [SettingProperty("Modifying AI troops wages Enabled", "Enables modifying AI troops wages by Tier")]
        [SettingPropertyGroup("Wages/AI/Wages By Tier", true)]
        public bool bUseAITierWagesModifiers { get; set; } = false;

        [XmlElement]
        [SettingProperty("Troop Hero wages Multiplier", 0.1f, 10.0f, "Multiply AI Troop Hero wages by the multiplier supplied")]
        [SettingPropertyGroup("Wages/AI/Wages By Tier")]
        public float tierAIHeroWagesMultiplier { get; set; } = 1.0f;

        [XmlElement]
        [SettingProperty("Troop Tier 0 wages Multiplier", 0.1f, 10.0f, "Multiply AI Troop Tier 0 wages by the multiplier supplied")]
        [SettingPropertyGroup("Wages/AI/Wages By Tier")]
        public float tier0AIWagesMultiplier { get; set; } = 1.0f;

        [XmlElement]
        [SettingProperty("Troop Tier 1 wages Multiplier", 0.1f, 10.0f, "Multiply AI Troop Tier 1 wages by the multiplier supplied")]
        [SettingPropertyGroup("Wages/AI/Wages By Tier")]
        public float tier1AIWagesMultiplier { get; set; } = 1.0f;

        [XmlElement]
        [SettingProperty("Troop Tier 2 wages Multiplier", 0.1f, 10.0f, "Multiply AI Troop Tier 2 wages by the multiplier supplied")]
        [SettingPropertyGroup("Wages/AI/Wages By Tier")]
        public float tier2AIWagesMultiplier { get; set; } = 1.0f;

        [XmlElement]
        [SettingProperty("Troop Tier 3 wages Multiplier", 0.1f, 10.0f, "Multiply AI Troop Tier 3 wages by the multiplier supplied")]
        [SettingPropertyGroup("Wages/AI/Wages By Tier")]
        public float tier3AIWagesMultiplier { get; set; } = 1.0f;

        [XmlElement]
        [SettingProperty("Troop Tier 4 wages Multiplier", 0.1f, 10.0f, "Multiply AI Troop Tier 4 wages by the multiplier supplied")]
        [SettingPropertyGroup("Wages/AI/Wages By Tier")]
        public float tier4AIWagesMultiplier { get; set; } = 1.0f;

        [XmlElement]
        [SettingProperty("Troop Tier 5 wages Multiplier", 0.1f, 10.0f, "Multiply Troop Tier 5 wages by the multiplier supplied")]
        [SettingPropertyGroup("Wages/AI/Wages By Tier")]
        public float tier5AIWagesMultiplier { get; set; } = 1.0f;

        [XmlElement]
        [SettingProperty("Troop Tier 6 wages Multiplier", 0.1f, 10.0f, "Multiply Troop Tier 6 wages by the multiplier supplied")]
        [SettingPropertyGroup("Wages/AI/Wages By Tier")]
        public float tier6AIWagesMultiplier { get; set; } = 1.0f;

        [XmlElement]
        [SettingProperty("Troop Tier 7+ wages Multiplier", 0.1f, 10.0f, "Multiply Troop Tier 7+ wages by the multiplier supplied")]
        [SettingPropertyGroup("Wages/AI/Wages By Tier")]
        public float tier7AIWagesMultiplier { get; set; } = 1.0f;

        //AI Caravan Wages
        [XmlElement]
        [SettingProperty("Modify AI Caravan Troops wages Enabled", "Enables modifying AI Caravan troops wages")]// modifying wages
        [SettingPropertyGroup("Wages/AI/Caravan Wages", true)]
        public bool bUseAICaravanWagesModifiers { get; set; } = false;

        [XmlElement]
        [SettingProperty("Caravan Troop cost Multiplier", 0.1f, 10.0f, "Multiply AI Caravan Troop cost by the multiplier supplied")]
        [SettingPropertyGroup("Wages/AI/Caravan Wages")]
        public float wagesAICaravanMultiplier { get; set; } = 1.0f;

        //AI Garrison Wages
        [XmlElement]
        [SettingProperty("Modify AI Garrison Troops wages Enabled", "Enables modifying AI Garrison troops wages")]// modifying wages
        [SettingPropertyGroup("Wages/AI/Garrison Wages", true)]
        public bool bUseAIGarrisonWagesModifiers { get; set; } = false;

        [XmlElement]
        [SettingProperty("Garrison Troop cost Multiplier", 0.1f, 10.0f, "Multiply AI Garrison Troop cost by the multiplier supplied")]
        [SettingPropertyGroup("Wages/AI/Garrison Wages")]
        public float wagesAIGarrisonMultiplier { get; set; } = 1.0f;



        //AI Mounted Troop Wages
        [XmlElement]
        [SettingProperty("Modify AI Troops with horses wages Enabled", "Enables modifying AI troops with horses wages")]
        [SettingPropertyGroup("Wages/AI/Mounted Wages", true)]
        public bool bUseAIWithHorsesWagesModifiers { get; set; } = false;

        /// <summary>
        /// version 0.0.5 additional daily wage cost for troops with horses
        /// </summary>
        [XmlElement]
        [SettingProperty("Troop with Horse daily wage cost ", 0, 1000, "Additional AI Troop Horse daily wage cost [Native 0]")]
        [SettingPropertyGroup("Wages/AI/Mounted Wages")]
        public int tierAIHorseWages { get; set; } = 0;


        //AI Mercenary Wages
        [XmlElement]
        [SettingProperty("Modify AI Mercenary wages Enabled", "Enables modifying AI mercenary wages")]
        [SettingPropertyGroup("Wages/AI/Mercenary Wages", true)]
        public bool bUseAIMercenaryWagesModifiers { get; set; } = false;

        [XmlElement]
        [SettingProperty("Mercenary cost Multiplier", 0.1f, 10.0f, "Multiply AI Mercenary cost by the multiplier supplied  [Native 1.5]")]
        [SettingPropertyGroup("Wages/AI/Mercenary Wages")]
        public float tierAIMercenaryWagesMultiplier { get; set; } = 1.5f;



        [XmlElement]
        [SettingProperty("Enable Player Upgrade cost Multiplier", "Enables Player Troop upgrade cost Multipliers")]
        [SettingPropertyGroup("Wages/Player/Upgrade Cost", true)]
        public bool bUsePlayerUpgradeCostMultiplier { get; set; } = true;

        [XmlElement]
        [SettingProperty("Troop Upgrade cost Multiplier", 0.1f, 10.0f, "Multiply the cost of upgrading troops fro the player and optionally players clan")]
        [SettingPropertyGroup("Wages/Player/Upgrade Cost")]
        public float playerUpgradeCostMultiplier { get; set; } = 1.0f;

        [XmlElement]
        [SettingProperty("Clan Uses Player Upgrade cost Multiplier Enabled", "Enables Clan member Troop upgrade cost to use player Multipliers")]
        [SettingPropertyGroup("Wages/Player/Upgrade Cost")]
        public bool bUsePlayerUpgradeCostForClanMembers { get; set; } = true;




        //AI Recruit Costs
        [XmlElement]
        [SettingProperty("AI Recruit Troops cost Multipliers Enabled", "Enables AI Recruit Troops cost Multipliers")]// modifying wages
        [SettingPropertyGroup("Wages/AI/Recruit Cost", true)]
        public bool bUseAIRecruitCostModifiers { get; set; } = false;

        [XmlElement]
        [SettingProperty("Troop Tier 0 Recruit cost Multiplier", 0.1f, 10.0f, "Multiply AI Troop Tier 0 Recruit cost by this value")]
        [SettingPropertyGroup("Wages/AI/Recruit Cost")]
        public float tier0AIRecruitCostMultiplier { get; set; } = 1.0f;

        [XmlElement]
        [SettingProperty("Troop Tier 1 Recruit cost Multiplier", 0.1f, 10.0f, "Multiply AI Troop Tier 1 Recruit cost by this value")]
        [SettingPropertyGroup("Wages/AI/Recruit Cost")]
        public float tier1AIRecruitCostMultiplier { get; set; } = 1.0f;

        [XmlElement]
        [SettingProperty("Troop Tier 2 Recruit cost Multiplier", 0.1f, 10.0f, "Multiply AI Troop Tier 2 Recruit cost by this value")]
        [SettingPropertyGroup("Wages/AI/Recruit Cost")]
        public float tier2AIRecruitCostMultiplier { get; set; } = 1.0f;

        [XmlElement]
        [SettingProperty("Troop Tier 3 Recruit cost Multiplier", 0.1f, 10.0f, "Multiply AI Troop Tier 3 Recruit cost by this value")]
        [SettingPropertyGroup("Wages/AI/Recruit Cost")]
        public float tier3AIRecruitCostMultiplier { get; set; } = 1.0f;

        [XmlElement]
        [SettingProperty("Troop Tier 4 Recruit cost Multiplier", 0.1f, 10.0f, "Multiply AI Troop Tier 4 Recruit cost by this value")]
        [SettingPropertyGroup("Wages/AI/Recruit Cost")]
        public float tier4AIRecruitCostMultiplier { get; set; } = 1.0f;

        [XmlElement]
        [SettingProperty("Troop Tier 5 Recruit cost Multiplier", 0.1f, 10.0f, "Multiply AI Troop Tier 5 Recruit cost by this value")]
        [SettingPropertyGroup("Wages/AI/Recruit Cost")]
        public float tier5AIRecruitCostMultiplier { get; set; } = 1.0f;

        [XmlElement]
        [SettingProperty("Troop Tier 6 Recruit cost Multiplier", 0.1f, 10.0f, "Multiply AI Troop Tier 6 Recruit cost by this value")]
        [SettingPropertyGroup("Wages/AI/Recruit Cost")]
        public float tier6AIRecruitCostMultiplier { get; set; } = 1.0f;

        [XmlElement]
        [SettingProperty("Troop Tier 7+ Recruit cost Multiplier", 0.1f, 10.0f, "Multiply AI Troop Tier 7+ Recruit cost by this value")]
        [SettingPropertyGroup("Wages/AI/Recruit Cost")]
        public float tier7AIRecruitCostMultiplier { get; set; } = 1.0f;


        [XmlElement]
        [SettingProperty("Troop Mercenary Recruit cost Multiplier", 0.1f, 10.0f, "Multiply AI Troop Mercenary Recruit cost by this value  [Native 1.5]")]
        [SettingPropertyGroup("Wages/AI/Recruit Cost")]
        public float tierMercenaryAIRecruitCostMultiplier { get; set; } = 1.5f;

        /// <summary>
        /// version 0.0.5 additional cost to recruit troop with horse
        /// </summary>
        [XmlElement]
        [SettingProperty("Troop With Mounts Recruit cost Tier < 4 ", 0, 1000, " AI Troop With Mounts Recruit cost by this value for troops Tier < 4 [Native 150]")]
        [SettingPropertyGroup("Wages/AI/Recruit Cost")]
        public int tierMountedAIRecruitCost { get; set; } = 150;

        /// <summary>
        /// version 0.0.5 additional cost to recruit troop with horse
        /// </summary>
        [XmlElement]
        [SettingProperty("Troop With Mounts Recruit cost Tier >= 4", 0, 1000, "AI Troop With Mounts Recruit cost by this value for troops Tier >= 4 [Native 150]")]
        [SettingPropertyGroup("Wages/AI/Recruit Cost")]
        public int tierMountedAIRecruitHighCost { get; set; } = 150;

    }



}
