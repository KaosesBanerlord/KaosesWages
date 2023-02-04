using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Library;

namespace KaosesWagesCore.Objects
{

    public class KaosesWageBase
    {
        public int tier0WageBase = 1;
        public int tier1WageBase = 2;
        public int tier2WageBase = 3;
        public int tier3WageBase = 5;
        public int tier4WageBase = 8;
        public int tier5WageBase = 12;
        public int tier6WageBase = 17;
        public int tier7WageBase = 23;
        public int tierOtherWageBase = 33;

        public bool UseCaravanWagesModifiers = false;
        public bool UseGarrisonWagesModifiers = false;
        public bool UseMercenaryWagesMultiplier = false;
        public bool UseBanditWagesModifiers = false;
        public bool UseWithHorsesWages = false;

        public float tierHeroWageMultiplier = 1.0f;
        public float tier0WageMultiplier = 1.0f;
        public float tier1WageMultiplier = 1.0f;
        public float tier2WageMultiplier = 1.0f;
        public float tier3WageMultiplier = 1.0f;
        public float tier4WageMultiplier = 1.0f;
        public float tier5WageMultiplier = 1.0f;
        public float tier6WageMultiplier = 1.0f;
        public float tier7WageMultiplier = 1.0f;
        public float mercenaryWageMultiplier = 2.0f;
        public float BanditWageMultiplier = 1.5f;
        public float garrisonWageMultiplier = 1.0f;
        public float caravanWageMultiplier = 1.0f;
        public int withHorsesWageCost = 0;

        public int tier0RecruitCostBase = 10;
        public int tier1RecruitCostBase = 20;
        public int tier2RecruitCostBase = 50;
        public int tier3RecruitCostBase = 100;
        public int tier4RecruitCostBase = 200;
        public int tier5RecruitCostBase = 400;
        public int tier6RecruitCostBase = 600;
        public int tier7RecruitCostBase = 1000;
        public int tierOtherRecruitCostBase = 1500;

        public float tier0RecruitCostMultiplier = 1.0f;
        public float tier1RecruitCostMultiplier = 1.0f;
        public float tier2RecruitCostMultiplier = 1.0f;
        public float tier3RecruitCostMultiplier = 1.0f;
        public float tier4RecruitCostMultiplier = 1.0f;
        public float tier5RecruitCostMultiplier = 1.0f;
        public float tier6RecruitCostMultiplier = 1.0f;
        public float tier7RecruitCostMultiplier = 1.0f;
        public int withHorsesRecriutCost = 150;
        public int withHorsesRecriutHighCost = 500;
        public float mercenaryRecruitCostMultiplier = 2.0f;
        public float banditRecruitCostMultiplier = 0.7f;


        protected int GetFinalBaseRecruitCost(CharacterObject troop, int cost, int withHorseAdditional)
        {
            bool IsMercenary = IsTroopMercenary(troop);
            bool IsBandit = IsTroopBandit(troop);

            if (IsMercenary)
            {
                //cost = MathF.Round((float)cost * mercenaryRecruitCostMultiplier);
                cost = MathF.Round((float)cost * mercenaryRecruitCostMultiplier);
            }

            if (IsBandit)
            {
                cost = MathF.Round((float)cost * banditRecruitCostMultiplier);
            }

            if (withHorseAdditional > 0)
            {
                cost += withHorseAdditional;
            }

            return cost;
        }


        protected int GetFinalBaseWageCost(CharacterObject troop, int cost, int withHorseAdditional)
        {

            bool IsMercenary = IsTroopMercenary(troop);
            bool IsBandit = IsTroopBandit(troop);

            if (IsMercenary && UseMercenaryWagesMultiplier)
            {
                cost = MathF.Round((float)cost * mercenaryWageMultiplier);
            }

            if (IsBandit && UseBanditWagesModifiers)
            {
                cost = MathF.Round((float)cost * BanditWageMultiplier);
            }

            if (UseCaravanWagesModifiers)
            {
                cost = MathF.Round((float)cost * caravanWageMultiplier);
            }

            if (withHorseAdditional > 0)
            {
                cost += withHorseAdditional;
            }

            return cost;
        }



