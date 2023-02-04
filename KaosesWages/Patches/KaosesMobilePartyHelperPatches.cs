using HarmonyLib;
using TaleWorlds.CampaignSystem;
using System.Reflection;
using Helpers;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;

namespace KaosesWages.Patches
{
    [HarmonyPatch(typeof(MobilePartyHelper), "DesertTroopsFromParty")]
    public class DesertTroopsFromPartyPatch
    {
        private static MethodInfo? openPartMethodInfo;

        static bool Prefix(MobileParty party, int stackNo, int numberOfDeserters, int numberOfWoundedDeserters, ref TroopRoster desertedTroopList)
        {
            if (party.MemberRoster.Count <= stackNo)
            {
                TroopRosterElement elementCopyAtIndex = party.MemberRoster.GetElementCopyAtIndex(stackNo);
                party.MemberRoster.AddToCounts(elementCopyAtIndex.Character, -(numberOfDeserters + numberOfWoundedDeserters), false, -numberOfWoundedDeserters, 0, true, -1);
                if (desertedTroopList == null)
                {
                    desertedTroopList = TroopRoster.CreateDummyTroopRoster();
                }
                if (desertedTroopList != null)
                {
                    desertedTroopList.AddToCounts(elementCopyAtIndex.Character, numberOfDeserters + numberOfWoundedDeserters, false, numberOfWoundedDeserters, 0, true, -1);

                }
            }
            return false;
        }

        //static bool Prepare() => MCMSettings.Instance is { } settings && (settings.SmithingEnergyDisable || settings.CraftingStaminaTweakEnabled) && MCMSettings.Instance.MCMSmithingHarmoneyPatches;

        //private static void GetMethodInfo()
        //{
        //    openPartMethodInfo = typeof(CraftingCampaignBehavior).GetMethod("OpenPart", BindingFlags.NonPublic | BindingFlags.Instance);
        //}
    }






}
