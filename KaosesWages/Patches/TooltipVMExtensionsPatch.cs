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
using KaosesWagesCore.Objects;
using KaosesWagesCore.Objects.Loaders;
using TaleWorlds.Core.ViewModelCollection.Information;
using TaleWorlds.CampaignSystem.Extensions;
using TaleWorlds.CampaignSystem.Party;

namespace KaosesWages.Patches
{
    class TooltipVMExtensionsPatch
    {

        [HarmonyPatch(typeof(PropertyBasedTooltipVMExtensions), "UpdateTooltip",
            new Type[] {
                typeof(PropertyBasedTooltipVM),
                typeof(CharacterObject)
            })] //tooltipVM,  character
        public class UpdateTooltipPatch
        {
            static bool Prefix(PropertyBasedTooltipVM propertyBasedTooltipVM, CharacterObject character)//TooltipVM __instance,
            {
                //Logger.Lm("UpdateTooltipPatch Before WagesTypes creation");
                KaosesTroopWage troopWage = new KaosesTroopWage();
                WagesDataLaoder wageData = new WagesDataLaoder(ref troopWage);

                int wage = troopWage.GetTroopWage(character);
                //Logger.Lm("UpdateTooltipPatch __instance:");
                propertyBasedTooltipVM.Mode = 1;
                propertyBasedTooltipVM.AddProperty("", character.Name.ToString(), 0, TooltipProperty.TooltipPropertyFlags.Title);
                GameTexts.SetVariable("LEVEL", character.Level);
                propertyBasedTooltipVM.AddProperty("", GameTexts.FindText("str_level", null).ToString(), 0, TooltipProperty.TooltipPropertyFlags.None);
                if (character.UpgradeTargets != null)
                {
                    //GameTexts.SetVariable("XP_AMOUNT", character.UpgradeXpCost);
                    GameTexts.SetVariable("XP_AMOUNT", character.GetUpgradeXpCost(PartyBase.MainParty, 0));
                    propertyBasedTooltipVM.AddProperty("", GameTexts.FindText("str_required_xp_to_upgrade", null).ToString(), 0, TooltipProperty.TooltipPropertyFlags.None);
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
                    propertyBasedTooltipVM.AddProperty("", GameTexts.FindText("str_LEFT_colon_RIGHT_wSpaceAfterColon", null).ToString(), 0, TooltipProperty.TooltipPropertyFlags.None);
                }

                propertyBasedTooltipVM.AddProperty("", "", 0, TooltipProperty.TooltipPropertyFlags.None);
                propertyBasedTooltipVM.AddProperty("", GameTexts.FindText("str_skills", null).ToString(), 0, TooltipProperty.TooltipPropertyFlags.None);
                propertyBasedTooltipVM.AddProperty("", "", 0, TooltipProperty.TooltipPropertyFlags.RundownSeperator);


                //foreach (SkillObject skillObject in SkillObject.All)
                foreach (SkillObject skill in Skills.All)
                {
                    if (character.GetSkillValue(skill) > 0)
                    {
                        propertyBasedTooltipVM.AddProperty(skill.Name.ToString(), character.GetSkillValue(skill).ToString(), 0, TooltipProperty.TooltipPropertyFlags.None);
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
