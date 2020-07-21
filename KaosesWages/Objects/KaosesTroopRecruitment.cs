using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Library;

namespace KaosesWages.Objects
{
    public class KaosesTroopRecruitment : KaosesWageBase
	{

		public KaosesTroopRecruitment()
        {

        }



		public int getTroopRecriutmentCostByTier(CharacterObject troop, bool withoutItemCost = false)
		{
			int num = 1500;
			int withHorseAdditional = this.getTroopHorseBase(troop, withoutItemCost);
			bool bIsMercenary = this.isTroopMercenary(troop);
			//bool bHasHorse = this.troopHasHorse(troop);

			switch (troop.Tier)
			{
				case -1:
					num = getCalculatedRecruitmentCost(-1, bIsMercenary, withHorseAdditional);
					break;
				case 0:
					num = getCalculatedRecruitmentCost(0, bIsMercenary, withHorseAdditional);
					break;
				case 1:
					num = getCalculatedRecruitmentCost(1, bIsMercenary, withHorseAdditional);
					break;
				case 2:
					num = getCalculatedRecruitmentCost(2, bIsMercenary, withHorseAdditional);
					break;
				case 3:
					num = getCalculatedRecruitmentCost(3, bIsMercenary, withHorseAdditional);
					break;
				case 4:
					num = getCalculatedRecruitmentCost(4, bIsMercenary, withHorseAdditional);
					break;
				case 5:
					num = getCalculatedRecruitmentCost(5, bIsMercenary, withHorseAdditional);
					break;
				case 6:
					num = getCalculatedRecruitmentCost(6, bIsMercenary, withHorseAdditional);
					break;
				case 7:
					num = getCalculatedRecruitmentCost(7, bIsMercenary, withHorseAdditional);
					break;
				default:
					num = getCalculatedRecruitmentCost(8, bIsMercenary, withHorseAdditional);
					break;
			}

			return num;
		}



		public int getCalculatedRecruitmentCost(int tier, bool bIsMercenary = false, int withHorseAdditional = 0)
		{
			int result = 0;

			switch (tier)
			{
				//case -1:
				//	troopMultipliedCosts = MathF.Round((float)cost * this.tier0CostMultiplier);
				//	break;
				case 0:
					result = MathF.Round((float)this.getFinalBasCost(this.tier0RecruitCostBase, withHorseAdditional, bIsMercenary) * this.tier0CostMultiplier);
					break;
				case 1:
					result = MathF.Round((float)this.getFinalBasCost(this.tier1RecruitCostBase, withHorseAdditional, bIsMercenary) * this.tier1CostMultiplier);
					break;
				case 2:
					result = MathF.Round((float)this.getFinalBasCost(this.tier2RecruitCostBase, withHorseAdditional, bIsMercenary) * this.tier2CostMultiplier);
					break;
				case 3:
					result = MathF.Round((float)this.getFinalBasCost(this.tier3RecruitCostBase, withHorseAdditional, bIsMercenary) * this.tier3CostMultiplier);
					break;
				case 4:
					result = MathF.Round((float)this.getFinalBasCost(this.tier4RecruitCostBase, withHorseAdditional, bIsMercenary) * this.tier4CostMultiplier);
					break;
				case 5:
					result = MathF.Round((float)this.getFinalBasCost(this.tier5RecruitCostBase, withHorseAdditional, bIsMercenary) * this.tier5CostMultiplier);
					break;
				case 6:
					result = MathF.Round((float)this.getFinalBasCost(this.tier6RecruitCostBase, withHorseAdditional, bIsMercenary) * this.tier6CostMultiplier);
					break;
				case 7:
					result = MathF.Round((float)this.getFinalBasCost(this.tier7RecruitCostBase, withHorseAdditional, bIsMercenary) * this.tier7CostMultiplier);
					break;
				default:
					result = MathF.Round((float)this.getFinalBasCost(this.tierOtherRecruitCostBase, withHorseAdditional, bIsMercenary) * this.tier7CostMultiplier);
					break;
			}

			if (result < 1)
			{
				result = 1;
			}
			return result;
		}
	}
}
