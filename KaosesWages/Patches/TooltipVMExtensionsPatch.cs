using HarmonyLib;
using KaosesWages.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using Helpers;
using TaleWorlds.Core;
using TaleWorlds.Core.ViewModelCollection;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.CampaignSystem.ViewModelCollection;
using TaleWorlds.CampaignSystem;

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
            static bool Prefix(TooltipVM tooltipVM, CharacterObject character)//TooltipVM __instance,
            {
                //Logger.Lm("UpdateTooltipPatch Before WagesTypes creation");
                KaosesTroopWage troopWage = new KaosesTroopWage();
                WagesDataLaoder wageData = new WagesDataLaoder(ref troopWage);

                int wage = troopWage.GetTroopWage(character);
                //Logger.Lm("UpdateTooltipPatch __instance:");
                tooltipVM.Mode = 1;
                tooltipVM.AddProperty("", character.Name.ToString(), 0, TooltipProperty.TooltipPropertyFlags.Title);
                GameTexts.SetVariable("LEVEL", character.Level);
                tooltipVM.AddProperty("", GameTexts.FindText("str_level", null).ToString(), 0, TooltipProperty.TooltipPropertyFlags.None);
                if (character.UpgradeTargets != null)
                {
                    GameTexts.SetVariable("XP_AMOUNT", character.UpgradeXpCost);
                    tooltipVM.AddProperty("", GameTexts.FindText("str_required_xp_to_upgrade", null).ToString(), 0, TooltipProperty.TooltipPropertyFlags.None);
                }
/*
                if (character.TroopWage > 0)
                {
                    GameTexts.SetVariable("LEFT", GameTexts.FindText("str_wage", null));
                    GameTexts.SetVariable("STR1", character.TroopWage);
                    GameTexts.SetVariable("STR2", "{=!}<img src=\"Icons\\Coin@2x\" extend=\"8\">");
                    GameTexts.SetVariable("RIGHT", GameTexts.FindText("str_STR1_space_STR2", null));
                    tooltipVM.AddProperty("", GameTexts.FindText("str_LEFT_colon_RIGHT_wSpaceAfterColon", null).ToString(), 0, TooltipProperty.TooltipPropertyFlags.None);
                }*/
                if (character.TroopWage > 0)
                {
                    GameTexts.SetVariable("LEFT", GameTexts.FindText("str_wage", null));
                    GameTexts.SetVariable("STR1", wage);
                    GameTexts.SetVariable("STR2", "{=!}<img src=\"Icons\\Coin@2x\">");
                    GameTexts.SetVariable("RIGHT", GameTexts.FindText("str_STR1_space_STR2", null));
                    tooltipVM.AddProperty("", GameTexts.FindText("str_LEFT_colon_RIGHT_wSpaceAfterColon", null).ToString(), 0, TooltipProperty.TooltipPropertyFlags.None);
                }

                tooltipVM.AddProperty("", "", 0, TooltipProperty.TooltipPropertyFlags.None);
                tooltipVM.AddProperty("", GameTexts.FindText("str_skills", null).ToString(), 0, TooltipProperty.TooltipPropertyFlags.None);
                tooltipVM.AddProperty("", "", 0, TooltipProperty.TooltipPropertyFlags.RundownSeperator);


                foreach (SkillObject skillObject in SkillObject.All)
                {
                    if (character.GetSkillValue(skillObject) > 0)
                    {
                        tooltipVM.AddProperty(skillObject.Name.ToString(), character.GetSkillValue(skillObject).ToString(), 0, TooltipProperty.TooltipPropertyFlags.None);
                    }
                }
                return false;
            }

        }


        static bool Prepare()
        {
            return true;
        }
    }
}