        protected bool TroopHasHorse(CharacterObject troop)
        {
            return troop.IsMounted; //troop.Equipment.Horse.Item != null
        }

        protected int GetTroopWithHorseRecruitCostAdditional(CharacterObject troop, bool withoutItemCost = false)
        {
            int additional = 0;
            if (troop.Equipment.Horse.Item != null && !withoutItemCost)
            {
                if (troop.Tier < 4)
                {
                    additional = withHorsesRecriutCost;
                }
                else
                {
                    additional = withHorsesRecriutHighCost;
                }
            }
            return additional;
        }

        protected int GetTroopWithHorseAdditionalWage(CharacterObject troop, bool withoutItemCost = false)
        {
            int additional = 0;
            if (troop.Equipment.Horse.Item != null && !withoutItemCost)
            {
                additional = withHorsesWageCost;
            }
            return additional;
        }

        protected bool IsTroopMercenary(CharacterObject troop)
        {
            return troop.Occupation == Occupation.Mercenary;// || troop.Occupation == Occupation.Gangster
        }

        protected bool IsRecruitMercenary(CharacterObject troop)
        {
            return troop.Occupation == Occupation.Mercenary || troop.Occupation == Occupation.Gangster || troop.Occupation == Occupation.CaravanGuard;
        }

        protected bool IsTroopBandit(CharacterObject troop)
        {
            return troop.Culture.IsBandit;
        }


