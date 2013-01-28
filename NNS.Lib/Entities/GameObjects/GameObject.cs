using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NNS.Lib.Entities.Sprites;
using NNS.Lib.Utils;

namespace NNS.Lib.Entities.GameObjects
{
    public class GameObject : Sprites.AnimatedSprite
    {
        #region Properties

        protected Boolean _dead;
        public virtual Boolean Dead
        {
            get
            {
                return this._dead;
            }
            set
            {
                this._dead = value;
            }
        }

        protected RotatedRectangle _bound;
        public virtual RotatedRectangle BoundingBox
        {
            get
            {
                return this._bound;
            }
            set
            {
                this._bound = value;
            }
        }

        protected float _radius;
        public virtual float Radius
        {
            get
            {
                return this._radius;
            }
            set
            {
                this._radius = value;
            }
        }

        #endregion

        #region Constructors
        public GameObject(Vector2 position, Color color, float rotation = 0f, float scale = 1f)
            : base(position,color,rotation,scale)
        {

        }
        #endregion

        #region Class Methods

        public override void Initialize()
        {
            base.Initialize();
            this.BoundingBox = new RotatedRectangle(
                                                    new Rectangle((int)this._position.X,
                                                                    (int)this._position.Y,
                                                                    (int)(this._currentAnimation.getFrame().Width * this._scale),
                                                                    (int)(this._currentAnimation.getFrame().Height * this._scale)),
                                                    this._rotation);
            this.Dead = false;
            this.Radius = Math.Max(this.Origin.X, this.Origin.Y);
        }

        #endregion


    }
}
