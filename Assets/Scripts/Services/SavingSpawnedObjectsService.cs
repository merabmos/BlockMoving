using Assets.Scripts.Models;
using Assets.Scripts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

namespace Assets.Services
{
    public class SavingSpawnedObjectsService
    {
        private static int enabledObjects = 0;
        private static List<MainBlockScript> spawnedObjects = new List<MainBlockScript>();
        private ObjectsPositionsService _objectsPositions;

        public SavingSpawnedObjectsService()
        {
            _objectsPositions = new ObjectsPositionsService();
        }
        public void AddAliveBlock(MainBlockScript gameObject)
        {
            spawnedObjects.Add(gameObject);
        }
        public void RemoveAliveBlock(MainBlockScript gameObject)
        {
            gameObject.gameObject.SetActive(false);

            gameObject.gameObject.transform.position = _objectsPositions.GetBlockSpawningPositionByScene(gameObject.GetBlockSize());
            enabledObjects--;

            if (spawnedObjects.Count > 0)
            {
                PeekLastMovingBlock()?.
                    SetFixed(false)?.
                    SetGrounded(false)?.
                    ChangeRigidBodyConstraints(RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation);
            }

        }
        public MainBlockScript PeekLastMovingBlock()
        {
            return spawnedObjects?.LastOrDefault(o => o.gameObject.activeInHierarchy);
        }

        public int EnablingBlock()
        {
            var objectScript = spawnedObjects.FirstOrDefault(o => !o.gameObject.activeInHierarchy);
            objectScript.gameObject.SetActive(true);
            objectScript.SetFixed(false).SetGrounded(true).ChangeRigidBodyConstraints(RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation);
            return ++enabledObjects;
        }

        public int EnabledBlocksCount()
        {
            return enabledObjects;
        }
    }
}
