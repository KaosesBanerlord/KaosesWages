using HarmonyLib;
using KaosesWages.Objects;
using KaosesWages.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ViewModelCollection;

namespace KaosesWages.Patches
{
    class PartyVMPatch
    {
        [HarmonyPatch(typeof(PartyVM), "RefreshCurrentCharacterInformation")]
        public class RefreshCurrentCharacterInformationPatch
        {
            static void Postfix(PartyVM __instance, PartyCharacterVM ____currentCharacter, string ____currentCharacterWageLbl)
            {
				WagesTypes wageTypes = new WagesTypes();
				KaosesTroopWage troopWage = new KaosesTroopWage();
				troopWage.SetWagesMultipliers(wageTypes);
				int wage = troopWage.getTroopWage(____currentCharacter.Character);
				bool flag = ____currentCharacter.Character == CharacterObject.PlayerCharacter;
				if (____currentCharacter.Type == PartyScreenLogic.TroopType.Member && !flag)
				{
					//____currentCharacterWageLbl = ____currentCharacter.Character.TroopWage.ToString();
					//____currentCharacterWageLbl = wage.ToString();
					__instance.CurrentCharacterWageLbl = wage.ToString();
					//Logging.lm("RefreshCurrentCharacterInformationPatch flag:" + flag.ToString());
					//Logging.lm("RefreshCurrentCharacterInformationPatch Type: " + ____currentCharacter.Type.ToString());
					//Logging.lm("RefreshCurrentCharacterInformationPatch Wage: " + wage.ToString() + "  Old Wage: " + ____currentCharacter.Character.TroopWage.ToString());
				}
				//Logging.lm("RefreshCurrentCharacterInformationPatch __instance:" + __instance.GetType().ToString());
			}
		}

        static bool Prepare()
        {
            return true;
        }
    }
}
