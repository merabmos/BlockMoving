using Assets.Scripts.Models;
using Assets.Scripts.Services;
using Assets.Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawnerScript : MonoBehaviour
{
    [SerializeField] private int countOfInsantiatingObjects;
    [SerializeField] private MainBlockScript blockCharacter;

    #region Private Properties
    private int AddableBlocksMaxCount;
    private SavingSpawnedObjectsService _savingSpawnedObjects;
    private ObjectsPositionsService _objectsPositions;
    #endregion
    void Start()
    {
        #region Initialize
        _savingSpawnedObjects = new SavingSpawnedObjectsService();
        _objectsPositions = new ObjectsPositionsService();
        AddableBlocksMaxCount = countOfInsantiatingObjects;
        #endregion

        SpawnBlockAndSave();

        _savingSpawnedObjects.EnablingBlock();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var enabledCount = _savingSpawnedObjects.EnablingBlock();
            if (enabledCount == countOfInsantiatingObjects)
            {
                countOfInsantiatingObjects += AddableBlocksMaxCount;
                SpawnBlockAndSave();
            }
        }
    }
    private void SpawnBlockAndSave()
    {
        for (int i = 0; i < AddableBlocksMaxCount; i++)
        {
            MainBlockScript gameObj = Instantiate(blockCharacter,
                _objectsPositions.GetBlockSpawningPositionByScene(blockCharacter.GetBlockSize()), transform.rotation);

            gameObj.gameObject.SetActive(false);
            _savingSpawnedObjects.AddAliveBlock(gameObj);
        }
    }
}
