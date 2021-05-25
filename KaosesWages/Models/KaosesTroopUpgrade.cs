using Helpers;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;
using TaleWorlds.CampaignSystem;
using KaosesWages.Settings;
using KaosesCommon;

namespace KaosesWages.Models
{
    class KaosesTroopUpgrade : DefaultPartyTroopUpgradeModel
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
                if (party.MobileParty.HasPerk(DefaultPerks.Throwing.ThrowingCompetitions, false))
                {
                    PerkHelper.AddPerkBonusForParty(DefaultPerks.Throwing.ThrowingCompetitions, party.MobileParty, true, ref explainedNumber);
                }
                if (party.IsMobile && party.LeaderHero != null && party.MobileParty.HasPerk(DefaultPerks.Steward.SoundReserves, false))
                {
                    PerkHelper.AddPerkBonusForParty(DefaultPerks.Steward.SoundReserves, party.MobileParty, true, ref explainedNumber);
                }
            }
            return (int)explainedNumber.ResultNumber / 2;
        }



       protected float GetUpgradeMultiplier(PartyBase party)
        {
            MCMSettings? _settings = Statics._settings;
            float upgradeCostMultiplier = 1.0f;
            if (party != null && party.MobileParty.IsMainParty && _settings.bUsePlayerUpgradeCostMultiplier)
            {
                upgradeCostMultiplier = _settings.playerUpgradeCostMultiplier;
            }
            else if (Kaoses.IsPlayerClan(party) && !party.MobileParty.IsMainParty && _settings.bUsePlayerUpgradeCostForClanMembers)
            {
                upgradeCostMultiplier = _settings.playerUpgradeCostMultiplier;
            }
            else if (Kaoses.IsPlayerClan(party) && !party.MobileParty.IsMainParty && _settings.bUseAIUpgradeCostMultiplier)
            {
                upgradeCostMultiplier = _settings.AIUpgradeCostMultiplier;
            }
            else if (_settings.bUseAIUpgradeCostMultiplier && !party.MobileParty.IsMainParty && !Kaoses.IsPlayerClan(party))
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
                runningTotal /= 2;
            }
            return runningTotal;
        }

    }
}
