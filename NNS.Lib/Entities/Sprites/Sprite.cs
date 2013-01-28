using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace NNS.Lib.Entities.Sprites
{
	public class Sprite : AnimatedSprite
    {
        #region Properties

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
                this._animations.Clear();
                this._animations.Add("base", new Animation(value, 5000, value.Width, AnimationType.Loop));
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
    
        #endregion

        #region Update & Draw
        public override void Update(GameTime gameTime)
		{
            base.Update(gameTime);
		}

		public override void Draw (SpriteBatch spriteBatch, GameTime gameTime)
		{
            base.Draw(spriteBatch, gameTime);
		}
		#endregion
	}
}

