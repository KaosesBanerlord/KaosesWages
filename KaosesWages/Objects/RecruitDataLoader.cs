using KaosesWages.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.CampaignSystem;

namespace KaosesWages.Objects
{
    public class RecruitDataLoader
    {
        public static ISettingsProviderInterface? _settings;
        public KaosesTroopRecruitment _troopRecruitment;


        /**
         * Imperial heavy horsemen level 21  cost 350  / 750   tier5 ?
         * Aserai youth level 11  Cost 200 /  120
         */
        public RecruitDataLoader(Hero buyerHero, ref KaosesTroopRecruitment troopRecruitment)
        {
            _settings = Statics._settings;
            _troopRecruitment = troopRecruitment;
            LoadRecruitBaseValues();
            if (buyerHero != null)
            {
                if (_settings.bUsePlayerRecruitCostModifiers && buyerHero.IsHumanPlayerCharacter)
                {
                    loadPlayerMultipliers();
                }else if (_settings.bUsePlayerCompanionRecruitCostModifiers && buyerHero.IsPlayerCompanion)
                {
                    loadPlayerMultipliers();
                }else if (_settings.bUseAIRecruitCostModifiers && buyerHero.IsPlayerCompanion)
                {
                    loadAIMultipliers();
                }else if (_settings.bUseAIRecruitCostModifiers && !buyerHero.IsHumanPlayerCharacter && !buyerHero.IsPlayerCompanion)
                {
                    loadAIMultipliers();
                }
            }
        }
        private void loadPlayerMultipliers()
        {
            _troopRecruitment.tier0RecruitCostMultiplier = _settings.tier0PlayerRecruitCostMultiplier;
            _troopRecruitment.tier1RecruitCostMultiplier = _settings.tier1PlayerRecruitCostMultiplier;
            _troopRecruitment.tier2RecruitCostMultiplier = _settings.tier2PlayerRecruitCostMultiplier;
            _troopRecruitment.tier3RecruitCostMultiplier = _settings.tier3PlayerRecruitCostMultiplier;
            _troopRecruitment.tier4RecruitCostMultiplier = _settings.tier4PlayerRecruitCostMultiplier;
            _troopRecruitment.tier5RecruitCostMultiplier = _settings.tier5PlayerRecruitCostMultiplier;
            _troopRecruitment.tier6RecruitCostMultiplier = _settings.tier6PlayerRecruitCostMultiplier;
            _troopRecruitment.tier7RecruitCostMultiplier = _settings.tier7PlayerRecruitCostMultiplier;
            _troopRecruitment.mercenaryRecruitCostMultiplier = _settings.tierMercenaryPlayerRecruitCostMultiplier;
            _troopRecruitment.banditRecruitCostMultiplier = _settings.tierBanditPlayerRecruitCostMultiplier;
            _troopRecruitment.withHorsesRecriutCost = _settings.tierMountedPlayerRecruitCost;
            _troopRecruitment.withHorsesRecriutHighCost = _settings.tierMountedPlayerRecruitHighCost;
        }

        private void loadAIMultipliers()
        {
            _troopRecruitment.tier0RecruitCostMultiplier = _settings.tier0AIRecruitCostMultiplier;
            _troopRecruitment.tier1RecruitCostMultiplier = _settings.tier1AIRecruitCostMultiplier;
            _troopRecruitment.tier2RecruitCostMultiplier = _settings.tier2AIRecruitCostMultiplier;
            _troopRecruitment.tier3RecruitCostMultiplier = _settings.tier3AIRecruitCostMultiplier;
            _troopRecruitment.tier4RecruitCostMultiplier = _settings.tier4AIRecruitCostMultiplier;
            _troopRecruitment.tier5RecruitCostMultiplier = _settings.tier5AIRecruitCostMultiplier;
            _troopRecruitment.tier6RecruitCostMultiplier = _settings.tier6AIRecruitCostMultiplier;
            _troopRecruitment.tier7RecruitCostMultiplier = _settings.tier7AIRecruitCostMultiplier;
            _troopRecruitment.mercenaryRecruitCostMultiplier = _settings.tierMercenaryAIRecruitCostMultiplier;
            _troopRecruitment.banditRecruitCostMultiplier = _settings.tierBanditAIRecruitCostMultiplier;
            _troopRecruitment.withHorsesRecriutCost = _settings.tierMountedAIRecruitCost;
            _troopRecruitment.withHorsesRecriutHighCost = _settings.tierMountedAIRecruitHighCost;
        }

        private void LoadRecruitBaseValues()
        {
            _troopRecruitment.tier0RecruitCostBase = _settings.tier0RecruitCostBase;
            _troopRecruitment.tier1RecruitCostBase = _settings.tier1RecruitCostBase;
            _troopRecruitment.tier2RecruitCostBase = _settings.tier2RecruitCostBase;
            _troopRecruitment.tier3RecruitCostBase = _settings.tier3RecruitCostBase;
            _troopRecruitment.tier4RecruitCostBase = _settings.tier4RecruitCostBase;
            _troopRecruitment.tier5RecruitCostBase = _settings.tier5RecruitCostBase;
            _troopRecruitment.tier6RecruitCostBase = _settings.tier6RecruitCostBase;
            _troopRecruitment.tier7RecruitCostBase = _settings.tier7RecruitCostBase;
            _troopRecruitment.tierOtherRecruitCostBase = _settings.tierOtherRecruitCostBase;
        }
    }
}