        public void DumpVariables()
        {
            KaosesCommon.Utils.Logger.Lm(" *********************************************************** ");
            KaosesCommon.Utils.Logger.Lm("KaosesWageBase: DumpVariables ");
            KaosesCommon.Utils.Logger.Lm("tier0WageBase: " + tier0WageBase);
            KaosesCommon.Utils.Logger.Lm("tier1WageBase: " + tier1WageBase);
            KaosesCommon.Utils.Logger.Lm("tier2WageBase: " + tier2WageBase);
            KaosesCommon.Utils.Logger.Lm("tier3WageBase: " + tier3WageBase);
            KaosesCommon.Utils.Logger.Lm("tier4WageBase: " + tier4WageBase);
            KaosesCommon.Utils.Logger.Lm("tier5WageBase: " + tier5WageBase);
            KaosesCommon.Utils.Logger.Lm("tier6WageBase: " + tier6WageBase);
            KaosesCommon.Utils.Logger.Lm("tier7WageBase: " + tier7WageBase);
            KaosesCommon.Utils.Logger.Lm("tierOtherWageBase: " + tierOtherWageBase);
            KaosesCommon.Utils.Logger.Lm(" ");
            KaosesCommon.Utils.Logger.Lm("UseCaravanWagesModifiers: " + UseCaravanWagesModifiers);
            KaosesCommon.Utils.Logger.Lm("UseGarrisonWagesModifiers: " + UseGarrisonWagesModifiers);
            KaosesCommon.Utils.Logger.Lm("UseMercenaryWagesMultiplier: " + UseMercenaryWagesMultiplier);
            KaosesCommon.Utils.Logger.Lm("UseBanditWagesModifiers: " + UseBanditWagesModifiers);
            KaosesCommon.Utils.Logger.Lm(" ");
            KaosesCommon.Utils.Logger.Lm("tierHeroWageMultiplier: " + tierHeroWageMultiplier);
            KaosesCommon.Utils.Logger.Lm("tier0WageMultiplier: " + tier0WageMultiplier);
            KaosesCommon.Utils.Logger.Lm("tier1WageMultiplier: " + tier1WageMultiplier);
            KaosesCommon.Utils.Logger.Lm("tier2WageMultiplier: " + tier2WageMultiplier);
            KaosesCommon.Utils.Logger.Lm("tier3WageMultiplier: " + tier3WageMultiplier);
            KaosesCommon.Utils.Logger.Lm("tier4WageMultiplier: " + tier4WageMultiplier);
            KaosesCommon.Utils.Logger.Lm("tier5WageMultiplier: " + tier5WageMultiplier);
            KaosesCommon.Utils.Logger.Lm("tier6WageMultiplier: " + tier6WageMultiplier);
            KaosesCommon.Utils.Logger.Lm("tier7WageMultiplier: " + tier7WageMultiplier);
            KaosesCommon.Utils.Logger.Lm(" ");
            KaosesCommon.Utils.Logger.Lm("mercenaryWageMultiplier: " + mercenaryWageMultiplier);
            KaosesCommon.Utils.Logger.Lm("BanditWageMultiplier: " + BanditWageMultiplier);
            KaosesCommon.Utils.Logger.Lm("garrisonWageMultiplier: " + garrisonWageMultiplier);
            KaosesCommon.Utils.Logger.Lm("caravanWageMultiplier: " + caravanWageMultiplier);
            KaosesCommon.Utils.Logger.Lm("withHorsesWageCost: " + withHorsesWageCost);
            KaosesCommon.Utils.Logger.Lm(" ");
            KaosesCommon.Utils.Logger.Lm(" ");
            KaosesCommon.Utils.Logger.Lm(" ");
            KaosesCommon.Utils.Logger.Lm("tier0RecruitCostBase: " + tier0RecruitCostBase);
            KaosesCommon.Utils.Logger.Lm("tier1RecruitCostBase: " + tier1RecruitCostBase);
            KaosesCommon.Utils.Logger.Lm("tier2RecruitCostBase: " + tier2RecruitCostBase);
            KaosesCommon.Utils.Logger.Lm("tier3RecruitCostBase: " + tier3RecruitCostBase);
            KaosesCommon.Utils.Logger.Lm("tier4RecruitCostBase: " + tier4RecruitCostBase);
            KaosesCommon.Utils.Logger.Lm("tier5RecruitCostBase: " + tier5RecruitCostBase);
            KaosesCommon.Utils.Logger.Lm("tier6RecruitCostBase: " + tier6RecruitCostBase);
            KaosesCommon.Utils.Logger.Lm("tier7RecruitCostBase: " + tier7RecruitCostBase);
            KaosesCommon.Utils.Logger.Lm(" ");
            KaosesCommon.Utils.Logger.Lm("tierOtherRecruitCostBase: " + tierOtherRecruitCostBase);
            KaosesCommon.Utils.Logger.Lm("tier0RecruitCostMultiplier: " + tier0RecruitCostMultiplier);
            KaosesCommon.Utils.Logger.Lm("tier1RecruitCostMultiplier: " + tier1RecruitCostMultiplier);
            KaosesCommon.Utils.Logger.Lm("tier2RecruitCostMultiplier: " + tier2RecruitCostMultiplier);
            KaosesCommon.Utils.Logger.Lm("tier3RecruitCostMultiplier: " + tier3RecruitCostMultiplier);
            KaosesCommon.Utils.Logger.Lm("tier4RecruitCostMultiplier: " + tier4RecruitCostMultiplier);
            KaosesCommon.Utils.Logger.Lm("tier5RecruitCostMultiplier: " + tier5RecruitCostMultiplier);
            KaosesCommon.Utils.Logger.Lm("tier6RecruitCostMultiplier: " + tier6RecruitCostMultiplier);
            KaosesCommon.Utils.Logger.Lm("tier7RecruitCostMultiplier: " + tier7RecruitCostMultiplier);
            KaosesCommon.Utils.Logger.Lm(" ");
            KaosesCommon.Utils.Logger.Lm("withHorsesRecriutCost: " + withHorsesRecriutCost);
            KaosesCommon.Utils.Logger.Lm("withHorsesRecriutHighCost: " + withHorsesRecriutHighCost);
            KaosesCommon.Utils.Logger.Lm("mercenaryRecruitCostMultiplier: " + mercenaryRecruitCostMultiplier);
            KaosesCommon.Utils.Logger.Lm("banditRecruitCostMultiplier: " + banditRecruitCostMultiplier);
            KaosesCommon.Utils.Logger.Lm(" ");
        }

    }
}
