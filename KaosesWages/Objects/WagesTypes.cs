using KaosesWages.Config;
using KaosesWages.Utils;
using TaleWorlds.CampaignSystem;

namespace KaosesWages.Objects
{
    public class WagesTypes
    {
        public MobileParty _mobileParty;
        public float tierHeroMultiplier = 1.0f;
        public float tier0Multiplier = 1.0f;
        public float tier1Multiplier = 1.0f;
        public float tier2Multiplier = 1.0f;
        public float tier3Multiplier = 1.0f;
        public float tier4Multiplier = 1.0f;
        public float tier5Multiplier = 1.0f;
        public float tier6Multiplier = 1.0f;
        public float tier7Multiplier = 1.0f;
        public float mercenaryMultiplier = 1.5f;
        public int withHorsesWage = 0;
        public float garrisonMultiplier = 1.0f;
        public float caravanMultiplier = 1.0f;


        public WagesTypes(MobileParty mobileParty)
        {
            if (mobileParty.IsMainParty)
            {
                if (Settings.Instance.bUsePlayerTierWagesModifiers)
                {
                    this.loadPlayerMultipliers();
                }
            }
            else if (mobileParty.IsLordParty)
            {
                if (this.isPlayerClan(mobileParty))
                {
                    if (Settings.Instance.bUsePlayerTierWagesModifiers)
                    {
                        this.loadPlayerMultipliers();
                    }
                }else
                {
                    if (Settings.Instance.bUseAITierWagesModifiers)
                    {
                        this.loadAIMultipliers();
                    }
                }
            }
            
            if (mobileParty.IsGarrison)
            {
                if (this.isPlayerClan(mobileParty))
                {
                    if (Settings.Instance.bUsePlayerGarrisonWagesModifiers)
                    {
                        this.loadPlayerMultipliers();
                        this.loadPlayerGarrisonMultipliers();
                    }
                }else
                {
                    if(Settings.Instance.bUseAIGarrisonWagesModifiers)
                    {
                        this.loadAIMultipliers();
                        this.loadAIGarrisonMultipliers();
                    }
                }
            }

            if (mobileParty.IsCaravan)
            {
                if(this.isPlayerClan(mobileParty))
                {
                    if (Settings.Instance.bUsePlayerCaravanWagesModifiers)
                    {
                        this.loadPlayerMultipliers();
                        this.loadPlayerCaravanMultipliers();
                    }
                }else
                {
                    if (Settings.Instance.bUseAICaravanWagesModifiers)
                    {
                        this.loadAIMultipliers();
                        this.loadAICaravanMultipliers();
                    }
                }
            }
            //this.logWageMultipliersAll(mobileParty);
            //this.logWageMultipliersPlayerClan(mobileParty, true);
            //this.logWageMultipliersAI(mobileParty, true);
            //this.logWageMultipliersCaravan(mobileParty, true);
            //Logging.lm("character.Tier < 4 StringId: " + elementCopyAtIndex.Character.StringId.ToString() + "  Wage Cost: " + tmp.ToString());
        }

        public WagesTypes()
        {
            if (Settings.Instance.bUsePlayerTierWagesModifiers)
            {
                this.loadPlayerMultipliers();
            }
        }

        private void loadPlayerMultipliers()
        {
            this.tierHeroMultiplier = Settings.Instance.tierPlayerHeroWagesMultiplier;
            this.tier0Multiplier = Settings.Instance.tier0PlayerWagesMultiplier;
            this.tier1Multiplier = Settings.Instance.tier1PlayerWagesMultiplier;
            this.tier2Multiplier = Settings.Instance.tier2PlayerWagesMultiplier;
            this.tier3Multiplier = Settings.Instance.tier3PlayerWagesMultiplier;
            this.tier4Multiplier = Settings.Instance.tier4PlayerWagesMultiplier;
            this.tier5Multiplier = Settings.Instance.tier5PlayerWagesMultiplier;
            this.tier6Multiplier = Settings.Instance.tier6PlayerWagesMultiplier;
            this.tier7Multiplier = Settings.Instance.tier7PlayerWagesMultiplier;
            if (Settings.Instance.bUsePlayerMercenaryWagesModifiers)
            {
                this.mercenaryMultiplier = Settings.Instance.tierPlayerMercenaryWagesMultiplier;
            }
            if (Settings.Instance.bUsePlayerWithHorsesWages)
            {
                this.withHorsesWage = Settings.Instance.tierPlayerHorseWages;
            }
        }

