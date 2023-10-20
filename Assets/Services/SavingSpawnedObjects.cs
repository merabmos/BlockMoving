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
        private static List<MainBlockScript> spawnedObjects = new List<MainBlockScript>();

        public void AddAliveBlock(MainBlockScript gameObject) { 
            spawnedObjects.Add(gameObject);
        }
        public void RemoveAliveBlock(MainBlockScript gameObject)
        {
            spawnedObjects.Remove(gameObject);
            PeekLastMovingBlock()?.
                SetFixed(false)?.
                SetGrounded(false)?.
                ChangeRigidBodyConstraints(RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation);
            
        }

        public MainBlockScript PeekLastMovingBlock()
        {
            return spawnedObjects?.Last();
        }
    }
}
