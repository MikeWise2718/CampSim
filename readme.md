# CampSim

- Author: Mike Wise
- Last Updated: 7 August 2020

## Prerequisites
- At least 20 GB of free space, 8 GB of memory, and as much CPU/GPU as possible.
- Although GPU is not strictly necessary, I think you will want a Nvidia 1060 or better for decent performance. 
- Visual Studio 2019 with Unity support installed (will probably still work with older versions of Visual Studio or even VS Code), it can probably work with VS Code too, but it is not being used here.

## Installation instructions (probably obsolete)`

1.	Make sure you have a recent version of Git (**git –version**, currently using 2.26.0.windows.1)
2.	Enable **git-lfs** for your user with **git lfs install**. If you don’t want to do this, you have to do step 7a and 7b (which is no big deal)
3.	Install Unity Hub (Currently using 2.3.0)
4.	Install a recent version of Unity (I am using 2019.3.7f1)
5.	Make sure Unity works (open it up add a sphere to a scene, move it around)
6.	Find a place where you will keep the project. It should have like 30+ GB free, preferably more so you can make safety clones quickly with no worries. 
7.  Make sure **git-lfs** is enabled, if not see the sub points below.
8.	Clone the **CampSim** project into a directory. Will take a few minutes, up to 10 if LFS is pulling down. 
    - a.	If you didn’t enable **git-lfs** globally, then after it has cloned, enter the directory and enable it locally (**git lfs install --local**) – see <https://github.com/git-lfs/git-lfs/wiki/Installation> for more information
    - b.	Now do a **git pull** which should pull any missing gif-lfs managed files that were left behind.
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
   - b. i to rename the git experience
5. Now see if it builds to a BuildWin
6. Force push it (`git push force`) to override the `tip ahead of branch on remote` message 
7. Go to Github and do a pull request on master - make some comments for fun
8. It should merge, their might be conflicts (git isn't perfect')
9. If there are conflicts - not sure how this goes - if not continue
10. go to master branch and pull new master
11. Push to azurerepos
12. Go to ADO and build it



## Changing Startup screen shot
1. Assume you have a png - put it in _textures.
2. Duplicate it.
3. Change to Sprite 
   - a. In Inspector from Project View, 
   - b. look at Texture Type and change from `Default` to `Sprite (2D and UI)`), 
   - c. it will have a sprite then as a sub-object
   - d. you can change it back if you want
4. Now go to player settings and change the startup 
   - Warning! note that there is a separate VR startup icon first in the list, don't change that one by mistake and think you have it

## Testing
- TBD (giggle)

## ToDos
- A lot of those enum regions (like in BuildingMan) can probably be eliminated 
- why is the quadcopter rotating when I move it?

## Problems and Solutions
- Console Error: "A Tree asset could not be loaded because the prefab is missing"
     -	Probably missed step 10 (i.e. the one about **TreesAndShrubs**) above. Otherwise you might need to re-import the **Treespackage** 

- Runs, but all the cars (and people now) are missing
     -   This happened to me when I imported without `gif-lfs`   enabled, it wasn't importing the car textures so you didn't see them


# Architectural Notes to Campus Simulator
`v0.21 - Mike Wise - 6 Aug 2020`
Ideally a program should have tight cohesion in its components and loose coupling between them, also variable and procedure names chosen so as to be self-documenting. 
Unfortunately, here that proves to be quite a problem. Tight-cohesion is fairly easy, but loose coupling is very difficult, mostly because our objects have multiple dependencies on one another. 
Here we analyze that.

## Overview
We have various scenarios, that we refer to as "scenes" (at one time we called them "regions" in some places that word still exists). Scenario would have been slightly better, might change it.

We have a top-level "SceneManager" object that manages our scenarios. The scenarios are composed of groups of objects that are all managed by their own unique manager – normally one manger per type of objects. Example objects are building, people, vehicles, streets, etc.

Management consists of managing their lifetime, and also frequently consolidating and managing the communication to other managers. Looking up the objects by their various identifying characteristics is another function that the managers frequently perform

## Managers
We use a manager-managees pattern, whereby a single manger manages multiple managees. Not that this is not exactly a singleton pattern since we could in theory have multiple managers – and we will probably need this for example when two scenarios need to interact (which is a definite possibility at this point but not one we have implemented yet). They usually encompass the factory pattern.
Managers perform the following functions:
-	They mediate communication between different kinds of objects by providing lookup dictionaries
-	They manage the lifespan of their managees
-	They usually have managee factories as a method
A list of our managers
### Entity Level
-	`PeopleMan` – Mangers people in the scene, their name, avatar, if they have a camera, etc.
-	`BuildingMan` – Manages buildings in the scene. Also trees, bushes, building alarms, and a bunch of other things that should probably have their own managers someday.
-	`VehicleMan` – Manages vehicles (cars) that can move around.
-	`GarageMan` – Manages places that vehicles can park
-	`StreetMan` – Manages streets in the scene. Data comes in from OSM through `DataFileMan`
-	`VideoMan` – Manages fixed cameras that can be in the scene. Also keeps track of viewer camera, and probably should keep track of people cams
-	`JourneyMan` – manages the journeys people take 
-	`ZoneMan` – manages evacuation zones people can go to during an evacuation
- `FrameMan` – Manages frames that can be used for ML computer vision (AI) training

### Base Service Level
-	`DataFileMan` - Manager – manages data sets (csv, json, etc) for the scenarios
-	`LinkMan` – manages nodes and links in the scene
-	`CoordMap` - manages coordinate system, mainly conversion from latlong to a local coordinate system
-	`MapMan` - Manages the creation of the map service tiled map and mesh
-	`UiMan` – Manages the UI 
## Managees

Managers manage these “managees”. (“Employees” or “ICs” didn’t really fit…)

