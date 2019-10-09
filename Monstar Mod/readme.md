# Monstar Mod(e) by SadBoxMan

## Overview
This is a mod for Risk of Rain 2 that adds in a select few monsters and robots and gives each new skills for a new and challenging experience.

> *For people who have some experience with Risk of Rain 2 and want something fun and challenging in between updates.*

<br>

## Installation
1. Place  MonstarMod.dll into its own folder inside of BEPINEX's "plugins" folder
2. Place the "assets" folder inside of the same folder that MonstarMod.dll is in
3. Enjoy!

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
- Elder's Authority
  - Fire 5 fireballs instead of 1
  - Taken directly from the Elder Lumerian
#### Secondary Variants:
- Elder's Whisper
  - Breathe fire and inflict burn on enemies
  - Also taken from the EL
  - Was originally a Primary SKill variant, but this led to situations where the Lemurian can't hit anything
    - *cough cough Vagrant*
- Soldier Tackle (name WIP)
  - Taken from the Unused Paladin character
  - Charge a short distance, then stun & knockback anything you hit
  - Also a decent way to move just a little faster
    - Can be used while sprinting!
  - I may remove it from the Lemurian since it fits better with the Clay Templar.
    - Then again, it's a helluva lot of fun since the Lemurian is just a helmet away from being a football player
    
<br>
 
### Imp Skills:
#### Utility Variants:
- Providence's Kiss (name WIP)
  - Turn invisible for about 5ish seconds. Stuns enemies on activation and on attacking out of it
  - Taken from the Unused Bandit character
    - Known as [banditbodycloak] internally
  - Lowered the cooldown so that the Imp has more of an edge in battle
- Providence's Rapture {name WIP}
  - Teleports the player to a fixed location on the map, usually very high in the sky
  - Taken from the Imp Boss 
  - It is actually broken, but at the same time it adds a bit of strategy to the Imp's Playstyle
    - ~~Teleport to a safe, fixed location at the expense of possible fall damage due to the height of the location.~~
    - No fall damage in Single Player


<br>

### Clay Templar Skills:
#### Primary Variants:
- Terravolley
  - Taken from the Dunestrider Boss, it fires jars filled with tar at foes.
  - Fires 5 - 11 jars depending on how long you hold the button for
  - Auto-travels to where the cursor is at the time of firing
    - This means that it can go clear across the map if aimed properly
#### Secondary Variants:
- Soldier Bash (name WIP)
  - Taken from the Unused Paladin character
  - Charge a short distance, then stun & knockback anything you hit
  - Also a decent way to move just a little faster
    - Can be used while sprinting!
- Clay Bowl (Name WIP)
  - Also taken from the Dunestrider boss
  - Fires ~3-4 giant balls of tar that follow the terrain
  - Also has the added bonus of homing in on nearby creatures
  - Can't do jack against airborne targets

<br>

### Alloy Vulture Skills:
#### Primary Variants:
- Wrath of the Alloys (name WIP?)
  - Fire 7(?) balls of energy that burn the ground for 5 seconds
    - Has intense knockback
  - Taken from the Secret Alloy Boss (the one you have to fight to unlock Loader)
  - Has a known bug with Multiplayer (documented below in the "Known Bugs" section)
    - Also needs further tweaking to justify the knockback penalty.

<br>

### Drone Skills
#### Primary Variants:
- STOCK: Standard S.A. Gun
  - 4-shot burst. Rather weak on its own.
- UPGRADE: Overclocked Gun
  - Just a beefed-up version of the base skill
     - A tad overpowered by the time you get to area 3/4
  - Taken from the Backup/Strike Drone
- UPGRADE: Rocket Launcher
  - Fire a big ol' rocket (splash damage included)
  - Taken from the unused Paladin character
    - Tweaked a great deal since the base stats cause... problems
- EXPERIMENTAL: Homing Missile Barrage
  - Should be a good weapon, but it actually has a fatal flaw:
    - Rockets will ALWAYS home in on the nearest target
  - I may replace this with the Paladin's rocket in the future
    - Make it more like a rocket launcher instead of a Lazy-EZ-Gun

<br>

### Walker-Turret Skills
#### Primary Variants:
- Gauss Cannon
  - It's just the Engineer's Base Turret's Gun...
- Gatling Gun (name WIP)
  - Same as the Gauss Cannon, but taken from the stationary Turrets instead
  - I plan on tweaking the functionality to make it a bit more interesting and not simply another damn gatling gun
 
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
- Multiplayer Bugs:
  - Vulture's "Wrath of the Alloys" only has knockback for the Host
  - Walker Turret only works for the Host
  - Icons do not show up in-game for other players
  - Drone's "Missile Barrage" has a mild graphical glitch
  - Templar's Clay Bowl locks other players in place during activation
  - Imp takes fall damage and cannot sprint in all directions
  
<br>

## Special Thanks
- Herb - For their Skill Utility Boiler-Plate Code
- The Risk of Rain 2 Modding Discord - For being a huge help and helping me debug this hot mess

<br>
 
## Dependencies
- BepinEX
- R2API
- ROR 
