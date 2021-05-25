using HarmonyLib;
using KaosesWages.Objects;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ViewModelCollection;

// Token: 0x0600067C RID: 1660 RVA: 0x0001F0AC File Offset: 0x0001D2AC
//namespace TaleWorlds.CampaignSystem.ViewModelCollection
//{
    // Token: 0x02000028 RID: 40
//    public class PartyVM : ViewModel, IPartyScreenLogicHandler, PartyScreenPrisonHandler, IPartyScreenTroopHandler
//private void RefreshCurrentCharacterInformation()

namespace KaosesWages.Patches
{
    class PartyVMPatch
    {
        [HarmonyPatch(typeof(PartyVM), "RefreshCurrentCharacterInformation")]
        public class RefreshCurrentCharacterInformationPatch
        {
            static void Postfix(PartyVM __instance, PartyCharacterVM ____currentCharacter, string ____currentCharacterWageLbl)
            {
                //Logger.Lm("RefreshCurrentCharacterInformationPatch");
                KaosesTroopWage troopWage = new KaosesTroopWage();
                WagesDataLaoder wageData = new WagesDataLaoder(ref troopWage);

                int wage = troopWage.GetTroopWage(____currentCharacter.Character);
                bool flag = ____currentCharacter.Character == CharacterObject.PlayerCharacter;
                if (____currentCharacter.Type == PartyScreenLogic.TroopType.Member && !flag)
                {
                    //____currentCharacterWageLbl = ____currentCharacter.Character.TroopWage.ToString();
                    //____currentCharacterWageLbl = wage.ToString();
                    __instance.CurrentCharacterWageLbl = wage.ToString();
                    //Logger.Lm("RefreshCurrentCharacterInformationPatch flag:" + flag.ToString());
                    //Logger.Lm("RefreshCurrentCharacterInformationPatch Type: " + ____currentCharacter.Type.ToString());
                    //Logger.Lm("RefreshCurrentCharacterInformationPatch Wage: " + wage.ToString() + "  Old Wage: " + ____currentCharacter.Character.TroopWage.ToString());
                }
                //Logger.Lm("RefreshCurrentCharacterInformationPatch __instance:" + __instance.GetType().ToString());
            }
        }

        static bool Prepare()
        {
            return true;
        }
    }
}
