using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Models
{
    public class SceneSize
    {
        public float sceneMinX { get; set; }
        public float sceneMaxX { get; set; }
        public float sceneMinY { get; set; }
        public float sceneMaxY { get; set; }

        public SceneSize()
        {
            float cameraSize = Camera.main.orthographicSize;
            float cameraAspect = Camera.main.aspect;

            sceneMinX = Camera.main.transform.position.x - cameraSize * cameraAspect;
            sceneMaxX = Camera.main.transform.position.x + cameraSize * cameraAspect;
            sceneMinY = Camera.main.transform.position.y - cameraSize;
            sceneMaxY = Camera.main.transform.position.y + cameraSize;
        }
    }
}
