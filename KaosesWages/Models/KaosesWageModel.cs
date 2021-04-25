using Helpers;
using KaosesWages.Objects;
using KaosesWages.Utils;
using System;
using System.Collections.Generic;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Party;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using System.Linq;
using TaleWorlds.Core;
/*
public sealed class GameModels : GameModelsManager
*/
namespace KaosesWages.Models
{
	public class KaosesWageModel : DefaultPartyWageModel
	{
        public override ExplainedNumber GetTotalWage(
          MobileParty mobileParty,
          bool includeDescriptions = false)
        {
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            int num5 = 0;
            int num6 = 0;
            int num7 = 0;
            int num8 = 0;
            int num9 = 0;
            int num10 = 0;
            int num11 = 0;
            bool flag = !mobileParty.HasPerk(DefaultPerks.Steward.AidCorps, false);
            int num12 = 0;
            int num13 = 0;

            KaosesTroopWage troopWages = new KaosesTroopWage();
            new WagesDataLaoder(mobileParty, ref troopWages);

            for (int index = 0; index < mobileParty.MemberRoster.Count; ++index)
            {
                TroopRosterElement elementCopyAtIndex = mobileParty.MemberRoster.GetElementCopyAtIndex(index);
                CharacterObject character = elementCopyAtIndex.Character;
                int num14 = flag ? elementCopyAtIndex.Number : elementCopyAtIndex.Number - elementCopyAtIndex.WoundedNumber;
                if (character.IsHero)
                {
                    CharacterObject character2 = elementCopyAtIndex.Character;
                    Hero owner = mobileParty.Party.Owner;
                    if (character2 != ((owner != null) ? owner.CharacterObject : null))
                    {
                        if (mobileParty.Leader != null && mobileParty.Leader.GetPerkValue(DefaultPerks.Steward.PaidInPromise))
                        {
                            //num3 += MathF.Round((float)elementCopyAtIndex.Character.TroopWage * (1f + DefaultPerks.Steward.PaidInPromise.PrimaryBonus * 0.01f));
                            num3 += MathF.Round((float)troopWages.GetTroopWage(elementCopyAtIndex.Character) * (1f + DefaultPerks.Steward.PaidInPromise.PrimaryBonus * 0.01f));
                        }
                        else
                        {
                            //num3 += elementCopyAtIndex.Character.TroopWage;
                            num3 += troopWages.GetTroopWage(elementCopyAtIndex.Character);
                        }
                    }
                }
                else
                {
                    if (character.Tier < 4) {
                        if (character.Culture.IsBandit) {
                            num9 += troopWages.GetTroopWage(elementCopyAtIndex.Character) * elementCopyAtIndex.Number;
                        }
                        num += troopWages.GetTroopWage(elementCopyAtIndex.Character) * num14;// 
                    } else if (character.Tier == 4)
                    {
                        if (character.Culture.IsBandit)
                        {
                            num10 += troopWages.GetTroopWage(elementCopyAtIndex.Character) * elementCopyAtIndex.Number;
                        }
                        num2 += troopWages.GetTroopWage(elementCopyAtIndex.Character) *  num14;// elementCopyAtIndex.Number
                    }
                    else if (character.Tier > 4)
                    {
                        if (character.Culture.IsBandit)
                        {
                            num11 += troopWages.GetTroopWage(elementCopyAtIndex.Character) * elementCopyAtIndex.Number;
                        }
                        num3 += troopWages.GetTroopWage(elementCopyAtIndex.Character) * num14;// 
                    }

                    if (character.IsInfantry)
                        num4 += num14;
                    if (character.IsMounted)
                        num5 += num14;
                    if (character.Occupation == Occupation.CaravanGuard)
                        num12 += elementCopyAtIndex.Number;
                    if (character.Occupation == Occupation.Mercenary)
                        num13 += elementCopyAtIndex.Number;
                    if (character.IsArcher)
                    {
                        num6 += num14;
                        if (character.Tier >= 4)
                        {
                            num7 += num14;
                            //num8 += elementCopyAtIndex.Character.TroopWage * elementCopyAtIndex.Number;
                            num8 += troopWages.GetTroopWage(elementCopyAtIndex.Character) * elementCopyAtIndex.Number;
                        }
                    }
                }
            }
            ExplainedNumber explainedNumber = new ExplainedNumber(0f, false, null);
            if (mobileParty.LeaderHero != null && mobileParty.LeaderHero.GetPerkValue(DefaultPerks.Roguery.DeepPockets))
            {
                num -= num9;
                num2 -= num10;
                num3 -= num11;
                int num15 = MathF.Round((float)(num9 + num10 + num11));
                explainedNumber.Add((float)num15, null, null);
                PerkHelper.AddPerkBonusForCharacter(DefaultPerks.Roguery.DeepPockets, mobileParty.LeaderHero.CharacterObject, false, ref explainedNumber);
            }
            int num16 = num + num2 + num3;
            if (mobileParty.IsGarrison)
            {
                if(troopWages.UseGarrisonWagesModifiers)
                {
                    float tgarrisonCost = num16 * troopWages.garrisonWageMultiplier;
                    num16 = (int)tgarrisonCost;
                }
            }
            ExplainedNumber result = new ExplainedNumber((float)num16, includeDescriptions, null);
            ExplainedNumber explainedNumber2 = new ExplainedNumber(1f, false, null);
            
            if (mobileParty.IsGarrison)
            {
                Settlement currentSettlement = mobileParty.CurrentSettlement;
                if (((currentSettlement != null) ? currentSettlement.Town : null) != null)
                {
                    if (mobileParty.CurrentSettlement.IsTown)
                    {
                        PerkHelper.AddPerkBonusForTown(DefaultPerks.OneHanded.MilitaryTradition, mobileParty.CurrentSettlement.Town, ref result);
                        PerkHelper.AddPerkBonusForTown(DefaultPerks.TwoHanded.Berserker, mobileParty.CurrentSettlement.Town, ref result);
                        PerkHelper.AddPerkBonusForTown(DefaultPerks.Bow.HunterClan, mobileParty.CurrentSettlement.Town, ref result);
                        float troopRatio = (float)num4 / (float)mobileParty.MemberRoster.TotalRegulars;
                        this.CalculatePartialGarrisonWageReduction(troopRatio, mobileParty, DefaultPerks.Polearm.StandardBearer, ref result, true);

                        float troopRatio2 = (float)num5 / (float)mobileParty.MemberRoster.TotalRegulars;
                        this.CalculatePartialGarrisonWageReduction(troopRatio2, mobileParty, DefaultPerks.Riding.CavalryTactics, ref result, true);

                        float troopRatio3 = (float)num6 / (float)mobileParty.MemberRoster.TotalRegulars;
                        this.CalculatePartialGarrisonWageReduction(troopRatio3, mobileParty, DefaultPerks.Crossbow.PeasantLeader, ref result, true);

                    }
                    else if (mobileParty.CurrentSettlement.IsCastle)
                    {
                        PerkHelper.AddPerkBonusForTown(DefaultPerks.Steward.StiffUpperLip, mobileParty.CurrentSettlement.Town, ref result);
                    }
                    PerkHelper.AddPerkBonusForTown(DefaultPerks.Steward.DrillSergant, mobileParty.CurrentSettlement.Town, ref result);
                    foreach (Building building in mobileParty.CurrentSettlement.Town.Buildings)
                    {
                        float buildingEffectAmount = building.GetBuildingEffectAmount(BuildingEffectEnum.GarrisonWageReduce);
                        if (buildingEffectAmount > 0f)
                        {
                            explainedNumber2.AddFactor(-(buildingEffectAmount / 100f), building.Name);
                        }
                    }

                }

            }
            result.Add(explainedNumber.ResultNumber, null, null);
            float value = (mobileParty.LeaderHero != null && mobileParty.LeaderHero.Clan.Kingdom != null && !mobileParty.LeaderHero.Clan.IsUnderMercenaryService && mobileParty.LeaderHero.Clan.Kingdom.ActivePolicies.Contains(DefaultPolicies.MilitaryCoronae)) ? 0.1f : 0f;
            if (mobileParty.HasPerk(DefaultPerks.Crossbow.PickedShots, false) && num7 > 0)
            {
                float value2 = DefaultPerks.Crossbow.PickedShots.PrimaryBonus * (float)num8;
                result.Add(value2, DefaultPerks.Crossbow.PickedShots.Name, null);
            }
            if (mobileParty.HasPerk(DefaultPerks.Trade.SwordForBarter, true))
            {
                float num17 = (float)num12 / (float)mobileParty.MemberRoster.TotalRegulars;
                if (num17 > 0f)
                {
                    float value3 = DefaultPerks.Trade.SwordForBarter.SecondaryBonus * num17;
                    result.AddFactor(value3, DefaultPerks.Trade.SwordForBarter.Name);
                }
            }
            if (mobileParty.HasPerk(DefaultPerks.Steward.Contractors, false))
            {
                float num18 = (float)num13 / (float)mobileParty.MemberRoster.TotalRegulars;
                if (num18 > 0f)
                {
                    float value4 = DefaultPerks.Steward.Contractors.PrimaryBonus * num18;
                    result.AddFactor(value4, DefaultPerks.Steward.Contractors.Name);
                }
            }

            result.AddFactor(value, DefaultPolicies.MilitaryCoronae.Name);
            result.AddFactor(explainedNumber2.ResultNumber - 1f, new TextObject("{=a6FfHHVg}Building Effects", null));
            if (mobileParty.HasPerk(DefaultPerks.Steward.Frugal, false))
            {
                result.AddFactor(DefaultPerks.Steward.Frugal.PrimaryBonus * 0.01f, DefaultPerks.Steward.Frugal.Name);
            }
            if (mobileParty.Army != null && mobileParty.HasPerk(DefaultPerks.Steward.EfficientCampaigner, true))
            {
                result.AddFactor(DefaultPerks.Steward.EfficientCampaigner.SecondaryBonus * 0.01f, DefaultPerks.Steward.EfficientCampaigner.Name);
            }
            if (mobileParty.SiegeEvent != null && Enumerable.Contains<PartyBase>(mobileParty.SiegeEvent.BesiegerCamp.SiegeParties, mobileParty.Party) && mobileParty.HasPerk(DefaultPerks.Steward.MasterOfWarcraft, false))
            {
                result.AddFactor(DefaultPerks.Steward.MasterOfWarcraft.PrimaryBonus * 0.01f, DefaultPerks.Steward.MasterOfWarcraft.Name);
            }
            if (mobileParty.EffectiveQuartermaster != null)
            {
                PerkHelper.AddEpicPerkBonusForCharacter(DefaultPerks.Steward.PriceOfLoyalty, mobileParty.EffectiveQuartermaster.CharacterObject, DefaultSkills.Steward, true, ref result, 200);
            }

            return result;
        }

