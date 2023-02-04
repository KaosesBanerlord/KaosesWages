using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Library;

namespace KaosesWagesCore.Objects
{

    public class KaosesTroopRecruitment : KaosesWageBase
    {

        public KaosesTroopRecruitment()
        {

        }



        public int GetTroopRecriutmentCostByTier(CharacterObject troop, bool withoutItemCost = false)
        {
            int result = 1500;
            int withHorseAdditional = GetTroopWithHorseRecruitCostAdditional(troop, withoutItemCost);
            int tierBase = GetRecruitBaseForTier(troop.Tier);
            float tierMultiplier = GetRecruitMultiplierForTier(troop.Tier);
            result = MathF.Round((float)GetFinalBaseRecruitCost(troop, tierBase, withHorseAdditional) * tierMultiplier);
            if (result < 1)
            {
                result = 1;
            }
            return result;
        }

        private int GetRecruitBaseForTier(int troopTier)
        {
            int tierBase = 0;
            switch (troopTier)
            {
                case 0:
                    tierBase = tier0RecruitCostBase;
                    break;
                case 1:
                    tierBase = tier1RecruitCostBase;
                    break;
                case 2:
                    tierBase = tier2RecruitCostBase;
                    break;
                case 3:
                    tierBase = tier3RecruitCostBase;
                    break;
                case 4:
                    tierBase = tier4RecruitCostBase;
                    break;
                case 5:
                    tierBase = tier5RecruitCostBase;
                    break;
                case 6:
                    tierBase = tier6RecruitCostBase;
                    break;
                case 7:
                    tierBase = tier7RecruitCostBase;
                    break;
                default:
                    tierBase = tierOtherRecruitCostBase;
                    break;
            }
            return tierBase;
        }


        private float GetRecruitMultiplierForTier(int troopTier)
        {
            float tierMultiplier = 1.0f;
            switch (troopTier)
            {
                case 0:
                    tierMultiplier = tier0RecruitCostMultiplier;
                    break;
                case 1:
                    tierMultiplier = tier1RecruitCostMultiplier;
                    break;
                case 2:
                    tierMultiplier = tier2RecruitCostMultiplier;
                    break;
                case 3:
                    tierMultiplier = tier3RecruitCostMultiplier;
                    break;
                case 4:
                    tierMultiplier = tier4RecruitCostMultiplier;
                    break;
                case 5:
                    tierMultiplier = tier5RecruitCostMultiplier;
                    break;
                case 6:
                    tierMultiplier = tier6RecruitCostMultiplier;
                    break;
                case 7:
                    tierMultiplier = tier7RecruitCostMultiplier;
                    break;
                default:
                    tierMultiplier = tier7RecruitCostMultiplier;
                    break;
            }
            return tierMultiplier;
        }

    }
}
