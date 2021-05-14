# Unity Generic Object Pool
An Updated Object pooler to increase performance when pooling many objects.

# Why use Object Pooling? 
It is computationally expensive to instantiate and destroy objects, such as bullets, that get re-used a lot.
Its a lot more performant to instantiate them all and to keep reference and to recycle them.

To use this object pool you will need to create a script for every pool you will need, and only one object is allowed per pool.

# Why use Queue instead of List?
Queue is benificial to use because it acts similar to a LinkedList in C++. With a Queue, when we Dequeue an object it Pops the first element from the Queue. When we Enqueue an object, it is added to the end of the queue, creating a first in, first out system. We will not need to access objects at specific indecies, therefor a Queue is perfect for what we need. [Read More about when to use Lists or Queues here!](https://stackoverflow.com/questions/10380692/queuet-vs-listt)

## The Setup
1) Create a new script, call it what you want your pool to be named, IE a enemy pool could be called EnemyPool.cs and attach it to a GameObject
2) In the script, we will follow the example below. The script will inherite from GenericObjectPool.cs, we will then give it a component type, such as ObjectTobePooled.cs, this could be any script or component that is attachable to a GameObject. 
```
public class GenericPool : GenericObjectPool<ObjectTobePooled>
{
    public override void AddPoolReference(ObjectTobePooled objectToAddReference) => objectToAddReference.GetComponent<IObjectPool>().pool = this;
}
```

3) We then need to override the virtual function AddPoolReference(), on every object that will be pooled, we want to this snipped of code. This creates an Interface that we access to give the pooled object the reference to the pool that it belongs to. This is done so that all we need to do is call pool.Recycle() when the object is no longer needed and it will know the proper pool to Recycle the object into.   

```
internal interface IObjectPool
{
        public GenericPool pool { get; set; }
}
```

## How to use the Pool?
To access the pool, we want to call our new PoolScript and use the Get() method to return the object we have pooled.
