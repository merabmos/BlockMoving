using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Services
{
    public class ObjectsSizesService
    {
        private static SceneSize sceneSize;
        static ObjectsSizesService()
        {
            sceneSize = new SceneSize();
        }
        public Vector3 GetHorizontalWallSizeByScene(BoxCollider2D boxCollider2D)
        {
            return GetSizeFromMinXtoMaxX(boxCollider2D);
        }

        public BlockSize GetBlockSize(BoxCollider2D boxCollider2D)
        {
            return new BlockSize(boxCollider2D);
        }


        #region Private Methods
        private Vector3 GetSizeFromMinXtoMaxX(BoxCollider2D boxCollider2D)
        {
            return new Vector3(SubstractTwoXPositions(sceneSize.GetSceneMaxX(), sceneSize.GetSceneMinX()), boxCollider2D.size.y);
        }
        private float SubstractTwoXPositions(float sceneMaxX,float sceneMinX)
        {
            return sceneMaxX - sceneMinX;
        }

        #endregion
    }
}