        private void loadAIMultipliers()
        {
            this.tierHeroMultiplier = Settings.Instance.tierAIHeroWagesMultiplier;
            this.tier0Multiplier = Settings.Instance.tier0AIWagesMultiplier;
            this.tier1Multiplier = Settings.Instance.tier1AIWagesMultiplier;
            this.tier2Multiplier = Settings.Instance.tier2AIWagesMultiplier;
            this.tier3Multiplier = Settings.Instance.tier3AIWagesMultiplier;
            this.tier4Multiplier = Settings.Instance.tier4AIWagesMultiplier;
            this.tier5Multiplier = Settings.Instance.tier5AIWagesMultiplier;
            this.tier6Multiplier = Settings.Instance.tier6AIWagesMultiplier;
            this.tier7Multiplier = Settings.Instance.tier7AIWagesMultiplier;
            if (Settings.Instance.bUseAIMercenaryWagesModifiers)
            {
                this.mercenaryMultiplier = Settings.Instance.tierAIMercenaryWagesMultiplier;
            }
            if (Settings.Instance.bUseAIWithHorsesWagesModifiers)
            {
                this.withHorsesWage = Settings.Instance.tierAIHorseWages;
            }
        }

        private void loadPlayerGarrisonMultipliers()
        {
            this.garrisonMultiplier = Settings.Instance.wagesPlayerGarrisonMultiplier;
        }

        private void loadAIGarrisonMultipliers()
        {
            this.garrisonMultiplier = Settings.Instance.wagesAIGarrisonMultiplier;
        }

        private void loadPlayerCaravanMultipliers()
        {
            this.caravanMultiplier = Settings.Instance.wagesPlayerCaravanMultiplier;
        }

        private void loadAICaravanMultipliers()
        {
            this.caravanMultiplier = Settings.Instance.wagesAICaravanMultiplier;
        }


        private bool isPlayerClan(MobileParty mobileParty)
        {
            bool isPlayerClan = false;
            Clan clan;
            Clan playerClan;
            if (mobileParty.IsCaravan)
            {
                Hero hero = mobileParty.LeaderHero;
                if (hero != null)
                {
                    clan = hero.Clan;
                    playerClan = Clan.PlayerClan;
                    if (clan == playerClan)
                    {
                        isPlayerClan = true;
                    }
                }
            }else if (mobileParty.IsGarrison)
            {
                Settlement settlement = mobileParty.CurrentSettlement;
                clan = settlement.OwnerClan;
                playerClan = Clan.PlayerClan;
                if (clan == playerClan)
                {
                    isPlayerClan = true;
                }
            }
            return isPlayerClan;
        }

