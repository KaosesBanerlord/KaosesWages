using Helpers;
using KaosesWagesCore.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using CoreConfig = KaosesWagesCore.Settings.KaosesWagesCoreConfig;
using CoreFactory = KaosesWagesCore.Objects.KaosesWagesCoreFactory;

namespace KaosesWagesCore.Models
{

    public class CompanionRecruitment : DefaultCompanionHiringPriceCalculationModel
    {
        // Token: 0x06002C1B RID: 11291 RVA: 0x000AB050 File Offset: 0x000A9250
        public override int GetCompanionHiringPrice(Hero companion)
        {
            ExplainedNumber explainedNumber = new ExplainedNumber(0f, false, null);
            Town town = companion.CurrentSettlement?.Town ?? SettlementHelper.FindNearestTown().Town;
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
            if (CoreFactory.Settings.bUsePlayerRecruitCostModifiers)
            {
                GearNativeCost *= CoreFactory.Settings.tierCompanionRecruitCostMultiplier;
                CompanionLevelCost *= CoreFactory.Settings.tierCompanionRecruitCostMultiplier;

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
