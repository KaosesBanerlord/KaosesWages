using KaosesWages.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.CampaignSystem;

namespace KaosesWages.Objects
{
    public class RecruiterType
    {
        public float tierHeroMultiplier = 1.0f;
        public float tier0Multiplier = 1.0f;
        public float tier1Multiplier = 1.0f;
        public float tier2Multiplier = 1.0f;
        public float tier3Multiplier = 1.0f;
        public float tier4Multiplier = 1.0f;
        public float tier5Multiplier = 1.0f;
        public float tier6Multiplier = 1.0f;
        public float tier7Multiplier = 1.0f;
        public float mercenaryCostMultiplier = 1.5f;
        public int withHorsesCost = 150;
        public int withHorsesHighCost = 150;
        /**
         * Imperial heavy horsemen lvl 21  cost 350  / 750   tier5 ?
         * 
         * aserai youth level 11  Cost 200 /  120
         * 
         * 20
         */
        public RecruiterType(Hero buyerHero)
        {
			//IsPlayerCompanion
            if(buyerHero != null)
            {
			    if (Settings.Instance.bUsePlayerRecruitCostModifiers && buyerHero.IsHumanPlayerCharacter)
			    {
                    this.loadPlayerMultipliers();
                }
			    if (Settings.Instance.bUsePlayerCompanionRecruitCostModifiers && buyerHero.IsPlayerCompanion)
                {
                    this.loadPlayerMultipliers();
                }
			    if (Settings.Instance.bUseAIRecruitCostModifiers && !buyerHero.IsHumanPlayerCharacter && !buyerHero.IsPlayerCompanion)
			    {
                    this.loadAIMultipliers();
                }
            }
        }
        private void loadPlayerMultipliers()
        {
            this.tier0Multiplier = Settings.Instance.tier0PlayerRecruitCostMultiplier;
            this.tier1Multiplier = Settings.Instance.tier1PlayerRecruitCostMultiplier;
            this.tier2Multiplier = Settings.Instance.tier2PlayerRecruitCostMultiplier;
            this.tier3Multiplier = Settings.Instance.tier3PlayerRecruitCostMultiplier;
            this.tier4Multiplier = Settings.Instance.tier4PlayerRecruitCostMultiplier;
            this.tier5Multiplier = Settings.Instance.tier5PlayerRecruitCostMultiplier;
            this.tier6Multiplier = Settings.Instance.tier6PlayerRecruitCostMultiplier;
            this.tier7Multiplier = Settings.Instance.tier7PlayerRecruitCostMultiplier;
            this.mercenaryCostMultiplier = Settings.Instance.tierMercenaryPlayerRecruitCostMultiplier;
            this.withHorsesCost = Settings.Instance.tierMountedPlayerRecruitCost;
            this.withHorsesHighCost = Settings.Instance.tierMountedPlayerRecruitHighCost;
        }

        private void loadAIMultipliers()
        {
            this.tier0Multiplier = Settings.Instance.tier0AIRecruitCostMultiplier;
            this.tier1Multiplier = Settings.Instance.tier1AIRecruitCostMultiplier;
            this.tier2Multiplier = Settings.Instance.tier2AIRecruitCostMultiplier;
            this.tier3Multiplier = Settings.Instance.tier3AIRecruitCostMultiplier;
            this.tier4Multiplier = Settings.Instance.tier4AIRecruitCostMultiplier;
            this.tier5Multiplier = Settings.Instance.tier5AIRecruitCostMultiplier;
            this.tier6Multiplier = Settings.Instance.tier6AIRecruitCostMultiplier;
            this.tier7Multiplier = Settings.Instance.tier7AIRecruitCostMultiplier;
            this.mercenaryCostMultiplier = Settings.Instance.tierMercenaryAIRecruitCostMultiplier;
            this.withHorsesCost = Settings.Instance.tierMountedAIRecruitCost;
            this.withHorsesHighCost = Settings.Instance.tierMountedAIRecruitHighCost;
        }
    }
}