        private void logWageMultipliers(MobileParty mobileParty)
        {
            Logging.lm("Debug  IsMainParty: " + mobileParty.IsMainParty.ToString());
            Logging.lm("Debug  IsLordParty: " + mobileParty.IsLordParty.ToString());
            Logging.lm("Debug  IsCaravan: " + mobileParty.IsCaravan.ToString());
            Logging.lm("Debug  IsGarrison: " + mobileParty.IsGarrison.ToString());
            bool isplayerClan = this.isPlayerClan(mobileParty);
            Logging.lm("Debug  isplayerClan: " + isplayerClan.ToString());
            Logging.lm("Debug  tierHero: " + this.tierHeroMultiplier.ToString());
            Logging.lm("Debug  tier0: " + this.tier0Multiplier.ToString());
            Logging.lm("Debug  tier1: " + this.tier1Multiplier.ToString());
            Logging.lm("Debug  tier2: " + this.tier2Multiplier.ToString());
            Logging.lm("Debug  tier3: " + this.tier3Multiplier.ToString());
            Logging.lm("Debug  tier4: " + this.tier4Multiplier.ToString());
            Logging.lm("Debug  tier5: " + this.tier5Multiplier.ToString());
            Logging.lm("Debug  tier6: " + this.tier6Multiplier.ToString());
            Logging.lm("Debug  tier7: " + this.tier7Multiplier.ToString());
            Logging.lm("Debug  mercenary: " + this.mercenaryMultiplier.ToString());
            Logging.lm("Debug  withHorses: " + this.withHorsesWage.ToString());
            Logging.lm("Debug  Garrison: " + this.garrisonMultiplier.ToString());
            Logging.lm("Debug  Caravan: " + this.caravanMultiplier.ToString());
            Logging.lm(" ");
            Logging.lm(" ");
        }


        protected void logWageMultipliersAll(MobileParty mobileParty)
        {
            Logging.lm("Debug  :------------ Log Wage Multipliers ALL -------------- ");
            Logging.lm("Debug Name : " + mobileParty.Name.ToString());
            Logging.lm("Debug StringId : " + mobileParty.StringId.ToString());
            this.logWageMultipliers(mobileParty);
        }

        protected void logWageMultipliersPlayerClan(MobileParty mobileParty, bool excludePlayer = false)
        {
            if (this.isPlayerClan(mobileParty))
            {
                if (excludePlayer && mobileParty.IsMainParty)
                {
                    return;
                }

                Logging.lm("Debug  :------------ Log Wage Multipliers PlayerClan -------------- ");
                Logging.lm("Debug Name : " + mobileParty.Name.ToString());
                Logging.lm("Debug StringId : " + mobileParty.StringId.ToString());
                this.logWageMultipliers(mobileParty);
            }
        }


        protected void logWageMultipliersAI(MobileParty mobileParty, bool lordPartiesOnly = false)
        {
            if (!this.isPlayerClan(mobileParty))
            {
                if (lordPartiesOnly && !mobileParty.IsLordParty)
                {
                    return;
                }
                Logging.lm("Debug  :------------ Log Wage Multipliers AI -------------- ");
                Logging.lm("Debug Name : " + mobileParty.Name.ToString());
                Logging.lm("Debug StringId : " + mobileParty.StringId.ToString());
                this.logWageMultipliers(mobileParty);
            }
        }


        protected void logWageMultipliersCaravan(MobileParty mobileParty, bool playerClanOnly = false)
        {
            if (mobileParty.IsCaravan)
            {
                if (playerClanOnly && !this.isPlayerClan(mobileParty))
                {
                    return;
                }
                Logging.lm("Debug  :------------ Log Wage Multipliers Caravan -------------- ");
                Logging.lm("Debug Name : " + mobileParty.Name.ToString());
                Logging.lm("Debug StringId : " + mobileParty.StringId.ToString());

                this.logWageMultipliers(mobileParty);
            }
        }
        protected void logWageMultipliersGarrison(MobileParty mobileParty, bool playerClanOnly = false)
        {
            if (mobileParty.IsGarrison)
            {
                if (playerClanOnly && !this.isPlayerClan(mobileParty))
                {
                    return;
                }
                Logging.lm("Debug  :------------ Log Wage Multipliers Garrison -------------- ");
                Logging.lm("Debug Name : " + mobileParty.Name.ToString());
                Logging.lm("Debug StringId : " + mobileParty.StringId.ToString());
                this.logWageMultipliers(mobileParty);
            }
        }

    }
}
