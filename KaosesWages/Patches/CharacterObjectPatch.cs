using HarmonyLib;
using KaosesWages.Config;
using KaosesWages.Objects;
using KaosesWages.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.CampaignSystem;

namespace KaosesWages.Patches
{
    class CharacterObjectPatch
    {
        [HarmonyPatch(typeof(CharacterObject), "UpgradeCost")]
        public class CharacterObjectUpgradeCostPatch
        {
            static void Postfix(PartyBase party, int index, ref int __result)
            {
                if (party != null && party.LeaderHero == Hero.MainHero)
                {
                    //float tmp = (int)__result * Settings.Instance.playerUpgradeCostMultiplier;
                    //Logging.lm("Player Only Old Cost: "+ __result + "  New UpgradeCost : " + tmp.ToString());
                    __result = (int)(__result * Settings.Instance.playerUpgradeCostMultiplier);

                }else if (KaosesWageBase.isPlayerClan(party) && Settings.Instance.bUsePlayerUpgradeCostForClanMembers)
                {
                    //float tmp = (int)__result * Settings.Instance.playerUpgradeCostMultiplier;
                    //Logging.lm("Player Clan Old Cost: " + __result + "  New UpgradeCost : " + tmp.ToString());
                    __result = (int)(__result * Settings.Instance.playerUpgradeCostMultiplier);
                }
            }

            static bool Prepare()
            {
                return  true;
            }

            static void Finalizer(Exception __exception)
            {
                if (__exception != null)
                {
                    Logging.lm(__exception.ToString());
                    //MessageBox.Show(__exception.FlattenException());
                }
            }
        }
    }
}
