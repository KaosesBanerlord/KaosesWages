using Helpers;
using KaosesWages.Config;
using KaosesWages.Objects;
using KaosesWages.Utils;
using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Party;
using TaleWorlds.Library;
/**

    public sealed class GameModels : GameModelsManager
    {
        public GameModels(IEnumerable<GameModel> inputComponents);

        public HeroDeathProbabilityCalculationModel HeroDeathProbabilityCalculationModel { get; }
        public HeirSelectionCalculationModel HeirSelectionCalculationModel { get; }
        public SettlementTaxModel SettlementTaxModel { get; }
        public ClanFinanceModel ClanFinanceModel { get; }
        public ClanPoliticsModel ClanPoliticsModel { get; }
        public ClanTierModel ClanTierModel { get; }
        public SettlementGarrisonModel SettlementGarrisonModel { get; }
        public BuildingConstructionModel BuildingConstructionModel { get; }
        public SettlementProsperityModel SettlementProsperityModel { get; }
        public SettlementLoyaltyModel SettlementLoyaltyModel { get; }
        public SettlementMilitiaModel SettlementMilitiaModel { get; }
        public SettlementValueModel SettlementValueModel { get; }
        public SettlementFoodModel SettlementFoodModel { get; }
        public SettlementEconomyModel SettlementConsumptionModel { get; }
        public TradeItemPriceFactorModel TradeItemPriceFactorModel { get; }
        public TargetScoreCalculatingModel TargetScoreCalculatingModel { get; }
        public SettlementSecurityModel SettlementSecurityModel { get; }
        public FaceGenAttributeChangerModel FaceGenAttributeChangerModel { get; }
        public BuildingEffectModel BuildingEffectModel { get; }
        public MarriageModel MarriageModel { get; }
        public PrisonerRecruitmentCalculationModel PrisonerRecruitmentCalculationModel { get; }
        public IssueDifficultyMultiplierCalculationModel IssueDifficultyMultiplierCalculationModel { get; }
        public SettlementAccessModel SettlementAccessModel { get; }
        public BuildingScoreCalculationModel BuildingScoreCalculationModel { get; }
        public CompanionHiringPriceCalculationModel CompanionHiringPriceCalculationModel { get; }
        public SiegeEventModel SiegeEventModel { get; }
        public SiegeStrategyActionModel SiegeStrategyActionModel { get; }
        public WallHitPointCalculationModel WallHitPointCalculationModel { get; }
        public TroopSacrificeModel TroopSacrificeModel { get; }
        public DisguiseDetectionModel DisguiseDetectionModel { get; }
        public CrimeModel CrimeModel { get; }
        public TournamentModel TournamentModel { get; }
        public NotablePowerModel NotablePowerModel { get; }
        public PregnancyModel PregnancyModel { get; }
        public DailyTroopXpBonusModel DailyTroopXpBonusModel { get; }
        public AgeModel AgeModel { get; }
        public BribeCalculationModel BribeCalculationModel { get; }
        public MapWeatherModel MapWeatherModel { get; }
        public MapDistanceModel MapDistanceModel { get; }
        public MapTrackModel MapTrackModel { get; }
        public PartyImpairmentModel PartyImpairmentModel { get; }
        public PartyFoodBuyingModel PartyFoodBuyingModel { get; }
        public MobilePartyFoodConsumptionModel MobilePartyFoodConsumptionModel { get; }
        public PartyTradeModel PartyTradeModel { get; }
        public SmithingModel SmithingModel { get; }
        public GenericXpModel GenericXpModel { get; }
        public CombatXpModel CombatXpModel { get; }
        public PartyMoraleModel PartyMoraleModel { get; }
        public CombatSimulationModel CombatSimulationModel { get; }
        public BarterModel BarterModel { get; }
        public PartyTrainingModel PartyTrainingModel { get; }
        public PartyHealingModel PartyHealingModel { get; }
        public PartySpeedModel PartySpeedCalculatingModel { get; }
        public StartEncounterModel StartEncounterBehavior { get; }
        public MapVisibilityListener MapVisibilityListener { get; }
        public MapVisibilityModel MapVisibilityModel { get; }
        public PersuasionModel PersuasionModel { get; }
        public DiplomacyModel DiplomacyModel { get; }
        public KingdomDecisionPermissionModel KingdomDecisionPermissionModel { get; }
        public TroopCountLimitModel TroopCountLimitModel { get; }
        public BattleRewardModel BattleRewardModel { get; }
        public EncounterGameMenuModel EncounterGameMenuModel { get; }
        public LordPartyHourlyMilitaryThinkModel LordPartyHourlyMilitaryThinkModel { get; }
        public LordPartyHourlyPersonalThinkModel LordPartyHourlyPersonalThinkModel { get; }
        public BanditDensityModel BanditDensityModel { get; }
        public ArmyManagementCalculationModel ArmyManagementCalculationModel { get; }
        public VolunteerProductionModel VolunteerProductionModel { get; }
        public VillageProductionCalculatorModel VillageProductionCalculatorModel { get; }
        public PlayerCaptivityModel PlayerCaptivityModel { get; }
        public PartyWageModel PartyWageModel { get; }
        public InventoryCapacityModel InventoryCapacityModel { get; }
        public PartySizeLimitModel PartySizeLimitModel { get; }
        public PartyLeaveTroopModel PartyLeaveTroopModel { get; }
        public ValuationModel ValuationModel { get; }
        public ItemUsabilityModel ItemUsabilityModel { get; }
        public CharacterStatsModel CharacterStatsModel { get; }
        public CharacterDevelopmentModel CharacterDevelopmentModel { get; }
        public WorkshopModel WorkshopModel { get; }
        public DifficultyModel DifficultyModel { get; }
    }
 */
