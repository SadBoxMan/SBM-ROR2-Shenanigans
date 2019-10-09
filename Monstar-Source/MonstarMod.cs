using BepInEx;
using RoR2;
using UnityEngine;
using RoR2.Skills;
using RoR2.UI;
using MonoMod;
using Mono;
using MonoMod.Utils;
using System.Collections.Generic;
using System;
using BepInEx.Configuration;
using System.Reflection;
using MonoMod.Cil;
using KinematicCharacterController;
using System.Linq;
using EntityStates;
using R2API;

namespace MonstarMod
{

    [BepInDependency("com.bepis.r2api")]
    [BepInPlugin("SadBoxMan.Monstar", "Monstar Mode", "1.0")]

    public class Monstar : BaseUnityPlugin
    {







        public void Start()
        {

            AssetBundle _MonstarIconBundle;
            //GameObject _prefab;

            //This is declaring a custom icon from an imported asset bundle
            _MonstarIconBundle = AssetBundle.LoadFromFile(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/assets/monstaricons");
            //_prefab = _MonstarIconBundle.LoadAsset<GameObject>("Assets/Import/belt/belt.prefab");
            Sprite LemurianBite_Icon = _MonstarIconBundle.LoadAsset<Sprite>("Assets/Import/icons/RoR2_lumerian_bite_icon.png");
            Sprite LemurianFireball_Icon = _MonstarIconBundle.LoadAsset<Sprite>("Assets/Import/icons/ror2_lumerian_fire_icon.jpg");
            Sprite GunnerDrone_Icon = _MonstarIconBundle.LoadAsset<Sprite>("Assets/Import/icons/RoR2_Drone_Standard_Fire.png");
            Sprite WalkerTurret_Icon = _MonstarIconBundle.LoadAsset<Sprite>("Assets/Import/icons/Walker.png");
            Sprite StrikeDrone_Icon = _MonstarIconBundle.LoadAsset<Sprite>("Assets/Import/icons/StrikeDrone_MG.png");


            //Toolbot Icons and Box setup
            GameObject ToolBotBodyfab = BodyCatalog.FindBodyPrefab("ToolbotBody");
            CharacterBody toolbox = ToolBotBodyfab.GetComponent<CharacterBody>();
            GameObject box = toolbox.preferredPodPrefab;
            SkillLocator ToolBot_SL = ToolBotBodyfab.GetComponent<SkillLocator>();
            GenericSkill ToolBot_primary = ToolBot_SL.primary;
            GenericSkill ToolBot_secondary = ToolBot_SL.secondary;
            GenericSkill ToolBot_utility = ToolBot_SL.utility;
            GenericSkill ToolBot_special = ToolBot_SL.special;
            SkillFamily ToolBot_pFam = ToolBot_primary.skillFamily;
            SkillFamily ToolBot_sFam = ToolBot_secondary.skillFamily;
            SkillFamily ToolBot_uFam = ToolBot_utility.skillFamily;
            SkillFamily ToolBot_spFam = ToolBot_special.skillFamily;
            Sprite ToolBotP_Icon = ToolBot_pFam.variants[ToolBot_pFam.defaultVariantIndex].skillDef.icon;
            Sprite ToolBotS_Icon = ToolBot_sFam.variants[ToolBot_sFam.defaultVariantIndex].skillDef.icon;
            Sprite ToolBotU_Icon = ToolBot_uFam.variants[ToolBot_uFam.defaultVariantIndex].skillDef.icon;
            Sprite ToolBotSP_Icon = ToolBot_spFam.variants[ToolBot_spFam.defaultVariantIndex].skillDef.icon;


            //Commando icons and Survivor Pod setup
            GameObject commandobodyfab = BodyCatalog.FindBodyPrefab("CommandoBody");
            SkillLocator commando_SL = commandobodyfab.GetComponent<SkillLocator>();
            GenericSkill commando_primary = commando_SL.primary;
            GenericSkill commando_secondary = commando_SL.secondary;
            GenericSkill commando_utility = commando_SL.utility;
            GenericSkill commando_special = commando_SL.special;
            SkillFamily commando_pFam = commando_primary.skillFamily;
            SkillFamily commando_sFam = commando_secondary.skillFamily;
            SkillFamily commando_uFam = commando_utility.skillFamily;
            SkillFamily commando_spFam = commando_special.skillFamily;
            Sprite commandoP_Icon = commando_pFam.variants[commando_pFam.defaultVariantIndex].skillDef.icon;
            Sprite commandoS_Icon = commando_sFam.variants[commando_sFam.defaultVariantIndex].skillDef.icon;
            Sprite commandoU_Icon = commando_uFam.variants[commando_uFam.defaultVariantIndex].skillDef.icon;
            Sprite commandoSP_Icon = commando_spFam.variants[commando_spFam.defaultVariantIndex].skillDef.icon;
            CharacterBody surv_pod = commandobodyfab.GetComponent<CharacterBody>();
            GameObject pod = surv_pod.preferredPodPrefab;

            //Engineer icon setup
            GameObject Engibodyfab = BodyCatalog.FindBodyPrefab("EngiBody");
            SkillLocator Engi_SL = Engibodyfab.GetComponent<SkillLocator>();
            GenericSkill Engi_primary = Engi_SL.primary;
            GenericSkill Engi_secondary = Engi_SL.secondary;
            GenericSkill Engi_utility = Engi_SL.utility;
            GenericSkill Engi_special = Engi_SL.special;
            SkillFamily Engi_pFam = Engi_primary.skillFamily;
            SkillFamily Engi_sFam = Engi_secondary.skillFamily;
            SkillFamily Engi_uFam = Engi_utility.skillFamily;
            SkillFamily Engi_spFam = Engi_special.skillFamily;
            Sprite EngiP_Icon = Engi_pFam.variants[Engi_pFam.defaultVariantIndex].skillDef.icon;
            Sprite EngiS_Icon = Engi_sFam.variants[Engi_sFam.defaultVariantIndex].skillDef.icon;
            Sprite EngiU_Icon = Engi_uFam.variants[Engi_uFam.defaultVariantIndex].skillDef.icon;
            Sprite EngiSP_Icon = Engi_spFam.variants[Engi_spFam.defaultVariantIndex].skillDef.icon;


            //Mage icon setup
            GameObject magebodyfab = BodyCatalog.FindBodyPrefab("MageBody");
            SkillLocator mage_SL = magebodyfab.GetComponent<SkillLocator>();
            GenericSkill mage_primary = mage_SL.primary;
            GenericSkill mage_secondary = mage_SL.secondary;
            GenericSkill mage_utility = mage_SL.utility;
            GenericSkill mage_special = mage_SL.special;
            SkillFamily mage_pFam = mage_primary.skillFamily;
            SkillFamily mage_sFam = mage_secondary.skillFamily;
            SkillFamily mage_uFam = mage_utility.skillFamily;
            SkillFamily mage_spFam = mage_special.skillFamily;
            Sprite mageP_Icon = mage_pFam.variants[mage_pFam.defaultVariantIndex].skillDef.icon;
            Sprite mageS_Icon = mage_sFam.variants[mage_sFam.defaultVariantIndex].skillDef.icon;
            Sprite mageU_Icon = mage_uFam.variants[mage_uFam.defaultVariantIndex].skillDef.icon;
            Sprite mageSP_Icon = mage_spFam.variants[mage_spFam.defaultVariantIndex].skillDef.icon;

            //Loader icon setup
            GameObject loaderbodyfab = BodyCatalog.FindBodyPrefab("LoaderBody");
            SkillLocator loader_SL = loaderbodyfab.GetComponent<SkillLocator>();
            GenericSkill loader_primary = loader_SL.primary;
            GenericSkill loader_secondary = loader_SL.secondary;
            GenericSkill loader_utility = loader_SL.utility;
            GenericSkill loader_special = loader_SL.special;
            SkillFamily loader_pFam = loader_primary.skillFamily;
            SkillFamily loader_sFam = loader_secondary.skillFamily;
            SkillFamily loader_uFam = loader_utility.skillFamily;
            SkillFamily loader_spFam = loader_special.skillFamily;
            Sprite loaderP_Icon = loader_pFam.variants[loader_pFam.defaultVariantIndex].skillDef.icon;
            Sprite loaderS_Icon = loader_sFam.variants[loader_sFam.defaultVariantIndex].skillDef.icon;
            Sprite loaderU_Icon = loader_uFam.variants[loader_uFam.defaultVariantIndex].skillDef.icon;
            Sprite loaderSP_Icon = loader_spFam.variants[loader_spFam.defaultVariantIndex].skillDef.icon;

            //Mercenary Icon Setup
            GameObject Mercbodyfab = BodyCatalog.FindBodyPrefab("MercBody");
            SkillLocator Merc_SL = Mercbodyfab.GetComponent<SkillLocator>();
            GenericSkill Merc_primary = Merc_SL.primary;
            GenericSkill Merc_secondary = Merc_SL.secondary;
            GenericSkill Merc_utility = Merc_SL.utility;
            GenericSkill Merc_special = Merc_SL.special;
            SkillFamily Merc_pFam = Merc_primary.skillFamily;
            SkillFamily Merc_sFam = Merc_secondary.skillFamily;
            SkillFamily Merc_uFam = Merc_utility.skillFamily;
            SkillFamily Merc_spFam = Merc_special.skillFamily;
            Sprite MercP_Icon = Merc_pFam.variants[Merc_pFam.defaultVariantIndex].skillDef.icon;
            Sprite MercS_Icon = Merc_sFam.variants[Merc_sFam.defaultVariantIndex].skillDef.icon;
            Sprite MercU_Icon = Merc_uFam.variants[Merc_uFam.defaultVariantIndex].skillDef.icon;
            Sprite MercSP_Icon = Merc_spFam.variants[Merc_spFam.defaultVariantIndex].skillDef.icon;

            //Huntress Icon Setup
            GameObject Huntressbodyfab = BodyCatalog.FindBodyPrefab("HuntressBody");
            SkillLocator Huntress_SL = Huntressbodyfab.GetComponent<SkillLocator>();
            GenericSkill Huntress_primary = Huntress_SL.primary;
            GenericSkill Huntress_secondary = Huntress_SL.secondary;
            GenericSkill Huntress_utility = Huntress_SL.utility;
            GenericSkill Huntress_special = Huntress_SL.special;
            SkillFamily Huntress_pFam = Huntress_primary.skillFamily;
            SkillFamily Huntress_sFam = Huntress_secondary.skillFamily;
            SkillFamily Huntress_uFam = Huntress_utility.skillFamily;
            SkillFamily Huntress_spFam = Huntress_special.skillFamily;
            Sprite HuntressP_Icon = Huntress_pFam.variants[Huntress_pFam.defaultVariantIndex].skillDef.icon;
            Sprite HuntressS_Icon = Huntress_sFam.variants[Huntress_sFam.defaultVariantIndex].skillDef.icon;
            Sprite HuntressU_Icon = Huntress_uFam.variants[Huntress_uFam.defaultVariantIndex].skillDef.icon;
            Sprite HuntressSP_Icon = Huntress_spFam.variants[Huntress_spFam.defaultVariantIndex].skillDef.icon;

            //REX Icon Setup
            GameObject Treebotbodyfab = BodyCatalog.FindBodyPrefab("TreebotBody");
            SkillLocator Treebot_SL = Treebotbodyfab.GetComponent<SkillLocator>();
            GenericSkill Treebot_primary = Treebot_SL.primary;
            GenericSkill Treebot_secondary = Treebot_SL.secondary;
            GenericSkill Treebot_utility = Treebot_SL.utility;
            GenericSkill Treebot_special = Treebot_SL.special;
            SkillFamily Treebot_pFam = Treebot_primary.skillFamily;
            SkillFamily Treebot_sFam = Treebot_secondary.skillFamily;
            SkillFamily Treebot_uFam = Treebot_utility.skillFamily;
            SkillFamily Treebot_spFam = Treebot_special.skillFamily;
            Sprite TreebotP_Icon = Treebot_pFam.variants[Treebot_pFam.defaultVariantIndex].skillDef.icon;
            Sprite TreebotS_Icon = Treebot_sFam.variants[Treebot_sFam.defaultVariantIndex].skillDef.icon;
            Sprite TreebotU_Icon = Treebot_uFam.variants[Treebot_uFam.defaultVariantIndex].skillDef.icon;
            Sprite TreebotSP_Icon = Treebot_spFam.variants[Treebot_spFam.defaultVariantIndex].skillDef.icon;






            //Lemurian Skills
            GameObject lemur_body = BodyCatalog.FindBodyPrefab("LemurianBody");
            SkillLocator lemur_SL = lemur_body.GetComponent<SkillLocator>();
            CharacterBody lemur_pod = lemur_body.GetComponent<CharacterBody>();
            lemur_pod.preferredPodPrefab = box;
            GenericSkill lemur_fireball = lemur_SL.primary;
            GenericSkill lemur_bite = lemur_SL.secondary;
            SkillFamily lemur_fireball_data = lemur_fireball.skillFamily;
            SkillFamily lemur_bite_data = lemur_bite.skillFamily;
            SkillDef lemurianFireball = lemur_fireball_data.variants[lemur_fireball_data.defaultVariantIndex].skillDef;
            SkillDef lemurianBite = lemur_bite_data.variants[lemur_bite_data.defaultVariantIndex].skillDef;
            lemurianFireball.skillNameToken = "Distinctive Fireball";
            lemurianFireball.skillDescriptionToken = "Spit a flaming glob of bile at enemies for <style=cIsDamage>100% damage.</style>";
            lemurianBite.skillNameToken = "Instinctive Bite";
            lemurianBite.skillDescriptionToken = "Bite Enemies for <style=cIsDamage>200% damage.</style>";
            lemurianFireball.icon = LemurianFireball_Icon;
            lemurianBite.icon = LemurianBite_Icon;


            //Lemur Fire Variant 1
            SkillDef lemurianFireball2 = ScriptableObject.CreateInstance<SkillDef>();
            lemurianFireball2.activationState = new SerializableEntityStateType("EntityStates.LemurianBruiserMonster.ChargeMegaFireball");
            lemurianFireball2.activationStateMachineName = "Weapon";
            lemurianFireball2.icon = mageP_Icon;
            lemurianFireball2.skillName = "LemurFireVolley";
            lemurianFireball2.skillNameToken = "Elder's Authority";
            lemurianFireball2.skillDescriptionToken = "Fire a volley of 5 fireballs that deal <style=cIsDamage>5x200% damage.</style>";
            lemurianFireball2.interruptPriority = InterruptPriority.Skill;
            lemurianFireball2.baseRechargeInterval = 4f;
            lemurianFireball2.baseMaxStock = 1;
            lemurianFireball2.rechargeStock = 1;
            lemurianFireball2.isBullets = false;
            lemurianFireball2.shootDelay = 0.3f;
            lemurianFireball2.beginSkillCooldownOnSkillEnd = false;
            lemurianFireball2.requiredStock = 1;
            lemurianFireball2.stockToConsume = 1;
            lemurianFireball2.isCombatSkill = true;
            lemurianFireball2.noSprint = true;
            lemurianFireball2.canceledFromSprinting = false;
            lemurianFireball2.mustKeyPress = false;
            lemurianFireball2.fullRestockOnAssign = true;
            lemurianFireball2.skillIndex = 90;

            SkillFamily.Variant lemur_P2variant = new SkillFamily.Variant();
            lemur_P2variant.skillDef = lemurianFireball2;
            lemur_P2variant.unlockableName = "LEMUR_FB2";

            int FB2prevLength = lemur_fireball_data.variants.Length;
            System.Array.Resize<SkillFamily.Variant>(ref lemur_fireball_data.variants, FB2prevLength + 1);
            lemur_fireball_data.variants[FB2prevLength] = lemur_P2variant;


            //Lemur Fire Variant 2
            SkillDef lemurianFireball3 = ScriptableObject.CreateInstance<SkillDef>();
            lemurianFireball3.activationState = new SerializableEntityStateType("EntityStates.LemurianBruiserMonster.Flamebreath");
            lemurianFireball3.activationStateMachineName = "Weapon";
            lemurianFireball3.icon = mageP_Icon;
            lemurianFireball3.skillName = "LemurFlamethrower";
            lemurianFireball3.skillNameToken = "Elder's Whisper";
            lemurianFireball3.skillDescriptionToken = "Short-range burst of flame that <style=cIsHealth>burns enemies</style> for <style=cIsDamage>50% damage per tick</style>.";
            lemurianFireball3.interruptPriority = InterruptPriority.Skill;
            lemurianFireball3.baseRechargeInterval = 1f;
            lemurianFireball3.baseMaxStock = 1;
            lemurianFireball3.rechargeStock = 1;
            lemurianFireball3.isBullets = false;
            lemurianFireball3.shootDelay = 0.3f;
            lemurianFireball3.beginSkillCooldownOnSkillEnd = true;
            lemurianFireball3.requiredStock = 1;
            lemurianFireball3.stockToConsume = 1;
            lemurianFireball3.isCombatSkill = true;
            lemurianFireball3.noSprint = true;
            lemurianFireball3.canceledFromSprinting = false;
            lemurianFireball3.mustKeyPress = false;
            lemurianFireball3.fullRestockOnAssign = true;
            lemurianFireball3.skillIndex = 91;

            SkillFamily.Variant lemur_P3variant = new SkillFamily.Variant();
            lemur_P3variant.skillDef = lemurianFireball3;
            lemur_P3variant.unlockableName = "LEMUR_B2";

            int FB3prevLength = lemur_bite_data.variants.Length;
            System.Array.Resize<SkillFamily.Variant>(ref lemur_bite_data.variants, FB3prevLength + 1);
            lemur_bite_data.variants[FB3prevLength] = lemur_P3variant;


            //Lemur Melee Variant
            SkillDef lemur_melee2 = ScriptableObject.CreateInstance<SkillDef>();
            lemur_melee2.activationState = new SerializableEntityStateType("EntityStates.Paladin.DashSlam");
            lemur_melee2.activationStateMachineName = "Weapon";
            lemur_melee2.icon = mageP_Icon;
            lemur_melee2.skillName = "LemurTackle";
            lemur_melee2.skillNameToken = "Soldier Tackle";
            lemur_melee2.skillDescriptionToken = "A charging tackle that <style=cIsDamage>stuns foes, knocking them back</style> and dealing <style=cIsDamage>250% damage</style>.";
            lemur_melee2.interruptPriority = InterruptPriority.Skill;
            lemur_melee2.baseRechargeInterval = 7f;
            lemur_melee2.baseMaxStock = 1;
            lemur_melee2.rechargeStock = 1;
            lemur_melee2.isBullets = false;
            lemur_melee2.shootDelay = 0.3f;
            lemur_melee2.beginSkillCooldownOnSkillEnd = false;
            lemur_melee2.requiredStock = 1;
            lemur_melee2.stockToConsume = 1;
            lemur_melee2.isCombatSkill = true;
            lemur_melee2.noSprint = false;
            lemur_melee2.canceledFromSprinting = false;
            lemur_melee2.mustKeyPress = false;
            lemur_melee2.fullRestockOnAssign = true;
            lemur_melee2.skillIndex = 119;

            SkillFamily.Variant lemur_Svariant = new SkillFamily.Variant();
            lemur_Svariant.skillDef = lemur_melee2;
            lemur_Svariant.unlockableName = "LEMUR_B2";

            int LB2prevLength = lemur_bite_data.variants.Length;
            System.Array.Resize<SkillFamily.Variant>(ref lemur_bite_data.variants, LB2prevLength + 1);
            lemur_bite_data.variants[LB2prevLength] = lemur_Svariant;



            //Imp Skills
            GameObject Impbodyfab = BodyCatalog.FindBodyPrefab("ImpBody");
            SkillLocator Imp_SL = Impbodyfab.GetComponent<SkillLocator>();
            GenericSkill Imp_primary = Imp_SL.primary;
            GenericSkill Imp_utility = Imp_SL.utility;
            SkillFamily Imp_pFam = Imp_primary.skillFamily;
            SkillFamily Imp_uFam = Imp_utility.skillFamily;
            SkillDef Imp_slot1 = Imp_pFam.variants[Imp_pFam.defaultVariantIndex].skillDef;
            SkillDef Imp_slot3 = Imp_uFam.variants[Imp_uFam.defaultVariantIndex].skillDef;
            CharacterBody Imp_pod = Impbodyfab.GetComponent<CharacterBody>();
            //Imp_pod.preferredPodPrefab = box;
            Imp_pod.crosshairPrefab = Resources.Load<GameObject>("prefabs/crosshair/NULL");
            Imp_slot1.skillNameToken = "Providence's Embrace";
            Imp_slot1.skillDescriptionToken = "Slash at your foes with each hand, dealing <style=cIsDamage>2x150% damage</style>. The deep lacerations cause creatures to <style=cIsHealth>bleed</style>.";
            Imp_slot3.skillNameToken = "Dark Warp";
            Imp_slot3.skillDescriptionToken = "Teleport out of danger. Holds 3 charges.";
            Imp_slot1.icon = HuntressP_Icon;
            Imp_slot3.icon = HuntressU_Icon;

            //Imp Extras
            Imp_pod.bodyFlags = CharacterBody.BodyFlags.IgnoreFallDamage;
            Imp_pod.bodyFlags = CharacterBody.BodyFlags.SprintAnyDirection;
            



            //Imp Utility 1
            SkillDef Imp_Float = ScriptableObject.CreateInstance<SkillDef>();
            Imp_Float.activationState = new SerializableEntityStateType("EntityStates.Commando.CommandoWeapon.CastSmokescreenNoDelay");
            Imp_Float.activationStateMachineName = "Weapon";
            Imp_Float.icon = mageP_Icon;
            Imp_Float.skillName = "LAST_SURPRISE";
            Imp_Float.skillNameToken = "Shadow Sneak";
            Imp_Float.skillDescriptionToken = "Go invisible, stun enemies when you come out of it.";
            Imp_Float.interruptPriority = InterruptPriority.PrioritySkill;
            Imp_Float.baseRechargeInterval = 3f;
            Imp_Float.baseMaxStock = 1;
            Imp_Float.rechargeStock = 1;
            Imp_Float.isBullets = false;
            Imp_Float.shootDelay = 0.3f;
            Imp_Float.beginSkillCooldownOnSkillEnd = true;
            Imp_Float.requiredStock = 1;
            Imp_Float.stockToConsume = 1;
            Imp_Float.isCombatSkill = true;
            Imp_Float.noSprint = false;
            Imp_Float.canceledFromSprinting = false;
            Imp_Float.mustKeyPress = false;
            Imp_Float.fullRestockOnAssign = true;
            Imp_Float.skillIndex = 9;
            

            SkillFamily.Variant imp_U1variant = new SkillFamily.Variant();
            imp_U1variant.skillDef = Imp_Float;
            imp_U1variant.unlockableName = "IMP_P1";

            int I2prevLength = Imp_uFam.variants.Length;
            System.Array.Resize<SkillFamily.Variant>(ref Imp_uFam.variants, I2prevLength + 1);
            Imp_uFam.variants[I2prevLength] = imp_U1variant;
            

            //Imp Utility 2
            SkillDef Imp_Escape = ScriptableObject.CreateInstance<SkillDef>();
            Imp_Escape.activationState = new SerializableEntityStateType("EntityStates.ImpBossMonster.BlinkState");
            Imp_Escape.activationStateMachineName = "Body";
            Imp_Escape.icon = mageP_Icon;
            Imp_Escape.skillName = "BEAM_ME_UP";
            Imp_Escape.skillNameToken = "Providence's Rapture";
            Imp_Escape.skillDescriptionToken = "Brings you far away from danger...";
            Imp_Escape.interruptPriority = InterruptPriority.PrioritySkill;
            Imp_Escape.baseRechargeInterval = 30f;
            Imp_Escape.baseMaxStock = 1;
            Imp_Escape.rechargeStock = 1;
            Imp_Escape.isBullets = true;
            Imp_Escape.shootDelay = 1f;
            Imp_Escape.beginSkillCooldownOnSkillEnd = true;
            Imp_Escape.requiredStock = 1;
            Imp_Escape.stockToConsume = 1;
            Imp_Escape.isCombatSkill = true;
            Imp_Escape.noSprint = true;
            Imp_Escape.canceledFromSprinting = false;
            Imp_Escape.mustKeyPress = false;
            Imp_Escape.fullRestockOnAssign = true;
            Imp_Escape.skillIndex = 84;

            SkillFamily.Variant imp_U2variant = new SkillFamily.Variant();
            imp_U2variant.skillDef = Imp_Escape;
            imp_U2variant.unlockableName = "IMP_P1";

            int I3prevLength = Imp_uFam.variants.Length;
            System.Array.Resize<SkillFamily.Variant>(ref Imp_uFam.variants, I3prevLength + 1);
            Imp_uFam.variants[I3prevLength] = imp_U2variant;

            

            //Clay Templar Skills
            GameObject ClayBruiserbodyfab = BodyCatalog.FindBodyPrefab("ClayBruiserBody");
            SkillLocator ClayBruiser_SL = ClayBruiserbodyfab.GetComponent<SkillLocator>();
            GenericSkill ClayBruiser_primary = ClayBruiser_SL.primary;
            GenericSkill ClayBruiser_secondary = ClayBruiser_SL.secondary;
            SkillFamily ClayBruiser_pFam = ClayBruiser_primary.skillFamily;
            SkillFamily ClayBruiser_sFam = ClayBruiser_secondary.skillFamily;
            SkillDef ClayBruiser_slot1 = ClayBruiser_pFam.variants[ClayBruiser_pFam.defaultVariantIndex].skillDef;
            SkillDef ClayBruiser_slot2 = ClayBruiser_sFam.variants[ClayBruiser_sFam.defaultVariantIndex].skillDef;
            //CharacterBody clayB_pod = ClayBruiserbodyfab.GetComponent<CharacterBody>();
            //clayB_pod.preferredPodPrefab = box;
            ClayBruiser_slot1.skillNameToken = "Sandstorm";
            ClayBruiser_slot1.skillDescriptionToken = "Continously shoot Tar at enemies for <style=cIsDamage>30% damage.</style>";
            ClayBruiser_slot2.skillNameToken = "Roar of Earth";
            ClayBruiser_slot2.skillDescriptionToken = "Spray a burst of Tar that covers enemies, slowing down their movements and knocking them back a fair distance.";
            ClayBruiser_slot2.icon = TreebotU_Icon;


            //Jar Toss
            SkillDef Clay_gun2 = ScriptableObject.CreateInstance<SkillDef>();
            Clay_gun2.activationState = new SerializableEntityStateType("EntityStates.ClayBoss.ClayBossWeapon.ChargeBombardment");
            Clay_gun2.activationStateMachineName = "Weapon";
            Clay_gun2.icon = mageP_Icon;
            Clay_gun2.skillName = "Pot_Toss";
            Clay_gun2.skillNameToken = "Terrastorm";
            Clay_gun2.skillDescriptionToken = "Launch a barrage of Jars filled with Tar that deal <style=cIsDamage>(5-11)x100% damage</style> each. Fires <style=cIsDamage>5</style> jars when pressed once.";
            Clay_gun2.interruptPriority = InterruptPriority.Skill;
            Clay_gun2.baseRechargeInterval = 3f;
            Clay_gun2.baseMaxStock = 1;
            Clay_gun2.rechargeStock = 1;
            Clay_gun2.isBullets = false;
            Clay_gun2.shootDelay = 0.3f;
            Clay_gun2.beginSkillCooldownOnSkillEnd = true;
            Clay_gun2.requiredStock = 1;
            Clay_gun2.stockToConsume = 1;
            Clay_gun2.isCombatSkill = true;
            Clay_gun2.noSprint = false;
            Clay_gun2.canceledFromSprinting = false;
            Clay_gun2.mustKeyPress = false;
            Clay_gun2.fullRestockOnAssign = true;
            Clay_gun2.skillIndex = 30;

            SkillFamily.Variant clay_P2variant = new SkillFamily.Variant();
            clay_P2variant.skillDef = Clay_gun2;
            clay_P2variant.unlockableName = "CLAY_G2";

            int CP2prevLength = ClayBruiser_pFam.variants.Length;
            System.Array.Resize<SkillFamily.Variant>(ref ClayBruiser_pFam.variants, CP2prevLength + 1);
            ClayBruiser_pFam.variants[CP2prevLength] = clay_P2variant;


            //Gun Bash
            SkillDef Clay_melee2 = ScriptableObject.CreateInstance<SkillDef>();
            Clay_melee2.activationState = new SerializableEntityStateType("EntityStates.Paladin.DashSlam");
            Clay_melee2.activationStateMachineName = "Weapon";
            Clay_melee2.icon = mageP_Icon;
            Clay_melee2.skillName = "ClayTackle";
            Clay_melee2.skillNameToken = "Soldier Tackle";
            Clay_melee2.skillDescriptionToken = "A charging tackle that <style=cIsDamage>stuns foes, knocking them back</style> and dealing <style=cIsDamage>250% damage</style>.";
            Clay_melee2.interruptPriority = InterruptPriority.Skill;
            Clay_melee2.baseRechargeInterval = 5f;
            Clay_melee2.baseMaxStock = 1;
            Clay_melee2.rechargeStock = 1;
            Clay_melee2.isBullets = false;
            Clay_melee2.shootDelay = 0.3f;
            Clay_melee2.beginSkillCooldownOnSkillEnd = false;
            Clay_melee2.requiredStock = 1;
            Clay_melee2.stockToConsume = 1;
            Clay_melee2.isCombatSkill = true;
            Clay_melee2.noSprint = false;
            Clay_melee2.canceledFromSprinting = false;
            Clay_melee2.mustKeyPress = false;
            Clay_melee2.fullRestockOnAssign = true;
            Clay_melee2.skillIndex = 119;

            SkillFamily.Variant clay_Svariant = new SkillFamily.Variant();
            clay_Svariant.skillDef = Clay_melee2;
            clay_Svariant.unlockableName = "CLAY_B2";

            int C2prevLength = ClayBruiser_sFam.variants.Length;
            System.Array.Resize<SkillFamily.Variant>(ref ClayBruiser_sFam.variants, C2prevLength + 1);
            ClayBruiser_sFam.variants[C2prevLength] = clay_Svariant;


            //Tar Bowling
            SkillDef Clay_melee3 = ScriptableObject.CreateInstance<SkillDef>();
            Clay_melee3.activationState = new SerializableEntityStateType("EntityStates.ClayBoss.FireTarball");
            Clay_melee3.activationStateMachineName = "Weapon";
            Clay_melee3.icon = mageP_Icon;
            Clay_melee3.skillName = "Tar_Bowl";
            Clay_melee3.skillNameToken = "Clay Bowl";
            Clay_melee3.skillDescriptionToken = "Fire off 3 large balls of Tar along the terrain that home in on targets for <style=cIsDamage>100% damage</style> each.";
            Clay_melee3.interruptPriority = InterruptPriority.Skill;
            Clay_melee3.baseRechargeInterval = 5f;
            Clay_melee3.baseMaxStock = 1;
            Clay_melee3.rechargeStock = 1;
            Clay_melee3.isBullets = false;
            Clay_melee3.shootDelay = 0.3f;
            Clay_melee3.beginSkillCooldownOnSkillEnd = false;
            Clay_melee3.requiredStock = 1;
            Clay_melee3.stockToConsume = 1;
            Clay_melee3.isCombatSkill = true;
            Clay_melee3.noSprint = false;
            Clay_melee3.canceledFromSprinting = false;
            Clay_melee3.mustKeyPress = false;
            Clay_melee3.fullRestockOnAssign = true;
            Clay_melee3.skillIndex = 32;

            SkillFamily.Variant clay_S3variant = new SkillFamily.Variant();
            clay_S3variant.skillDef = Clay_melee3;
            clay_S3variant.unlockableName = "CLAY_B3";

            int C3prevLength = ClayBruiser_sFam.variants.Length;
            System.Array.Resize<SkillFamily.Variant>(ref ClayBruiser_sFam.variants, C3prevLength + 1);
            ClayBruiser_sFam.variants[C3prevLength] = clay_S3variant;



            //Vulture Skills
            GameObject birb_body = BodyCatalog.FindBodyPrefab("VultureBody");
            SkillLocator birb_SL = birb_body.GetComponent<SkillLocator>();
            CharacterBody birb_pod = birb_body.GetComponent<CharacterBody>();


            birb_pod.preferredPodPrefab = box;
            birb_pod.crosshairPrefab = Resources.Load<GameObject>("prefabs/crosshair/TreebotCrosshair");
            GenericSkill birb_feather = birb_SL.primary;
            GenericSkill birb_flight = birb_SL.utility;
            SkillFamily birb_feather_data = birb_feather.skillFamily;
            SkillFamily birb_flight_data = birb_flight.skillFamily;
            SkillDef vultureFeather = birb_feather_data.variants[birb_feather_data.defaultVariantIndex].skillDef;
            SkillDef vultureFlight = birb_flight_data.variants[birb_flight_data.defaultVariantIndex].skillDef;
            vultureFeather.skillNameToken = "Carrion Windblade";
            vultureFeather.skillDescriptionToken = "Fling a crescent-shaped gust of wind at foes for <style=cIsDamage>225% damage.</style>";
            vultureFlight.skillNameToken = "Flight";
            vultureFlight.skillDescriptionToken = "Transition from standing to Flying. Rise and fall by using the Camera and forward/backward.";
            vultureFeather.icon = MercS_Icon;

            

            SkillDef Vulture_P2 = ScriptableObject.CreateInstance<SkillDef>();
            Vulture_P2.activationState = new SerializableEntityStateType("EntityStates.RoboBallBoss.Weapon.ChargeSuperEyeblast");
            Vulture_P2.activationStateMachineName = "Weapon";
            Vulture_P2.icon = HuntressSP_Icon;
            Vulture_P2.skillName = "BIRB_BALLS";
            Vulture_P2.skillNameToken = "Wrath of the Alloys";
            Vulture_P2.skillDescriptionToken = "Fire a horizontal/vertical blast of energy balls that deal <style=cIsDamage>100% damage</style> and burn the ground for 5 seconds. <style=cIsHealth>Knocks you back as well...</style>";
            Vulture_P2.interruptPriority = InterruptPriority.Skill;
            Vulture_P2.baseRechargeInterval = 6f;
            Vulture_P2.baseMaxStock = 1;
            Vulture_P2.rechargeStock = 1;
            Vulture_P2.isBullets = false;
            Vulture_P2.shootDelay = 0.3f;
            Vulture_P2.beginSkillCooldownOnSkillEnd = false;
            Vulture_P2.requiredStock = 1;
            Vulture_P2.stockToConsume = 1;
            Vulture_P2.isCombatSkill = true;
            Vulture_P2.noSprint = false;
            Vulture_P2.canceledFromSprinting = false;
            Vulture_P2.mustKeyPress = false;
            Vulture_P2.fullRestockOnAssign = true;
            Vulture_P2.skillIndex = 127;

            SkillFamily.Variant V_variant2 = new SkillFamily.Variant();
            V_variant2.skillDef = Vulture_P2;
            V_variant2.unlockableName = "V_B2";

            int V_P2prevLength = birb_feather_data.variants.Length;
            System.Array.Resize<SkillFamily.Variant>(ref birb_feather_data.variants, V_P2prevLength + 1);
            birb_feather_data.variants[V_P2prevLength] = V_variant2;



            //GSM Drone Skills
            GameObject Drone1bodyfab = BodyCatalog.FindBodyPrefab("Drone1Body");
            //Base Crosshair is fine
            //Drone1bodyfab.GetComponent<CharacterBody>().crosshairPrefab = Resources.Load<GameObject>("prefabs/crosshair/tiltedbracketcrosshair");
            SkillLocator Drone1_SL = Drone1bodyfab.GetComponent<SkillLocator>();
            GenericSkill Drone1_primary = Drone1_SL.primary;
            SkillFamily Drone1_pFam = Drone1_primary.skillFamily;
            SkillDef Drone1_slot1 = Drone1_pFam.variants[Drone1_pFam.defaultVariantIndex].skillDef;
            CharacterBody Drone1_pod = Drone1bodyfab.GetComponent<CharacterBody>();
            Drone1_pod.preferredPodPrefab = box;
            Drone1_pod.crosshairPrefab = Resources.Load<GameObject>("prefabs/crosshair/StandardCrosshair");
            Drone1_slot1.skillNameToken = "STOCK: Standard SA Gun";
            Drone1_slot1.skillDescriptionToken = "Fire a volley of 4 rounds that deals <style=cIsDamage>4x50% damage</style>.";
            Drone1_slot1.icon = GunnerDrone_Icon;


            //Attempt at enabling Equipment Slot
            //EquipmentSlot Drone1_item_module = Drone1bodyfab.GetComponent<EquipmentSlot>();
            //SkillLocator.PassiveSkill Nanomachines = new SkillLocator.PassiveSkill();
            //Nanomachines.enabled = true;

            //Gunner Drone Variant 1
            SkillDef GunnerDrone_Gun2 = ScriptableObject.CreateInstance<SkillDef>();
            GunnerDrone_Gun2.activationState = new SerializableEntityStateType("EntityStates.Drone.DroneWeapon.FireTurret");
            GunnerDrone_Gun2.activationStateMachineName = "Weapon";
            GunnerDrone_Gun2.icon = StrikeDrone_Icon;
            GunnerDrone_Gun2.skillName = "Test";
            GunnerDrone_Gun2.skillNameToken = "UPGRADE: Overclocked Gun";
            GunnerDrone_Gun2.skillDescriptionToken = "Turns the standard gun into a minigun that deals <style=cIsDamage>50% damage</style> per bullet.";
            GunnerDrone_Gun2.interruptPriority = InterruptPriority.Skill;
            GunnerDrone_Gun2.baseRechargeInterval = 0.1f;
            GunnerDrone_Gun2.baseMaxStock = 1;
            GunnerDrone_Gun2.rechargeStock = 1;
            GunnerDrone_Gun2.isBullets = false;
            GunnerDrone_Gun2.shootDelay = 0.3f;
            GunnerDrone_Gun2.beginSkillCooldownOnSkillEnd = false;
            GunnerDrone_Gun2.requiredStock = 1;
            GunnerDrone_Gun2.stockToConsume = 1;
            GunnerDrone_Gun2.isCombatSkill = true;
            GunnerDrone_Gun2.noSprint = true;
            GunnerDrone_Gun2.canceledFromSprinting = false;
            GunnerDrone_Gun2.mustKeyPress = false;
            GunnerDrone_Gun2.fullRestockOnAssign = true;
            GunnerDrone_Gun2.skillIndex = 7;

            SkillFamily.Variant GD_variant1 = new SkillFamily.Variant();
            GD_variant1.skillDef = GunnerDrone_Gun2;
            GD_variant1.unlockableName = "GD_P2";

            int GD2prevLength = Drone1_pFam.variants.Length;
            System.Array.Resize<SkillFamily.Variant>(ref Drone1_pFam.variants, GD2prevLength + 1);
            Drone1_pFam.variants[GD2prevLength] = GD_variant1;

            //Gunner Skin Attempt
            //SkinDef DroneChassis = ScriptableObject.CreateInstance<SkinDef>();
            //DroneChassis.nameToken = "Test";
            //ModelSkinController Chase = DroneChassis.




            //Gunner Drone Variant 2
            SkillDef GunnerDrone_Gun3 = ScriptableObject.CreateInstance<SkillDef>();
            GunnerDrone_Gun3.activationState = new SerializableEntityStateType("EntityStates.Paladin.PaladinWeapon.FireRocket");
            GunnerDrone_Gun3.activationStateMachineName = "Weapon";
            GunnerDrone_Gun3.icon = mageP_Icon;
            GunnerDrone_Gun3.skillName = "DRONE_MISSILE";
            GunnerDrone_Gun3.skillNameToken = "UPGRADE: Rocket Launcher";
            GunnerDrone_Gun3.skillDescriptionToken = "Fire a rocket for <style=cIsDamage>220% damage</style>";
            GunnerDrone_Gun3.interruptPriority = InterruptPriority.Skill;
            GunnerDrone_Gun3.baseRechargeInterval = 0.6f;
            GunnerDrone_Gun3.baseMaxStock = 1;
            GunnerDrone_Gun3.rechargeStock = 1;
            GunnerDrone_Gun3.isBullets = false;
            GunnerDrone_Gun3.shootDelay = 0.3f;
            GunnerDrone_Gun3.beginSkillCooldownOnSkillEnd = false;
            GunnerDrone_Gun3.requiredStock = 1;
            GunnerDrone_Gun3.stockToConsume = 1;
            GunnerDrone_Gun3.isCombatSkill = true;
            GunnerDrone_Gun3.noSprint = true;
            GunnerDrone_Gun3.canceledFromSprinting = false;
            GunnerDrone_Gun3.mustKeyPress = false;
            GunnerDrone_Gun3.fullRestockOnAssign = true;
            GunnerDrone_Gun3.skillIndex = 120;

            SkillFamily.Variant GD_variant2 = new SkillFamily.Variant();
            GD_variant2.skillDef = GunnerDrone_Gun3;
            GD_variant2.unlockableName = "GD_P3";

            int GD3prevLength = Drone1_pFam.variants.Length;
            System.Array.Resize<SkillFamily.Variant>(ref Drone1_pFam.variants, GD3prevLength + 1);
            Drone1_pFam.variants[GD3prevLength] = GD_variant2;


            //Gunner Drone Variant 3
            SkillDef GunnerDrone_Gun4 = ScriptableObject.CreateInstance<SkillDef>();
            GunnerDrone_Gun4.activationState = new SerializableEntityStateType("EntityStates.Drone.DroneWeapon.FireMissileBarrage");
            GunnerDrone_Gun4.activationStateMachineName = "Weapon";
            GunnerDrone_Gun4.icon = mageP_Icon;
            GunnerDrone_Gun4.skillName = "DRONE_MISSILE_BARRAGE";
            GunnerDrone_Gun4.skillNameToken = "EXPERIMENTAL: Ballistic Missile Barrage";
            GunnerDrone_Gun4.skillDescriptionToken = "Launch a barrage of 4 missiles that deals <style=cIsDamage>4x90% damage</style>. <style=cIsHealth>Homes in on the <u>closest</u> enemy</style>";
            GunnerDrone_Gun4.interruptPriority = InterruptPriority.Skill;
            GunnerDrone_Gun4.baseRechargeInterval = 1.5f;
            GunnerDrone_Gun4.baseMaxStock = 1;
            GunnerDrone_Gun4.rechargeStock = 1;
            GunnerDrone_Gun4.isBullets = false;
            GunnerDrone_Gun4.shootDelay = 0.5f;
            GunnerDrone_Gun4.beginSkillCooldownOnSkillEnd = false;
            GunnerDrone_Gun4.requiredStock = 1;
            GunnerDrone_Gun4.stockToConsume = 1;
            GunnerDrone_Gun4.isCombatSkill = true;
            GunnerDrone_Gun4.noSprint = true;
            GunnerDrone_Gun4.canceledFromSprinting = false;
            GunnerDrone_Gun4.mustKeyPress = false;
            GunnerDrone_Gun4.fullRestockOnAssign = true;
            GunnerDrone_Gun4.skillIndex = 117;

            SkillFamily.Variant GD_variant3 = new SkillFamily.Variant();
            GD_variant3.skillDef = GunnerDrone_Gun4;
            GD_variant3.unlockableName = "GD_P4";

            int GD4prevLength = Drone1_pFam.variants.Length;
            System.Array.Resize<SkillFamily.Variant>(ref Drone1_pFam.variants, GD4prevLength + 1);
            Drone1_pFam.variants[GD4prevLength] = GD_variant3;



            //Walker Turret Skills
            GameObject EngiWalkerTurretbodyfab = BodyCatalog.FindBodyPrefab("EngiWalkerTurretBody");
            SkillLocator EngiWalkerTurret_SL = EngiWalkerTurretbodyfab.GetComponent<SkillLocator>();
            GenericSkill EngiWalkerTurret_primary = EngiWalkerTurret_SL.primary;
            SkillFamily EngiWalkerTurret_pFam = EngiWalkerTurret_primary.skillFamily;
            SkillDef EngiWalkerTurret_slot1 = EngiWalkerTurret_pFam.variants[EngiWalkerTurret_pFam.defaultVariantIndex].skillDef;
            CharacterBody EngiWalkerTurret_pod = EngiWalkerTurretbodyfab.GetComponent<CharacterBody>();
            EngiWalkerTurret_pod.preferredPodPrefab = box;
            EngiWalkerTurret_pod.crosshairPrefab = Resources.Load<GameObject>("prefabs/crosshair/BanditCrosshair");
            EngiWalkerTurret_slot1.skillNameToken = "TR58 Carbonizer Beam";
            EngiWalkerTurret_slot1.skillDescriptionToken = "Fire a laser that deals <style=cIsDamage>30% damage</style> per tick and slows down enemies.";
            EngiWalkerTurret_slot1.icon = WalkerTurret_Icon;


            //Walker Turret Variant 1
            SkillDef Walker_Beam3 = ScriptableObject.CreateInstance<SkillDef>();
            Walker_Beam3.activationState = new SerializableEntityStateType("EntityStates.EngiTurret.EngiTurretWeapon.FireGauss");
            Walker_Beam3.activationStateMachineName = "Weapon";
            Walker_Beam3.icon = EngiSP_Icon;
            Walker_Beam3.skillName = "Walker_Beam_3";
            Walker_Beam3.skillNameToken = "TR12 Gauss Cannon";
            Walker_Beam3.skillDescriptionToken = "Fire a Gauss Cannon for <style=cIsDamage>up to 70% damage</style>.";
            Walker_Beam3.interruptPriority = InterruptPriority.Any;
            Walker_Beam3.baseRechargeInterval = 0f;
            Walker_Beam3.baseMaxStock = 1;
            Walker_Beam3.rechargeStock = 1;
            Walker_Beam3.isBullets = false;
            Walker_Beam3.shootDelay = 0.1f;
            Walker_Beam3.beginSkillCooldownOnSkillEnd = false;
            Walker_Beam3.requiredStock = 1;
            Walker_Beam3.stockToConsume = 1;
            Walker_Beam3.isCombatSkill = true;
            Walker_Beam3.noSprint = true;
            Walker_Beam3.canceledFromSprinting = false;
            Walker_Beam3.mustKeyPress = false;
            Walker_Beam3.fullRestockOnAssign = true;
            Walker_Beam3.skillIndex = 62;

            SkillFamily.Variant WT_variant3 = new SkillFamily.Variant();
            WT_variant3.skillDef = Walker_Beam3;
            WT_variant3.unlockableName = "WT_B3";

            int WT3prevLength = EngiWalkerTurret_pFam.variants.Length;
            System.Array.Resize<SkillFamily.Variant>(ref EngiWalkerTurret_pFam.variants, WT3prevLength + 1);
            EngiWalkerTurret_pFam.variants[WT3prevLength] = WT_variant3;


            //Walker Beam Variant 2
            SkillDef Walker_Beam2 = ScriptableObject.CreateInstance<SkillDef>();
            Walker_Beam2.activationState = new SerializableEntityStateType("EntityStates.Drone.DroneWeapon.FireGatling");
            Walker_Beam2.activationStateMachineName = "Weapon";
            Walker_Beam2.icon = commandoP_Icon;
            Walker_Beam2.skillName = "Walker_Beam_2";
            Walker_Beam2.skillNameToken = "Jury-Rigged Gatling Gun";
            Walker_Beam2.skillDescriptionToken = "Fire a gatling-gun that deals <style=cIsDamage>40x30% damage</style>.";
            Walker_Beam2.interruptPriority = InterruptPriority.Any;
            Walker_Beam2.baseRechargeInterval = 2f;
            Walker_Beam2.baseMaxStock = 42;
            Walker_Beam2.rechargeStock = 3;
            Walker_Beam2.isBullets = true;
            Walker_Beam2.shootDelay = 0.1f;
            Walker_Beam2.beginSkillCooldownOnSkillEnd = false;
            Walker_Beam2.requiredStock = 1;
            Walker_Beam2.stockToConsume = 1;
            Walker_Beam2.isCombatSkill = true;
            Walker_Beam2.noSprint = true;
            Walker_Beam2.canceledFromSprinting = false;
            Walker_Beam2.mustKeyPress = false;
            Walker_Beam2.fullRestockOnAssign = false;
            Walker_Beam2.skillIndex = 154;

            SkillFamily.Variant WT_variant2 = new SkillFamily.Variant();
            WT_variant2.skillDef = Walker_Beam2;
            WT_variant2.unlockableName = "WT_B2";

            int WT2prevLength = EngiWalkerTurret_pFam.variants.Length;
            System.Array.Resize<SkillFamily.Variant>(ref EngiWalkerTurret_pFam.variants, WT2prevLength + 1);
            EngiWalkerTurret_pFam.variants[WT2prevLength] = WT_variant2;



            /*
            var Missile_Drone = new SurvivorDef
            {
                bodyPrefab = BodyCatalog.FindBodyPrefab("MissileDroneBody"),
                descriptionToken = "Military Issue Drone: Missile Drone. \nIf you want something dead, this is the drone for you!\n\n<style=cSub>< i > This version of the Missile Drone is running on older firmware and cannot access its Equipment Subroutines. <style=cIsHealth>(cannot use Equipment)</style></style>.\n\n< i > The missiles this Unit fires homes in on the closest enemy, which can provide problems if you are being overwhelmed.",
                displayPrefab = Resources.Load<GameObject>("prefabs/characterbodies/MissileDroneBody"),
                primaryColor = new Color(0.8039216f, 0.482352942f, 0.843137264f),
                unlockableName = "EngiWalker",
                survivorIndex = SurvivorIndex.Count + 1,
            };
            GameObject MissileDronebodyfab = BodyCatalog.FindBodyPrefab("MissileDroneBody");
            SkillLocator MissileDrone_SL = MissileDronebodyfab.GetComponent<SkillLocator>();
            GenericSkill MissileDrone_primary = MissileDrone_SL.primary;
            SkillFamily MissileDrone_pFam = MissileDrone_primary.skillFamily;
            SkillDef MissileDrone_slot1 = MissileDrone_pFam.variants[MissileDrone_pFam.defaultVariantIndex].skillDef;
            CharacterBody MissileDrone_pod = MissileDronebodyfab.GetComponent<CharacterBody>();
            MissileDrone_pod.preferredPodPrefab = box;
            MissileDrone_pod.crosshairPrefab = Resources.Load<GameObject>("prefabs/crosshair/NULL");
            MissileDrone_slot1.skillNameToken = "Ballistic Missile Barage";
            MissileDrone_slot1.skillDescriptionToken = "Launch a barrage of 4 missiles that deals <style=cIsDamage>4x90% damage</style>.";
            MissileDrone_slot1.icon = commandoSP_Icon;
            */



            /*
            var Strike_Drone = new SurvivorDef
            {
                bodyPrefab = BodyCatalog.FindBodyPrefab("BackupDroneBody"),
                descriptionToken = "Unstable Surplus Drone: The Strike Drone. \n2.0 version of the Standard Gunner Drone, but discontinued after many units spontaneously combusted. \n\n<style=cSub>< i > Possesses the same manuverability as the Gunner Drone, but also the same Equipment bugs... <style=cIsHealth>(cannot use Equipment)</style>.\n\n< i > The Minigun has a bit of a delay before it stops firing bullets.\n\n< i > The mounted gun deals more damage the closer you are to an enemy, but less damage if you are too far.</style>",
                displayPrefab = Resources.Load<GameObject>("prefabs/characterbodies/BackupDroneBody"),
                primaryColor = new Color(0.8039216f, 0.482352942f, 0.843137264f),
                unlockableName = "OldDrone",
                survivorIndex = SurvivorIndex.Count + 1,
            };
            GameObject BackupDronebodyfab = BodyCatalog.FindBodyPrefab("BackupDroneBody");
            SkillLocator BackupDrone_SL = BackupDronebodyfab.GetComponent<SkillLocator>();
            GenericSkill BackupDrone_primary = BackupDrone_SL.primary;
            SkillFamily BackupDrone_pFam = BackupDrone_primary.skillFamily;
            SkillDef BackupDrone_slot1 = BackupDrone_pFam.variants[BackupDrone_pFam.defaultVariantIndex].skillDef;
            CharacterBody BackupDrone_pod = BackupDronebodyfab.GetComponent<CharacterBody>();
            BackupDrone_pod.preferredPodPrefab = box;
            BackupDrone_slot1.skillNameToken = "Mini-Minigun";
            BackupDrone_slot1.skillDescriptionToken = "Shoot a rapid-fire Minigun that deals <style=cIsDamage>60% damage</style>.";
            BackupDrone_slot1.icon = StrikeDrone_Icon;
            */


            /*
            var Super_Drone = new SurvivorDef
            {
                bodyPrefab = BodyCatalog.FindBodyPrefab("MegaDroneBody"),
                descriptionToken = "Summary Text\n\n<style=cSub>< i >Flavor-Text</style>",
                displayPrefab = Resources.Load<GameObject>("prefabs/characterbodies/MegaDroneBody"),
                primaryColor = new Color(0.8039216f, 0.482352942f, 0.843137264f),
                unlockableName = "MegaDrone",
                survivorIndex = SurvivorIndex.Count + 1,
            };
            GameObject MegaDronebodyfab = BodyCatalog.FindBodyPrefab("MegaDroneBody");
            SkillLocator MegaDrone_SL = MegaDronebodyfab.GetComponent<SkillLocator>();
            GenericSkill MegaDrone_primary = MegaDrone_SL.primary;
            GenericSkill MegaDrone_secondary = MegaDrone_SL.secondary;
            SkillFamily MegaDrone_pFam = MegaDrone_primary.skillFamily;
            SkillFamily MegaDrone_sFam = MegaDrone_secondary.skillFamily;
            SkillDef MegaDrone_slot1 = MegaDrone_pFam.variants[MegaDrone_pFam.defaultVariantIndex].skillDef;
            SkillDef MegaDrone_slot2 = MegaDrone_sFam.variants[MegaDrone_sFam.defaultVariantIndex].skillDef;
            CharacterBody MegaDrone_pod = MegaDronebodyfab.GetComponent<CharacterBody>();
            MegaDrone_pod.preferredPodPrefab = box;
            MegaDrone_slot1.skillNameToken = "S4SH4-Minigun";
            MegaDrone_slot1.skillDescriptionToken = "Fire twin-mounted Miniguns that deal <style=cIsDamage>150% damage</style> per bullet.";
            MegaDrone_slot2.skillNameToken = "CR0K3T-Launcher";
            MegaDrone_slot2.skillDescriptionToken = "Fire two large rockets that deal <style=cIsDamage>2x310% damage</style>.";
            MegaDrone_slot1.icon = commandoP_Icon;
            MegaDrone_slot2.icon = commandoSP_Icon;
            */


            /*
            int bodyIndex = BodyCatalog.FindBodyIndex("BackupDroneBody");
            SkillLocator skillLocator = BodyCatalog.GetBodyPrefab(bodyIndex).GetComponent<SkillLocator>();
            SkillFamily skillFamily = skillLocator.primary.skillFamily;
            SkillDef defaultSkill = skillFamily.variants[skillFamily.defaultVariantIndex].skillDef;
            defaultSkill.activationState = new SerializableEntityStateType("EntityStates.Engi.EngiWeapon.FireMines");
            object box2 = defaultSkill.activationState;
            defaultSkill.activationState = (SerializableEntityStateType)box2;
            */

            //SurvivorAPI.SurvivorDefinitions.Insert(3, survivor);
            //SurvivorAPI.SurvivorDefinitions.Insert(2, survivor2);
            //SurvivorAPI.SurvivorDefinitions.Insert(3, Engi_Walker);

            //tacks on the survivors to the end of the list

            //R2API.SurvivorAPI.AddSurvivorOnReady(test);
            //SurvivorAPI.SurvivorDefinitions.Insert(3, ClayB_Surv);

            //GameObject lizhard = CharacterBody.CharacterBody("lemurianBody");
            //Boiler-Plate for Skill additions/edits
            //First, locate your character
            //GameObject commandobodyfab = BodyCatalog.FindBodyPrefab("CommandoBody");
            //then prime the skill set
            //SkillLocator commando_SL = commandobodyfab.GetComponent<SkillLocator>();
            //define your slot to pull/push data to/from
            //GenericSkill commando_primary = commando_SL.primary;
            //get that slot's skillFamily
            //SkillFamily commando_pFam = commando_primary.skillFamily;
            //finally declare the skillDef for the slot for editing
            //SkillDef commando_slot1 = commando_pFam.variants[commando_pFam.defaultVariantIndex].skillDef;




        }

        public void Awake()
        {
            SurvivorAPI.SurvivorCatalogReady += delegate (object s, EventArgs e)
            {
                //GSM Drone
                var Gun_Drone = new SurvivorDef
                {
                    bodyPrefab = BodyCatalog.FindBodyPrefab("Drone1Body"),
                    descriptionToken = "Experimental Drone: G.S.M. Model. \nMulti-Purpose, Custom-Built Drone, combines the functionality of multiple units both civilian and military. NOT FOR RETAIL SALE!\n\n<style=cSub>< i > In order to build this custom unit, some corners had to be cut. <style=cIsHealth>(cannot use Equipment)</style>.\n\n< i > This Drone Unit is quick and nimble, but is also somewhat fragile.\n\n< i > The mounted gun deals more damage the closer you are to an enemy, but less damage if you are too far. \n\n< i > The Missile Barrage rockets home in on the closest enemy, which can cause a problem if you are being overwhelmed.</style>",
                    displayPrefab = Resources.Load<GameObject>("prefabs/characterbodies/Drone1Body"),
                    primaryColor = new Color(0.19f, 0.69f, 0.96f),
                    unlockableName = "GDrone",
                    survivorIndex = SurvivorIndex.Count + 1,

                };
                //SurvivorAPI.SurvivorDefinitions.Insert(1, Gun_Drone);

                //Engineer Walker Turret
                var Engi_Walker = new SurvivorDef
                {
                    bodyPrefab = BodyCatalog.FindBodyPrefab("EngiWalkerTurretBody"),
                    descriptionToken = "<i>No way in Hell am I going down there! I'll send in one of my new Walker Turrets instead!</i>\n~The Engineer when asked by Loader to do some scavenging on the surface of the planet.\n\n<style=cSub>< i > Unfortunately, the Engineer forgot to program his Walker to use equipment... <style=cIsHealth>(cannot use Equipment)</style>.\n\n< i > Can easily walk up steep slopes\n\n< i >The TR58 Carbonizer Beam has a very limited range but can be fired continuously.\n\n< i ><style=cIsHealth><u>WILL NOT WORK IN MULTIPLAYER!!!</u></style></style>",
                    displayPrefab = Resources.Load<GameObject>("prefabs/characterbodies/EngiWalkerTurretBody"),
                    primaryColor = new Color(0.8039216f, 0.482352942f, 0.843137264f),
                    unlockableName = "EngiWalker",
                    survivorIndex = SurvivorIndex.Count + 1,

                };
                

                //Lemurian
                var Lemur_Surv = new SurvivorDef
                {

                    bodyPrefab = BodyCatalog.FindBodyPrefab("LemurianBody"),
                    descriptionToken = "The Lemurian is the very definition of struggle. Weak and fragile, but determined to rise to the top of the food chain. \n\n<style=cSub>< i > Gets <style=cIsHealth>stunned easily</style>. Only engage in hand-to-hand if absolutely necessary or confident!\n\n< i > Due to their bizarre physiology, <style=cIsHealth>they cannot use <u>most</u> healing-based items.</style></color>",
                    displayPrefab = Resources.Load<GameObject>("prefabs/characterbodies/LemurianBody"),
                    primaryColor = new Color(0.8039216f, 0.482352942f, 0.843137264f),
                    unlockableName = "Lemur",
                    survivorIndex = SurvivorIndex.Count + 1

                };

                //Imp
                var Imp_Surv = new SurvivorDef
                {
                    bodyPrefab = BodyCatalog.FindBodyPrefab("ImpBody"),
                    descriptionToken = "Summary Text\n\n<style=cSub>< i >Flavor-Text</style>",
                    displayPrefab = Resources.Load<GameObject>("prefabs/characterbodies/ImpBody"),
                    primaryColor = new Color(0.4f, 0.17f, 0.17f),
                    unlockableName = "Imp",
                    survivorIndex = SurvivorIndex.Count + 1,
                };

                //Clay Templar
                var ClayB_Surv = new SurvivorDef
                {
                    bodyPrefab = BodyCatalog.FindBodyPrefab("ClayBruiserBody"),
                    descriptionToken = "A wandering Clayman. It got seperated from its Dunestrider and now travels the planet in hopes of finding its leader. \n\n<style=cSub>< i > The Templar's Jar gets more accurate the closer you are to a target.\n\n< i > The Jar has a slow start-up and slows you down while using it.\n\n< i > Due to their bizarre physiology, <style=cIsHealth>they cannot use <i>most</i> healing-based items.</style></color>",
                    displayPrefab = Resources.Load<GameObject>("prefabs/characterbodies/claybruiserbody"),
                    primaryColor = new Color(0.8039216f, 0.482352942f, 0.843137264f),
                    unlockableName = "Characters.Experiment",
                    survivorIndex = SurvivorIndex.Count + 1

                };

                //Vulture
                var Birb_Surv = new SurvivorDef
                {
                    bodyPrefab = BodyCatalog.FindBodyPrefab("VultureBody"),
                    descriptionToken = "After having many of its eggs broken by the strange newcomers, one of the Vultures decided to drop its opportunistic lifestyle and hunt down the trespassers. \n\n<style=cSub>< ! > When landing, you will automatically drift towards the nearest solid surface</color>",
                    displayPrefab = Resources.Load<GameObject>("prefabs/characterbodies/vulturebody"),
                    primaryColor = new Color(0.8039216f, 0.482352942f, 0.843137264f),
                    unlockableName = "Carrion Pigeon",
                    survivorIndex = SurvivorIndex.Count + 1
                };

                SurvivorAPI.SurvivorDefinitions.Insert(4, Engi_Walker);
                R2API.SurvivorAPI.AddSurvivorOnReady(Gun_Drone);
                R2API.SurvivorAPI.AddSurvivorOnReady(Lemur_Surv);
                R2API.SurvivorAPI.AddSurvivorOnReady(Imp_Surv);
                R2API.SurvivorAPI.AddSurvivorOnReady(ClayB_Surv);
                R2API.SurvivorAPI.AddSurvivorOnReady(Birb_Surv);


            };



        }

        //The Update() method is run on every frame of the game.
        public void Update()
        {




            //This if statement checks if the player has currently pressed F2, and then proceeds into the statement:
            if (Input.GetKeyDown(KeyCode.F4))
            {
                //We grab a list of all available Tier 3 drops:
                //var dropList = Run.instance.availableTier3DropList;

                Chat.AddMessage("spell icup");

                //Randomly get the next item:
                //var nextItem = Run.instance.treasureRng.RangeInt(0, dropList.Count);

                //Get the player body to use a position:
                //var transform = PlayerCharacterMasterController.instances[0].master.GetBodyObject().transform;

                //And then finally drop it infront of the player.
                //PickupDropletController.CreatePickupDroplet(dropList[nextItem], transform.position, transform.forward * 20f);
            }

        }





    }
}