        // Token: 0x06002D5F RID: 11615 RVA: 0x000B4610 File Offset: 0x000B2810
        private void CalculatePartialGarrisonWageReduction(float troopRatio, MobileParty mobileParty, PerkObject perk, ref ExplainedNumber garrisonWageReductionMultiplier, bool isSecondaryEffect)
        {
            if (troopRatio > 0f && mobileParty.CurrentSettlement.Town.Governor != null && PerkHelper.GetPerkValueForTown(perk, mobileParty.CurrentSettlement.Town))
            {
                garrisonWageReductionMultiplier.AddFactor(isSecondaryEffect ? (perk.SecondaryBonus * troopRatio * 0.01f) : (perk.PrimaryBonus * troopRatio * 0.01f), perk.Name);
            }
        }

        public override int GetTroopRecruitmentCost(
          CharacterObject troop,
          Hero buyerHero,
          bool withoutItemCost = false)
        {
            KaosesTroopRecruitment troopRecruitment = new KaosesTroopRecruitment();
            try
            {
                RecruitDataLoader recruiterType = new RecruitDataLoader(buyerHero, ref troopRecruitment);
            }
            catch (Exception e)
            {
                Logging.Lm(e.Message.ToString());
                Logging.Lm(e.ToString());
            }

            //int num = 10 * MathF.Round((float)troop.Level * MathF.Pow((float)troop.Level, 0.65f) * 0.2f);
            int num = troopRecruitment.GetTroopRecriutmentCostByTier(troop, withoutItemCost);
            

            bool flag = troop.Occupation == Occupation.Mercenary || troop.Occupation == Occupation.Gangster || troop.Occupation == Occupation.CaravanGuard;
            float num2 = 2f;
            if (flag)
            {
                num = MathF.Round((float)num * num2);
            }
/*

            if (troop.IsHero)
            {
                float temp = num * 2;
                Logging.Lm("Recruit target is Hero original cost :"+ num.ToString()+"  new cost would be :"+ temp.ToString());
            }
*/

            if (buyerHero != null)
            {
                ExplainedNumber explainedNumber = new ExplainedNumber(1f, false, null);
                if (troop.Tier >= 2 && buyerHero.GetPerkValue(DefaultPerks.Throwing.HeadHunter))
                {
                    explainedNumber.AddFactor(DefaultPerks.Throwing.HeadHunter.SecondaryBonus * 0.01f, null);
                }
                if (troop.IsInfantry)
                {
                    if (buyerHero.GetPerkValue(DefaultPerks.OneHanded.ChinkInTheArmor))
                    {
                        explainedNumber.AddFactor(DefaultPerks.OneHanded.ChinkInTheArmor.SecondaryBonus * 0.01f, null);
                    }
                    if (buyerHero.GetPerkValue(DefaultPerks.TwoHanded.ShowOfStrength))
                    {
                        explainedNumber.AddFactor(DefaultPerks.TwoHanded.ShowOfStrength.SecondaryBonus * 0.01f, null);
                    }
                    if (buyerHero.GetPerkValue(DefaultPerks.Polearm.GenerousRations))
                    {
                        explainedNumber.AddFactor(DefaultPerks.Polearm.GenerousRations.SecondaryBonus * 0.01f, null);
                    }
                }
                if (troop.IsArcher)
                {
                    if (buyerHero.GetPerkValue(DefaultPerks.Bow.RenownedArcher))
                    {
                        explainedNumber.AddFactor(DefaultPerks.Bow.RenownedArcher.SecondaryBonus * 0.01f, null);
                    }
                    if (buyerHero.GetPerkValue(DefaultPerks.Crossbow.Piercer))
                    {
                        explainedNumber.AddFactor(DefaultPerks.Crossbow.Piercer.SecondaryBonus * 0.01f, null);
                    }
                }
                if (buyerHero.IsPartyLeader && buyerHero.GetPerkValue(DefaultPerks.Steward.Frugal))
                {
                    explainedNumber.AddFactor(DefaultPerks.Steward.Frugal.SecondaryBonus * 0.01f, null);
                }
                if (flag && buyerHero.GetPerkValue(DefaultPerks.Trade.SwordForBarter))
                {
                    explainedNumber.AddFactor(DefaultPerks.Trade.SwordForBarter.PrimaryBonus, null);
                }
                num = Math.Max(1, MathF.Round((float)num * explainedNumber.ResultNumber));
            }

            return num;
        }

    }
}
