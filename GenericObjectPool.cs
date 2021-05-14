using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericObjectPool<T> : MonoBehaviour where T : Component
{
    #region Fields
    [SerializeField]
    private T prefab;

    private Queue<T> pooledObjects = new Queue<T>();
    #endregion

    #region Singleton
    //Singleton Instantiation
    public static GenericObjectPool<T> Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this.gameObject);
        else
            Instance = this;

        DontDestroyOnLoad(this);
    }


    #endregion

    #region Public Pool Accessing
    /// <summary>
    /// Gets Object of Type T from Pool
    /// </summary>
    /// <returns>Object of Type T</returns>
    public T Get()
    {
        if (pooledObjects.Count == 0)
            AddObjects(1);

        return pooledObjects.Dequeue();
    }

    /// <summary>
    /// Recycles object that was being used back into the active pool
    /// </summary>
    /// <param name="objectToSet"></param>
    public void Recycle(T objectToSet)
    {
        objectToSet.gameObject.SetActive(false);
        pooledObjects.Enqueue(objectToSet);
    }
    #endregion

    #region Pool Modifying
    /// <summary>
    /// 
    /// </summary>
    /// <param name="count"></param>
    private void AddObjects(int count)
    {
        for (int i = 0; i < count; i++)
        {
            var newObject = Instantiate(prefab, Vector3.zero, Quaternion.identity, transform);
            AddPoolReference(newObject);
            Recycle(newObject);
        }
    }

    /// <summary>
    /// Adds reference to the pooled object Via Interface
    /// </summary>
    /// <param name="objectToAddReference"></param>
    public abstract void AddPoolReference(T objectToAddReference);
    #endregion
}
