using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NNS.Lib.Entities.GameObjects;
using Microsoft.Xna.Framework;

namespace NNS.Lib.Utils
{
    public class Collisions
    {
        #region Class Methods

        public static Boolean checkCollision(GameObject a, GameObject b)
        {
            //check circle collision
            if (Vector2.Distance(a.Position, b.Position) < a.Radius + b.Radius)
            {
                if (a.BoundingBox.Intersects(b.BoundingBox))
                    return true;
            }
            return false;
        }

        #endregion
    }
}
