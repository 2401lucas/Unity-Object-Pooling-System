# Unity-Object-Pool
A very simple singleton object pooler for optimization. It can handle all of the object pooling during the game loading and is persistant throughout scenes

Currently to get the objects from the pool you need to know the index in the pool, will be changed to either use the position or the name.
# What is pooling? 
It is computationally expensive to instantiate and destroy objects like bullets that get re-used a lot.
Its a lot more effective to instantiate them all in the beginning and to keep re-using them by setting them active/false

This script can act as a pooling control hub, it will create all pooled objects you need at the start and objects can be called as and when needed by other scripts.

## How to setup
1) Create a new empty GameObject
2) Create a new script called ObjectPooler and attach it to the GameObject
3) Replace the contents of ObjectPooler with contents of the ObjectPooler script that can be found in this repo.
4) In the inspector, in the script component, enter the number of gameObjects you want pooled and then add their prefabs to the list.
5) Increase Amount to Pool to at least 1. You can also check the 'Load More If None Left' box if you are unsure on how many you will need
6) Access the Pooled Objects by using

```
GameObject GO = ObjectPooler.Instance.GetGameObject(/*Index of the Pooled Object*/);
 //Make changes to your gameObject here
 ```
 
## In the Editor
![image](https://user-images.githubusercontent.com/32739337/102151045-4fa96100-3e48-11eb-9bed-7c8a8cb7eb8f.png)

Here we have the option to enable debugging and to assign new objects to the pool

## Assigning new Objects to the pool
![image](https://user-images.githubusercontent.com/32739337/102151204-b890d900-3e48-11eb-9eb3-d1654fcea0c7.png)

### Assignables
Set the name you want to use for retrieving the GameObject from the pool

Set the initial amount you want to be created.

Set the GameOject to be pooled

### Settings

If you enable Load More If None Left, then if the pool runs out of the object you want, it will create a new one and add it to the pool

## Debugging
When Debug is enabled it gives more information on what the pool is doing

![image](https://user-images.githubusercontent.com/32739337/102151501-6ef4be00-3e49-11eb-8320-d3e5529cddf4.png)
![image](https://user-images.githubusercontent.com/32739337/102151883-3b666380-3e4a-11eb-85bf-440009247c92.png)