### Model Managees
Model managees are managees whose data determines the Graphics managees (see next view). They should not have components that cause GameObjects to appear on the screen – that task is reserved for the graphics manages. They can be thought of as harboring the invariants and data that determine the graphics managees. 
-	The lifetime of Model Managees should be longer than the graphics managees that they determine
-	Computationally intensive tasks should be cached here.
-	Presumably most model managees will be associated with a non-intersecting set of graphics managees
-	Model managees have “business logic” 

### Graphics Managees
Graphics manages are the graphical object (in Unity “GameObjects”) and their components that actually make up the visual scene. Usually they will end up being passed to the GPU.
-	These should be able to be deleted and rapidly re-created when their model managees change
-	Graphics managees do not have “business logic”
 


## Initialization Sequence
Originally, we just had a single initialization call per manager, but eventually that simply did not work because of the interdependencies that came about as our application became more complex. 
The managers are statically initialized in the scene (to ease development since you can inspect and set variables without running the scene). They are not destroyed during the app (although they can be made subordinate to a single object if needed but I found it did not really help in anyway).
We now have a multi-phase initialization during a new scene startup.
This is done once per application invocation instance:
-	`OneTime Initialization` – Initializations that is done once per application instance (CampSim invocation) and is scene independent. For example, `UiMan` finds all the objects that were manually placed in the `UiPrefab` and initializes its references to them. This will not ever change over the application lifetime. So these calls are not repeated.
-	Current name and signature `Init0()`
-	Name should change since `Init0` is not very descriptive
-	Mostly consists of finding objects
-	Should only be done once
-	Should probably be done in manager awakes

These are done every time we change a scenario, or we do a total refresh of a scene. <br>

-	`Object Deletion` – Only significant when a prior scene was instantiated. Current objects in the various managers are deleted. The manager should come to a state that is indistinguishable on each startup.
    -	Current name is “DeleteBuildings”, “DeletePeople”, etc.
    -	Should give them all a common
    
-	`Base Services Initialization` – Scene Initialization of our lower level base services 
    -	Note that from this point `DataFileMan` and `LinkMan` and `CoordMan` need to be usable.

-	`Model Initialization` – stored settings are (normally read from `PlayerPref`) so that settings can be retained in a scene. 
    - No intra-model communication should happen here as the values are not guaranteed to be defined
    - Additional initialization that depends only on stored settings or is independent of those values can also optionally be performed.
    -	Current name and signature `ModelInitialization(SceneSelE newregion)`
    - Many of these probably violate the no intra-module communication, we need to clear that up


-	`Model Initialization` – The Model Managees are created
    -	Current name and signature “SetMode(SceneSelE newregion)”
    -	Can rely on data from other modules that was set in value initialization

-	`Model Initialization Post`
    -	Various signatures
    -	Object Linking happens here – intra-manager initialization that requires the objects to have been created in multiple modules is done


-	Graphic Object Initialization – GameObjects are created. Here we restrict ourselves to object creation that needs no inter manager communication, whereby most modules will need services from `LinkCloudMan`
    -	Has delete and create signatures
    -	TODO: Has a filter that can be set so that subsets can be handled
    
## Scene Updating
During a scenario we can do various things – examples are:
-	like start some simulation like a building evacuation
-	change some settings that determine appearance
-	move our viewer around
-	change cameras, etc. 
-	Changing the base scenario would actually be one of these too. 
Some of these will require changes to the scene that affect the way it is initialized, so we might need to redo some or even all of the initialization.

Models can be modified in a `ModelMutate` phase
We distinguish between five classes. 

All of these are rooted in update, but the first four are queued and combined, and the last one (object modification) is just immediately executed

The first four are centrally managed - i.e. queued up and executed. A higher level refresh is a superset of the lower ones:
  -	`Total Refresh` – those that require the entire scene to be read in again and re-initialized.
      - Obviously this takes the longest
      
  -	`Object Refresh` – No data is reread in, however all the graphics objects are destroyed and then reinitialized
      - This should be considerably faster
  
  -	`Subset Object Refresh` – subsets of objects are created and deleted
      - not actually implemented yet
      - anticipate filters using name lists, name filters and maybe coordinate filters
      
  -	`Partial Object Refresh` – Individual game objects are deleted and recreated locally. 
       - this just happens on the fly as we change our model - rooted from an update event. 
       
  -	`Object modification` – attributes (Components) of game objects are modified. This might trigger Unity to do a lot of work, but it does not (should not?) affect our object hierarchy visibly. 
       - For example moving an object along by having a model managee change its graphics managee position (`gameobject.transform.position`) works this way.
       - Should I allow a model Mutate To do this directly?
       - we should call all these routines "MutateModel maybe"
  

## Individual Manager Notes

### BuildingMan


# Big ToDos

- Better map calibration
  - CoordMapMan calibration echo on and off
  - Sphino use
  - Refine coordinates
  - 

  

- Eliminate coordinate fixed initialization - use LonLat everywhere
  - Building positions
  - Building rooms and corridors
  - Extra points (in LinkCloud)

- Restructure Buildings

- Azure function for OSM retrieve 
  - Python code
  - json output

  
- DataFrame extentions
  - csvc extensions for dataframe extra data
  - json outout and input
  - python version based on pandas


- Fix LinkCloud violation of model managee initialization in object refresh
  - need a fragline variant that doesn't create objects, but just returns a linked list of fragmented lines
  - need a fragline variant that then takes those lines and realizes them as game objects

- Eliminate inter-module communication in ModelInitialization
   - de-public as many variables as possible
   - make accessor function for the ones left over so we can check for the model initialization state and flag warnings

   
- Better debugging logger
  - remote communication 
  - colors
  - filterable attributes
  - indenting functionality