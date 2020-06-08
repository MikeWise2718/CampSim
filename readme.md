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

## Check-in New Version
1. Assuming you are on a feature branch, and the master is on master.
2. Assume master is dual-remoted, one to the github repo, and one to the azurerepos for building on ADO
3. Make sure all the version info is updated
   - a. Build version in InfoPanel.cs
   - b. Startup screen shot is annotated if needed
4. Squash all the commits down to one 
   - a. easy with lazygit, ? for help - basically s then enter)
   - b. i to rename the git expereience
5. Now see if it builds to a BuildWin
6. Force push it (`git push force`) to override the `tip ahead of branch on remote` message 
7. Go to Github and do a pull request on master - make some comments for fun
8. It should merge, their might be conflicts (git isn't perfect')
9. If there are conflicts - not sure how this goes - if not continue
10. go to master branch and pull new master
11. Push to azureepos
12. Go to ADO and build it




## Startup screen shot
1. Assume you have a png - put it in _textures.
2. Duplicate it.
3. Change to Sprite 
   - a. In Inspector from Project View, 
   - b. look at Texture Type and change from `Default` to `Sprite (2D and UI)`), 
   - c. it will have a sprite then as a sub-object
   - d. you can change it back if you want
4. Now go to player settings and change the startup 
   - Warning! note that there is a seperate VR startup icon first in the list, don't change that one by mistake and think you have it

## Testing
- TBD

## ToDos
- A lot of those enum regions (like in BuildingMan) can probably be elimanated 
- Timings for builds
- why is the quadcopter rotating when I move it?

## Problems and Solutions
- Console Error: "A Tree asset could not be loaded because the prefab is missing"
     -	Probably missed step 10 (i.e. the one about **TreesAndShrubs**) above. Otherwise you might need to re-import the **Treespackage** 

- Runs, but all the cars (and people now) are missing
     -   This happened to me when I imported without gif-lfs enabled, it wasn't importing the car textures so you didn't see them
