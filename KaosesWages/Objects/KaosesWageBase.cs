using KaosesWages.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Library;

namespace KaosesWages.Objects
{
    public class KaosesWageBase
    {

		public int tier0WageBase = 1;
		public int tier1WageBase = 2;
		public int tier2WageBase = 3;
		public int tier3WageBase = 5;
		public int tier4WageBase = 8;
		public int tier5WageBase = 13;
		public int tier6WageBase = 21;
		public int tier7WageBase = 33;
		public int tierOtherWageBase = 50;

		public float tierHeroMultiplier = 1.0f;
		public float tier0Multiplier = 1.0f;
		public float tier1Multiplier = 1.0f;
		public float tier2Multiplier = 1.0f;
		public float tier3Multiplier = 1.0f;
		public float tier4Multiplier = 1.0f;
		public float tier5Multiplier = 1.0f;
		public float tier6Multiplier = 1.0f;
		public float tier7Multiplier = 1.0f;
		public float mercenaryMultiplier = 1.5f;
		public int withHorsesWageCost = 0;
		public float garrisonMultiplier = 1.0f;
		public float caravanMultiplier = 1.0f;

		public int tier0RecruitCostBase = 10;
		public int tier1RecruitCostBase = 20;
		public int tier2RecruitCostBase = 50;
		public int tier3RecruitCostBase = 100;
		public int tier4RecruitCostBase = 200;
		public int tier5RecruitCostBase = 400;
		public int tier6RecruitCostBase = 600;
		public int tier7RecruitCostBase = 1000;
		public int tierOtherRecruitCostBase = 1500;

		public float tier0CostMultiplier = 1.0f;
		public float tier1CostMultiplier = 1.0f;
		public float tier2CostMultiplier = 1.0f;
		public float tier3CostMultiplier = 1.0f;
		public float tier4CostMultiplier = 1.0f;
		public float tier5CostMultiplier = 1.0f;
		public float tier6CostMultiplier = 1.0f;
		public float tier7CostMultiplier = 1.0f;
		public float mercenaryCostMultiplier = 1.5f;
		public int withHorsesRecriutCost = 150;
		public int withHorsesRecriutHighCost = 150;

		public void SetWagesMultipliers(WagesTypes wageTypes)
		{
			this.tierHeroMultiplier = wageTypes.tierHeroMultiplier;
			this.tier0Multiplier = wageTypes.tier0Multiplier;
			this.tier1Multiplier = wageTypes.tier1Multiplier;
			this.tier2Multiplier = wageTypes.tier2Multiplier;
			this.tier3Multiplier = wageTypes.tier3Multiplier;
			this.tier4Multiplier = wageTypes.tier4Multiplier;
			this.tier5Multiplier = wageTypes.tier5Multiplier;
			this.tier6Multiplier = wageTypes.tier6Multiplier;
			this.tier7Multiplier = wageTypes.tier7Multiplier;
			this.mercenaryMultiplier = wageTypes.mercenaryMultiplier;
			this.withHorsesWageCost = wageTypes.withHorsesWage;
			this.garrisonMultiplier = wageTypes.garrisonMultiplier;
			this.caravanMultiplier = wageTypes.caravanMultiplier;
		}

		public void setRecruitMultipliers(RecruiterType recruiterType)
		{
			this.tier0CostMultiplier = recruiterType.tier0Multiplier;
			this.tier1CostMultiplier = recruiterType.tier1Multiplier;
			this.tier2CostMultiplier = recruiterType.tier2Multiplier;
			this.tier3CostMultiplier = recruiterType.tier3Multiplier;
			this.tier4CostMultiplier = recruiterType.tier4Multiplier;
			this.tier5CostMultiplier = recruiterType.tier5Multiplier;
			this.tier6CostMultiplier = recruiterType.tier6Multiplier;
			this.tier7CostMultiplier = recruiterType.tier7Multiplier;
			this.mercenaryCostMultiplier = recruiterType.mercenaryCostMultiplier;
			this.withHorsesRecriutCost = recruiterType.withHorsesCost;
			this.withHorsesRecriutHighCost = recruiterType.withHorsesHighCost;
		}

		public int getFinalBasCost(int cost, int withHorseAdditional, bool bIsMercenary = false)
		{
			if (withHorseAdditional > 0)
			{
				cost += withHorseAdditional;
			}
			if (bIsMercenary)
			{
				cost = MathF.Round((float)cost * this.mercenaryCostMultiplier);
			}
			return cost;
		}

		public bool troopHasHorse(CharacterObject troop)
		{
			bool isMounted = false;
			if (troop.Equipment.Horse.Item != null)
			{
				isMounted = true;
			}
			return isMounted;
		}

		public int getTroopHorseBase(CharacterObject troop, bool withoutItemCost = false)
		{
			int withHorseAdditional = 0;
			if (troop.Equipment.Horse.Item != null && !withoutItemCost)
			{
				if (troop.Tier < 4)
				{
					withHorseAdditional = this.withHorsesRecriutCost;
				}
				else
				{
					withHorseAdditional = this.withHorsesRecriutHighCost;
				}

			}
			return withHorseAdditional;
		}
		public int getTroopHorseWage(CharacterObject troop, bool withoutItemCost = false)
		{
			int withHorseAdditional = 0;
			if (troop.Equipment.Horse.Item != null && !withoutItemCost)
			{
				withHorseAdditional = this.withHorsesWageCost;
			}
			return withHorseAdditional;
		}

		public bool isTroopMercenary(CharacterObject troop)
		{
			bool isMercenary = false;
			bool flag = troop.Occupation == Occupation.Mercenary || troop.Occupation == Occupation.Gangster;
			if (flag)
			{
				isMercenary = true;
			}
			return isMercenary;
		}

		public static bool isPlayerClan(PartyBase party)
		{
			bool isSame  = false;
			Hero hero = party.LeaderHero;
			if (hero != null)
			{
				Clan clan = hero.Clan;
				Clan playerClan = Clan.PlayerClan;
				if(clan == playerClan)
				{
					isSame = true;
				}
			}
			return isSame;
		}
	}
}
