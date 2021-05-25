using Helpers;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;
using TaleWorlds.Core;

namespace KaosesWages.Models
{
    class CompanionRecruitment : DefaultCompanionHiringPriceCalculationModel
    {
        // Token: 0x06002C1B RID: 11291 RVA: 0x000AB050 File Offset: 0x000A9250
        public override int GetCompanionHiringPrice(Hero companion)
        {
            ExplainedNumber explainedNumber = new ExplainedNumber(0f, false, null);
            Settlement currentSettlement = companion.CurrentSettlement;
            Town town = (currentSettlement != null) ? currentSettlement.Town : null;
            if (town == null)
            {
                town = SettlementHelper.FindNearestSettlement((Settlement x) => x.IsTown).Town;
            }
            float num = 0f;
            for (EquipmentIndex equipmentIndex = EquipmentIndex.WeaponItemBeginSlot; equipmentIndex < EquipmentIndex.NumEquipmentSetSlots; equipmentIndex++)
            {
                EquipmentElement itemRosterElement = companion.CharacterObject.Equipment[equipmentIndex];
                if (itemRosterElement.Item != null)
                {
                    num += (float)town.GetItemPrice(itemRosterElement, null, false);
                }
            }
            for (EquipmentIndex equipmentIndex2 = EquipmentIndex.WeaponItemBeginSlot; equipmentIndex2 < EquipmentIndex.NumEquipmentSetSlots; equipmentIndex2++)
            {
                EquipmentElement itemRosterElement2 = companion.CharacterObject.FirstCivilianEquipment[equipmentIndex2];
                if (itemRosterElement2.Item != null)
                {
                    num += (float)town.GetItemPrice(itemRosterElement2, null, false);
                }
            }
            float GearNativeCost = num / 2f;
            float CompanionLevelCost = companion.CharacterObject.Level * 10;
            if (Statics._settings.bUsePlayerRecruitCostModifiers)
            {
                GearNativeCost *= Statics._settings.tierCompanionRecruitCostMultiplier;
                CompanionLevelCost *= Statics._settings.tierCompanionRecruitCostMultiplier;

            }
            explainedNumber.Add(GearNativeCost, null, null);
            explainedNumber.Add(CompanionLevelCost, null, null);


            if (Hero.MainHero.IsPartyLeader && Hero.MainHero.GetPerkValue(DefaultPerks.Steward.PaidInPromise))
            {
                explainedNumber.AddFactor(DefaultPerks.Steward.PaidInPromise.PrimaryBonus * 0.01f, null);
            }
            if (Hero.MainHero.PartyBelongedTo != null)
            {
                PerkHelper.AddPerkBonusForParty(DefaultPerks.Trade.GreatInvestor, Hero.MainHero.PartyBelongedTo, false, ref explainedNumber);
            }
            return (int)explainedNumber.ResultNumber;
        }

    }
}
