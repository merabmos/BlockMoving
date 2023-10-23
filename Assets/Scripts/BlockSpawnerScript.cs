using Assets.Scripts.Models;
using Assets.Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawnerScript : MonoBehaviour
{
    [SerializeField] private int countOfInsantiatingObjects;
    [SerializeField] private MainBlockScript blockCharacter;

    private int AddableBlocksMaxCount;
    private SavingSpawnedObjects savingSpawnedObjects;
    private SceneSize sceneSize;

    // Start is called before the first frame update
    void Start()
    {
        savingSpawnedObjects = new SavingSpawnedObjects();
        sceneSize = new SceneSize();
        AddableBlocksMaxCount = countOfInsantiatingObjects;

        SpawnBlockAndSave();
        savingSpawnedObjects.EnablingBlock();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var enabledCount = savingSpawnedObjects.EnablingBlock();
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
            var getBlockSizesTuple = blockCharacter.GetSizeXandY();
            MainBlockScript gameObj = Instantiate(blockCharacter,
                new Vector3(sceneSize.sceneMinX + (getBlockSizesTuple.Item1 / 2),
                sceneSize.sceneMinY + (getBlockSizesTuple.Item2 / 2), 0), transform.rotation);

            gameObj.gameObject.SetActive(false);
            savingSpawnedObjects.AddAliveBlock(gameObj);
        }
    }


}
