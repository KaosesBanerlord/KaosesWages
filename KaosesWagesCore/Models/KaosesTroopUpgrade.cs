using Helpers;
using KaosesCommon.Helpers;
using KaosesWagesCore.Objects;
using KaosesWagesCore.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;
using CoreConfig = KaosesWagesCore.Settings.KaosesWagesCoreConfig;
using CoreFactory = KaosesWagesCore.Objects.KaosesWagesCoreFactory;

namespace KaosesWagesCore.Models
{

    public class KaosesTroopUpgrade : DefaultPartyTroopUpgradeModel
    {
        // Token: 0x06002C5C RID: 11356 RVA: 0x000ABFD0 File Offset: 0x000AA1D0
        public override int GetGoldCostForUpgrade(
          PartyBase party,
          CharacterObject characterObject,
          CharacterObject upgradeTarget)
        {
            PartyWageModel partyWageModel = Campaign.Current.Models.PartyWageModel;
            float runningTotal = 0.0f;
            float upgradeCostMultiplier = GetUpgradeMultiplier(party);


            int troopRecruitmentCost = partyWageModel.GetTroopRecruitmentCost(upgradeTarget, null, true);
            int troopRecruitmentCost2 = partyWageModel.GetTroopRecruitmentCost(characterObject, null, true);
            runningTotal = troopRecruitmentCost - troopRecruitmentCost2;
            runningTotal = GetUnitTypedCosts(characterObject, runningTotal);
            runningTotal *= upgradeCostMultiplier;

            ExplainedNumber explainedNumber = new ExplainedNumber((float)runningTotal, false, null);

            if (party.IsMobile && party.LeaderHero != null)
            {
                if (party.MobileParty.HasPerk(DefaultPerks.Bow.RenownedArcher, true))
                {
                    PerkHelper.AddPerkBonusForParty(DefaultPerks.Bow.RenownedArcher, party.MobileParty, false, ref explainedNumber);
                }
                if (party.IsMobile && party.LeaderHero != null && party.MobileParty.HasPerk(DefaultPerks.Steward.SoundReserves, false))
                {
                    PerkHelper.AddPerkBonusForParty(DefaultPerks.Steward.SoundReserves, party.MobileParty, true, ref explainedNumber);
                }
            }
            if (characterObject.IsInfantry && party.MobileParty.HasPerk(DefaultPerks.Throwing.ThrowingCompetitions))
            {
                PerkHelper.AddPerkBonusForParty(DefaultPerks.Throwing.ThrowingCompetitions, party.MobileParty, true, ref explainedNumber);
            }

            if (characterObject.IsMounted && PartyBaseHelper.HasFeat(party, DefaultCulturalFeats.KhuzaitRecruitUpgradeFeat))
            {
                explainedNumber.AddFactor(DefaultCulturalFeats.KhuzaitRecruitUpgradeFeat.EffectBonus, GameTexts.FindText("str_culture"));
            }

            else if (characterObject.IsInfantry && PartyBaseHelper.HasFeat(party, DefaultCulturalFeats.SturgianRecruitUpgradeFeat))
            {
                explainedNumber.AddFactor(DefaultCulturalFeats.SturgianRecruitUpgradeFeat.EffectBonus, GameTexts.FindText("str_culture"));
            }

            //return (int)explainedNumber.ResultNumber / 2;
            return (int)explainedNumber.ResultNumber;
        }

        protected float GetUpgradeMultiplier(PartyBase party)
        {
            CoreConfig _settings = CoreFactory.Settings;
            float upgradeCostMultiplier = 1.0f;
            if (party != null && party.MobileParty.IsMainParty && _settings.bUsePlayerUpgradeCostMultiplier)
            {
                upgradeCostMultiplier = _settings.playerUpgradeCostMultiplier;
            }
            else if (KFaction.IsPlayerClan(party) && !party.MobileParty.IsMainParty && _settings.bUsePlayerUpgradeCostForClanMembers)
            {
                upgradeCostMultiplier = _settings.playerUpgradeCostMultiplier;
            }
            else if (KFaction.IsPlayerClan(party) && !party.MobileParty.IsMainParty && _settings.bUseAIUpgradeCostMultiplier)
            {
                upgradeCostMultiplier = _settings.AIUpgradeCostMultiplier;
            }
            else if (_settings.bUseAIUpgradeCostMultiplier && !party.MobileParty.IsMainParty && !KFaction.IsPlayerClan(party))
            {
                upgradeCostMultiplier = _settings.AIUpgradeCostMultiplier;
            }
            return upgradeCostMultiplier;
        }

        protected float GetUnitTypedCosts(CharacterObject characterObject, float runningTotal)
        {
            if (characterObject.Occupation == Occupation.Mercenary)
            {
                runningTotal *= 2;
            }
            else if (characterObject.Occupation == Occupation.Gangster)
            {
                runningTotal *= 3;
                //runningTotal /= 2;
            }
            return runningTotal;
        }

    }
}
