using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace NNS.Lib.Entities.Sprites
{
	public class AnimatedSprite : Common.UniqueID
	{
		protected Dictionary<String,Animation> _animations;
		protected Animation _currentAnimation;

        #region Properties

        protected Boolean _initialized = false;
        public virtual Boolean Initialized
        {
            get
            {
                return this._initialized;
            }
            set
            {
                this._initialized = value;
            }
        }

        protected float _scale = 1f;
        public virtual float Scale
        {
            get
            {
                return this._scale;
            }
            set
            {
                this._scale = value;
            }
        }

        protected float _rotation = 0f;
        public virtual float Rotation
        {
            get
            {
                return this._rotation;
            }
            set
            {
                this._rotation = value;
            }
        }

        protected Vector2 _position = Vector2.Zero;
        public virtual Vector2 Position
        {
            get
            {
                return this._position;
            }
            set
            {
                this._position = value;
            }
        }

        protected Vector2 _origin = Vector2.Zero;
        public virtual Vector2 Origin
        {
            get
            {
                return this._origin;
            }
            set
            {
                this._origin = value;
            }
        }

        protected Color _color;
        public virtual Color Color
        {
            get
            {
                return this._color;
            }
            set
            {
                this._color = value;
            }
        }

        #endregion

        #region Constructors

        public AnimatedSprite() 
            : base()
        {
            this._animations = new Dictionary<string, Animation>();
        }

        public AnimatedSprite(Vector2 position, Color color, float rotation = 0f, float scale = 1f)
            : base()
        {
            this._animations = new Dictionary<string, Animation>();
            this.Position = position;
            this.Color = color;
            this.Rotation = rotation;
            this.Scale = scale;
        }

        #endregion


        #region Class Methods
        public virtual void Initialize()
        {
            Rectangle bound = this._currentAnimation.getFrame();
            this.Origin = new Vector2(bound.Width / 2, bound.Height / 2) * this._scale;
        }

        public void addAnimation(String key, Animation animation)
        {
            this._animations.Add(key, animation);
            if (_currentAnimation == null)
                _currentAnimation = animation;
        }

        public void switchAnimation(String animation)
        {
            this._currentAnimation.Reset();
            this._currentAnimation = this._animations[animation];
        }
        #endregion

        #region Update & Draw
        public virtual void Update (GameTime gameTime)
		{
			if(_animations.Count > 0){

                if (!this.Initialized)
                    this.Initialize();

				if(_currentAnimation == null)

					_currentAnimation = _animations.Values.First();//_animations.First();

				_currentAnimation.Update(gameTime);
			}
		}

        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
		{
			if(_animations.Count > 0){
				spriteBatch.Draw( this._currentAnimation.Texture,
			                  this.Position,
			                  this._currentAnimation.getFrame(),
			                  this.Color,
			                  this.Rotation,
			                  this.Origin,
			                  this.Scale,
			                  SpriteEffects.None,
			                  0f
				);
			}
        }
        #endregion
    }
}

