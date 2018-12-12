# EveApp4.0
Hopefully final Eve repo

Basic concept:

An UWP App that lets the user see the most lucrative deals (Best priced) on each type of item, in each region, in the Eve Online MMORPG. The app enables the user to search for specific items by name or type ID.

How:

We extract data from an Eve Online Open API. Then we deserialize and cast the JSON objects to local objects (EveObjModel). The objects are sorted into items supplied and items in demand. We cut the list so they only contain the most ”lucrative” instance of the different item types.

Authors: See collaborators

COMPE 361 - SDSU, Fall 2018. 