namespace KaosesWages.Models
{

	class KaosesWageModel : DefaultPartyWageModel
	{
		public override int GetTotalWage(MobileParty mobileParty, StatExplainer explanation = null)
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			new ExplainedNumber(0f, explanation, null);
			KaosesTroopWage troopWages = new KaosesTroopWage();

			try
			{
				WagesTypes wageTypes = new WagesTypes(mobileParty);
				troopWages.SetWagesMultipliers(wageTypes);
			}
			catch (Exception e)
			{
				Logging.lm(e.Message.ToString());
				Logging.lm(e.ToString());
			}

			for (int i = 0; i < mobileParty.MemberRoster.Count; i++)
			{
				TroopRosterElement elementCopyAtIndex = mobileParty.MemberRoster.GetElementCopyAtIndex(i);
				CharacterObject character = elementCopyAtIndex.Character;
				if (character.IsHero)
				{
					if (elementCopyAtIndex.Character != mobileParty.Party.Owner.CharacterObject)
					{
						num3 += troopWages.getTroopWage(elementCopyAtIndex.Character);
					}
				}
				else if (character.Tier < 4)
				{
					num += troopWages.getTroopWage(elementCopyAtIndex.Character) * elementCopyAtIndex.Number;
				}
				else if (character.Tier == 4)
				{
					num2 += troopWages.getTroopWage(elementCopyAtIndex.Character) * elementCopyAtIndex.Number;
				}
				else if (character.Tier > 4)
				{
					num3 += troopWages.getTroopWage(elementCopyAtIndex.Character) * elementCopyAtIndex.Number;
				}
			}

			if (mobileParty.HasPerk(DefaultPerks.Leadership.LevySergeant, false))
			{
				ExplainedNumber explainedNumber = new ExplainedNumber(1f, null);
				if (explanation != null)
				{
					explanation.AddLine(DefaultPerks.Leadership.LevySergeant.Name.ToString(),
						(float)(num + num2) - (float)(num + num2) * explainedNumber.ResultNumber, StatExplainer.OperationType.Add);
				}
				PerkHelper.AddPerkBonusForParty(DefaultPerks.Leadership.LevySergeant, mobileParty, ref explainedNumber);
				num = MathF.Round(explainedNumber.ResultNumber * (float)num);
				num2 = MathF.Round(explainedNumber.ResultNumber * (float)num2);
			}

			if (mobileParty.HasPerk(DefaultPerks.Leadership.VeteransRespect, false))
			{
				ExplainedNumber explainedNumber2 = new ExplainedNumber(1f, null);
				if (explanation != null)
				{
					explanation.AddLine(DefaultPerks.Leadership.VeteransRespect.Name.ToString(),
						(float)(num2 + num3) - (float)(num2 + num3) * explainedNumber2.ResultNumber, StatExplainer.OperationType.Add);
				}
				PerkHelper.AddPerkBonusForParty(DefaultPerks.Leadership.VeteransRespect, mobileParty, ref explainedNumber2);
				num2 = MathF.Round(explainedNumber2.ResultNumber * (float)num2);
				num3 = MathF.Round((float)num3 * explainedNumber2.ResultNumber);
			}
			ExplainedNumber explainedNumber3 = new ExplainedNumber(1f, null);
			if (mobileParty.IsGarrison && mobileParty.CurrentSettlement != null && mobileParty.CurrentSettlement.IsTown)
			{
				PerkHelper.AddPerkBonusForTown(DefaultPerks.OneHanded.StrengthInNumbers, mobileParty.CurrentSettlement.Town, ref explainedNumber3);
			}

