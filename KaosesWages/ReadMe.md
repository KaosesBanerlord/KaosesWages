# Kaoses Wages

## Description
a Kaoses mod for bannerlords. The mod allows for the modifying of troop wages
upgrade costs, recruitment costs, additional horse troop wages.

## ChangeLog
- 0.0.1 
  - Initial Creation of Modul codes.

- 0.0.2 
  - Updated to work with MODLIB ve1.3.

- 0.0.3 
  - Updated mod to have a config file With MODLib now being optional. 
  - The mod works with out MODLib being installed. 
  - Versions of modlib below 1.3 are no longer supported.

- 0.0.4 
  - Added Garrison and Caravan multipliers. 
  - Separated out all multipliers to be player and AI separately as requested.

- 0.0.5 
  - Change Troop horse and mercenary wage to be applied per troop. 
  - Horse multiplier changed to a set amount. 
  - All wages are done via troop tier instead of level. 
  - Implemented troop recruitment cost multipliers.
  - Config file renamed to Config.base.json so as to not overwrite existing file. 

- 0.0.6 
- 0.0.7 ??
- 0.0.8 ??
- 0.0.9 
  - Fixed horse wages to apply without tier troop wages.
  - Updated the troop upgrade cost code to 1.5.9
  - Upgraded Settings menu to Mod Configeration menu
  - Made Mod Configeration Menu Optional
  - Added setttings
    - bUseAIUpgradeCostMultiplier = false 
	- AIUpgradeCostMultiplier = 0
    - bUsePlayerBanditWagesModifiers = false
    - playerBanditWagesMultiplier = 0.5
    - tierBanditPlayerRecruitCostMultiplier = 0.5
    - bUseAIBanditWagesModifiers = false
    - tierAIBanditWagesMultiplier = 0.5
    - tierBanditAIRecruitCostMultiplier = 0.5
    - bUsePlayerCompanionWagesCostModifiers = false
    - tier0RecruitCostBase "10" /* Recruit Base Cost */
    - tier1RecruitCostBase "20" /* Recruit Base Cost */
    - tier2RecruitCostBase "50" /* Recruit Base Cost */
    - tier3RecruitCostBase "100" /* Recruit Base Cost */
    - tier4RecruitCostBase "200" /* Recruit Base Cost */
    - tier5RecruitCostBase "400" /* Recruit Base Cost */
    - tier6RecruitCostBase "600" /* Recruit Base Cost */
    - tier7RecruitCostBase "1000" /* Recruit Base Cost */
    - tierOtherRecruitCostBase "1500" /* Recruit Base Cost */
    - tier0WagesBase "1" /* Wage Base Cost */
    - tier1WagesBase "2" /* Wage Base Cost */
    - tier2WagesBase "3" /* Wage Base Cost */
    - tier3WagesBase "5" /* Wage Base Cost */
    - tier4WagesBase "8" /* Wage Base Cost */
    - tier5WagesBase "12" /* Wage Base Cost */
    - tier6WagesBase "17" /* Wage Base Cost */
    - tier7WagesBase "23" /* Wage Base Cost */
    - tierOtherWagesBase "33"  /* Wage Base Cost */
  - remove config.base.json file
  - Updated config.json
  - Fixed issue with garrison wages multiplier
  - Added tierCompanionRecruitCostMultiplier to change the cost of player recruiting companions
  - Added MCM Presets
    - Kaoses {Increase various costs}
    - Native {resets values to native values}
   


## Todo





Helpful information:
### Bannerlord Modding Documentation:	
https://docs.bannerlordmodding.com/
### Harmony Patching Documentation:		
https://harmony.pardeike.net/articles/patching.html
### TaleWorlds Modding Forums:			
https://forums.taleworlds.com/index.php?pages/modding/
### Mount and Blade Discord:			
https://discordapp.com/invite/mountandblade
### TW Forum - Modding Discord:			
https://discordapp.com/invite/ykFVJGQ




