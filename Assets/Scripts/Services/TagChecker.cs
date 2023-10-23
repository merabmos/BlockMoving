using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Services
{
    public static class TagChecker
    {
        public static bool ObjectHasTag(this GameObject gameObject ,string tag)
        {
            return gameObject.gameObject.tag == tag;
        }
    }
}
