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
using System.Collections;
using MonoMod.Cil;
using KinematicCharacterController;
using System.Linq;
using EntityStates;
using R2API.Utils;
using SurvivorUtils;

namespace MonstarMod
{
    [R2APISubmoduleDependency(new string[]
{
        "SurvivorAPI"
})]
    [BepInDependency("com.bepis.r2api")]
    [BepInPlugin("SadBoxMan.Monstar", "Monstar Mod", "1.3.6")]
    



    public class Monstar : BaseUnityPlugin
    {
        
        //For declaring the prefab
        //GameObject _prefab;

        //Priming the Asset Bundle for imports


                //Prefab Load Example
                //_prefab = _MonstarIconBundle.LoadAsset<GameObject>("Assets/Import/belt/belt.prefab");


        public void Start()
        {

            //Declaring type for Bundle
            AssetBundle _MonstarIconBundle;
            //For declaring the prefab
            //GameObject _prefab;

            //Priming the Asset Bundle for imports
            _MonstarIconBundle = AssetBundle.LoadFromFile(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/monstaricons");

            //Prefab Load Example
            //_prefab = _MonstarIconBundle.LoadAsset<GameObject>("Assets/Import/belt/belt.prefab");

            //AudioClip genericSound = _MonstarIconBundle.LoadAsset<AudioClip>("Assets/Import/sound/generic.mp3");
            //Lemurian Icons
            Sprite LemurianBite_Icon = _MonstarIconBundle.LoadAsset<Sprite>("Assets/Import/icons/RoR2_lumerian_bite_icon.png");
            Sprite LemurianFireball_Icon = _MonstarIconBundle.LoadAsset<Sprite>("Assets/Import/icons/ror2_lumerian_fire_icon.jpg");
            Sprite LemurianSuperFireball_Icon = _MonstarIconBundle.LoadAsset<Sprite>("Assets/Import/icons/RoR2_Lumerian_Elder's_Authority.png");
            Sprite LemurianDragonBreath_Icon = _MonstarIconBundle.LoadAsset<Sprite>("Assets/Import/icons/RoR2_Elder's_Whisper_icon.png");

            //Shoulder Bash Icon
            Sprite WarioBash_Lemurian_Icon = _MonstarIconBundle.LoadAsset<Sprite>("Assets/Import/icons/RoR2_WarioBash_Lemurian_placeholder.png");
            Sprite WarioBash_Clay_Icon = _MonstarIconBundle.LoadAsset<Sprite>("Assets/Import/icons/RoR2_WarioBash_Clay_placeholder.png");

            //Imp Icons
            Sprite ImpSwipe_Icon = _MonstarIconBundle.LoadAsset<Sprite>("Assets/Import/icons/RoR2_Imp_placeholder.png");
            Sprite ImpBlink_Icon = _MonstarIconBundle.LoadAsset<Sprite>("Assets/Import/icons/RoR2_Imp_placeholder.png");
            Sprite ImpCloak_Icon = _MonstarIconBundle.LoadAsset<Sprite>("Assets/Import/icons/RoR2_Imp_placeholder.png");
            Sprite ImpSuperBlink_Icon = _MonstarIconBundle.LoadAsset<Sprite>("Assets/Import/icons/RoR2_Imp_placeholder.png");

            //Clay Icons
            Sprite ClayMinigun_Icon = _MonstarIconBundle.LoadAsset<Sprite>("Assets/Import/icons/RoR2_Clay_placeholder.png");
            Sprite ClaySpray_Icon = _MonstarIconBundle.LoadAsset<Sprite>("Assets/Import/icons/RoR2_Clay_placeholder.png");
            Sprite ClayJarToss_Icon = _MonstarIconBundle.LoadAsset<Sprite>("Assets/Import/icons/RoR2_Clay_placeholder.png");
            Sprite ClayBowl_Icon = _MonstarIconBundle.LoadAsset<Sprite>("Assets/Import/icons/RoR2_Clay_placeholder.png");

            //Vulture Icons
            Sprite VultureWindblade_Icon = _MonstarIconBundle.LoadAsset<Sprite>("Assets/Import/icons/RoR2_Vulture_placeholder.png");
            Sprite VultureFlight_Icon = _MonstarIconBundle.LoadAsset<Sprite>("Assets/Import/icons/RoR2_Vulture_placeholder.png");
            Sprite VultureSuperBall_Icon = _MonstarIconBundle.LoadAsset<Sprite>("Assets/Import/icons/RoR2_Vulture_placeholder.png");

            //Walker Turret Icons
            Sprite WalkerTurret_Icon = _MonstarIconBundle.LoadAsset<Sprite>("Assets/Import/icons/Walker.png");
            Sprite GunnerTurret_Icon = _MonstarIconBundle.LoadAsset<Sprite>("Assets/Import/icons/RoR2_Walker_Turret_placeholder.png");

            //Gunner Drone Icons
            Sprite GunnerDrone_Icon = _MonstarIconBundle.LoadAsset<Sprite>("Assets/Import/icons/RoR2_Drone_Standard_Fire.png");
            Sprite StrikeDrone_Icon = _MonstarIconBundle.LoadAsset<Sprite>("Assets/Import/icons/RoR2_Drone_Minigun_icon.png");
            Sprite RocketDrone_Icon = _MonstarIconBundle.LoadAsset<Sprite>("Assets/Import/icons/RoR2_Drone_placeholder.png");
            Sprite MissileDrone_Icon = _MonstarIconBundle.LoadAsset<Sprite>("Assets/Import/icons/RoR2_Drone_Missile_Barrage.png");


            //MULT Icon & Survivor Pod Setup
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
            //MULT Icons
            Sprite ToolBotP_Icon = ToolBot_pFam.variants[ToolBot_pFam.defaultVariantIndex].skillDef.icon;
            Sprite ToolBotS_Icon = ToolBot_sFam.variants[ToolBot_sFam.defaultVariantIndex].skillDef.icon;
            Sprite ToolBotU_Icon = ToolBot_uFam.variants[ToolBot_uFam.defaultVariantIndex].skillDef.icon;
            Sprite ToolBotSP_Icon = ToolBot_spFam.variants[ToolBot_spFam.defaultVariantIndex].skillDef.icon;



            //Commando Icon & Survivor Pod Setup
            GameObject commandobodyfab = BodyCatalog.FindBodyPrefab("CommandoBody");
            CharacterBody surv_pod = commandobodyfab.GetComponent<CharacterBody>();
            GameObject pod = surv_pod.preferredPodPrefab;
            SkillLocator commando_SL = commandobodyfab.GetComponent<SkillLocator>();
            GenericSkill commando_primary = commando_SL.primary;
            GenericSkill commando_secondary = commando_SL.secondary;
            GenericSkill commando_utility = commando_SL.utility;
            GenericSkill commando_special = commando_SL.special;
            SkillFamily commando_pFam = commando_primary.skillFamily;
            SkillFamily commando_sFam = commando_secondary.skillFamily;
            SkillFamily commando_uFam = commando_utility.skillFamily;
            SkillFamily commando_spFam = commando_special.skillFamily;
            //Commando Icons
            Sprite commandoP_Icon = commando_pFam.variants[commando_pFam.defaultVariantIndex].skillDef.icon;
            Sprite commandoS_Icon = commando_sFam.variants[commando_sFam.defaultVariantIndex].skillDef.icon;
            Sprite commandoU_Icon = commando_uFam.variants[commando_uFam.defaultVariantIndex].skillDef.icon;
            Sprite commandoSP_Icon = commando_spFam.variants[commando_spFam.defaultVariantIndex].skillDef.icon;



            //Engineer Setup
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
            //Engineer Icons
            Sprite EngiP_Icon = Engi_pFam.variants[Engi_pFam.defaultVariantIndex].skillDef.icon;
            Sprite EngiS_Icon = Engi_sFam.variants[Engi_sFam.defaultVariantIndex].skillDef.icon;
            Sprite EngiU_Icon = Engi_uFam.variants[Engi_uFam.defaultVariantIndex].skillDef.icon;
            Sprite EngiSP_Icon = Engi_spFam.variants[Engi_spFam.defaultVariantIndex].skillDef.icon;



            //Mage Setup
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
            //Mage Icons
            Sprite mageP_Icon = mage_pFam.variants[mage_pFam.defaultVariantIndex].skillDef.icon;
            Sprite mageS_Icon = mage_sFam.variants[mage_sFam.defaultVariantIndex].skillDef.icon;
            Sprite mageU_Icon = mage_uFam.variants[mage_uFam.defaultVariantIndex].skillDef.icon;
            Sprite mageSP_Icon = mage_spFam.variants[mage_spFam.defaultVariantIndex].skillDef.icon;



            //Loader Setup
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
            //Loader Icons
            Sprite loaderP_Icon = loader_pFam.variants[loader_pFam.defaultVariantIndex].skillDef.icon;
            Sprite loaderS_Icon = loader_sFam.variants[loader_sFam.defaultVariantIndex].skillDef.icon;
            Sprite loaderU_Icon = loader_uFam.variants[loader_uFam.defaultVariantIndex].skillDef.icon;
            Sprite loaderSP_Icon = loader_spFam.variants[loader_spFam.defaultVariantIndex].skillDef.icon;



            //Mercenary Setup
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
            //Merc Icons
            Sprite MercP_Icon = Merc_pFam.variants[Merc_pFam.defaultVariantIndex].skillDef.icon;
            Sprite MercS_Icon = Merc_sFam.variants[Merc_sFam.defaultVariantIndex].skillDef.icon;
            Sprite MercU_Icon = Merc_uFam.variants[Merc_uFam.defaultVariantIndex].skillDef.icon;
            Sprite MercSP_Icon = Merc_spFam.variants[Merc_spFam.defaultVariantIndex].skillDef.icon;

           





            //Huntress Setup
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
            //Huntress Icons
            Sprite HuntressP_Icon = Huntress_pFam.variants[Huntress_pFam.defaultVariantIndex].skillDef.icon;
            Sprite HuntressS_Icon = Huntress_sFam.variants[Huntress_sFam.defaultVariantIndex].skillDef.icon;
            Sprite HuntressU_Icon = Huntress_uFam.variants[Huntress_uFam.defaultVariantIndex].skillDef.icon;
            Sprite HuntressSP_Icon = Huntress_spFam.variants[Huntress_spFam.defaultVariantIndex].skillDef.icon;



            //REX Setup
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
            //REX Icons
            Sprite TreebotP_Icon = Treebot_pFam.variants[Treebot_pFam.defaultVariantIndex].skillDef.icon;
            Sprite TreebotS_Icon = Treebot_sFam.variants[Treebot_sFam.defaultVariantIndex].skillDef.icon;
            Sprite TreebotU_Icon = Treebot_uFam.variants[Treebot_uFam.defaultVariantIndex].skillDef.icon;
            Sprite TreebotSP_Icon = Treebot_spFam.variants[Treebot_spFam.defaultVariantIndex].skillDef.icon;






            //Lemurian Skills
            GameObject lemur_body = BodyCatalog.FindBodyPrefab("LemurianBody");

            //SkinDef[] l1 = BodyCatalog.GetBodySkins(1);
            //SerializableLoadout.BodyLoadout l3;

            //SkinDef.MeshReplacement lemur_alt = lemur_body.;
            //lemur_alt.mesh = "";


            CharacterBody lemur_pod = lemur_body.GetComponent<CharacterBody>();
            lemur_pod.preferredPodPrefab = box;
            lemur_pod.baseRegen = 0.4f;
            lemur_pod.levelRegen = 0.08f;

            SkillLocator lemur_SL = lemur_body.GetComponent<SkillLocator>();
            GenericSkill lemur_fireball = lemur_SL.primary;
            GenericSkill lemur_bite = lemur_SL.secondary;
            SkillFamily lemur_fireball_data = lemur_fireball.skillFamily;
            SkillFamily lemur_bite_data = lemur_bite.skillFamily;
            SkillDef lemurianFireball = lemur_fireball_data.variants[lemur_fireball_data.defaultVariantIndex].skillDef;
            SkillDef lemurianBite = lemur_bite_data.variants[lemur_bite_data.defaultVariantIndex].skillDef;

            lemurianFireball.skillNameToken = "Distinctive Fireball";
            lemurianFireball.skillDescriptionToken = "Spit a ball of fire at enemies for <style=cIsDamage>100% damage.</style>";
            lemurianFireball.icon = LemurianFireball_Icon;

            lemurianBite.skillNameToken = "Instinctive Bite";
            lemurianBite.skillDescriptionToken = "Bite Enemies for <style=cIsDamage>200% damage.</style>";
            lemurianBite.icon = LemurianBite_Icon;

            /*
            SkinDef butt = ScriptableObject.CreateInstance<SkinDef>();
            butt.icon = LemurianBite_Icon;
            SkinDef[] barp = BodyCatalog.GetBodySkins(1);
            */


            //Lemur Fire Variant 1
            SkillDef lemurianFireball2 = ScriptableObject.CreateInstance<SkillDef>();
            lemurianFireball2.activationState = new SerializableEntityStateType("EntityStates.LemurianBruiserMonster.ChargeMegaFireball");
            lemurianFireball2.activationStateMachineName = "Weapon";
            lemurianFireball2.icon = LemurianSuperFireball_Icon;
            lemurianFireball2.skillName = "LemurFireVolley";
            lemurianFireball2.skillNameToken = "Elder's Authority";
            lemurianFireball2.skillDescriptionToken = "Fire a volley of 5 fireballs that deal <style=cIsDamage>5x200% damage.</style>";
            lemurianFireball2.interruptPriority = InterruptPriority.Skill;
            lemurianFireball2.baseRechargeInterval = 3f;
            lemurianFireball2.baseMaxStock = 1;
            lemurianFireball2.rechargeStock = 1;
            lemurianFireball2.isBullets = false;
            lemurianFireball2.shootDelay = 0.3f;
            lemurianFireball2.beginSkillCooldownOnSkillEnd = true;
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
            lemurianFireball3.icon = LemurianDragonBreath_Icon;
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
            lemur_melee2.icon = WarioBash_Lemurian_Icon;
            lemur_melee2.skillName = "LemurTackle";
            lemur_melee2.skillNameToken = "Soldier Tackle";
            lemur_melee2.skillDescriptionToken = "A charging tackle that <color=#95cde5>stuns foes, knocking them back</color> and dealing <style=cIsDamage>250% damage</style>.";
            lemur_melee2.interruptPriority = InterruptPriority.Skill;
            lemur_melee2.baseRechargeInterval = 5f;
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

            CharacterBody Imp_pod = Impbodyfab.GetComponent<CharacterBody>();
            Imp_pod.preferredPodPrefab = box;
            Imp_pod.crosshairPrefab = Resources.Load<GameObject>("prefabs/crosshair/NULL");
            Imp_pod.baseJumpCount = 2;
            Imp_pod.bodyFlags = CharacterBody.BodyFlags.SprintAnyDirection;
            Imp_pod.bodyFlags = CharacterBody.BodyFlags.IgnoreFallDamage;






            //transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);

            SkillLocator Imp_SL = Impbodyfab.GetComponent<SkillLocator>();
            GenericSkill Imp_primary = Imp_SL.primary;
            GenericSkill Imp_utility = Imp_SL.utility;
            SkillFamily Imp_pFam = Imp_primary.skillFamily;
            SkillFamily Imp_uFam = Imp_utility.skillFamily;
            SkillDef Imp_slot1 = Imp_pFam.variants[Imp_pFam.defaultVariantIndex].skillDef;
            SkillDef Imp_slot3 = Imp_uFam.variants[Imp_uFam.defaultVariantIndex].skillDef;

            Imp_slot1.skillNameToken = "Rend Flesh";
            Imp_slot1.skillDescriptionToken = "Slash at your foes with each hand, dealing <style=cIsDamage>2x150% damage</style>. The deep lacerations cause creatures to <color=#95cde5>bleed</color>.";
            Imp_slot1.icon = ImpSwipe_Icon;
            Imp_slot1.beginSkillCooldownOnSkillEnd = true;
            Imp_slot1.canceledFromSprinting = false;
            Imp_slot1.noSprint = false;
            Imp_slot1.baseRechargeInterval = 0f;

            Imp_slot3.skillNameToken = "Dark Warp";
            Imp_slot3.skillDescriptionToken = "<color=#95cde5>Teleport</color> out of danger. <color=#95cde5>Holds 3 charges.</color>";
            Imp_slot3.icon = ImpBlink_Icon;


            //Imp "Passive"
 
               

            //Imp Utility 1
            SkillDef Imp_Float = ScriptableObject.CreateInstance<SkillDef>();
            Imp_Float.activationState = new SerializableEntityStateType("EntityStates.Commando.CommandoWeapon.CastSmokescreenNoDelay");
            Imp_Float.activationStateMachineName = "Weapon";
            Imp_Float.icon = ImpCloak_Icon;
            Imp_Float.skillName = "LAST_SURPRISE";
            Imp_Float.skillNameToken = "Shadow Sneak";
            Imp_Float.skillDescriptionToken = "<color=#95cde5>Go invisible</color>, <color=#95cde5>stunning creatures</color> in close proximity. Deals <style=cIsDamage>220% damage</style>.";
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
            Imp_Escape.icon = ImpSuperBlink_Icon;
            Imp_Escape.skillName = "BEAM_ME_UP";
            Imp_Escape.skillNameToken = "Providence's Rapture";
            Imp_Escape.skillDescriptionToken = "<style=cIsHealing>Brings you far away from danger...</style>";
            Imp_Escape.interruptPriority = InterruptPriority.PrioritySkill;
            Imp_Escape.baseRechargeInterval = 45f;
            Imp_Escape.baseMaxStock = 1;
            Imp_Escape.rechargeStock = 1;
            Imp_Escape.isBullets = false;
            Imp_Escape.shootDelay = 1f;
            Imp_Escape.beginSkillCooldownOnSkillEnd = false;
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


            //Imp Utility 3
            SkillDef Imp_Bomb = ScriptableObject.CreateInstance<SkillDef>();
            Imp_Bomb.activationState = new SerializableEntityStateType("EntityStates.NullifierMonster.FirePortalBomb");
            Imp_Bomb.activationStateMachineName = "Weapon";
            Imp_Bomb.icon = ImpCloak_Icon;
            Imp_Bomb.skillName = "VOID_BOMB";
            Imp_Bomb.skillNameToken = "null_skill";
            Imp_Bomb.skillDescriptionToken = "Coat the area nearby with bombs of Void Energy. Deals <style=cIsDamage>100% damage</style>.";
            Imp_Bomb.interruptPriority = InterruptPriority.PrioritySkill;
            Imp_Bomb.baseRechargeInterval = 2.5f;
            Imp_Bomb.baseMaxStock = 1;
            Imp_Bomb.rechargeStock = 1;
            Imp_Bomb.isBullets = false;
            Imp_Bomb.shootDelay = 0.3f;
            Imp_Bomb.beginSkillCooldownOnSkillEnd = false;
            Imp_Bomb.requiredStock = 1;
            Imp_Bomb.stockToConsume = 1;
            Imp_Bomb.isCombatSkill = true;
            Imp_Bomb.noSprint = false;
            Imp_Bomb.canceledFromSprinting = false;
            Imp_Bomb.mustKeyPress = false;
            Imp_Bomb.fullRestockOnAssign = true;
            Imp_Bomb.skillIndex = 163;


            SkillFamily.Variant imp_U3variant = new SkillFamily.Variant();
            imp_U3variant.skillDef = Imp_Bomb;
            imp_U3variant.unlockableName = "IMP_U3";

            int I4prevLength = Imp_uFam.variants.Length;
            System.Array.Resize<SkillFamily.Variant>(ref Imp_uFam.variants, I4prevLength + 1);
            Imp_uFam.variants[I4prevLength] = imp_U3variant;



            //Clay Templar Skills
            GameObject ClayBruiserbodyfab = BodyCatalog.FindBodyPrefab("ClayBruiserBody");

            CharacterBody clayB_pod = ClayBruiserbodyfab.GetComponent<CharacterBody>();

            FootstepHandler clay_trail = ClayBruiserbodyfab.GetComponent<FootstepHandler>();


            clayB_pod.preferredPodPrefab = box;
            clayB_pod.crosshairPrefab = Resources.Load<GameObject>("prefabs/crosshair/StandardCrosshair");
            clayB_pod.baseRegen = 0.6f;
            clayB_pod.levelRegen = 0.15f;
            //clayB_pod.HasBuff(BuffIndex.AffixBlue);
            //clayB_pod.AddBuff(BuffIndex.AffixBlue);
            


            SkillLocator ClayBruiser_SL = ClayBruiserbodyfab.GetComponent<SkillLocator>();
            GenericSkill ClayBruiser_primary = ClayBruiser_SL.primary;
            GenericSkill ClayBruiser_secondary = ClayBruiser_SL.secondary;
            SkillFamily ClayBruiser_pFam = ClayBruiser_primary.skillFamily;
            SkillFamily ClayBruiser_sFam = ClayBruiser_secondary.skillFamily;
            SkillDef ClayBruiser_slot1 = ClayBruiser_pFam.variants[ClayBruiser_pFam.defaultVariantIndex].skillDef;
            SkillDef ClayBruiser_slot2 = ClayBruiser_sFam.variants[ClayBruiser_sFam.defaultVariantIndex].skillDef;

            ClayBruiser_slot1.skillNameToken = "Sandstorm";
            ClayBruiser_slot1.skillDescriptionToken = "Continously shoot Tar at enemies for <style=cIsDamage>30% damage.</style>";
            ClayBruiser_slot1.icon = ClayMinigun_Icon;

            ClayBruiser_slot2.skillNameToken = "Roar of Earth";
            ClayBruiser_slot2.skillDescriptionToken = "Spray a burst of Tar that covers enemies which <color=#95cde5>slows down movement speed and attack speed</color>. Also <color=#95cde5>knocks opponents back</color>.";
            ClayBruiser_slot2.icon = ClaySpray_Icon;


            //Jar Toss
            SkillDef Clay_gun2 = ScriptableObject.CreateInstance<SkillDef>();
            Clay_gun2.activationState = new SerializableEntityStateType("EntityStates.ClayBoss.ClayBossWeapon.ChargeBombardment");
            Clay_gun2.activationStateMachineName = "Weapon";
            Clay_gun2.icon = ClayJarToss_Icon;
            Clay_gun2.skillName = "Pot_Toss";
            Clay_gun2.skillNameToken = "Terravolley";
            Clay_gun2.skillDescriptionToken = "Launch a barrage of Jars filled with Tar that deal <style=cIsDamage>(5-11)x100% damage</style> each. Fires <style=cIsDamage>five</style> jars when pressed once.";
            Clay_gun2.interruptPriority = InterruptPriority.Skill;
            Clay_gun2.baseRechargeInterval = 2.34f;
            Clay_gun2.baseMaxStock = 1;
            Clay_gun2.rechargeStock = 1;
            Clay_gun2.isBullets = false;
            Clay_gun2.shootDelay = 0.3f;
            Clay_gun2.beginSkillCooldownOnSkillEnd = true;
            Clay_gun2.requiredStock = 1;
            Clay_gun2.stockToConsume = 1;
            Clay_gun2.isCombatSkill = true;
            Clay_gun2.noSprint = true;
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

            //Tar Bowling
            SkillDef Clay_melee3 = ScriptableObject.CreateInstance<SkillDef>();
            Clay_melee3.activationState = new SerializableEntityStateType("EntityStates.ClayBoss.FireTarball");
            Clay_melee3.activationStateMachineName = "Weapon";
            Clay_melee3.icon = ClayBowl_Icon;
            Clay_melee3.skillName = "Tar_Bowl";
            Clay_melee3.skillNameToken = "Clay Bowl";
            Clay_melee3.skillDescriptionToken = "Fire off <style=cIsDamage>three</style> large balls of Tar along the terrain that home in on opponents for <style=cIsDamage>100% damage</style> each. Covers opponents in Tar, which <color=#95cde5>slows down movement and attack speed</color>";
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


            //Gun Bash
            SkillDef Clay_melee2 = ScriptableObject.CreateInstance<SkillDef>();
            Clay_melee2.activationState = new SerializableEntityStateType("EntityStates.Paladin.DashSlam");
            Clay_melee2.activationStateMachineName = "Weapon";
            Clay_melee2.icon = WarioBash_Clay_Icon;
            Clay_melee2.skillName = "ClayTackle";
            Clay_melee2.skillNameToken = "Soldier Tackle";
            Clay_melee2.skillDescriptionToken = "A charging tackle that <color=#95cde5>stuns opponents, knocking them back</color> and dealing <style=cIsDamage>250% damage</style>.";
            Clay_melee2.interruptPriority = InterruptPriority.Skill;
            Clay_melee2.baseRechargeInterval = 3.33f;
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



            //Vulture Skills
            GameObject birb_body = BodyCatalog.FindBodyPrefab("VultureBody");

            CharacterBody birb_pod = birb_body.GetComponent<CharacterBody>();
            birb_pod.preferredPodPrefab = box;
            birb_pod.crosshairPrefab = Resources.Load<GameObject>("prefabs/crosshair/TreebotCrosshair");

            //Transform Testis = birb_pod.aimOriginTransform;
            //Testis.localScale += new Vector3(-0.5f, -0.5f, -0.5f);
            //Testis.position += new Vector3(0, 0, -2);

            SkillLocator birb_SL = birb_body.GetComponent<SkillLocator>();
            GenericSkill birb_feather = birb_SL.primary;
            GenericSkill birb_flight = birb_SL.utility;
            SkillFamily birb_feather_data = birb_feather.skillFamily;
            SkillFamily birb_flight_data = birb_flight.skillFamily;
            SkillDef vultureFeather = birb_feather_data.variants[birb_feather_data.defaultVariantIndex].skillDef;
            SkillDef vultureFlight = birb_flight_data.variants[birb_flight_data.defaultVariantIndex].skillDef;

            vultureFeather.skillNameToken = "Carrion Windblade";
            vultureFeather.skillDescriptionToken = "Fling a crescent-shaped gust of wind at foes for <style=cIsDamage>225% damage.</style>";
            vultureFeather.icon = VultureWindblade_Icon;

            vultureFlight.skillNameToken = "Flight";
            vultureFlight.skillDescriptionToken = "Transition from Standing to Flying. Rise and fall by using the Camera and forward/backward.";
            //vultureFlight.icon = VultureFlight_Icon;


            //Vulture Primary Variant
            SkillDef Vulture_P2 = ScriptableObject.CreateInstance<SkillDef>();
            Vulture_P2.activationState = new SerializableEntityStateType("EntityStates.RoboBallBoss.Weapon.ChargeSuperEyeblast");
            Vulture_P2.activationStateMachineName = "Weapon";
            Vulture_P2.icon = VultureSuperBall_Icon;
            Vulture_P2.skillName = "BIRB_BALLS";
            Vulture_P2.skillNameToken = "Wrath of the Alloys";
            Vulture_P2.skillDescriptionToken = "Fire a <color=#95cde5>horizontal/vertical</color> blast of energy balls that deal <style=cIsDamage>100% damage</style> and <color=#95cde5>burn the ground for 5 seconds</color>. <style=cIsHealth>Knocks you back as well...</style>";
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


            

            //G.S.M. Drone Skills
            GameObject Drone1bodyfab = BodyCatalog.FindBodyPrefab("Drone1Body");
            Drone1bodyfab.AddComponent<EquipmentSlot>();
         
            CharacterBody Drone1_pod = Drone1bodyfab.GetComponent<CharacterBody>();
            Drone1_pod.preferredPodPrefab = box;
            Drone1_pod.crosshairPrefab = Resources.Load<GameObject>("prefabs/crosshair/StandardCrosshair");
            
            SkillLocator Drone1_SL = Drone1bodyfab.GetComponent<SkillLocator>();
            GenericSkill Drone1_primary = Drone1_SL.primary;

            SkillFamily Drone1_pFam = Drone1_primary.skillFamily;
            SkillDef Drone1_slot1 = Drone1_pFam.variants[Drone1_pFam.defaultVariantIndex].skillDef;

            Drone1_slot1.skillNameToken = "STOCK: Standard SA Gun";
            Drone1_slot1.skillDescriptionToken = "Fire a volley of 4 rounds that deals <style=cIsDamage>4x50% damage</style>.";
            Drone1_slot1.icon = GunnerDrone_Icon;

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


            //Gunner Drone Variant 2
            SkillDef GunnerDrone_Gun3 = ScriptableObject.CreateInstance<SkillDef>();
            GunnerDrone_Gun3.activationState = new SerializableEntityStateType("EntityStates.Paladin.PaladinWeapon.FireRocket");
            GunnerDrone_Gun3.activationStateMachineName = "Weapon";
            GunnerDrone_Gun3.icon = RocketDrone_Icon;
            GunnerDrone_Gun3.skillName = "DRONE_MISSILE";
            GunnerDrone_Gun3.skillNameToken = "UPGRADE: Rocket Launcher";
            GunnerDrone_Gun3.skillDescriptionToken = "Fire a large rocket for <style=cIsDamage>220% damage</style>. Deals <style=cIsDamage>splash damage</style> as well.";
            GunnerDrone_Gun3.interruptPriority = InterruptPriority.Skill;
            GunnerDrone_Gun3.baseRechargeInterval = 0.73f;
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
            GunnerDrone_Gun4.icon = MissileDrone_Icon;
            GunnerDrone_Gun4.skillName = "DRONE_MISSILE_BARRAGE";
            GunnerDrone_Gun4.skillNameToken = "EXPERIMENTAL: Ballistic Missile Barrage";
            GunnerDrone_Gun4.skillDescriptionToken = "Launch a barrage of 4 <color=#95cde5>homing missiles</color> that deals <style=cIsDamage>4x90% damage</style>.";
            GunnerDrone_Gun4.interruptPriority = InterruptPriority.Skill;
            GunnerDrone_Gun4.baseRechargeInterval = 1.33f;
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
            EngiWalkerTurretbodyfab.AddComponent<EquipmentSlot>();

            CharacterBody EngiWalkerTurret_pod = EngiWalkerTurretbodyfab.GetComponent<CharacterBody>();
            EngiWalkerTurret_pod.preferredPodPrefab = pod;
            EngiWalkerTurret_pod.crosshairPrefab = Resources.Load<GameObject>("prefabs/crosshair/BanditCrosshair");
            EngiWalkerTurret_pod.bodyFlags = CharacterBody.BodyFlags.SprintAnyDirection;
            EngiWalkerTurret_pod.baseNameToken = "RC-TR58 Carbonizer Turret";
            EngiWalkerTurret_pod.subtitleNameToken = "The Engi's Finest Creation";

            //Transform Testis = EngiWalkerTurret_pod.aimOriginTransform;
            //Testis.localScale += new Vector3(-0.5f, -0.5f, -0.5f);
            //Testis.position += new Vector3(0, 1, 0);


            SkillLocator EngiWalkerTurret_SL = EngiWalkerTurretbodyfab.GetComponent<SkillLocator>();
            GenericSkill EngiWalkerTurret_primary = EngiWalkerTurret_SL.primary;
            SkillFamily EngiWalkerTurret_pFam = EngiWalkerTurret_primary.skillFamily;
            SkillDef EngiWalkerTurret_slot1 = EngiWalkerTurret_pFam.variants[EngiWalkerTurret_pFam.defaultVariantIndex].skillDef;

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
            Walker_Beam2.icon = GunnerTurret_Icon;
            Walker_Beam2.skillName = "Walker_Beam_2";
            Walker_Beam2.skillNameToken = "Jury-Rigged Gatling Gun";
            Walker_Beam2.skillDescriptionToken = "Fire a gatling-gun that deals <style=cIsDamage>42x30% damage</style>.";
            Walker_Beam2.interruptPriority = InterruptPriority.Any;
            Walker_Beam2.baseRechargeInterval = 1.75f;
            Walker_Beam2.baseMaxStock = 42;
            Walker_Beam2.rechargeStock = 3;
            Walker_Beam2.isBullets = true;
            Walker_Beam2.shootDelay = 0.1f;
            Walker_Beam2.beginSkillCooldownOnSkillEnd = false;
            Walker_Beam2.requiredStock = 1;
            Walker_Beam2.stockToConsume = 1;
            Walker_Beam2.isCombatSkill = true;
            Walker_Beam2.noSprint = true;
            Walker_Beam2.canceledFromSprinting = true;
            Walker_Beam2.mustKeyPress = false;
            Walker_Beam2.fullRestockOnAssign = false;
            Walker_Beam2.skillIndex = 154;

            SkillFamily.Variant WT_variant2 = new SkillFamily.Variant();
            WT_variant2.skillDef = Walker_Beam2;
            WT_variant2.unlockableName = "WT_B2";

            int WT2prevLength = EngiWalkerTurret_pFam.variants.Length;
            System.Array.Resize<SkillFamily.Variant>(ref EngiWalkerTurret_pFam.variants, WT2prevLength + 1);
            EngiWalkerTurret_pFam.variants[WT2prevLength] = WT_variant2;


            //Walker Beam Variant 3
            SkillDef walker_beam4 = ScriptableObject.CreateInstance<SkillDef>();
            walker_beam4.activationState = new SerializableEntityStateType("EntityStates.GlobalSkills.LunarNeedle.FireLunarNeedle");
            walker_beam4.activationStateMachineName = "Weapon";
            walker_beam4.icon = GunnerTurret_Icon;
            walker_beam4.skillName = "Walker_Beam_4";
            walker_beam4.skillNameToken = "Occular Blast";
            walker_beam4.skillDescriptionToken = "Fire homing energy crystals that stick to enemies and explode for <style=cIsDamage>12x150% damage</style>.";
            walker_beam4.interruptPriority = InterruptPriority.Any;
            walker_beam4.baseRechargeInterval = 1f;
            walker_beam4.baseMaxStock = 24;
            walker_beam4.rechargeStock = 6;
            walker_beam4.isBullets = true;
            walker_beam4.shootDelay = 0f;
            walker_beam4.beginSkillCooldownOnSkillEnd = false;
            walker_beam4.requiredStock = 1;
            walker_beam4.stockToConsume = 1;
            walker_beam4.isCombatSkill = true;
            walker_beam4.noSprint = true;
            walker_beam4.canceledFromSprinting = false;
            walker_beam4.mustKeyPress = false;
            walker_beam4.fullRestockOnAssign = true;
            walker_beam4.skillIndex = 164;

            SkillFamily.Variant WT_variant4 = new SkillFamily.Variant();
            WT_variant4.skillDef = walker_beam4;
            WT_variant4.unlockableName = "WT_B4";

            int WT4prevLength = EngiWalkerTurret_pFam.variants.Length;
            System.Array.Resize<SkillFamily.Variant>(ref EngiWalkerTurret_pFam.variants, WT4prevLength + 1);
            EngiWalkerTurret_pFam.variants[WT4prevLength] = WT_variant4;

            //Test Skills
            GameObject testPrefab = BodyCatalog.FindBodyPrefab("NullifierBody");
            CharacterBody testBody = testPrefab.GetComponent<CharacterBody>();
            testBody.preferredPodPrefab = box;
            

            Transform Testis = testBody.aimOriginTransform;
            //Testis.localScale += new Vector3(-2f, -2f, -2f);
            Testis.position += new Vector3(0, -5f, 10);
            


        }

        public void Awake()
        {

            var lemurian_display = Resources.Load<GameObject>("prefabs/characterbodies/LemurianBody").GetComponent<RoR2.ModelLocator>().modelTransform.gameObject;
            lemurian_display.AddComponent<Lemurian_Display>();


            var imp_display = Resources.Load<GameObject>("prefabs/characterbodies/ImpBody").GetComponent<RoR2.ModelLocator>().modelTransform.gameObject;
            imp_display.AddComponent<Imp_Display>();

            var clay_display = Resources.Load<GameObject>("prefabs/characterbodies/claybruiserbody").GetComponent<RoR2.ModelLocator>().modelTransform.gameObject;
            clay_display.AddComponent<Clay_Display>();

            var birb_display = Resources.Load<GameObject>("prefabs/characterbodies/Vulturebody").GetComponent<RoR2.ModelLocator>().modelTransform.gameObject;
            birb_display.AddComponent<Birb_Display>();

            var drone_display = Resources.Load<GameObject>("prefabs/characterbodies/Drone1Body").GetComponent<RoR2.ModelLocator>().modelTransform.gameObject;
            drone_display.AddComponent<Drone_Display>();

            var walker_display = Resources.Load<GameObject>("prefabs/characterbodies/EngiWalkerTurretBody").GetComponent<RoR2.ModelLocator>().modelTransform.gameObject;
            walker_display.AddComponent<Walker_Display>();
            
            
            //var test_display = Resources.Load<GameObject>("prefabs/characterbodies/GravekeeperBody").GetComponent<RoR2.ModelLocator>().modelTransform.gameObject;
            //test_display.AddComponent<Test_Display>();
            

            //Lemurian
            var Lemur_Surv = new SurvivorDef
            {

                
                bodyPrefab = Resources.Load<GameObject>("prefabs/characterbodies/LemurianBody"),
                descriptionToken = "The Lemurian is the very definition of struggle. Weak and fragile, but determined to rise to the top of the food chain." +
                "\n\n<style=cSub>< i > Gets <style=cIsHealth>stunned easily</style>. Only engage in hand-to-hand if absolutely necessary or confident!" +
                "\n\n< i > Due to their bizarre physiology, <style=cIsHealth>they cannot use some healing-based items.</style></color>",
                displayPrefab = lemurian_display,
                primaryColor = new Color(0.4901960784f, 0.1490196078f, 0.8039215686f),
                unlockableName = "Lemur"
                
            };

            //Imp
            var Imp_Surv = new SurvivorDef
            {
                bodyPrefab = Resources.Load<GameObject>("prefabs/characterbodies/ImpBody"),
                descriptionToken = "An aspiring peon that seeks to please its Overlord by sacrificing many creatures. It is using the chaos caused by the bizarre visitors to achieve its goal swiftly." +
                "\n\n<style=cSub>" +
                "< i > The Bleed from its 'Rend Flesh' stacks, so make sure that both claws hit your opponent for maximum damage output!" +
                "\n\n< i > Has great mobility, meaning it can double jump and avoid fall damage!" +
                "\n\n< i > 'Providence's Rapture' always brings you to the same fixed point on each map. Learn these points and plan accordingly!" +
                "\n\n< i > In order to stun enemies a second time with Shadow Sneak, you must attack out of it." +
                "\n\n< i > Shadow Sneak also gives the Imp a burst of speed for increased sneak potential." +
                "\n\n< i > If you hit an enemy with 3 null_skill Bombs, they will be bound in Void Energy, rendering them unable to move for roughly 3-4 seconds!" +
                "</style>",
                displayPrefab = imp_display,
                primaryColor = new Color(0.6156862745f, 0.07450980392f, 0.07450980392f),
                unlockableName = "Imp"
            };

            

            //Clay Templar
            var ClayB_Surv = new SurvivorDef
            {
                bodyPrefab = Resources.Load<GameObject>("prefabs/characterbodies/claybruiserbody"),
                descriptionToken = "A wandering Clayman. It got seperated from its Dunestrider some time ago. Leaderless and without purpose, it now wanders the planet searching for strong creatures to fight in an effort to validate its solitary existance. " +
                "\n\n<style=cSub>" +
                "< i > Sandstorm gets more accurate the closer you are to a target." +
                "\n\n< i > Sandstorm has a slow start-up and slows you down while using it." +
                "\n\n< i > Due to their bizarre physiology, <style=cIsHealth>they cannot use some healing-based items.</style>" +
                "\n\n< i > Terravolley's Jars will travel to wherever the <u>center</u> of the crosshair is pointing. Aim true! " +
                "\n\n< i > Clay Bowl will always travel along the ground and slightly home in on enemies." +
                "</color>",
                displayPrefab = clay_display,
                primaryColor = new Color(0.9568627451f, 0.6431372549f, 0.3764705882f),
                unlockableName = "Buff_Tarboy"

            };

            //Vulture
            var Birb_Surv = new SurvivorDef
            {
                bodyPrefab = Resources.Load<GameObject>("prefabs/characterbodies/vulturebody"),
                descriptionToken = "After having many of its eggs broken by the strange newcomers, one of the Vultures decided to drop its opportunistic lifestyle and hunt down the trespassers. " +
                "\n\n<style=cSub>< ! > When landing, you will automatically drift towards the nearest solid surface" +
                "\n\n< i > 'Wrath of the Alloys' randomly transitions from a vertical volley and a horizontal volley. It also has intense knockback due to its power.</color>",
                displayPrefab = birb_display,
                primaryColor = new Color(0.06274509804f, 0.5019607843f, 0.4392156863f),
                unlockableName = "Carrion Pigeon"
            };

            //GSM Drone
            var Gun_Drone = new SurvivorDef
            {
                bodyPrefab = Resources.Load<GameObject>("prefabs/characterbodies/Drone1Body"),
                descriptionToken = "Experimental Drone: G.S.M. Model. \nMulti-Purpose, Custom-Built Drone, combines the functionality of multiple units both civilian and military. NOT FOR RETAIL SALE!" +
                "\n\n<style=cSub>< i > Thus Unit is quick and nimble, but its chassis is somewhat fragile." +
                "\n\n< i > The mounted gun deals more damage the closer you are to an enemy, but less damage if you are too far." +
                "\n\n< i > The Missile Barrage rockets home in on the closest enemy, which can cause a problem if you are being overwhelmed.</style>",
                displayPrefab = drone_display,
                primaryColor = new Color(0.3176470588f, 0.5647058824f, 0.9294117647f),
                unlockableName = "GDrone"

            };

            //Engineer Walker Turret
            var Engi_Walker = new SurvivorDef
            {
                bodyPrefab = Resources.Load<GameObject>("prefabs/characterbodies/EngiWalkerTurretBody"),
                descriptionToken = "<i>No way in Hell am I going down there! I'll send in one of my new Walker Turrets instead!</i>" +
                "\n~The Engineer when asked by Loader to do some scavenging on the surface of the planet." +
                "\n\n<style=cSub>< i > Can easily walk up steep slopes\n\n< i > The TR58 Carbonizer Beam has a short-range, and isn't affected by attack-speed buffs." +
                "\n\n< i >The Gatling Gun has a 2-Second reload between each batch of bullets." +
                "\n\n< i >The Occular Blast is a more refined version of the in-game Lunar Item. Thanks, Engie!" +
                "\n\n< i ><style=cIsHealth><u> WILL NOT WORK IN MULTIPLAYER!!!</u></style></style>",
                displayPrefab = walker_display,
                primaryColor = new Color(0.3019607843f, 0.7490196078f, 0.4392156863f),
                unlockableName = "EngiWalker"

            };

            
            //Test
            SurvivorDef test = new SurvivorDef
            {
                bodyPrefab = Resources.Load<GameObject>("prefabs/characterbodies/nullifierBody"),
                descriptionToken = "Experiment 5A",
                displayPrefab = Resources.Load<GameObject>("prefabs/characterbodies/nullifierBody"),
                primaryColor = new Color(0.3019607843f, 0.7490196078f, 0.4392156863f),
                unlockableName = "EngiWalker"

            };
            

            R2API.SurvivorAPI.AddSurvivor(Engi_Walker);
            R2API.SurvivorAPI.AddSurvivor(Gun_Drone);
            R2API.SurvivorAPI.AddSurvivor(Lemur_Surv);
            R2API.SurvivorAPI.AddSurvivor(Imp_Surv);
            R2API.SurvivorAPI.AddSurvivor(ClayB_Surv);
            R2API.SurvivorAPI.AddSurvivor(Birb_Surv);
            //R2API.SurvivorAPI.AddSurvivor(test);



        }


        //Lemur Display
        public class Lemurian_Display : MonoBehaviour
        {
            
            
            internal void OnEnable()
            {
                
                if (gameObject.transform.parent.gameObject.name == "CharacterPad")
                {
                    Debug.Log("Lemurian Display - - - SUCCESS!");
                    var animator = gameObject.GetComponent<Animator>();
                    Shooting(animator);

                }
                else
                {
                    Debug.Log("");
                    //transform.localScale += new Vector3(1.5f, 1.5f, 1.5f);
                }
            }

            private void Shooting(Animator animator)
            {
                PlayAnimation("Body", "Spawn1", "Spawn1.playbackRate", 1, animator);
                transform.Translate(0f, 0, -1f);
                transform.localScale += new Vector3(-0.02f, -0.02f, -0.02f);


            }       
            private void PlayAnimation(string layerName, string animationStateName, string playbackRateParam, float duration, Animator animator)
            {
                int layerIndex = animator.GetLayerIndex(layerName);
                animator.SetFloat(playbackRateParam, 1f);
                animator.PlayInFixedTime(animationStateName, layerIndex, 0f);
                animator.Update(0f);
                float length = animator.GetCurrentAnimatorStateInfo(layerIndex).length;
                animator.SetFloat(playbackRateParam, length / duration);

            }          
        }


        //Imp Display
        private class Imp_Display : MonoBehaviour
        {
            internal void OnEnable()
            {
                if (gameObject.transform.parent.gameObject.name == "CharacterPad")
                {
                    Debug.Log("Imp Display - - - SUCCESS!");
                    var animator = gameObject.GetComponent<Animator>();
                    Shooting(animator);

                }
                else
                {
                    Debug.Log("");
                }
            }

            private void Shooting(Animator animator)
            {
                PlayAnimation("Body", "Hurt1", "Hurt1.playbackRate", 1f, animator);
                transform.Translate(0.0f, 0, -1f);
                transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
                //transform.Rotate(0, 125, 0);
                //GameObject

            }


           

            private void PlayAnimation(string layerName, string animationStateName, string playbackRateParam, float duration, Animator animator)
            {
                int layerIndex = animator.GetLayerIndex(layerName);
                animator.SetFloat(playbackRateParam, 1f);
                animator.PlayInFixedTime(animationStateName, layerIndex, 0f);
                animator.Update(0f);
                float length = animator.GetCurrentAnimatorStateInfo(layerIndex).length;
                animator.SetFloat(playbackRateParam, length / duration);
            }
        }

        
        //Clay T. Display
        private class Clay_Display : MonoBehaviour
        {
            internal void OnEnable()
            {
                if (gameObject.transform.parent.gameObject.name == "CharacterPad")
                {
                    Debug.Log("animation");
                    var animator = gameObject.GetComponent<Animator>();
                    Shooting(animator);

                }
                else
                {
                    Debug.Log("");

                }
            }
            private void Shooting(Animator animator)
            {
                PlayAnimation("Body", "Spawn", "Spawn.playbackRate", 1.3f, animator);

                //Enable this for a slo-mo on the Clay's Spawn animation
                //PlayAnimation("Body", "Spawn", "Spawn.playbackRate", 15, animator);

                transform.Translate(0.8f, 0, -1f);
                transform.localScale += new Vector3(-2.05f, -0.05f, -2.05f);
                transform.Rotate(0, 125, 0);
            }

            private void PlayAnimation(string layerName, string animationStateName, string playbackRateParam, float duration, Animator animator)
            {
                int layerIndex = animator.GetLayerIndex(layerName);
                animator.SetFloat(playbackRateParam, 1f);
                animator.PlayInFixedTime(animationStateName, layerIndex, 0f);
                animator.Update(0f);
                float length = animator.GetCurrentAnimatorStateInfo(layerIndex).length;
                animator.SetFloat(playbackRateParam, length / duration);
            }
        }


        //Vulture Display
        private class Birb_Display : MonoBehaviour
        {
            internal void OnEnable()
            {
                if (gameObject.transform.parent.gameObject.name == "CharacterPad")
                {
                    Debug.Log("Vulture Display - - - SUCCESS!");
                    var animator = gameObject.GetComponent<Animator>();
                    Shooting(animator);

                }
                else
                {
                    Debug.Log("");
                }
            }
            private void Shooting(Animator animator)
            {
                PlayAnimation("Body", "Spawn", "Spawn.playbackRate", 1, animator);

                transform.Translate(0f, 0, -1f);
                transform.localScale += new Vector3(-0.05f, -0.05f, -0.05f);
            }

            private void PlayAnimation(string layerName, string animationStateName, string playbackRateParam, float duration, Animator animator)
            {
                int layerIndex = animator.GetLayerIndex(layerName);
                animator.SetFloat(playbackRateParam, 1f);
                animator.PlayInFixedTime(animationStateName, layerIndex, 0f);
                animator.Update(0f);
                float length = animator.GetCurrentAnimatorStateInfo(layerIndex).length;
                animator.SetFloat(playbackRateParam, length / duration);
            }
        }


        //Drone Display
        private class Drone_Display : MonoBehaviour
        {
            internal void OnEnable()
            {
                if (gameObject.transform.parent.gameObject.name == "CharacterPad")
                {
                    Debug.Log("Drone Display - - - SUCCESS!");
                    var animator = gameObject.GetComponent<Animator>();
                    Shooting(animator);

                }
                else
                {
                    Debug.Log("");
                }
            }
            private void Shooting(Animator animator)
            {
                PlayAnimation("Body", "Idle", "Idle.playbackRate", 3, animator);

                transform.Translate(0f, 1f, -0.5f);
                transform.Rotate(0, 160f, 0);
            }

            private void PlayAnimation(string layerName, string animationStateName, string playbackRateParam, float duration, Animator animator)
            {
                int layerIndex = animator.GetLayerIndex(layerName);
                animator.SetFloat(playbackRateParam, 1f);
                animator.PlayInFixedTime(animationStateName, layerIndex, 0f);
                animator.Update(0f);
                float length = animator.GetCurrentAnimatorStateInfo(layerIndex).length;
                animator.SetFloat(playbackRateParam, length / duration);
            }
        }


        //Walker Display
        private class Walker_Display : MonoBehaviour
        {
            internal void OnEnable()
            {
                if (gameObject.transform.parent.gameObject.name == "CharacterPad")
                {
                    Debug.Log("Walker Display - - - SUCCESS!");
                    var animator = gameObject.GetComponent<Animator>();
                    Shooting(animator);

                }
                else
                {
                    Debug.Log("");
                }
            }
            private void Shooting(Animator animator)
            {
                PlayAnimation("Body", "Spawn", "Spawn.playbackRate", 1.11f, animator);
                transform.localScale += new Vector3(-1f, 0f, 0f);
                transform.Translate(0f, 0f, -0.5f);
                transform.Rotate(0f, -107f, 0f);
            }

            private void PlayAnimation(string layerName, string animationStateName, string playbackRateParam, float duration, Animator animator)
            {
                int layerIndex = animator.GetLayerIndex(layerName);
                animator.SetFloat(playbackRateParam, 1f);
                animator.PlayInFixedTime(animationStateName, layerIndex, 0f);
                animator.Update(0f);
                float length = animator.GetCurrentAnimatorStateInfo(layerIndex).length;
                animator.SetFloat(playbackRateParam, length / duration);
            }
        }

        /*
        //Test Display
        private class Test_Display : MonoBehaviour
        {


            

            internal void OnEnable()
            {
                if (gameObject.transform.parent.gameObject.name == "CharacterPad")
                {
                    Debug.Log("Test Display - - - SUCCESS!");
                    var animator = gameObject.GetComponent<Animator>();
                    Shooting(animator);

                }
                else
                {
                    GameObject zest = BodyCatalog.FindBodyPrefab("LemurianBody");
                    CharacterBody testbody = zest.GetComponent<CharacterBody>();
                    Debug.Log(testbody.isPlayerControlled);
                    //transform.Translate(0f, 0, -1f);
                    //transform.localScale += new Vector3(-0.2f, -0.2f, -0.2f);
                    transform.localScale += new Vector3(-0.65f, -0.65f, -0.65f);
                    

                }
            }

            private void Shooting(Animator animator)
            {
                PlayAnimation("Body", "Hurt1", "Hurt1.playbackRate", 1f, animator);
                transform.Translate(0.0f, 0, -1f);
                transform.localScale += new Vector3(-0.9f, -0.9f, -0.9f);
                //transform.Rotate(0, 125, 0);

            }

            private void PlayAnimation(string layerName, string animationStateName, string playbackRateParam, float duration, Animator animator)
            {
                int layerIndex = animator.GetLayerIndex(layerName);
                animator.SetFloat(playbackRateParam, 1f);
                animator.PlayInFixedTime(animationStateName, layerIndex, 0f);
                animator.Update(0f);
                float length = animator.GetCurrentAnimatorStateInfo(layerIndex).length;
                animator.SetFloat(playbackRateParam, length / duration);
            }
        }
        */




        //The Update() method is run on every frame of the game.
        public void Update()
        {


            //This if statement checks if the player has currently pressed F2, and then proceeds into the statement:
            if (Input.GetKeyDown(KeyCode.F4))
            {

                
                //We grab a list of all available Tier 3 drops:
                //var dropList = Run.instance.availableTier3DropList;

                //Chat.AddMessage("spell icup");
                //transform.Translate(0, 1, 0);

                //Randomly get the next item:
                //var nextItem = Run.instance.treasureRng.RangeInt(0, dropList.Count);

                //Get the player body to use a position:
                //var testy = PlayerCharacterMasterController.instances[0].master.GetBodyObject().transform;
                

                //And then finally drop it infront of the player.
                //PickupDropletController.CreatePickupDroplet(dropList[nextItem], transform.position, transform.forward * 20f);
            }



        }





    }
}
