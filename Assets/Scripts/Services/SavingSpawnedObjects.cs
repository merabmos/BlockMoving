using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Services
{
    public class SavingSpawnedObjects
    {
        private static int enabledObjects = 0;
        private static List<MainBlockScript> spawnedObjects = new List<MainBlockScript>();

        public void AddAliveBlock(MainBlockScript gameObject)
        {
            spawnedObjects.Add(gameObject);
        }
        public void RemoveAliveBlock(MainBlockScript gameObject)
        {
            gameObject.gameObject.SetActive(false);
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
            return spawnedObjects?.Last();
        }

        public int EnablingBlock()
        {
            var gmObject = spawnedObjects.FirstOrDefault(o => !o.gameObject.activeInHierarchy).gameObject;
            gmObject.SetActive(true);
            return ++enabledObjects;
        }

        public int EnabledBlocksCount()
        {
            return enabledObjects;
        }
    }
}
