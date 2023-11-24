# One Interface Multiple Implementation

## Purpose: 

Suppose we have two clients - a Farmer and a ZooKeeper. 
Each of them dependens on an IAnimal which they Feed() - a Cow and a Lion. 
We would like to inject the animals at runtime like: 
services.AddTransient<IAnimal, Cow>();
services.AddTransient<IAnimal, Lion>();
This won't work since the service provider wont be able to know when to inject which impl. 


## Solution:

Use an AnimalResolver which the clients depends on, inject this resolver to the clients. 
Then, each client gives the resolver its class runtime name. 
The resolver - which is configured at the DI section returns the implementation of IAnimal according to the class name. 

The good news are that if we want to change the Implementations given to some client, for example, change the app that 
the Farmer gets a Horse, we only need to change the injection of the resolver at the DI. 

**One place to change - one file to re-compile.**