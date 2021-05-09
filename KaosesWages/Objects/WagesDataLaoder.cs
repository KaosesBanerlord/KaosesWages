using KaosesWages.Common;
using KaosesWages.Settings;
using KaosesWages.Utils;
using TaleWorlds.CampaignSystem;

namespace KaosesWages.Objects
{
    public class WagesDataLaoder
    {
        public static ISettingsProviderInterface? _settings;
        public static KaosesTroopWage? _troopWages;

        public WagesDataLaoder(ref KaosesTroopWage troopWages)
        {
            _settings = Statics._settings;
            _troopWages = troopWages;
            LoadBaseWageValues();
            loadPlayerAdditional();
            if (_settings.bUsePlayerTierWagesModifiers)
            {
                loadPlayerMultipliers();
            }
        }

        public WagesDataLaoder(MobileParty mobileParty, ref KaosesTroopWage troopWages)
        {
            _settings = Statics._settings;
            _troopWages = troopWages;
            LoadBaseWageValues();
            if (mobileParty.IsMainParty)
            {
                loadPlayerAdditional();
                if (_settings.bUsePlayerTierWagesModifiers)
                {
                    loadPlayerMultipliers();
                }
            }
            else if (mobileParty.IsLordParty || mobileParty.IsGarrison || mobileParty.IsCaravan) 
            {
                if (Kaoses.IsPlayerClan(mobileParty))
                {
                    loadPlayerAdditional();
                    if (_settings.bUsePlayerCompanionWagesCostModifiers && _settings.bUsePlayerTierWagesModifiers)
                    {
                            loadPlayerMultipliers();
                    }
                    else if (_settings.bUseAITierWagesModifiers)
                    {
                        loadAIMultipliers();
                    }
                }else
                {
                    loadAIAdditional();
                    if (_settings.bUseAITierWagesModifiers)
                    {
                        loadAIMultipliers();
                    }
                }
            }

        }

        private void loadPlayerMultipliers()
        {
            _troopWages.tierHeroWageMultiplier = _settings.tierPlayerCompanionWagesMultiplier;
            _troopWages.tier0WageMultiplier = _settings.tier0PlayerWagesMultiplier;
            _troopWages.tier1WageMultiplier = _settings.tier1PlayerWagesMultiplier;
            _troopWages.tier2WageMultiplier = _settings.tier2PlayerWagesMultiplier;
            _troopWages.tier3WageMultiplier = _settings.tier3PlayerWagesMultiplier;
            _troopWages.tier4WageMultiplier = _settings.tier4PlayerWagesMultiplier;
            _troopWages.tier5WageMultiplier = _settings.tier5PlayerWagesMultiplier;
            _troopWages.tier6WageMultiplier = _settings.tier6PlayerWagesMultiplier;
            _troopWages.tier7WageMultiplier = _settings.tier7PlayerWagesMultiplier;
        }

        private void loadPlayerAdditional()
        {
            if (_settings.bUsePlayerMercenaryWagesModifiers)
            {
                _troopWages.UseMercenaryWagesMultiplier = true;
                _troopWages.mercenaryWageMultiplier = _settings.tierPlayerMercenaryWagesMultiplier;
            }
            if(_settings.bUsePlayerBanditWagesModifiers)
            {
                _troopWages.UseBanditWagesModifiers = true;
                _troopWages.BanditWageMultiplier = _settings.playerBanditWagesMultiplier;
            }
            if (_settings.bUsePlayerWithHorsesWages)
            {
                _troopWages.withHorsesWageCost = _settings.tierPlayerHorseWages;
            }
            if (_settings.bUsePlayerCaravanWagesModifiers)
            {
                _troopWages.UseCaravanWagesModifiers = true;
                _troopWages.caravanWageMultiplier = _settings.wagesPlayerCaravanMultiplier;
            }
            if (_settings.bUsePlayerGarrisonWagesModifiers)
            {
                _troopWages.UseGarrisonWagesModifiers = true;
                _troopWages.garrisonWageMultiplier = _settings.wagesPlayerGarrisonMultiplier;
            }
        }

        private void loadAIMultipliers()
        {
            _troopWages.tierHeroWageMultiplier = _settings.tierAIHeroWagesMultiplier;
            _troopWages.tier0WageMultiplier = _settings.tier0AIWagesMultiplier;
            _troopWages.tier1WageMultiplier = _settings.tier1AIWagesMultiplier;
            _troopWages.tier2WageMultiplier = _settings.tier2AIWagesMultiplier;
            _troopWages.tier3WageMultiplier = _settings.tier3AIWagesMultiplier;
            _troopWages.tier4WageMultiplier = _settings.tier4AIWagesMultiplier;
            _troopWages.tier5WageMultiplier = _settings.tier5AIWagesMultiplier;
            _troopWages.tier6WageMultiplier = _settings.tier6AIWagesMultiplier;
            _troopWages.tier7WageMultiplier = _settings.tier7AIWagesMultiplier;
        }

        private void loadAIAdditional()
        {
            if (_settings.bUseAIMercenaryWagesModifiers)
            {
                _troopWages.UseMercenaryWagesMultiplier = true;
                _troopWages.mercenaryWageMultiplier = _settings.tierAIMercenaryWagesMultiplier;
            }
            if (_settings.bUseAIBanditWagesModifiers)
            {
                _troopWages.UseBanditWagesModifiers = true;
                _troopWages.BanditWageMultiplier = _settings.tierAIBanditWagesMultiplier;
            }
            if (_settings.bUseAIWithHorsesWagesModifiers)
            {
                _troopWages.withHorsesWageCost = _settings.tierAIHorseWages;
            }
            if (_settings.bUseAICaravanWagesModifiers)
            {
                _troopWages.UseCaravanWagesModifiers = true;
                _troopWages.caravanWageMultiplier = _settings.wagesAICaravanMultiplier;
            }
            if (_settings.bUseAIGarrisonWagesModifiers)
            {
                _troopWages.UseGarrisonWagesModifiers = true;
                _troopWages.garrisonWageMultiplier = _settings.wagesAIGarrisonMultiplier;
            }
        }

        private void LoadBaseWageValues()
        {
            _troopWages.tier0WageBase = _settings.tier0WagesBase;
            _troopWages.tier1WageBase = _settings.tier1WagesBase;
            _troopWages.tier2WageBase = _settings.tier2WagesBase;
            _troopWages.tier3WageBase = _settings.tier3WagesBase;
            _troopWages.tier4WageBase = _settings.tier4WagesBase;
            _troopWages.tier5WageBase = _settings.tier5WagesBase;
            _troopWages.tier6WageBase = _settings.tier6WagesBase;
            _troopWages.tier7WageBase = _settings.tier7WagesBase;
            _troopWages.tierOtherWageBase = _settings.tierOtherWagesBase;
        }

    }
}
