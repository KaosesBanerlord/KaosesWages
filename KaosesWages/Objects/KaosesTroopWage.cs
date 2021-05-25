using System.Diagnostics;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Library;

namespace KaosesWages.Objects
{
    public class KaosesTroopWage : KaosesWageBase
    {

        public KaosesTroopWage()
        {

        }

        // Token: 0x17000205 RID: 517
        // (get) Token: 0x0600092D RID: 2349 RVA: 0x00033E9C File Offset: 0x0003209C

        public int GetTroopWage(CharacterObject troop)
        {
            int result = 23;
            if (troop.IsHero){
                return MathF.Round((float)2 + troop.Level * 2 * tierHeroWageMultiplier);
            }

            int withHorseAdditional = GetTroopWithHorseAdditionalWage(troop);
            float multiplier = GetWageMultiplierForTier(troop.Tier);
            int wageBase = GetWageBaseForTier(troop.Tier);
            result = MathF.Round((float)GetFinalBaseWageCost(troop, wageBase, withHorseAdditional) * multiplier);

            if (result < 1)
            {
                result = 1;
            }
            return result;
        }



        // Token: 0x06002D7A RID: 11642 RVA: 0x000B55D0 File Offset: 0x000B37D0
        public int GetCharacterWage(int tier)
        {
            int result = 23;
            float multiplier = GetWageMultiplierForTier(tier);
            int wageBase = GetWageBaseForTier(tier);
            result = MathF.Round((float)wageBase * multiplier);
            return result;
        }

        private int GetWageBaseForTier(int troopTier)
        {
            int wageBase = 0;
            switch (troopTier)
            {
                case 0:
                    wageBase = tier0WageBase;
                    break;
                case 1:
                    wageBase = tier1WageBase;
                    break;
                case 2:
                    wageBase = tier2WageBase;
                    break;
                case 3:
                    wageBase = tier3WageBase;
                    break;
                case 4:
                    wageBase = tier4WageBase;
                    break;
                case 5:
                    wageBase = tier5WageBase;
                    break;
                case 6:
                    wageBase = tier6WageBase;
                    break;
                case 7:
                    wageBase = tier7WageBase;
                    break;
                default:
                    wageBase = tierOtherWageBase;
                    break;
            }
            return wageBase;
        }


        private float GetWageMultiplierForTier(int troopTier)
        {
            float multiplier = 1.0f;
            switch (troopTier)
            {
                case 0:
                    multiplier = tier0WageMultiplier;
                    break;
                case 1:
                    multiplier = tier1WageMultiplier;
                    break;
                case 2:
                    multiplier = tier2WageMultiplier;
                    break;
                case 3:
                    multiplier = tier3WageMultiplier;
                    break;
                case 4:
                    multiplier = tier4WageMultiplier;
                    break;
                case 5:
                    multiplier = tier5WageMultiplier;
                    break;
                case 6:
                    multiplier = tier6WageMultiplier;
                    break;
                case 7:
                    multiplier = tier7WageMultiplier;
                    break;
                default:
                    multiplier = tier7WageMultiplier;
                    break;
            }
            return multiplier;
        }


    }
}
