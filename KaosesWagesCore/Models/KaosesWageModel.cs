using Helpers;
using KaosesWagesCore.Objects;
using KaosesWagesCore.Objects.Loaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.MapEvents;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements.Buildings;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace KaosesWagesCore.Models
{

    public class KaosesWageModel : DefaultPartyWageModel
    {
        private static readonly TextObject _cultureText = GameTexts.FindText("str_culture");
        private static readonly TextObject _buildingEffects = GameTexts.FindText("str_building_effects");

        public override ExplainedNumber GetTotalWage(
          MobileParty mobileParty,
          bool includeDescriptions = false)
        {
            int num1 = 0;
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
            bool flag = !mobileParty.HasPerk(DefaultPerks.Steward.AidCorps);
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
                    if (elementCopyAtIndex.Character.HeroObject != character.HeroObject.Clan?.Leader)
                    {
                        if (mobileParty.LeaderHero != null && mobileParty.LeaderHero.GetPerkValue(DefaultPerks.Steward.PaidInPromise))
                        {
                            //num3 += MathF.Round((float)elementCopyAtIndex.Character.TroopWage * (float)(1.0 + (double)DefaultPerks.Steward.PaidInPromise.PrimaryBonus * 0.00999999977648258));
                            num3 += MathF.Round((float)troopWages.GetTroopWage(elementCopyAtIndex.Character) * (float)(1.0 + (double)DefaultPerks.Steward.PaidInPromise.PrimaryBonus * 0.00999999977648258));
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
                    if (character.Tier < 4)
                    {
                        if (character.Culture.IsBandit)
                        {
                            //num9 += elementCopyAtIndex.Character.TroopWage * elementCopyAtIndex.Number;
                            num9 += troopWages.GetTroopWage(elementCopyAtIndex.Character) * elementCopyAtIndex.Number;
                        }
                        //num1 += elementCopyAtIndex.Character.TroopWage * num14;
                        num1 += troopWages.GetTroopWage(elementCopyAtIndex.Character) * num14;// 
                    }
                    else if (character.Tier == 4)
                    {
                        if (character.Culture.IsBandit)
                        {
                            //num10 += elementCopyAtIndex.Character.TroopWage * elementCopyAtIndex.Number;
                            num10 += troopWages.GetTroopWage(elementCopyAtIndex.Character) * elementCopyAtIndex.Number;
                        }
                        //num2 += elementCopyAtIndex.Character.TroopWage * num14;
                        num2 += troopWages.GetTroopWage(elementCopyAtIndex.Character) * num14;// elementCopyAtIndex.Number
                    }
                    else if (character.Tier > 4)
                    {
                        if (character.Culture.IsBandit)
                        {
                            //num11 += elementCopyAtIndex.Character.TroopWage * elementCopyAtIndex.Number;
                            num11 += troopWages.GetTroopWage(elementCopyAtIndex.Character) * elementCopyAtIndex.Number;
                        }
                        //num3 += elementCopyAtIndex.Character.TroopWage * num14;
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
                    if (character.IsRanged)
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
            ExplainedNumber bonuses = new ExplainedNumber();
            if (mobileParty.LeaderHero != null && mobileParty.LeaderHero.GetPerkValue(DefaultPerks.Roguery.DeepPockets))
            {
                num1 -= num9;
                num2 -= num10;
                num3 -= num11;
                int num15 = num9 + num10 + num11;
                bonuses.Add((float)num15);
                PerkHelper.AddPerkBonusForCharacter(DefaultPerks.Roguery.DeepPockets, mobileParty.LeaderHero.CharacterObject, false, ref bonuses);
            }
            int baseNumber = num1 + num2 + num3;
            if (mobileParty.HasPerk(DefaultPerks.Crossbow.PickedShots) && num7 > 0)
            {
                float num16 = (float)num8 * DefaultPerks.Crossbow.PickedShots.PrimaryBonus;
                baseNumber += (int)num16;
            }

            if (troopWages.UseGarrisonWagesModifiers)
            {
                float tgarrisonCost = baseNumber * troopWages.garrisonWageMultiplier;
                baseNumber = (int)tgarrisonCost;
            }

            if (troopWages.UseCaravanWagesModifiers && mobileParty.IsCaravan)
            {
                float tCaravanCost = MathF.Round((float)baseNumber * troopWages.caravanWageMultiplier);
                baseNumber = (int)tCaravanCost;
            }

            ExplainedNumber totalWage = new ExplainedNumber((float)baseNumber, includeDescriptions);
            ExplainedNumber explainedNumber = new ExplainedNumber(1f);
            if (mobileParty.IsGarrison && mobileParty.CurrentSettlement?.Town != null)
            {
                if (mobileParty.CurrentSettlement.IsTown)
                {
                    PerkHelper.AddPerkBonusForTown(DefaultPerks.OneHanded.MilitaryTradition, mobileParty.CurrentSettlement.Town, ref totalWage);
                    PerkHelper.AddPerkBonusForTown(DefaultPerks.TwoHanded.Berserker, mobileParty.CurrentSettlement.Town, ref totalWage);
                    PerkHelper.AddPerkBonusForTown(DefaultPerks.Bow.HunterClan, mobileParty.CurrentSettlement.Town, ref totalWage);
                    this.CalculatePartialGarrisonWageReduction((float)num4 / (float)mobileParty.MemberRoster.TotalRegulars, mobileParty, DefaultPerks.Polearm.StandardBearer, ref totalWage, true);
                    this.CalculatePartialGarrisonWageReduction((float)num5 / (float)mobileParty.MemberRoster.TotalRegulars, mobileParty, DefaultPerks.Riding.CavalryTactics, ref totalWage, true);
                    this.CalculatePartialGarrisonWageReduction((float)num6 / (float)mobileParty.MemberRoster.TotalRegulars, mobileParty, DefaultPerks.Crossbow.PeasantLeader, ref totalWage, true);
                }
                else if (mobileParty.CurrentSettlement.IsCastle)
                    PerkHelper.AddPerkBonusForTown(DefaultPerks.Steward.StiffUpperLip, mobileParty.CurrentSettlement.Town, ref totalWage);
                PerkHelper.AddPerkBonusForTown(DefaultPerks.Steward.DrillSergant, mobileParty.CurrentSettlement.Town, ref totalWage);
                if (mobileParty.CurrentSettlement.Culture.HasFeat(DefaultCulturalFeats.EmpireGarrisonWageFeat))
                    totalWage.AddFactor(DefaultCulturalFeats.EmpireGarrisonWageFeat.EffectBonus, GameTexts.FindText("str_culture"));
                foreach (Building building in mobileParty.CurrentSettlement.Town.Buildings)
                {
                    float buildingEffectAmount = building.GetBuildingEffectAmount(BuildingEffectEnum.GarrisonWageReduce);
                    if ((double)buildingEffectAmount > 0.0)
                        explainedNumber.AddFactor((float)-((double)buildingEffectAmount / 100.0), building.Name);
                }
            }
            totalWage.Add(bonuses.ResultNumber);
            float num17 = mobileParty.LeaderHero == null || mobileParty.LeaderHero.Clan.Kingdom == null || mobileParty.LeaderHero.Clan.IsUnderMercenaryService || !mobileParty.LeaderHero.Clan.Kingdom.ActivePolicies.Contains(DefaultPolicies.MilitaryCoronae) ? 0.0f : 0.1f;
            if (mobileParty.HasPerk(DefaultPerks.Trade.SwordForBarter, true))
            {
                float num18 = (float)num12 / (float)mobileParty.MemberRoster.TotalRegulars;
                if ((double)num18 > 0.0)
                {
                    float num19 = DefaultPerks.Trade.SwordForBarter.SecondaryBonus * num18;
                    totalWage.AddFactor(num19, DefaultPerks.Trade.SwordForBarter.Name);
                }
            }
            if (mobileParty.HasPerk(DefaultPerks.Steward.Contractors))
            {
                float num20 = (float)num13 / (float)mobileParty.MemberRoster.TotalRegulars;
                if ((double)num20 > 0.0)
                {
                    float num21 = DefaultPerks.Steward.Contractors.PrimaryBonus * num20;
                    totalWage.AddFactor(num21, DefaultPerks.Steward.Contractors.Name);
                }
            }
            if (mobileParty.HasPerk(DefaultPerks.Trade.MercenaryConnections, true))
            {
                float num22 = (float)num13 / (float)mobileParty.MemberRoster.TotalRegulars;
                if ((double)num22 > 0.0)
                {
                    float num23 = DefaultPerks.Trade.MercenaryConnections.SecondaryBonus * num22;
                    totalWage.AddFactor(num23, DefaultPerks.Trade.MercenaryConnections.Name);
                }
            }
            totalWage.AddFactor(num17, DefaultPolicies.MilitaryCoronae.Name);
            totalWage.AddFactor(explainedNumber.ResultNumber - 1f, KaosesWageModel._buildingEffects);
            if (PartyBaseHelper.HasFeat(mobileParty.Party, DefaultCulturalFeats.AseraiIncreasedWageFeat))
                totalWage.AddFactor(DefaultCulturalFeats.AseraiIncreasedWageFeat.EffectBonus, KaosesWageModel._cultureText);
            if (mobileParty.HasPerk(DefaultPerks.Steward.Frugal))
                totalWage.AddFactor(DefaultPerks.Steward.Frugal.PrimaryBonus * 0.01f, DefaultPerks.Steward.Frugal.Name);
            if (mobileParty.Army != null && mobileParty.HasPerk(DefaultPerks.Steward.EfficientCampaigner, true))
                totalWage.AddFactor(DefaultPerks.Steward.EfficientCampaigner.SecondaryBonus * 0.01f, DefaultPerks.Steward.EfficientCampaigner.Name);
            if (mobileParty.SiegeEvent != null && mobileParty.SiegeEvent.BesiegerCamp.GetInvolvedPartiesForEventType(MapEvent.BattleTypes.Siege).Contains<PartyBase>(mobileParty.Party) && mobileParty.HasPerk(DefaultPerks.Steward.MasterOfWarcraft))
                totalWage.AddFactor(DefaultPerks.Steward.MasterOfWarcraft.PrimaryBonus * 0.01f, DefaultPerks.Steward.MasterOfWarcraft.Name);
            if (mobileParty.EffectiveQuartermaster != null)
                PerkHelper.AddEpicPerkBonusForCharacter(DefaultPerks.Steward.PriceOfLoyalty, mobileParty.EffectiveQuartermaster.CharacterObject, DefaultSkills.Steward, true, ref totalWage);
            return totalWage;
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
                KaosesCommon.Utils.Logger.Lm(e.Message.ToString());
                KaosesCommon.Utils.Logger.Lm(e.ToString());
            }

            //int num = 10 * MathF.Round((float)troop.Level * MathF.Pow((float)troop.Level, 0.65f) * 0.2f);
            int num = troopRecruitment.GetTroopRecriutmentCostByTier(troop, withoutItemCost);


            bool flag = troop.Occupation == Occupation.Mercenary || troop.Occupation == Occupation.Gangster || troop.Occupation == Occupation.CaravanGuard;
            float num2 = 2f;
            if (flag)
            {
                //num = MathF.Round((float)num * num2);
            }
            /*

                        if (troop.IsHero)
                        {
                            float temp = num * 2;
                            Logger.Lm("Recruit target is Hero original cost :"+ num.ToString()+"  new cost would be :"+ temp.ToString());
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
                    if (buyerHero.GetPerkValue(DefaultPerks.Polearm.HardyFrontline))//DefaultPerks.Polearm.GenerousRations
                    {
                        explainedNumber.AddFactor(DefaultPerks.Polearm.HardyFrontline.SecondaryBonus * 0.01f, null);
                    }
                }
                if (troop.IsRanged)
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
