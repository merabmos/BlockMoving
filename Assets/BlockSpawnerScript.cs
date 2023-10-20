using Assets.Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawnerScript : MonoBehaviour
{
    [SerializeField] private MainBlockScript blockCharacter;
    private SavingSpawnedObjects savingSpawnedObjects;
    // Start is called before the first frame update
    void Start()
    {
        savingSpawnedObjects = new SavingSpawnedObjects();
        SpawnBlockAndSave();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnBlockAndSave();
        }
    }

    private void SpawnBlockAndSave()
    { 
       MainBlockScript gameObj = Instantiate<MainBlockScript>(blockCharacter);
       savingSpawnedObjects.AddAliveBlock(gameObj);
    }

  
} 
