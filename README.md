# Unity-Object-Pool
A singleton object pooler for all of your optimization. It can handle all of the object pooling during the game loading and is persistant throughout scenes

Currently to get the objects from the pool you need to know the position in the pool, will be changed to either use the position or the name.

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
When Debug is enabled it gives more information on what is happening

![image](https://user-images.githubusercontent.com/32739337/102151501-6ef4be00-3e49-11eb-8320-d3e5529cddf4.png)
![image](https://user-images.githubusercontent.com/32739337/102151883-3b666380-3e4a-11eb-85bf-440009247c92.png)
