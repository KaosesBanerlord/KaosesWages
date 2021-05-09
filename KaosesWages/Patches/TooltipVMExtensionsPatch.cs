using HarmonyLib;
using KaosesWages.Objects;
using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ViewModelCollection;
using TaleWorlds.Core;
using TaleWorlds.Core.ViewModelCollection;

namespace KaosesWages.Patches
{
    class TooltipVMExtensionsPatch
    {

        [HarmonyPatch(typeof(TooltipVMExtensions), "UpdateTooltip", 
            new Type[] { 
                typeof(TooltipVM), 
                typeof(CharacterObject) 
            })] //tooltipVM,  character
        public class UpdateTooltipPatch
        {
            static void Postfix(TooltipVM tooltipVM, CharacterObject character)//TooltipVM __instance,
            {
                //Logging.Lm("UpdateTooltipPatch Before WagesTypes creation");
                KaosesTroopWage troopWage = new KaosesTroopWage();
                WagesDataLaoder wageData = new WagesDataLaoder(ref troopWage);

                int wage = troopWage.GetTroopWage(character);
                //Logging.lm("UpdateTooltipPatch __instance:");
                if (character.TroopWage > 0)
                {
                    GameTexts.SetVariable("LEFT", GameTexts.FindText("str_wage", null));
                    GameTexts.SetVariable("STR1", wage);
                    GameTexts.SetVariable("STR2", "{=!}<img src=\"Icons\\Coin@2x\">");
                    GameTexts.SetVariable("RIGHT", GameTexts.FindText("str_STR1_space_STR2", null));
                    tooltipVM.AddProperty("", GameTexts.FindText("str_LEFT_colon_RIGHT_wSpaceAfterColon", null).ToString(), 0, TooltipProperty.TooltipPropertyFlags.None);
                }

            }
        }

        static bool Prepare()
        {
            return true;
        }
    }
}
