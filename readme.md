# CampSim

- Author: Mike Wise
- Last Updated: 20 April 2020 - 15:08

## Prerequisites
- At least 20 GB of free space, 8 GB of memory, and as much CPU/GPU as possible, although GPU is not stricly necessary. 
- Visual Studio 2017 with Unity support installed, it can probably work with VS Code too, but it is not being used here.

## Installation instructions (probably obsolete)

1.	Make sure you have a recent version of Git (**git –version**, currently using 2.26.0.windows.1)
2.	Enable **git-lfs** for your user with **git lfs install**. If you don’t want to do this, you have to do step 7a and 7b (which is no big deal)
3.	Install Unity Hub (Currently using 2.3.0)
4.	Install a recent version of Unity (I am using 2019.3.7f1)
5.	Make sure Unity works (open it up add a sphere to a scene, move it around)
6.	Find a place where you will keep the project. It should have like 30+ GB free, preferably more so you can make safety clones quickly with no worries. 
7.  Make sure **git-lfs** is enabled, if not see the sub points below.
8.	Clone the **CampSim** project into a directory. Will take a few minutes, up to 10 if LFS is pulling down. 
    - a.	If you didn’t enable **git-lfs** globally, then after it has cloned, enter the directory and enable it locally (**git lfs install --local**) – see <https://github.com/git-lfs/git-lfs/wiki/Installation> for more inforamation
    - b.	Now do a **git pull** which should pull any missing lfs managed files that were left behind.
    - c.	The github repo is 1.86 GB (which is too big, waiting for a complaint email)
	 - d.	After cloning to disk it is like 5.86 GB
	 - e.	After compilation and using it for a while it will need around 12-13 GB.
	 - f.   Consider doing a **git pull -a** to get development branches
9.	From Hub, open the project. It should take a while to compile all the scripts, bake the texture maps, etc. the first time you open it (like 30 minutes)
	 - a.	The status bar sometimes doesn’t update if you don’t move the mouse. I assume it is still working in the background… very disconcerting.
	 - b.	This would probably be a lot faster if we removed some things that are no longer being used, like the floor plan bitmaps
10.	Go to **Assets/Resources/TreesAndShrubs** and see if the icons look like trees and shrubs. If not left click on each of them and do a **Reimport** individually to refresh the prefab instance.


## Testing
- TBD

## Problems and Solutions
**public const string InstantPreviewWarningPrefabPath =            "Assets/GoogleARCore/SDK/InstantPreview/Prefabs/Instant Preview Touch Warning.prefab";**
     -	File where (missing) line was referenced was: **D:\Unity\onefloortestforparking\Assets\GoogleARCore\SDK\InstantPreview\Scripts\InstantPreviewManager.cs**
     -	Reference was at line  54
     -	Saw this on both Windows and Ubuntu

- Console Error: "A Tree asset could not be loaded because the prefab is missing"
     -	Probably missed step 10 (i.e. the one about **TreesAndShrubs**) above. Otherwise you might need to re-import the **Treespackage** 

- Runs, but all the cars (and people now) are missing
     -   This happened to me when I imported without gif-lfs enabled, it wasn't importing the car textures so you didn't see them
