using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ObjectPooler : MonoBehaviour
{
    public bool debug = false;
    [Header("GameObjects to be Pooled")] public GameObjectToBePooled[] gameObjectsToBePooled;

    private List<GameObject> pooledGameObjects = new List<GameObject>();
    private float timer;

    #region Singleton

    //Singleton Instantiation
    public static ObjectPooler Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this.gameObject);
        else
            Instance = this;

        DontDestroyOnLoad(this);
    }

    #endregion

    void Start()
    {
        //Initialize();
    }

    //Call to Initialize the pool
    public void Initialize()
    {
        if (debug) {print("Pooling has started"); timer = Time.realtimeSinceStartup; } 

        for (int i = 0; i < gameObjectsToBePooled.Length; i++)
        {
            for (int j = 0; j < gameObjectsToBePooled[i].amountToBePooled; j++)
            {
                GameObject go = Instantiate(gameObjectsToBePooled[i].gameObjectToBePooled);
                go.SetActive(false);
                go.transform.SetParent(transform);

                pooledGameObjects.Add(go);
            }
        }

        if (debug) {print("Pooling has ended, " + pooledGameObjects.Count + " Pooled Objects"); print("Generating Pool Took " + (Time.realtimeSinceStartup - timer));}
    }

    public GameObject GetGameObject(int position)
    {
        int startPosInList = 0;
        for (int i = 0; i < position; i++)
        {
            startPosInList += gameObjectsToBePooled[i].amountToBePooled;
        }

        if (debug) print("Start Position in List is " + startPosInList);

        for (int i = startPosInList; i < startPosInList + gameObjectsToBePooled[position].amountToBePooled; i++)
        {
            if (!pooledGameObjects[i].activeSelf) return pooledGameObjects[i];
        }

        if (debug) print("No Objects Ready in Pool " + gameObjectsToBePooled[position].name);

        if (gameObjectsToBePooled[position].loadMoreIfNoneLeft)
        {
            if (debug) print("Added Object in Pool " + gameObjectsToBePooled[position].name);
            pooledGameObjects.Insert(startPosInList + gameObjectsToBePooled[position].amountToBePooled, gameObjectsToBePooled[position].gameObjectToBePooled);
            gameObjectsToBePooled[position].amountToBePooled++;
            return pooledGameObjects[startPosInList + gameObjectsToBePooled[position].amountToBePooled - 1];
        }

        return null;
    }

    public void ResetPool()
    {
        foreach (var objectInPool in pooledGameObjects)
        {
            if (objectInPool.activeSelf)
            {
                SetObjectInPool(objectInPool);
            }
        }
    }

    public void SetObjectInPool(GameObject go)
    {
        if (debug) print(go.name + " Set in Pool");

        go.SetActive(false);
        go.transform.position = Vector3.zero;
    }
}

[Serializable]
public struct GameObjectToBePooled
{
    [Header("Object Info")]
    public string name;
    public int amountToBePooled;
    public GameObject gameObjectToBePooled;

    [Header("Settings")] 
    public bool loadMoreIfNoneLeft;
}
