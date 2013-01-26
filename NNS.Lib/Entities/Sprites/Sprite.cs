using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace NNS.Lib.Entities.Sprites
{
	public class Sprite : Common.UniqueID
    {
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

        protected Texture2D _texture;
        public virtual Texture2D Texture
        {
            get
            {
                return this._texture;
            }
            set
            {
                this._texture = value;
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

        public Sprite()
            : base()
        {

        }

        public Sprite(Vector2 position, Texture2D texture, Color color, float rotation = 0f, float scale = 1f)
            : base()
        {
            this.Position = position;
            this.Texture = texture;
            this.Color = color;
            this.Rotation = rotation;
            this.Scale = scale;
        }

        #endregion

        #region Class Methods
        public virtual void Initialize()
        {
            this.Origin = new Vector2(this._texture.Width / 2, this._texture.Height / 2) * this._scale;
        }
        #endregion

        #region Update & Draw
        public virtual void Update (GameTime gameTime)
		{
            if (!this.Initialized)
                this.Initialize();
		}

		public virtual void Draw (SpriteBatch spriteBatch, GameTime gameTime)
		{
			spriteBatch.Draw(this._texture,
			                 this._position,
			                 this._texture.Bounds,
			                 this._color,
			                 this._rotation,
			                 this._origin,
			                 this._scale,
			                 SpriteEffects.None,
			                 0f);
		}
		#endregion
	}
}

