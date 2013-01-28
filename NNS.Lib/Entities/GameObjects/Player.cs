using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using NNS.Lib.Managers;

namespace NNS.Lib.Entities.GameObjects
{
    public class Player : GameObject
    {
        public Player(Vector2 position, Color color):base(position,color)
        {
            Texture2D text = Texture2DManager.Instance.get("player");
            this.addAnimation("base", new Sprites.Animation(text, 9000, text.Width, Sprites.AnimationType.Loop));
        }

        public override void Update(GameTime gameTime)
        {
            Vector2 mouse = new Vector2(InputManager.Mouse().X, InputManager.Mouse().Y);
            Vector2 direction = this.Position - mouse;
            this.Rotation = (float)Math.Atan2(direction.X, -direction.Y);

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            base.Draw(spriteBatch, gameTime);
        }

    }
}
