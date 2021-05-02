using KaosesWages.Utils;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Library;

namespace KaosesWages.Objects
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
                Logging.Lm("IsMercenary  cost  " + cost.ToString());
                //cost = MathF.Round((float)cost * mercenaryRecruitCostMultiplier);
                cost = MathF.Round((float)cost * mercenaryRecruitCostMultiplier);
                Logging.Lm("IsMercenary  new  " + cost.ToString());
            }

            if (IsBandit)
            {
                Logging.Lm("IsBandit  cost  " + cost.ToString());
                cost = MathF.Round((float)cost * banditRecruitCostMultiplier);
                Logging.Lm("IsBandit  new  " + cost.ToString());
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
            Logging.Lm(" *********************************************************** ");
            Logging.Lm("KaosesWageBase: DumpVariables ");
            Logging.Lm("tier0WageBase: " + tier0WageBase);
            Logging.Lm("tier1WageBase: " + tier1WageBase);
            Logging.Lm("tier2WageBase: " + tier2WageBase);
            Logging.Lm("tier3WageBase: " + tier3WageBase);
            Logging.Lm("tier4WageBase: " + tier4WageBase);
            Logging.Lm("tier5WageBase: " + tier5WageBase);
            Logging.Lm("tier6WageBase: " + tier6WageBase);
            Logging.Lm("tier7WageBase: " + tier7WageBase);
            Logging.Lm("tierOtherWageBase: " + tierOtherWageBase);
            Logging.Lm(" ");
            Logging.Lm("UseCaravanWagesModifiers: " + UseCaravanWagesModifiers);
            Logging.Lm("UseGarrisonWagesModifiers: " + UseGarrisonWagesModifiers);
            Logging.Lm("UseMercenaryWagesMultiplier: " + UseMercenaryWagesMultiplier);
            Logging.Lm("UseBanditWagesModifiers: " + UseBanditWagesModifiers);
            Logging.Lm(" ");
            Logging.Lm("tierHeroWageMultiplier: " + tierHeroWageMultiplier);
            Logging.Lm("tier0WageMultiplier: " + tier0WageMultiplier);
            Logging.Lm("tier1WageMultiplier: " + tier1WageMultiplier);
            Logging.Lm("tier2WageMultiplier: " + tier2WageMultiplier);
            Logging.Lm("tier3WageMultiplier: " + tier3WageMultiplier);
            Logging.Lm("tier4WageMultiplier: " + tier4WageMultiplier);
            Logging.Lm("tier5WageMultiplier: " + tier5WageMultiplier);
            Logging.Lm("tier6WageMultiplier: " + tier6WageMultiplier);
            Logging.Lm("tier7WageMultiplier: " + tier7WageMultiplier);
            Logging.Lm(" ");
            Logging.Lm("mercenaryWageMultiplier: " + mercenaryWageMultiplier);
            Logging.Lm("BanditWageMultiplier: " + BanditWageMultiplier);
            Logging.Lm("garrisonWageMultiplier: " + garrisonWageMultiplier);
            Logging.Lm("caravanWageMultiplier: " + caravanWageMultiplier);
            Logging.Lm("withHorsesWageCost: " + withHorsesWageCost);
            Logging.Lm(" ");
            Logging.Lm(" ");
            Logging.Lm(" ");
            Logging.Lm("tier0RecruitCostBase: " + tier0RecruitCostBase);
            Logging.Lm("tier1RecruitCostBase: " + tier1RecruitCostBase);
            Logging.Lm("tier2RecruitCostBase: " + tier2RecruitCostBase);
            Logging.Lm("tier3RecruitCostBase: " + tier3RecruitCostBase);
            Logging.Lm("tier4RecruitCostBase: " + tier4RecruitCostBase);
            Logging.Lm("tier5RecruitCostBase: " + tier5RecruitCostBase);
            Logging.Lm("tier6RecruitCostBase: " + tier6RecruitCostBase);
            Logging.Lm("tier7RecruitCostBase: " + tier7RecruitCostBase);
            Logging.Lm(" ");
            Logging.Lm("tierOtherRecruitCostBase: " + tierOtherRecruitCostBase);
            Logging.Lm("tier0RecruitCostMultiplier: " + tier0RecruitCostMultiplier);
            Logging.Lm("tier1RecruitCostMultiplier: " + tier1RecruitCostMultiplier);
            Logging.Lm("tier2RecruitCostMultiplier: " + tier2RecruitCostMultiplier);
            Logging.Lm("tier3RecruitCostMultiplier: " + tier3RecruitCostMultiplier);
            Logging.Lm("tier4RecruitCostMultiplier: " + tier4RecruitCostMultiplier);
            Logging.Lm("tier5RecruitCostMultiplier: " + tier5RecruitCostMultiplier);
            Logging.Lm("tier6RecruitCostMultiplier: " + tier6RecruitCostMultiplier);
            Logging.Lm("tier7RecruitCostMultiplier: " + tier7RecruitCostMultiplier);
            Logging.Lm(" ");
            Logging.Lm("withHorsesRecriutCost: " + withHorsesRecriutCost);
            Logging.Lm("withHorsesRecriutHighCost: " + withHorsesRecriutHighCost);
            Logging.Lm("mercenaryRecruitCostMultiplier: " + mercenaryRecruitCostMultiplier);
            Logging.Lm("banditRecruitCostMultiplier: " + banditRecruitCostMultiplier);
            Logging.Lm(" ");
        }

    }
}
