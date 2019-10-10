# Monstar Mod(e) by SadBoxMan

## Overview
This is a mod for Risk of Rain 2 that adds in a select few monsters and robots and gives each new skills for a new and challenging experience.

*A fun novelty and Proof-of-Concept that adds some challenge and even more replayability*

<br>

## Features
Includes ~~7~~ 6 new survivors:
  - The Lemurian
  - The Imp
  - The Clay Templar
  - The Alloy Vulture
  - The G.S.M. Unit (Multi-Function Drone)
  - The Engi's Walking Turret
  - ~~The TS-280 Prototype Drone~~
<br>
Adds in new Skill variations for alternate playstyles.
<br>Balancing for new survivor skills


## Skills Added
### Lemurian Skills:
#### Primary Variants:
- **Elder's Authority**
  - Fire 5 fireballs instead of 1
  - Taken directly from the Elder Lumerian
#### Secondary Variants:
- **Elder's Whisper**
  - Breathe fire and inflict burn on enemies
  - Also taken from the Elder Lumerian
  - Was originally a Primary SKill variant, but this led to situations where the Lemurian can't hit anything
    - *cough cough Vagrant*
- **Soldier Tackle (name WIP)**
  - Taken from the Unused Paladin character
  - Charge a short distance, then stun & knockback anything you hit
  - Also a decent way to move just a little faster
    - Can be used while sprinting!
    
<br>
 
### Imp Skills:
#### Passive:
- **Sprint in any direction**
  - The Imp is already floating everywhere, doesn't make much sense for it to not be able to just float at equal speeds in any direction
- **Take no fall damage**
  - The jump is naturally very high, and just 1 jump upgrade inflicts fall-damage
- **NOTE: PASSIVE FLAGS ONLY WORK IN SINGLE PLAYER. WHEN PLAYING ONLINE THEY BREAK**
#### Utility Variants:
- **Shadow Sneak (name WIP)**
  - Turn invisible for about 5ish seconds. Stuns enemies on activation and on attacking out of it
  - Taken from the Unused Bandit character
    - Known as [banditbodycloak] internally
  - Lowered the cooldown so that the Imp has more of an edge in battle
- **Providence's Rapture {name WIP}**
  - Teleports the player to a fixed location on the map, usually very high in the sky
  - Taken from the Imp Boss 
  - It is actually broken, but at the same time it adds a bit of strategy to the Imp's Playstyle
    - Teleport to a safe, fixed location.... Which is usually very high in the sky (hence the Fall Damage change)

<br>

### Clay Templar Skills:
#### Primary Variants:
- **Terravolley**
  - Taken from the Dunestrider Boss, it fires jars filled with tar at foes.
  - Fires 5 - 11 jars depending on how long you hold the button for
  - Auto-travels to where the cursor is at the time of firing
    - This means that it can go clear across the map if aimed properly
#### Secondary Variants:
- **Soldier Bash (name WIP)**
  - Taken from the Unused Paladin character
  - Charge a short distance, then stun & knockback anything you hit
  - Also a decent way to move just a little faster
    - Can be used while sprinting!
- **Clay Bowl (Name WIP)**
  - Also taken from the Dunestrider boss
  - Fires ~3-4 giant balls of tar that follow the terrain
  - Also has the added bonus of homing in on nearby creatures
  - Can't do jack against airborne targets
  - **HAS A BUG IN MULTIPLAYER, SEE BUG NOTES BELOW FOR DETAILS**

<br>

### Alloy Vulture Skills:
#### Primary Variants:
- **Wrath of the Alloys (name WIP?)**
  - Fire 7(?) balls of energy that burn the ground for 5 seconds
    - Has intense knockback
  - **Has a known bug with Multiplayer (documented below in the "Known Bugs" section)**
<br>

### Drone Skills
#### Primary Variants:
- **STOCK: Standard S.A. Gun**
  - 4-shot burst. Rather weak on its own.
- **UPGRADE: Overclocked Strike-Gun**
  - Just a beefed-up version of the base skill
     - A tad overpowered by the time you get to area 3/4
  - Taken from the Backup/Strike Drone
- **UPGRADE: CR0CK37 Launcher**
  - Fire a large rocket
    - Also includes Splash Damage
  - Taken from the Unused Paladin character
    - Tweaked *heavily* to best fit the Drone
- **EXPERIMENTAL: Homing Missile Barrage**
  - Fire 4 small missiles that home in the nearest enemy
    - Always homes in on the **closest** enemy relative to your position
  - **Has a known bug with Multiplayer (documented below in the "Known Bugs" section)**


<br>

### Walker-Turret Skills
#### **WILL NOT WORK IN MULTIPLAYER**
#### Primary Variants:
- **TR12 Gauss Cannon**
  - It's just the Engineer's Base Turret's Gun...
- **Gatling Gun (name WIP)**
  - 40 shots with a 2 second cooldown when you run out of ammunition
 
<br>

## Plans
- [ ] Add more Survivors(?)
  - [x] Remove Mega Drone(?)
- [x] Add lore-friendly flavor text
  - [ ] Balance skills to better fit the survivors
- [x] Fix general Multiplayer Compatibility
  - [ ] Fix other Multiplayer Bugs
- [ ] Change Walker Turret's Name to match it's actual name
- [ ] Add new icons for all new skills
  - [x] Find someone who knows how to draw
- [ ] Add in Display Prefabs for each new survivor
- [ ] Add Skin functionality

<br>

## Known Bugs
- Skill Variants won't even show up if you don't have at least 1 variant unlocked already for the base survivors
- Many Skills aren't animated properly and may look a bit goofy
- Imp's "Providence's Rapture" skill is technically a glitch all on its own

<br>

### Various Multiplayer Bugs
  - Vulture's "Wrath of the Alloys" only has knockback for the Host
  - Walker Turret only works for the Host
  - Icons do not show up in-game for other players
  - Drone's "Missile Barrage" has a mild graphical glitch
  - Imp's "Passive Skills" do not work for anyone online

  
<br>

## Special Thanks
- Rein - For their Skill Utility Code
- The Risk of Rain 2 Modding Discord - For being a huge help and helping me debug this hot mess

<br>
 
## Dependencies
- BepinEX
- R2API
- ROR 

<br>

# Installation
###  With BepInEx
 1. Extract "Monstar Mod.dll" from the zip file and place it into  "/Risk of Rain 2/BepInEx/plugins/Monstar Mod/" folder.
 2. Extract the "Assets" Folder and place in the same folder as "Monstar Mod.dll"
 3. If everything is done correctly, the Monstar Mod folder will have "Monstar Mod.dll" and a folder called "Assets"
 4. Enjoy!
