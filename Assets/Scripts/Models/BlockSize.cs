using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Models
{
    public class BlockSize
    {
        public readonly float height;
        public readonly float width;
        public BlockSize(float width, float height) {
            this.height = height;
            this.width = width;
        }

        public BlockSize(BoxCollider2D boxCollider2D)
        {
            width = boxCollider2D.size.x;
            height = boxCollider2D.size.y;
        }
    }
}
