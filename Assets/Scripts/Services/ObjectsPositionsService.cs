using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

namespace Assets.Scripts.Services
{
    public class ObjectsPositionsService
    {
        private static SceneSize sceneSize;
        static ObjectsPositionsService()
        {
            sceneSize = new SceneSize();
        }
        public Vector3 GetRightWallPositionByScene(BoxCollider2D boxCollider2D)
        {
            return new Vector3(sceneSize.GetSceneMaxX() + DivideBy2(boxCollider2D.size.x), 0);
        }

        public Vector3 GetLeftWallPositionByScene(BoxCollider2D boxCollider2D)
        {
            return new Vector3(sceneSize.GetSceneMinX() - DivideBy2(boxCollider2D.size.x), 0);
        }

        public Vector3 GetTopWallPositionByScene(BoxCollider2D boxCollider2D)
        {
            return new Vector3(0, sceneSize.GetSceneMaxY() + DivideBy2(boxCollider2D.size.y));
        }

        public Vector3 GetBottomWallPositionByScene(BoxCollider2D boxCollider2D)
        {
            return new Vector3(0,sceneSize.GetSceneMinY() - DivideBy2(boxCollider2D.size.y));
        }

        public Vector3 GetBlockSpawningPositionByScene(BlockSize blockSize)
        {
            return new Vector3(sceneSize.GetSceneMinX() + DivideBy2(blockSize.width),
                sceneSize.GetSceneMinY() + DivideBy2(blockSize.height), 0);
        }

        private float DivideBy2(float size)
        {
            return size / 2;
        }
    }
}