			float num4 = (float)(num + num2 + num3);
			float num5 = (mobileParty.LeaderHero != null && mobileParty.LeaderHero.Clan.Kingdom != null && !mobileParty.LeaderHero.Clan.IsUnderMercenaryService && mobileParty.LeaderHero.Clan.Kingdom.ActivePolicies.Contains(DefaultPolicies.MilitaryCoronae)) ? 1.1f : 1f;

			float subFinal = num4 * num5 * explainedNumber3.ResultNumber;

			if (mobileParty.IsCaravan)
			{
				subFinal *= troopWages.caravanMultiplier;
			}
			if (mobileParty.IsGarrison)
			{
				subFinal *= troopWages.garrisonMultiplier;
			}

			int final = (int)subFinal;
			return final;
		}


		public override int GetGoldCostForUpgrade(CharacterObject characterObject, CharacterObject upgradeTarget)
		{
			int troopRecruitmentCost = this.GetTroopRecruitmentCost(upgradeTarget, null, true);
			int troopRecruitmentCost2 = this.GetTroopRecruitmentCost(characterObject, null, true);
			bool flag = characterObject.Occupation == Occupation.Mercenary || characterObject.Occupation == Occupation.Gangster;
			return (troopRecruitmentCost - troopRecruitmentCost2) / ((!flag) ? 2 : 3);
		}

		public override int GetTroopRecruitmentCost(CharacterObject troop, Hero buyerHero, bool withoutItemCost = false)
		{
			int num = 10 * MathF.Round((float)troop.Level * MathF.Pow((float)troop.Level, 0.65f) * 0.2f);
			//Logging.lm("Recruitment Cost Tier: " + troop.Tier.ToString() + "  Level: " + troop.Level.ToString());
			KaosesTroopRecruitment troopRecruitCost = new KaosesTroopRecruitment();
			try
			{
				RecruiterType recruiterType = new RecruiterType(buyerHero);
				troopRecruitCost.setRecruitMultipliers(recruiterType);
			}
			catch (Exception e)
			{
				Logging.lm(e.Message.ToString());
				Logging.lm(e.ToString());
			}
			/*
			if (Settings.Instance.bUseNativeRecruitCostSystem)
			{
				//num = getTroopRecriutmentCostByLevel(troop, withoutItemCost);
			}else
			{
				num = getTroopRecriutmentCostByTier(troop, withoutItemCost);
			}
			*/
			num = troopRecruitCost.getTroopRecriutmentCostByTier(troop, withoutItemCost);
			/*
			bool flag = troop.Occupation == Occupation.Mercenary || troop.Occupation == Occupation.Gangster;
			float num2 = 1.5f * this.mercenaryCostMultiplier;
			if (flag)
			{
				num = MathF.Round((float)num * num2);
			}
			*/
			return num;
		}




		/*
		private int getTroopRecriutmentCostByLevel(CharacterObject troop, bool withoutItemCost = false)
		{
			int num = 1500;
			if (troop.Level <= 1)
			{
				num = getCalculatedRecruitmentCost(10, 0);
			}
			else if (troop.Level <= 6)
			{
				num = getCalculatedRecruitmentCost(20, 1);
			}
			else if (troop.Level <= 11)
			{
				num = getCalculatedRecruitmentCost(50, 2);
			}
			else if (troop.Level <= 16)
			{
				num = getCalculatedRecruitmentCost(100, 3);
			}
			else if (troop.Level <= 21)
			{
				num = getCalculatedRecruitmentCost(200, 4);
			}
			else if (troop.Level <= 26)
			{
				num = getCalculatedRecruitmentCost(400, 5);
			}
			else if (troop.Level <= 31)
			{
				num = getCalculatedRecruitmentCost(600, 6);
			}
			else if (troop.Level <= 36)
			{
				num = getCalculatedRecruitmentCost(1000, 7);
			}
			else
			{
				num = getCalculatedRecruitmentCost(1500, 7);
			}

			if (troop.Equipment.Horse.Item != null && !withoutItemCost)
			{
				if (troop.Level < 26)
				{
					float multipliedNumber = 150 * this.withHorsesCostMultiplier;
					num += (int)multipliedNumber;
				}
				else
				{
					float multipliedNumber = 500 * this.withHorsesCostMultiplier;
					num += (int)multipliedNumber;
				}
			}
			return num;
		}
		*/

	}
}