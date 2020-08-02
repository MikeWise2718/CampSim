# CampSim

- Author: Mike Wise
- Last Updated: 23 June 2020 - 15:08

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
   - a. Build version in GraphUtil.cs (search for `_verstring`)
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


## Architectural Notes to CampusSimulator - Mike Wise - 1 Aug 2020
Ideally a program should have tight cohesion in its components and loose coupling between them, also variable and procedure names chosen so as to be self-documenting. 
Unfortunately, here that proves to be quite a problem. Tight-cohesion is fairly easy, but loose coupling is very difficult, mostly because our objects have multiple dependencies on one another. 
Here we analyze that.

### Overview
We have various scenarios, that we refer to as "scenes" (at one time we called them "regions" in some places that word still exists). Scenario would have been slightly better, might change it.

We have a top-level "SceneManager" object that manages our scenarios. The scenarios are composed of groups of objects that are all managed by their own unique manager – normally one manger per type of objects. Example objects are building, people, vehicles, streets, etc.

Management consists of managing their lifetime, and also frequently consolidating and managing the communication to other managers. Looking up the objects by their various identifying characteristics is another function that the managers frequently perform

### Managers
We use a manager-managees pattern, whereby a single manger manages multiple managees. Not that this is not exactly a singleton pattern since we could in theory have multiple managers – and we will probably need this for example when two scenarios need to interact (which is a definite possibility at this point but not one we have implemented yet).
A list of our managers

Top Level
-	`PeopleMan` – Mangers people in the scene, their name, avatar, if they have a camera, etc.
-	`BuildingMan` – Manages buildings in the scene. Also trees, bushes, building alarms, and a bunch of other things that should probably have their own managers someday.
-	`VehicleMan` – Manages vehicles (cars) that can move around.
-	`GarageMan` – Manages places that vehicles can park
-	`StreetMan` – Manages streets in the scene. Data comes in from OSM through `DataFileMan`
-	`VideoMan` – Manages fixed cameras that can be in the scene. Also keeps track of viewer camera, and probably should keep track of people cams
-	`JourneyMan` – manages the journeys people take 
-	`ZoneMan` – manages evacuation zones people can go to during an evacuation
Lower Level
-	`FrameMan` – Manages frames that can be used for ML computer vision (AI) training
-	`DataFileMan` - Manager – manages data sets (csv, json, etc) for the scenarios
-	`LinkMan` – manages nodes and links in the scene
-	`UiMan` – Manges the UI 


 
## Initialization Sequence
Originally, we just had a single initialization call per manager, but that simply did not work because of the interdependencies. We now have a multi-phase initialization during a new scene startup.
-	OneTime Initialization – Initializations that is done once per application instance (CampSim invocation) and is scene independent. For example, `UiMan` finds all the objects that were manually placed in the `UiPrefab` and initializes its references to them. This will not ever change over the application lifetime.

-	Object Deletion – Only significant when a prior scene was instantiated. Current objects in the various managers are deleted. The manager should come to a state that is indistinguishable on each startup.

-	Value Initialization – stored values are read from the `PlayerPref` so that settings can be retained in a scene. Additional initialization that depends only on those settings or is independent of those values can also optionally be performed.

-	Note that from this point `DataFileMan` and `LinkMan` need to be usable.

-	TODO: files are read and data structures are built. 

-	Graphic Object Initialization – gameobjects are created. Here we restrict ourselves to object creation that needs no inter manager communication, whereby most modules will need services from `LinkCloudMan`

-	Object Linking – intramanager initialization that requires the objects to have been created in multiple modules is done


## Scene Updating
During a scenario we can do various things – examples are:
-	like start some simulation like a building evacuation
-	change some settings that determine appearance
-	move our viewer around
-	change cameras, etc. 
-	Changing the base scenario would actually be one of these too. 
Some of these will require changes to the scene that affect the way it is initialized, so we might need to redo some or even all of the initialization.
We distinguish between three classes.
-	Total Refresh – those that require the entire scene to be initialized.
-	Object Refresh – No data is reread in, however all the graphics objects are destroyed and then reinitialized
-	Partial Object Refresh – Individual game objects are deleted and recreated locally. This should be logged somewhere.
-	Object modification – attributes (Components) of game objects are modified. This might trigger Unity to do a lot of work, but it does not (should not?) affect our object hierarchy visibly. This should also be logged somewhere.





