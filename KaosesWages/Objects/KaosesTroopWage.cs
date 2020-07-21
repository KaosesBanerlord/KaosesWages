using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Library;

namespace KaosesWages.Objects
{
    public class KaosesTroopWage : KaosesWageBase
	{

		public KaosesTroopWage()
		{

		}


		// Copied out of source public sealed class CharacterObject : BasicCharacterObject, ICharacterData
		public int getTroopWage(CharacterObject troop)
		{
			if (troop.IsHero)
			{
				return getCalculatedWages(-1, false, 0, 2 + troop.Level * 2);
			}
			int withHorseAdditional = this.getTroopHorseWage(troop);
			bool bIsMercenary = this.isTroopMercenary(troop);

			int result = 33;
			switch (troop.Tier)
			{
				case -1:
					result = this.getCalculatedWages(-1, bIsMercenary, withHorseAdditional);
					break;
				case 0:
					result = this.getCalculatedWages(0, bIsMercenary, withHorseAdditional);
					break;
				case 1:
					result = this.getCalculatedWages(1, bIsMercenary, withHorseAdditional);
					break;
				case 2:
					result = this.getCalculatedWages(2, bIsMercenary, withHorseAdditional);
					break;
				case 3:
					result = this.getCalculatedWages(3, bIsMercenary, withHorseAdditional);
					break;
				case 4:
					result = this.getCalculatedWages(4, bIsMercenary, withHorseAdditional);
					break;
				case 5:
					result = this.getCalculatedWages(5, bIsMercenary, withHorseAdditional);
					break;
				case 6:
					result = this.getCalculatedWages(6, bIsMercenary, withHorseAdditional);
					break;
				case 7:
					result = this.getCalculatedWages(7, bIsMercenary, withHorseAdditional);
					break;
				default:
					result = this.getCalculatedWages(8, bIsMercenary, withHorseAdditional);
					break;
			}
			return result;
		}


		private int getCalculatedWages(int tier, bool bIsMercenary = false, int withHorseAdditional = 0, int heroBasewage = 0)
		{
			int result = 0;
			switch (tier)
			{
				case -1:
					result = MathF.Round((float)heroBasewage * this.tierHeroMultiplier);
					break;
				case 0:
					result = MathF.Round((float)this.getFinalBasCost(this.tier0WageBase, withHorseAdditional, bIsMercenary) * this.tier0Multiplier);
					break;
				case 1:
					result = MathF.Round((float)this.getFinalBasCost(this.tier1WageBase, withHorseAdditional, bIsMercenary) * this.tier1Multiplier);
					break;
				case 2:
					result = MathF.Round((float)this.getFinalBasCost(this.tier2WageBase, withHorseAdditional, bIsMercenary) * this.tier2Multiplier);
					break;
				case 3:
					result = MathF.Round((float)this.getFinalBasCost(this.tier3WageBase, withHorseAdditional, bIsMercenary) * this.tier3Multiplier);
					break;
				case 4:
					result = MathF.Round((float)this.getFinalBasCost(this.tier4WageBase, withHorseAdditional, bIsMercenary) * this.tier4Multiplier);
					break;
				case 5:
					result = MathF.Round((float)this.getFinalBasCost(this.tier5WageBase, withHorseAdditional, bIsMercenary) * this.tier5Multiplier);
					break;
				case 6:
					result = MathF.Round((float)this.getFinalBasCost(this.tier6WageBase, withHorseAdditional, bIsMercenary) * this.tier6Multiplier);
					break;
				case 7:
					result = MathF.Round((float)this.getFinalBasCost(this.tier7WageBase, withHorseAdditional, bIsMercenary) * this.tier7Multiplier);
					break;
				default:
					result = MathF.Round((float)this.getFinalBasCost(this.tierOtherWageBase, withHorseAdditional, bIsMercenary) * this.tier7Multiplier);
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
