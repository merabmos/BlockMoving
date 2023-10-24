using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Models
{
    public  class SceneSize
    {
        public static readonly float sceneMinX;
        public static readonly float sceneMaxX;
        public static readonly float sceneMinY;
        public static readonly float sceneMaxY;

        static SceneSize()
        {
            float cameraSize = Camera.main.orthographicSize;
            float cameraAspect = Camera.main.aspect;

            sceneMinX = Camera.main.transform.position.x - cameraSize * cameraAspect;
            sceneMaxX = Camera.main.transform.position.x + cameraSize * cameraAspect;
            sceneMinY = Camera.main.transform.position.y - cameraSize;
            sceneMaxY = Camera.main.transform.position.y + cameraSize;
        }

        public float GetSceneMinX() { return sceneMinX; }
        public float GetSceneMaxX() { return sceneMaxX; }
        public float GetSceneMinY() {  return sceneMinY; }
        public float GetSceneMaxY() {  return sceneMaxY; }  

    }
}
